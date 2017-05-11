using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTBoxTiles.Devices
{
    class USB : Device
    {
        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }

        public USB()
        {
            TableLayoutPanel tableSmall = (TableLayoutPanel)UI_small.Controls.Find("table", true).First();
            tableSmall.Controls.Add(new CheckBox() { Name = "Connect", Text = "Connected" }, 0, 2);
            TableLayoutPanel tableLarge = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
            tableLarge.Controls.Add(new CheckBox() { Name = "Connect", Text = "Connected" }, 0, 5);
            tableLarge.Controls.Add(new Label() { Name = "Client", Text = "client_id: " }, 0, 6);
            tableLarge.Controls.Add(new Label() { Name = "IP", Text = "IP: " }, 0, 7);
            tableLarge.Controls.Add(new Label() { Name = "Port", Text = "port: " }, 1, 7);
        }

        public void updateLargeUI()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
            UpdateLargeCommonUI(table);
            UpdateLargeConnectUI(table, client_id, ip_address, port);
        }

        public void updateSmallUI()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_small.Controls.Find("table", true).First();
            UpdateSmallCommonUI(table);
            UpdateSmallConnectUI(table);
        }
    }
}
