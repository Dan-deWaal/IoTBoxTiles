using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTBoxTiles.Devices.Controls;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Threading;
using System.Net.Sockets;
using System.Security.Authentication;
using MessagePack;
using NAudio.Lame;
using NAudio.Wave;

namespace IoTBoxTiles.Devices
{ 
    public class Audio : Device
    {
        private ServerComm _servComm = ServerComm.Instance;
        //private ProgState _progState = ProgState.NotConnected;
        private bool _sending = false;
        private bool _receiving = false;
        private SslStream _sslClient;
        private MemoryStream _inStream = new MemoryStream();
        private MemoryStream _outStream = new MemoryStream();
        private LameMP3FileWriter _writer = null;
        private Thread _audioThread = null;

        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }
        public bool speaker_status { get; set; }
        public bool mic_status { get; set; }
        public int speaker_VU { get; set; }
        public int mic_VU { get; set; }

        public bool _willSend { get; set; }
        public bool _willRecv { get; set; }

        public Audio(Device old_device) : base(old_device)
        {
        }

        public Audio(JObject device) : base(device)
        {
        }
    
        public override void UpdateDevice(JObject device)
        {
            base.UpdateDevice(device);
            connected = (bool)device["connected"];
            client_id = (int?)device["client_id"];
            ip_address = (string)device["ip_address"];
            port = (int?)device["port"];
            speaker_status = (bool)device["speaker_status"];
            mic_status = (bool)device["mic_status"];
            speaker_VU = (int)device["speaker_VU"];
            mic_VU = (int)device["mic_VU"];
        }

        public override void CreateDevice()
        {
            AddSmallUI(new AudioSmall(this));
            AddLargeUI(new AudioLarge(this));
        }

        internal async void UpdateAudioConnectionsAsync(CheckBox sendChkBox, CheckBox receiveChkBox)
        {
            sendChkBox.Enabled = _willRecv;
            _sending = sendChkBox.Checked = _willRecv && sendChkBox.Checked;
            if (_sending)
            {
                StartSendingAudio();
            }

            receiveChkBox.Enabled = _willSend;
            _receiving = receiveChkBox.Checked = _willSend && receiveChkBox.Checked;
            if (_receiving && _audioThread == null)
            {
                _audioThread = new Thread(new ThreadStart(PlayAudio));
                _audioThread.Start();
            }
            else if (_audioThread != null)
            {
                _audioThread.Abort();
                _audioThread = null;
            }
            await SendData(_receiving, _sending, null);
        }

        public void connectAudio()
        {
            Console.WriteLine("Connect Audio");
            base.ServerRequest(this); 
            UpdateLargeUI();
            UpdateSmallUI();
        }

        public void disconnectAudio()
        {
            Console.WriteLine("Disconnect Audio");
            client_name = null;
            UpdateLargeUI();
            UpdateSmallUI();
            //other disconnect code

            //send msg to server = "disconnected from device"
        }

        public override async void ConnectDevice(ConnectionDetail connectiondetails)
        {
            Console.WriteLine("Connecting Audio... {0} : {1}",connectiondetails.details.ip_address, connectiondetails.details.port);
            UpdateLargeUI();
            UpdateSmallUI();

            TcpClient tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(IPAddress.Parse(connectiondetails.details.ip_address), connectiondetails.details.port);
            _sslClient = new SslStream(tcpClient.GetStream(), false,
                 new RemoteCertificateValidationCallback((obj, a, b, c) => true));
            await _sslClient.AuthenticateAsClientAsync("iot.duality.co.nz");
            //check for success?
            Console.WriteLine("Connected Audio direct: {0}", tcpClient.Client.RemoteEndPoint);
            //_progState = ProgState.Connected;
            connected = true;

            client_name = _servComm.GetNETBIOSName();
            UpdateUI();
            try
            {
                while (_sslClient != null)
                {
                    await ReceiveDataAsync();
                }
            }
            catch { }
            finally
            {
                //This is disconnection
                client_name = null;
                connected = false;
                UpdateUI();
            }
        }

