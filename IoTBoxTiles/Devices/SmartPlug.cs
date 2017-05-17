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
    public class SmartPlug : Device
    {
        //unique properties

        public SmartPlug(Device old_device) : base(old_device)
        {
        }

        public SmartPlug(JObject device) : base(device)
        {
        }

        public override void CreateDevice()
        {
            AddSmallUI(new SmartPlugSmall(this));
            AddLargeUI(new SmartPlugLarge(this));
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
