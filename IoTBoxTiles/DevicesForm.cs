using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using IoTBoxTiles.Devices;

namespace IoTBoxTiles
{
    public partial class DevicesForm : Form
    {
        private List<Device> _devices = new List<Device>();
        private ServerComm _serv_comm = new ServerComm();
        private string _username, _password;
        private bool _large_ui;

        //this should be obtained from the server
        String[] _dev_types;

        public DevicesForm(List<DeviceBase> device_list, string username, string password)
        {
            InitializeComponent();
            foreach (var dev in device_list)
            {
                _devices.Add(new Device(dev));
            }
            _username = username;
            _password = password;
        }

        private void buildTreeView()
        {
            Console.WriteLine("Building TreeView...");
            //tv_ == treeview_
            tv_DeviceList.BeginUpdate();
            tv_DeviceList.Nodes.Clear();
            tv_DeviceList.Nodes.Add("Devices");
            tv_DeviceList.Nodes[0].Tag = "Devices";
            tv_DeviceList.Nodes[0].Nodes.Add("Online");
            tv_DeviceList.Nodes[0].Nodes[0].Tag = "Online";
            tv_DeviceList.Nodes[0].Nodes.Add("Offline");
            tv_DeviceList.Nodes[0].Nodes[1].Tag = "Offline";
            foreach (var dev in _devices)
            {
                if (dev.online)
                {
                    tv_DeviceList.Nodes[0].Nodes[0].Nodes.Add(dev.friendly_name);
                    tv_DeviceList.Nodes[0].Nodes[0].LastNode.Tag = "user_" + dev.friendly_name;
                }
                else
                {
                    tv_DeviceList.Nodes[0].Nodes[1].Nodes.Add(dev.friendly_name);
                    tv_DeviceList.Nodes[0].Nodes[1].LastNode.Tag = "user_" + dev.friendly_name;
                }
            }
            tv_DeviceList.Nodes[0].ExpandAll();
            tv_DeviceList.EndUpdate();
        }

        private void createDevices()
        {
            Console.WriteLine("Creating Device Objects...");
            List<Device> new_devices = new List<Device>();
            foreach (var dev in _devices)
            {
                switch (dev.module_type)
                {
                    case 0: //unknown
                        break;
                    case 1: // *** Smartplug ***
                        SmartPlug smartplug = new SmartPlug();
                        new_devices.Add(smartplug);
                        smartplug.device_id = dev.device_id;
                        smartplug.friendly_name = dev.friendly_name;
                        smartplug.module_type = dev.module_type;
                        smartplug.online = dev.online;
                        smartplug.url = dev.url;
                        break;
                    case 2: // *** Bluetooth ***
                        Bluetooth bluetooth = new Bluetooth();
                        new_devices.Add(bluetooth);
                        bluetooth.device_id = dev.device_id;
                        bluetooth.friendly_name = dev.friendly_name;
                        bluetooth.module_type = dev.module_type;
                        bluetooth.online = dev.online;
                        bluetooth.url = dev.url;
                        break;
                    case 3: // *** USB ***
                        USB usb = new USB();
                        new_devices.Add(usb);
                        usb.device_id = dev.device_id;
                        usb.friendly_name = dev.friendly_name;
                        usb.module_type = dev.module_type;
                        usb.online = dev.online;
                        usb.url = dev.url;
                        break;
                    case 4: // *** Infrared ***
                        Infrared infrared = new Infrared();
                        new_devices.Add(infrared);
                        infrared.device_id = dev.device_id;
                        infrared.friendly_name = dev.friendly_name;
                        infrared.module_type = dev.module_type;
                        infrared.online = dev.online;
                        infrared.url = dev.url;
                        break;
                    case 5: // *** Industrial ***
                        Industrial industrial = new Industrial();
                        new_devices.Add(industrial);
                        industrial.device_id = dev.device_id;
                        industrial.friendly_name = dev.friendly_name;
                        industrial.module_type = dev.module_type;
                        industrial.online = dev.online;
                        industrial.url = dev.url;
                        break;
                    case 6: // *** Multiboard ***
                        Multiboard multiboard = new Multiboard();
                        new_devices.Add(multiboard);
                        multiboard.device_id = dev.device_id;
                        multiboard.friendly_name = dev.friendly_name;
                        multiboard.module_type = dev.module_type;
                        multiboard.online = dev.online;
                        multiboard.url = dev.url;
                        break;
                    case 7: // *** Audio ***
                        Audio audio = new Audio(dev);
                        new_devices.Add(audio);
                        break;
                    default:
                        break;
                }
            }
            _devices.Clear();
            _devices.AddRange(new_devices);
        }

