using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTBoxTiles.Devices.Controls;
using Newtonsoft.Json.Linq;

namespace IoTBoxTiles.Devices
{
    public class Audio : Device
    {
        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }
        public bool speaker_status { get; set; }
        public bool mic_status { get; set; }
        public int speaker_VU { get; set; }
        public int mic_VU { get; set; }

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

        public override void UpdateLargeUI()
        {
            ((AudioLarge)UI_large).UpdateUI();
        }

        public override void UpdateSmallUI()
        {
            ((AudioSmall)UI_small.Controls[0]).UpdateUI();
        }
    }
}
