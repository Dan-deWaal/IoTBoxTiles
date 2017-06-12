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
    public class Multiboard : Device
    {
        //unique properties
        public List<KeyValuePair<string, bool>> _boards { get; set; }

        public Multiboard(Device old_device) : base(old_device)
        {
            _boards = new List<KeyValuePair<string, bool>>() {
                new KeyValuePair<string, bool>("board1",true),
                new KeyValuePair<string, bool>("board2",false),
                new KeyValuePair<string, bool>("board3",true),
                new KeyValuePair<string, bool>("board4",false)
            };
        }

        public Multiboard(JObject device) : base(device)
        {
            _boards = new List<KeyValuePair<string, bool>>() {
                new KeyValuePair<string, bool>("board1",true),
                new KeyValuePair<string, bool>("board2",false),
                new KeyValuePair<string, bool>("board3",true),
                new KeyValuePair<string, bool>("board4",false)
            };
        }

        public override void CreateDevice()
        {
            AddSmallUI(new MultiboardSmall(this));
            AddLargeUI(new MultiboardLarge(this));
        }

        public override void UpdateLargeUI()
        {
            ((MultiboardLarge)UI_large).UpdateUI();
        }

        public override void UpdateSmallUI()
        {
            ((MultiboardSmall)UI_small.Controls[0]).UpdateUI();
        }
    }
}