        private async void updateBasicDetails()
        {
            lbl_status.Text = "Downloading devices...  ";
            Tuple<int, HttpResponseMessage> devdetails = await 
                _serv_comm.GetAsync(_serv_comm.details, _username, _password);
            switch (devdetails.Item1)
            {
                case 0: //server not connected
                    Console.WriteLine("Server Problem");
                    lbl_status.Text = "Server Problem";
                    break;
                case 1: //success
                    var jsonString = await devdetails.Item2.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonString);
                    break;
                case 2: //fail
                    Console.WriteLine("Failed");
                    lbl_status.Text = "Failed";
                    break;
            }
        }

        private async void Form2_LoadAsync(object sender, EventArgs e)
        {
            var result = await _serv_comm.GetAsync("https://iot.duality.co.nz/api/1/device/types");
            if (result.Item1 != 1)
            {
                // should be handled better
                MessageBox.Show("Server disconnected during intialisation.");
                this.Close();
            }
            var json_str = await result.Item2.Content.ReadAsStringAsync();
            _dev_types = JsonConvert.DeserializeObject<string[]>(json_str);
            createDevices();
            buildTreeView();
            //updateBasicDetails();
            refresh();

            lbl_status.Text = "Ready.";
        }

        private void tv_DeviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            String tag = e.Node.Tag.ToString();

            if (tag.StartsWith("user_"))
            {
                _large_ui = true;
                foreach (var dev in _devices)
                {
                    dev.show_large = tag.Substring(5) == dev.friendly_name;
                    dev.show_small = false;
                }
            }
            else
            {
                _large_ui = false;
                foreach (var dev in _devices)
                {
                    dev.show_small = false;
                    dev.show_large = false;
                    if (tag == "Devices" 
                        || (tag == "Online" && dev.online)
                        || (tag == "Offline" && !dev.online))
                        dev.show_small = true;
                }
            }
            updatePanels();
        }

        private void updatePanels()
        {
            deviceFlowLayout.Controls.Clear();
            foreach (var dev in _devices)
            {
                if (dev.show_large)
                {
                    deviceFlowLayout.Controls.Add(dev.UI_large);
                }
                if (dev.show_small)
                {
                    deviceFlowLayout.Controls.Add(dev.UI_small);
                }
            }
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            if (_large_ui)
            {
                UserControl large_control = (UserControl)deviceTableLayout.Controls.Find("UILarge", true).FirstOrDefault();
                if (large_control == null)
                    return;
                large_control.Width = deviceFlowLayout.ClientSize.Width - 2;
                large_control.Height = deviceFlowLayout.ClientSize.Height - 2;
            }
        }

        private void refresh()
        {
            foreach (var dev in _devices)
            {
                switch (dev.module_type)
                {
                    case 0:
                        break;
                    case 1:
                        SmartPlug sm = (SmartPlug)dev;
                        sm.updateLargeUI();
                        sm.updateSmallUI();
                        break;
                    case 2:
                        Bluetooth bt = (Bluetooth)dev;
                        bt.updateLargeUI();
                        bt.updateSmallUI();
                        break;
                    case 3:
                        USB usb = (USB)dev;
                        usb.updateLargeUI();
                        usb.updateSmallUI();
                        break;
                    case 4:
                        Infrared ir = (Infrared)dev;
                        ir.updateLargeUI();
                        ir.updateSmallUI();
                        break;
                    case 5:
                        Industrial ind = (Industrial)dev;
                        ind.updateLargeUI();
                        ind.updateSmallUI();
                        break;
                    case 6:
                        Multiboard mb = (Multiboard)dev;
                        mb.updateLargeUI();
                        mb.updateSmallUI();
                        break;
                    case 7:
                        Audio au = (Audio)dev;
                        au.UpdateLargeUI();
                        au.UpdateSmallUI();
                        break;
                    default:
                        break;
                }
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("Really quit?", string.Empty, MessageBoxButtons.YesNo);
            //if (result == DialogResult.No)
            //{
            //    e.Cancel = true;
            //} else
            //{
            Application.Exit();
            //}
        }

    }
}
