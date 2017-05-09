using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTBoxTiles.Devices
{
    class SmartPlug : Device
    {
        //unique properties

        public SmartPlug()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
        }

        public void updateLargeUI()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
            updateLargeCommonUI(table);
        }

        public void updateSmallUI()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_small.Controls.Find("table", true).First();
            updateSmallCommonUI(table);
        }
    }
}
