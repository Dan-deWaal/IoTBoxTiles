using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTBoxTiles.Devices.Controls;

namespace IoTBoxTiles.Devices
{
    public class SmartPlug : Device
    {
        //unique properties

        public SmartPlug(Device old_device) : base(old_device)
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
            UI_small.Controls.Add(new SmartPlugSmall(this));

            UI_large = new SmartPlugLarge(this)
            {
                Name = "UILarge",
                Width = 400,
                Height = 600,
                BorderStyle = BorderStyle.FixedSingle,
            };
        }

        public override void UpdateLargeUI()
        {
            ((SmartPlugLarge)UI_large).UpdateUI();
        }

        public override void UpdateSmallUI()
        {
            ((SmartPlugSmall)UI_small.Controls[0]).UpdateUI();
        }
    }
}
