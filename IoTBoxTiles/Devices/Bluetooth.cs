using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTBoxTiles.Devices.Controls.Parts;
using IoTBoxTiles.Devices.Controls;
using Newtonsoft.Json.Linq;

namespace IoTBoxTiles.Devices
{
    public class Bluetooth : Device
    {
        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }

        public Bluetooth(Device old_device) : base(old_device)
        {
        }

        public Bluetooth(JObject device) : base(device)
        {
        }

        public override void CreateDevice()
        {
            AddSmallUI(new BluetoothSmall(this));
            AddLargeUI(new BluetoothLarge(this));
        }

        public override void UpdateLargeUI()
        {
            ((BluetoothLarge)UI_large).UpdateUI();
        }

        public override void UpdateSmallUI()
        {
            ((BluetoothSmall)UI_small.Controls[0]).UpdateUI();
        }
    }
}

