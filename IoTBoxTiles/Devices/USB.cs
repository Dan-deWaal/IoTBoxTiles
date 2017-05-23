using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTBoxTiles.Devices.Controls;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace IoTBoxTiles.Devices
{
    public class USB : Device
    {
        ThreadStart _usbref = null;
        public Thread _usbthread = null;

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

        public void connectUSB()
        {
            //polling server goes here
            client_name = "test USB"; //this is retrieved from server

            UpdateLargeUI();
            UpdateSmallUI();

            //this runs upon poll success
            Console.WriteLine("Connect USB");
            try
            {
                USBdriver usbdriver = new USBdriver("127.0.0.1", 12345);
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
