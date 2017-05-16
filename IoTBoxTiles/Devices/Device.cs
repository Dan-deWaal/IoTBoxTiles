using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTBoxTiles.Devices
{
    public class Device : DeviceBase
    {
        private ServerComm _serverComm = ServerComm.Instance;

        //Global Properties
        public DateTime first_connected { get; set; }
        public DateTime last_checked { get; set; }
        public bool plug_status { get; set; }
        public float? current_consumption { get; set; } // nullable float

        //UI Elements
        public Control UI_small { get; set; }
        public Control UI_large { get; set; }
        public bool show_small { get; set; }
        public bool show_large { get; set; }

        // constructors
        public Device()
        {
            CreateDevice();
        }

        public Device(DeviceBase old_device)
        {
            device_id = old_device.device_id;
            friendly_name = old_device.friendly_name;
            module_type = old_device.module_type;
            online = old_device.online;
            url = old_device.url;

            CreateDevice();
        }

        public Device(Device old_device)
        {
            // from device base
            device_id = old_device.device_id;
            friendly_name = old_device.friendly_name;
            module_type = old_device.module_type;
            online = old_device.online;
            url = old_device.url;

            // from full device object
            first_connected = old_device.first_connected;
            last_checked = old_device.last_checked;
            plug_status = old_device.plug_status;
            current_consumption = old_device.current_consumption;

            CreateDevice();
        }

        public virtual void CreateDevice()
        {
            // Small UI element
            UI_small = new Panel()
            {
                Width = 270,
                Height = 200,
                BorderStyle = BorderStyle.FixedSingle
            };

            TableLayoutPanel deviceSmallTable = new TableLayoutPanel()
            {
                Name = "table",
                Dock = DockStyle.Fill
            };
            deviceSmallTable.Controls.Add(new Label() { Name = "Name", Text = "Name" }, 0, 0); //friendly_name
            deviceSmallTable.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 1);
            deviceSmallTable.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 1);
            UI_small.Controls.Add(deviceSmallTable);
            show_small = false;

            // Large UI element
            UI_large = new Panel()
            {
                Name = "UILargePanel",
                //UI_large.Dock = DockStyle.Fill;
                BorderStyle = BorderStyle.Fixed3D
            };

            TableLayoutPanel deviceLargeTable = new TableLayoutPanel()
            {
                Name = "table",
                Dock = DockStyle.Fill
            };
            deviceLargeTable.Controls.Add(new Label() { Name = "Name", Text = "Name" }, 0, 0); //friendly_name
            deviceLargeTable.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 1);
            deviceLargeTable.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 1);
            deviceLargeTable.Controls.Add(new Label() { Name = "FirstConn", Text = "first_connected: " + first_connected.ToString() }, 0, 2);
            deviceLargeTable.Controls.Add(new Label() { Name = "LastCheck", Text = "last_checked: " + last_checked.ToString() }, 0, 3);
            deviceLargeTable.Controls.Add(new Label() { Name = "DeviceID", Text = "device_id: " + device_id.ToString() }, 0, 4);
            UI_large.Controls.Add(deviceLargeTable);
            show_large = false;
        }

        public void UpdateUI()
        {
            UpdateLargeUI();
            UpdateSmallUI();
        }

        public virtual void UpdateLargeUI() { }
        public virtual void UpdateSmallUI() { }

        public void UpdateLargeCommonUI(TableLayoutPanel table)
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

        public void UpdateSmallCommonUI(TableLayoutPanel table)
        {
            Label name_lbl = (Label)table.Controls.Find("Name", true).First();
            name_lbl.Text = friendly_name;
            CheckBox power_cb = (CheckBox)table.Controls.Find("Power", true).First();
            power_cb.Checked = plug_status;
            Label current_lbl = (Label)table.Controls.Find("Current", true).First();
            current_lbl.Text = current_consumption.ToString();
        }

        public void UpdateLargeConnectUI(TableLayoutPanel table, int? client_id, string ip_address, int? port)
        {
            CheckBox conn_cb = (CheckBox)table.Controls.Find("Connect", true).First();
            conn_cb.Checked = plug_status;
            Label ci_lbl = (Label)table.Controls.Find("Client", true).First();
            ci_lbl.Text = "client_id: " + (client_id?.ToString() ?? "not available");

            Label ip_lbl = (Label)table.Controls.Find("IP", true).First();
            ip_lbl.Text = "IP: " + (ip_address?.ToString() ?? "not available");

            Label port_lbl = (Label)table.Controls.Find("Port", true).First();
            port_lbl.Text = "port: " + (port?.ToString() ?? "not available");
        }

        public void UpdateSmallConnectUI(TableLayoutPanel table)
        {
            CheckBox conn_cb = (CheckBox)table.Controls.Find("Connect", true).First();
            conn_cb.Checked = plug_status;
        }

        public void ChangePower(bool on)
        {
            StringBuilder deviceUri = new StringBuilder(_serverComm.Root);
            deviceUri.Append("/device/");
            deviceUri.Append(device_id);
            deviceUri.Append("/power");
            if (on)
                deviceUri.Append("/on");
            else
                deviceUri.Append("/off");

            if (on)
            {
                // _serverComm.PostAsync(deviceUri.ToString(), email: );
            }
        }
    }
}
