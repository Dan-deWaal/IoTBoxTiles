using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTBoxTiles.Devices.Controls;
using Newtonsoft.Json.Linq;
using System.Threading;
using Newtonsoft.Json;
using System.Net.Http;

namespace IoTBoxTiles.Devices
{
    public class USB : Device
    {
        ThreadStart _usbref = null;
        public Thread _usbthread = null;
        public ServerComm _servComm = ServerComm.Instance;

        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }
        public string client_name { get; set; }
        
        public USB(Device old_device) : base(old_device)
        {
        }

        public USB(JObject device) : base(device)
        {
        }

        public override void CreateDevice()
        {
            AddSmallUI(new USBSmall(this));
            AddLargeUI(new USBLarge(this));
        }

        public override void UpdateLargeUI()
        {
            ((USBLarge)UI_large).UpdateUI();
        }

        public override void UpdateSmallUI()
        {
            ((USBSmall)UI_small.Controls[0]).UpdateUI();
        }

        public async void connectUSB()
        {
            //changing client_name to a value changes the UI to "connected"

            //Send a request to the server for Device Info
            var result = await base.ServerRequest();
            if (result.Item1 == ServerResponse.Connected)
            {
                Console.WriteLine("Response Success");
                client_name = _servComm.GetNETBIOSName();
                //deserialize ip & port content
                string jsonstr = await result.Item2.Content.ReadAsStringAsync();
                Console.WriteLine(jsonstr);
                ConnectionDetail connectiondetails = JsonConvert.DeserializeObject<ConnectionDetail>(jsonstr);
                Console.WriteLine("IP: {0},  Port: {1},  Status: {2}", connectiondetails.details.ip_address, connectiondetails.details.port, connectiondetails.status);
                //do the direct connect
                if (connectiondetails.status.Contains("success")){
                    DeviceConnect(connectiondetails.details.ip_address, connectiondetails.details.port);
                }
            }
            else
            {
                Console.WriteLine("Fail!");
                client_name = null;
            }

            UpdateLargeUI();
            UpdateSmallUI();
            
        }

        public void DeviceConnect(string remote_ip, int remote_port)
        {
            Console.WriteLine("Connect USB");
            try
            {
                USBdriver usbdriver = new USBdriver(remote_ip, remote_port); //("192.168.0.137", 12345); //("127.0.0.1", 12345);
                _usbref = new ThreadStart(usbdriver.listen);
                _usbthread = new Thread(_usbref);
                DevicesForm._openThreads.Add(_usbthread);
                _usbthread.Start();
                //send msg to server = "connected to device"
            }
            catch (Exception e)
            {
                Console.WriteLine("Socket not created. " + e);
                //turn off button UI
                client_name = null;
                UpdateLargeUI();
                UpdateSmallUI();
                //send msg to server - "cannot connect to device"
            }
        }

        public void disconnectUSB()
        {
            Console.WriteLine("Disconnect USB");
            client_name = null;
            _usbthread.Abort();
            DevicesForm._openThreads.Remove(_usbthread);
            //send msg to server = "disconnected from device"
        }

        

    }
}
