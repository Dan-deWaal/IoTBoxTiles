using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTBoxTiles
{
    public class DeviceList
    {
        //Initial Data
        public int device_id { get; set; }
        public string friendly_name { get; set; }
        public int module_type { get; set; }
        public bool online { get; set; }
        public string url { get; set; }
    }

    public class Device
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
    
    public class SmartPlug : Device
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

    public class Bluetooth : Device
    {
        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }

        public Bluetooth()
        {
            TableLayoutPanel tableSmall = (TableLayoutPanel)UI_small.Controls.Find("table", true).First();
            tableSmall.Controls.Add(new CheckBox() { Name = "Connect", Text = "Connected" }, 0, 2);
            TableLayoutPanel tableLarge = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
            tableLarge.Controls.Add(new CheckBox() { Name = "Connect", Text = "Connected" }, 0, 5);
            tableLarge.Controls.Add(new Label() { Name = "Client", Text = "client_id: "}, 0, 6);
            tableLarge.Controls.Add(new Label() { Name = "IP", Text = "IP: "}, 0, 7);
            tableLarge.Controls.Add(new Label() { Name = "Port", Text = "port: "}, 1, 7);
        }

        public void updateLargeUI()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
            updateLargeCommonUI(table);
            updateLargeConnectUI(table, client_id, ip_address, port);
        }

        public void updateSmallUI()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_small.Controls.Find("table", true).First();
            updateSmallCommonUI(table);
            updateSmallConnectUI(table);
        }
    }

    public class USB : Device
    {
        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }

        public USB()
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

    public class Infrared : Device
    {
        //unique properties
        //public List<Tuple> buttons(string_name, string_code, bool_quick) { get; set; }
        public bool repeater { get; set; }
        public bool feedback { get; set; }
        
        public Infrared()
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

    public class Industrial : Device
    {
        //unique properties
        public bool conn { get; set; }
        public int com_port { get; set; }
        public string com_settings { get; set; }
        public List<string> ser_mon { get; set; }

        public Industrial()
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

    public class Multiboard : Device
    {
        //unique properties
        //public List<Tuple> buttons(string_name, bool_power, float_curr) { get; set; }
        public bool repeater { get; set; }
        public bool feedback { get; set; }

        public Multiboard()
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

    public class Audio : Device
    {
        //unique properties
        public bool connected { get; set; }
        public int? client_id { get; set; } //nullable int
        public string ip_address { get; set; } //convert to IP datatype be better?
        public int? port { get; set; }
        public bool speaker_status { get; set; }
        public bool mic_status { get; set; }
        public float speaker_VU { get; set; }
        public float mic_VU { get; set; }

        public Audio()
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

    public class Err
    {
        public string error { get; set; }
    }
}
