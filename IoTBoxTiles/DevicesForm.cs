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
        private ServerComm _servComm = ServerComm.Instance;
        private string _username, _password;
        private bool _largeUi;
        
        String[] _devTypes;

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
            tv_DeviceList.SelectedNode = tv_DeviceList.Nodes[0];
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
                        SmartPlug smartplug = new SmartPlug(dev);
                        new_devices.Add(smartplug);
                        break;
                    case 2: // *** Bluetooth ***
                        Bluetooth bluetooth = new Bluetooth(dev);
                        new_devices.Add(bluetooth);
                        break;
                    case 3: // *** USB ***
                        USB usb = new USB(dev);
                        new_devices.Add(usb);
                        break;
                    case 4: // *** Infrared ***
                        Infrared infrared = new Infrared(dev);
                        new_devices.Add(infrared);
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
            var devdetails = await 
                _servComm.GetAsync(_servComm.Details);
            switch (devdetails.Item1)
            {
                case ServerResponse.NotConnected: //server not connected
                    Console.WriteLine("Server Problem");
                    lbl_status.Text = "Server Problem";
                    break;
                case ServerResponse.Connected: //success
                    var jsonString = await devdetails.Item2.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonString);
                    break;
                case ServerResponse.ServerFailure: //fail
                    Console.WriteLine("Failed");
                    lbl_status.Text = "Failed";
                    break;
            }
        }

        private async void Form2_LoadAsync(object sender, EventArgs e)
        {
            var result = await _servComm.GetAsync(_servComm.Root + "/device/types", false);
            if (result.Item1 != ServerResponse.Connected)
            {
                // should be handled better
                MessageBox.Show("Server disconnected during intialisation.");
                this.Close();
            }
            var json_str = await result.Item2.Content.ReadAsStringAsync();
            _devTypes = JsonConvert.DeserializeObject<string[]>(json_str);
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
                _largeUi = true;
                foreach (var dev in _devices)
                {
                    if (tag.Substring(5) == dev.friendly_name)
                        dev.DisplayState = DisplayStates.Large;
                    else
                        dev.DisplayState = DisplayStates.None;
                }
            }
            else
            {
                _largeUi = false;
                foreach (var dev in _devices)
                {
                    if (tag == "Devices" 
                        || (tag == "Online" && dev.online)
                        || (tag == "Offline" && !dev.online))
                        dev.DisplayState = DisplayStates.Small;
                    else
                        dev.DisplayState = DisplayStates.None;
                }
            }
            updatePanels();
        }

        private void updatePanels()
        {
            deviceFlowLayout.Controls.Clear();
            foreach (var dev in _devices)
            {
                if (dev.DisplayState == DisplayStates.Large)
                {
                    deviceFlowLayout.Controls.Add(dev.UI_large);
                }
                else if (dev.DisplayState == DisplayStates.Small)
                {
                    deviceFlowLayout.Controls.Add(dev.UI_small);
                }
            }
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            if (_largeUi)
            {
                UserControl large_control = (UserControl)Controls.Find("UILarge", true).FirstOrDefault();
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
                dev.UpdateUI();
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Really quit?", "Confirm Quit", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
