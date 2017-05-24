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
            client_name = "test USB"; //this is retrieved from server

            //Send a request to the server for Device Info
            string request = JsonConvert.SerializeObject(new RequestInfo
            {
                localIP = _servComm.GetLocalIPAddress(),
                hostname = _servComm.GetNETBIOSName()
            });
            StringBuilder deviceUri = new StringBuilder(_servComm.Root);
            deviceUri.Append("/device/");
            deviceUri.Append(device_id);
            deviceUri.Append("/connect");
            var result = await _servComm.PostAsync(deviceUri.ToString(),
                new StringContent(request), contentType:"application/json");
            if (result.Item1 != ServerResponse.Connected)
            {
                // should be handled better
                MessageBox.Show("Server disconnected during intialisation.");
            }
            //Console.WriteLine("Request: {0}", result);

            //assume success
            //Poll server for Device Info


            UpdateLargeUI();
            UpdateSmallUI();

            //this runs upon poll success
            Console.WriteLine("Connect USB");
            try
            {
                USBdriver usbdriver = new USBdriver("192.168.0.137", 12345); //("192.168.0.137", 12345); //("127.0.0.1", 12345);
                _usbref = new ThreadStart(usbdriver.listen);
                _usbthread = new Thread(_usbref);
                DevicesForm._openThreads.Add(_usbthread);
                _usbthread.Start();
                Console.WriteLine("Socket created: {0} : {1}", ip_address, port);
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
