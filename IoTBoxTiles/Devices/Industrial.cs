using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using IoTBoxTiles.Devices.Controls;

namespace IoTBoxTiles.Devices
{
    public class Industrial : Device
    {
        //unique properties
        public bool connected { get; set; }
        public int com_port { get; set; }
        public string com_settings { get; set; }
        public List<string> ser_mon { get; set; }

        public Industrial(Device old_device) : base(old_device)
        {
        }

        public Industrial(JObject device) : base(device)
        {
        }

        public override void UpdateDevice(JObject device)
        {
            base.UpdateDevice(device);
            //connected = (bool)device["connected"];
            //com_port = (int)device["com_port"];
            //com_settings = (string)device["com_settings"];
        }

        public override void CreateDevice()
        {
            base.CreateDevice();
            AddSmallUI(new IndustrialSmall(this));
            AddLargeUI(new IndustrialLarge(this));
        }

        public override void UpdateLargeUI()
        {
            ((IndustrialLarge)UI_large).UpdateUI();
        }

        public override void UpdateSmallUI()
        {
            ((IndustrialSmall)UI_small.Controls[0]).UpdateUI();
        }
    }
}
