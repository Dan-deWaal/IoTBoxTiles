using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTBoxTiles.Devices.Controls;

namespace IoTBoxTiles.Devices
{
    public class Audio : Device
    {
        public Audio(Device old_device) : base(old_device)
        {
        }

        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }
        public bool speaker_status { get; set; }
        public bool mic_status { get; set; }
        public int speaker_VU { get; set; }
        public int mic_VU { get; set; }

        public override void CreateDevice()
        {
            UI_small = new Panel()
            {
                Width = 270,
                Height = 200,
                BorderStyle = BorderStyle.FixedSingle
            };
            UI_small.Controls.Add(new AudioSmall(this));

            UI_large = new Panel()
            {
                Width = 400,
                Height = 600,
                BorderStyle = BorderStyle.FixedSingle,
                // Dock = DockStyle.Fill
            };
            UI_large.Controls.Add(new AudioLarge(this));
        }

        public void UpdateLargeUI()
        {
            ((AudioLarge)UI_large.Controls[0]).UpdateUI(UI_large.Width, UI_large.Height);
        }

        public void UpdateSmallUI()
        {
            ((AudioSmall)UI_small.Controls[0]).UpdateUI(UI_small.Width, UI_small.Height);
        }
    }
}
