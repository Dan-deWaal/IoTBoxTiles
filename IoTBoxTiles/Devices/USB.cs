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
        Thread _usbthread = null;

        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }

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
            Console.WriteLine("Connect USB");
            USBdriver usbdriver = new USBdriver("127.0.0.1", 12345);
            _usbref = new ThreadStart(usbdriver.listen);
            _usbthread = new Thread(_usbref);
            _usbthread.Start();
        }

        public void disconnectUSB()
        {
            Console.WriteLine("Disconnect USB");
            _usbthread.Abort();
        }
    }
}
