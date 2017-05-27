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
        public override string client_name { get; set; }
        
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
            if (_usbthread != null)
            {
                if (!_usbthread.IsAlive)
                {
                    client_name = null;
                }
            }
            ((USBLarge)UI_large).UpdateUI();
        }

        public override void UpdateSmallUI()
        {
            ((USBSmall)UI_small.Controls[0]).UpdateUI();
        }

        public void connectUSB()
        {
            //changing client_name to a value changes the UI to "connected"
            
            //Send a request to the server for Device Info
            base.ServerRequest(this);
            
            UpdateLargeUI();
            UpdateSmallUI();
            
        }

        public override void ConnectDevice(ConnectionDetail connectiondetails)
        {
            Console.WriteLine("Connecting USB...");
            client_name = _servComm.GetNETBIOSName();
            UpdateLargeUI();
            UpdateSmallUI();
            try
            {
                USBdriver usbdriver = new USBdriver(connectiondetails.details.ip_address, connectiondetails.details.port); 
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
            UpdateLargeUI();
            UpdateSmallUI();
            if (_usbthread != null)
            {
                _usbthread.Abort();
                DevicesForm._openThreads.Remove(_usbthread);
            }
            //send msg to server = "disconnected from device"
        }

        

    }
}
