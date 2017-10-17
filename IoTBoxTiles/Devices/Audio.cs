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
using CSCore;
using CSCore.SoundIn;
using System.Diagnostics;
using CSCore.Streams;

namespace IoTBoxTiles.Devices
{ 
    public class Audio : Device
    {
        private ServerComm _servComm = ServerComm.Instance;
        //private ProgState _progState = ProgState.NotConnected;
        private bool _sending = false;
        private bool _receiving = false;
        private NetworkStream _nsClient;
        private Thread _audioThread = null;
        private Process _oggEncProcess;
        private WasapiCapture _waveIn;
        private IWaveSource _finalSource;

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
            Console.WriteLine("Connecting Audio... {0} : {1}", connectiondetails.details.ip_address, connectiondetails.details.port);
            UpdateLargeUI();
            UpdateSmallUI();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += 
                (s, cert, chain, sslPolicyErrors) => true;

            TcpClient tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(IPAddress.Parse(connectiondetails.details.ip_address), connectiondetails.details.port);

            _nsClient = tcpClient.GetStream();
            Console.WriteLine("Connected Audio direct: {0}", tcpClient.Client.RemoteEndPoint);
            //_progState = ProgState.Connected;
            connected = true;

            client_name = _servComm.GetNETBIOSName();
            UpdateUI();
            try
            {
                while (_nsClient != null)
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
            { }
        }

        private void StartSendingAudio()
        {
            _oggEncProcess = new Process();
            _oggEncProcess.StartInfo.UseShellExecute = false;
            _oggEncProcess.StartInfo.RedirectStandardInput = true;
            _oggEncProcess.StartInfo.RedirectStandardOutput = true;
            _oggEncProcess.StartInfo.FileName = "oggenc2.exe";
            _oggEncProcess.StartInfo.Arguments = "--raw --raw-format=3 --raw-rate=44100 -";
            //_oggEncProcess.StartInfo.Arguments = "--raw --raw-format=3 --raw-rate=48000 --resample 000 -";
            _oggEncProcess.StartInfo.CreateNoWindow = true;
            _oggEncProcess.Start();

            _waveIn = new CSCore.SoundIn.WasapiLoopbackCapture();
            _waveIn.Initialize();
            var soundInSource = new SoundInSource(_waveIn);
            var singleBlockNotificationStream = new SingleBlockNotificationStream(soundInSource.ToSampleSource());
            _finalSource = singleBlockNotificationStream.ToWaveSource();

            byte[] inBuffer = new byte[_finalSource.WaveFormat.BytesPerSecond / 2];
            soundInSource.DataAvailable += (s, _) =>
            {
                int read = 0;
                while ((read = _finalSource.Read(inBuffer, 0, inBuffer.Length)) > 0)
                { 
                    _oggEncProcess.StandardInput.BaseStream.Write(inBuffer, 0, read);
                }
            };

            var stdOut = new AsyncStreamChunker(_oggEncProcess.StandardOutput);
            stdOut.DataReceived += async (s, data) =>
            {
                await SendData(_receiving, _sending, data);
            };
            stdOut.Start();
            
            _waveIn.Start();
        }

        private async Task SendData(bool willReceive, bool willSend, byte[] oggData)
        {
            if (_nsClient == null)
                return;
            if (oggData == null)
                return;

            byte[] buffer = MessagePackSerializer.Serialize(new AudioPack()
            {
                WillReceive = willReceive,
                WillSend = willSend,
                OggData = oggData
            });
            await _nsClient.WriteAsync(buffer, 0, buffer.Length);
            if (oggData != null)
                Console.WriteLine("wrote {0} bytes", buffer.Length);
        }

        private async Task ReceiveDataAsync()
        {
            Console.WriteLine("receiving data");
            byte[] buffer = new byte[1024];
            int bytesRead = 1;
            int totalLen = 0;
            while (bytesRead > 0)
            {
                bytesRead = await _nsClient.ReadAsync(buffer,
                    totalLen, buffer.Length - totalLen);
                totalLen += bytesRead;

                if (Encoding.UTF8.GetString(buffer.Take(totalLen).ToArray()).Contains("<EOF>"))
                    break;
            }

           

            if (bytesRead < 0)
            {
                Console.WriteLine("Socket closed?");
                _nsClient.Dispose();
                _nsClient = null;
                return;
            }
            
            var resp = MessagePackSerializer.Deserialize<AudioPack>(buffer.Take(totalLen).ToArray());
            _willRecv = resp.WillReceive;
            _willSend = resp.WillSend;
            UpdateUI();
            if (resp.OggData != null)
            {
                //var pos = _inStream.Position;
                //_inStream.Position = _inStream.Length;
                //await _inStream.WriteAsync(resp.OggData, 0, resp.OggData.Length);
                //_inStream.Position = pos;
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
        public byte[] OggData { get; set; }

        [Key(3)]
        public string EOF = "<EOF>";
    }
}

class AsyncStreamChunker
{
    public delegate void EventHandler<args>(object sender, byte[] data);
    public event EventHandler<byte[]> DataReceived;

    protected byte[] _buffer;
    protected int _bufCount = 0;

    private StreamReader _reader;

    public bool Active { get; private set; }

    public void Start()
    {
        if (!Active)
        {
            Active = true;
            BeginReadAsync();
        }
    }

    public void Stop()
    {
        Active = false;
    }

    public AsyncStreamChunker(StreamReader reader, int chunkSize = 512)
    {
        _buffer = new byte[chunkSize];
        _reader = reader;
        Active = false;
    }

    protected void BeginReadAsync()
    {
        if (Active)
            _reader.BaseStream.BeginRead(_buffer, _bufCount, _buffer.Length - _bufCount, new AsyncCallback(ReadCallback), null);
    }

    private void ReadCallback(IAsyncResult asyncResult)
    {
        int bytesRead;

        if (!Active)
            return;

        bytesRead = _reader.BaseStream.EndRead(asyncResult);

        if (bytesRead <= 0)
        {
            Stop();
            return;
        }

        _bufCount += bytesRead;
        if (_bufCount == _buffer.Length)
        {
            if (DataReceived != null)
                DataReceived.Invoke(this, _buffer);
            _bufCount = 0;
        }

        // wait for more data from stream
        BeginReadAsync();
    }
}