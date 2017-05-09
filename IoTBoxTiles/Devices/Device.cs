using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTBoxTiles.Devices
{
    class Device
    {
        //Initial Data
        public int device_id { get; set; }
        public string friendly_name { get; set; }
        public int module_type { get; set; }
        public bool online { get; set; }
        public string url { get; set; }

        //Global Properties
        public DateTime first_connected { get; set; }
        public DateTime last_checked { get; set; }
        public bool plug_status { get; set; } //nullable int
        public float? current_consumption { get; set; } //nullable float

        //UI Elements
        public Panel UI_small { get; set; }
        public Panel UI_large { get; set; }
        public bool show_small { get; set; }
        public bool show_large { get; set; }

        public Device()
        {
            // Small UI element
            UI_small = new Panel();
            UI_small.Width = 200;
            UI_small.Height = 180;
            UI_small.BorderStyle = BorderStyle.Fixed3D;
            show_small = false;
            TableLayoutPanel table1 = new TableLayoutPanel();
            table1.Name = "table";
            table1.Dock = DockStyle.Fill;
            table1.Controls.Add(new Label() { Name = "Name", Text = "Name" }, 0, 0); //friendly_name
            table1.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 1);
            table1.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 1);
            UI_small.Controls.Add(table1);

            // Large UI element
            UI_large = new Panel();
            UI_large.Name = "UILargePanel";
            UI_large.Width = 400;
            UI_large.Height = 580;
            //UI_large.Dock = DockStyle.Fill;
            UI_large.BorderStyle = BorderStyle.Fixed3D;
            show_large = false;
            TableLayoutPanel table2 = new TableLayoutPanel();
            table2.Name = "table";
            table2.Dock = DockStyle.Fill;
            table2.Controls.Add(new Label() { Name = "Name", Text = "Name" }, 0, 0); //friendly_name
            table2.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 1);
            table2.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 1);
            table2.Controls.Add(new Label() { Name = "FirstConn", Text = "first_connected: " + first_connected.ToString() }, 0, 2);
            table2.Controls.Add(new Label() { Name = "LastCheck", Text = "last_checked: " + last_checked.ToString() }, 0, 3);
            table2.Controls.Add(new Label() { Name = "DeviceID", Text = "device_id: " + device_id.ToString() }, 0, 4);
            UI_large.Controls.Add(table2);
        }

        public void updateLargeCommonUI(TableLayoutPanel table)
        {
            Label name_lbl = (Label)table.Controls.Find("Name", true).First();
            name_lbl.Text = friendly_name;
            CheckBox power_cb = (CheckBox)table.Controls.Find("Power", true).First();
            power_cb.Checked = plug_status;
            Label current_lbl = (Label)table.Controls.Find("Current", true).First();
            current_lbl.Text = "current: " + current_consumption.ToString() + " mA";
            Label first_lbl = (Label)table.Controls.Find("FirstConn", true).First();
            first_lbl.Text = "first_connected: " + first_connected.ToString();
            Label last_lbl = (Label)table.Controls.Find("LastCheck", true).First();
            last_lbl.Text = "last_checked: " + last_checked.ToString();
            Label id_lbl = (Label)table.Controls.Find("DeviceID", true).First();
            id_lbl.Text = "device_id: " + device_id.ToString();
        }

        public void updateSmallCommonUI(TableLayoutPanel table)
        {
            Label name_lbl = (Label)table.Controls.Find("Name", true).First();
            name_lbl.Text = friendly_name;
            CheckBox power_cb = (CheckBox)table.Controls.Find("Power", true).First();
            power_cb.Checked = plug_status;
            Label current_lbl = (Label)table.Controls.Find("Current", true).First();
            current_lbl.Text = current_consumption.ToString();
        }

        public void updateLargeConnectUI(TableLayoutPanel table, int? client_id, string ip_address, int? port)
        {
            CheckBox conn_cb = (CheckBox)table.Controls.Find("Connect", true).First();
            conn_cb.Checked = plug_status;
            Label ci_lbl = (Label)table.Controls.Find("Client", true).First();
            try
            { //nullables must be in try catch
                ci_lbl.Text = "client_id: " + client_id.ToString();
            }
            catch
            {
                ci_lbl.Text = "client_id: not available";
            }
            Label ip_lbl = (Label)table.Controls.Find("IP", true).First();
            try
            { //nullables must be in try catch
                ip_lbl.Text = "IP: " + ip_address.ToString();
            }
            catch
            {
                ip_lbl.Text = "IP: not available";
            }
            Label port_lbl = (Label)table.Controls.Find("Port", true).First();
            try
            { //nullables must be in try catch
                port_lbl.Text = "port: " + port.ToString();
            }
            catch
            {
                port_lbl.Text = "port: not available";
            }
        }

        public void updateSmallConnectUI(TableLayoutPanel table)
        {
            CheckBox conn_cb = (CheckBox)table.Controls.Find("Connect", true).First();
            conn_cb.Checked = plug_status;
        }
    }
}
