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
            UI_small.Width = 300;
            UI_small.Height = 400;
            show_small = false;
            TableLayoutPanel table1 = new TableLayoutPanel();
            table1.Name = "table";
            table1.Dock = DockStyle.Fill;
            table1.Controls.Add(new Label() { Name = "Name", Text = friendly_name }, 0, 0);
            table1.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 1);
            table1.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 1);
            UI_small.Controls.Add(table1);

            // Large UI element
            UI_large = new Panel();
            UI_large.Dock = DockStyle.Fill;
            show_large = false;
            TableLayoutPanel table2 = new TableLayoutPanel();
            table2.Name = "table";
            table2.Dock = DockStyle.Fill;
            table2.Controls.Add(new Label() { Name = "Name", Text = friendly_name }, 0, 0);
            table2.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 1);
            table2.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 1);
            table2.Controls.Add(new Label() { Name = "FirstConn", Text = "first_connected: " + first_connected.ToString() }, 0, 2);
            table2.Controls.Add(new Label() { Name = "LastCheck", Text = "last_checked: " + last_checked.ToString() }, 0, 3);
            UI_large.Controls.Add(table2);
        }
    }
    
    public class SmartPlug : Device
    {
        //unique properties

        public SmartPlug()
        {
            TableLayoutPanel table = (TableLayoutPanel)UI_large.Controls.Find("table", true).First();
            table.Controls.Add(new Label() { Name = "DeviceID", Text = "device_id: " + device_id.ToString() }, 0, 4);
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

        }
    }

    public class Err
    {
        public string error { get; set; }
    }
}
