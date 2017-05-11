using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTBoxTiles.Devices
{
    class Industrial : Device
    {
        //unique properties
        public bool conn { get; set; }
        public int com_port { get; set; }
        public string com_settings { get; set; }
        public List<string> ser_mon { get; set; }

        public Industrial()
        {
            TableLayoutPanel tableSmall = (TableLayoutPanel)UI_small.Controls.Find("table", true).First();
            tableSmall.Controls.Add(new CheckBox() { Name = "Connect", Text = "Connected" }, 0, 2);
            tableSmall.Controls.Add(new Label() { Name = "COMPort", Text = "COM : " }, 0, 3);
            TableLayoutPanel tableLarge = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
            tableLarge.Controls.Add(new CheckBox() { Name = "Connect", Text = "Connected" }, 0, 5);
            tableLarge.Controls.Add(new Label() { Name = "COMPort", Text = "COM : " }, 0, 6);
            tableLarge.Controls.Add(new Label() { Name = "Settings", Text = "Serial Settings : " }, 0, 7);
            tableLarge.Controls.Add(new Label() { Name = "Monitor", Text = "Monitor : " }, 0, 8);
        }

        public void updateLargeUI()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
            UpdateLargeCommonUI(table);
            CheckBox conn_cb = (CheckBox)table.Controls.Find("Connect", true).First();
            conn_cb.Checked = plug_status;
            Label com_lbl = (Label)table.Controls.Find("COMPort", true).First();
            com_lbl.Text = "COM : " + com_port;
            Label set_lbl = (Label)table.Controls.Find("Settings", true).First();
            set_lbl.Text = "Serial Settings : " + com_settings;
            Label mon_lbl = (Label)table.Controls.Find("Monitor", true).First();
            mon_lbl.Text = "Monitor : " + ser_mon;
        }

        public void updateSmallUI()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_small.Controls.Find("table", true).First();
            UpdateSmallCommonUI(table);
            CheckBox conn_cb = (CheckBox)table.Controls.Find("Connect", true).First();
            conn_cb.Checked = plug_status;
            Label com_lbl = (Label)table.Controls.Find("COMPort", true).First();
            com_lbl.Text = "COM : " + com_port;
        }
    }
}
