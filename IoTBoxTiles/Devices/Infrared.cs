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
        public List<KeyValuePair<string, bool>> _feedback { get; set; }
        public List<IRButton> _buttons { get; set; }

        public Infrared(Device old_device) : base(old_device)
        {
            _feedback = new List<KeyValuePair<string, bool>>() {
                new KeyValuePair<string, bool>("1",true),
                new KeyValuePair<string, bool>("2",false),
                new KeyValuePair<string, bool>("3",true),
                new KeyValuePair<string, bool>("4",false)
            };
            _buttons = new List<IRButton>();

            // *** fake buttons ***
            _buttons.Add(new IRButton());
            _buttons.First().id = 1;
            _buttons.First().name = "Bob";
            
            // **   remove!!   **
        }

        public Infrared(JObject device) : base(device)
        {
        }

        public override void CreateDevice()
        {
            UI_small = new Panel()
            {
                Name = "UISmallPanel",
                Width = 270,
                Height = 200,
                BorderStyle = BorderStyle.FixedSingle
            };
            UI_small.Controls.Add(new InfraredSmall(this));

            UI_large = new InfraredLarge(this)
            {
                Name = "UILarge",
                Width = 400,
                Height = 600,
                BorderStyle = BorderStyle.FixedSingle,
            };
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
            public int? id { get; set; }
            public int? icon { get; set; }
            public string name { get; set; }
            public bool? continuous { get; set; }
            public int? num_pulses { get; set; }
            public IRButton()
            {
            }

        }
    }
}