        private void PlayAudio()
        {
            while (_receiving)
            {
                while (_inStream.Length < 4000)
                    Thread.Sleep(100);

                _inStream.Position = 0;
                using (WaveStream blockAlignedStream = new BlockAlignReductionStream(
                    WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(_inStream))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            Thread.Sleep(100);
                        }
                    }
                    _inStream.SetLength(0);
                    _inStream.Position = 0;
                }
            }
        }

        private async void StartSendingAudio()
        {
            if (_writer != null)
                return;
            var waveIn = new WasapiLoopbackCapture();
            using (_writer = new LameMP3FileWriter(_outStream, waveIn.WaveFormat, LAMEPreset.ABR_256))
            {
                waveIn.DataAvailable += OnDataAvailable;
                waveIn.StartRecording();

                while (_sending && _sslClient != null)
                {
                    while (_outStream.Length < 4196)
                        await Task.Delay(100);

                    _outStream.Position = 0;
                    byte[] mp3Data = new byte[32768];
                    int bytesRead = await _outStream.ReadAsync(mp3Data, 0, mp3Data.Length);
                    _outStream.SetLength(0);
                    _outStream.Position = 0;

                    if (bytesRead != 0)
                        await SendData(_receiving, _sending,
                            mp3Data.Take(bytesRead).ToArray());
                }
            }
            waveIn.StopRecording();
            waveIn.DataAvailable -= OnDataAvailable;
        }

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            _writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        private async Task SendData(bool willReceive, bool willSend, byte[] mp3Data)
        {
            if (_sslClient == null)
                return;

            byte[] buffer = MessagePackSerializer.Serialize(new AudioPack()
            {
                WillReceive = willReceive,
                WillSend = willSend,
                Mp3Data = mp3Data
            });
            await _sslClient.WriteAsync(buffer, 0, buffer.Length);
            if (mp3Data != null)
                Console.WriteLine("wrote {0} bytes", buffer.Length);
        }

        private async Task ReceiveDataAsync()
        {
            byte[] buffer = new byte[65536];
            int bytesRead = 1;
            int totalLen = 0;
            while (bytesRead > 0)
            {
                bytesRead = await _sslClient.ReadAsync(buffer,
                    totalLen, buffer.Length - totalLen);
                totalLen += bytesRead;

                if (Encoding.UTF8.GetString(buffer.Take(totalLen).ToArray()).Contains("<EOF>"))
                    break;
            }

            if (bytesRead < 0)
            {
                Console.WriteLine("Socket closed?");
                _sslClient.Dispose();
                _sslClient = null;
                return;
            }

            var resp = MessagePackSerializer.Deserialize<AudioPack>(buffer.Take(totalLen).ToArray());
            _willRecv = resp.WillReceive;
            _willSend = resp.WillSend;
            UpdateUI();

            if (resp.Mp3Data != null)
            {
                var pos = _inStream.Position;
                _inStream.Position = _inStream.Length;
                await _inStream.WriteAsync(resp.Mp3Data, 0, resp.Mp3Data.Length);
                _inStream.Position = pos;
            }
        }

        private static IPAddress GetLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address;
            }
        }

        public override void UpdateLargeUI()
        {
            ((AudioLarge)UI_large).UpdateUI();
        }

        public override void UpdateSmallUI()
        {
            ((AudioSmall)UI_small.Controls[0]).UpdateUI();
        }
    }
    
    [MessagePackObject]
    public class AudioPack
    {
        [Key(0)]
        public bool WillReceive { get; set; }

        [Key(1)]
        public bool WillSend { get; set; }

        [Key(2)]
        public byte[] Mp3Data { get; set; }

        [Key(3)]
        public string EOF = "<EOF>";
    }
}
