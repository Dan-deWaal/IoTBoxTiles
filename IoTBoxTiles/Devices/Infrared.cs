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
    public class Infrared : Device
    {
        //unique properties
        public bool _repeater { get; set; }
        public List<KeyValuePair<string, bool>?> _feedback { get; set; }
        public List<IRButton> _buttons { get; set; }

        public Infrared(Device old_device) : base(old_device)
        {
            _buttons = new List<IRButton>();
            _feedback = new List<KeyValuePair<string, bool>?>();
        }

        public Infrared(JObject device) : base(device)
        {
        }

        public override void UpdateDevice(JObject device)
        {
            base.UpdateDevice(device);
            _repeater = (bool)device["repeater"];
            _feedback.Clear();
            foreach (JToken fbItem in device["feedback"])
            {
                if ((bool)fbItem["enabled"])
                {
                    _feedback.Add(new KeyValuePair<string, bool>((string)fbItem["name"], (bool)fbItem["input"]));
                } else
                {
                    _feedback.Add(null);
                }
            }
            if (device["buttons"] != null)
            {
                _buttons.Clear();
                foreach (JToken buttItem in device["buttons"])
                {
                    _buttons.Add(new IRButton(buttItem));
                }
            }
        }

        public override void CreateDevice()
        {
            AddSmallUI(new InfraredSmall(this));
            AddLargeUI(new InfraredLarge(this));
        }

        public override void UpdateLargeUI()
        {
            ((InfraredLarge)UI_large).UpdateUI();
        }

        public override void UpdateSmallUI()
        {
            ((InfraredSmall)UI_small.Controls[0]).UpdateUI();
        }

        public class IRButton
        {
            public int id { get; set; }
            public int? icon { get; set; }
            public string name { get; set; }
            public bool continuous { get; set; }
            public int? num_pulses { get; set; }

            public IRButton(JToken buttonData)
            {
                id = (int)buttonData["id"];
                icon = (int?)buttonData["icon"];
                name = (string)buttonData["name"];
                continuous = (bool)buttonData["continuous"];
                num_pulses = (int?)buttonData["pulses"];
            }
        }
    }
}
