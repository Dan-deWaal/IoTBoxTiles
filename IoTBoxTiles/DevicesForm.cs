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
using Newtonsoft.Json.Linq;
using System.Threading;
using Microsoft.Win32;

namespace IoTBoxTiles
{
    public partial class DevicesForm : Form
    {
        private List<Device> _devices = new List<Device>();
        private ServerComm _servComm = ServerComm.Instance;
        private bool _largeUi;
        public static List<Thread> _openThreads = new List<Thread>();
        private static string userRoot = "HKEY_CURRENT_USER";
        private static string subkey = @"Software\IoTBox";
        public static string _keyName = userRoot + "\\" + subkey;
        public static int? _client_id = null;

        String[] _devTypes;

        public DevicesForm(List<DeviceBase> device_list)
        {
            InitializeComponent();
            foreach (var dev in device_list)
            {
                _devices.Add(new Device(dev));
            }
            _client_id = (int?)Registry.GetValue(_keyName, _servComm.Email, null);
            Console.WriteLine("Client ID: {0}", _client_id);
        }

        private void buildTreeView()
        {
            //Console.WriteLine("Building TreeView...");
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
                    tv_DeviceList.Nodes[0].Nodes[0].LastNode.Tag = dev.device_id;
                }
                else
                {
                    tv_DeviceList.Nodes[0].Nodes[1].Nodes.Add(dev.friendly_name);
                    tv_DeviceList.Nodes[0].Nodes[1].LastNode.Tag = dev.device_id;
                }
            }
            tv_DeviceList.Nodes[0].ExpandAll();
            tv_DeviceList.EndUpdate();
            tv_DeviceList.SelectedNode = tv_DeviceList.Nodes[0];
        }

        private void createDevices()
        {
            //Console.WriteLine("Creating Device Objects...");
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
                        Industrial industrial = new Industrial(dev);
                        new_devices.Add(industrial);
                        break;
                    case 6: // *** Multiboard ***
                        Multiboard multiboard = new Multiboard(dev);
                        new_devices.Add(multiboard);
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

        private async void UpdateDeviceDetails(object sender = null, EventArgs e = null)
        {
            lbl_status.Text = "Downloading devices...  ";
            string jsonStr = null;
            var devDetails = await _servComm.GetAsync(_servComm.Root + "/user/devices/details");

            switch (devDetails.Item1)
            {
                case ServerResponse.NotConnected:
                    lbl_status.Text = "Server Problem";
                    break;
                case ServerResponse.Connected:
                    jsonStr = await devDetails.Item2.Content.ReadAsStringAsync();
                    break;
                case ServerResponse.ServerFailure:
                    lbl_status.Text = "Failed";
                    break;
            }
            if (jsonStr == null)
                return;
            
            List<JObject> newDevs = JsonConvert.DeserializeObject<List<JObject>>(jsonStr);

            _devices.RemoveAll( dev => !newDevs.Exists(dev.SameDevice) );
            var addedDevs = new List<Device>();
            foreach (var dev in _devices)
            {
                int i = newDevs.FindIndex(dev.SameDevice);
                if (i != -1)
                {
                    dev.UpdateDevice(newDevs[i]);
                }
                else
                {
                    // i hate this
                    switch ((int)newDevs[i]["module_type"])
                    {
                        case 1:
                            addedDevs.Add(new SmartPlug(newDevs[i]));
                            break;
                        case 2:
                            addedDevs.Add(new Bluetooth(newDevs[i]));
                            break;
                        case 3:
                            addedDevs.Add(new USB(newDevs[i]));
                            break;
                        case 4:
                            addedDevs.Add(new Infrared(newDevs[i]));
                            break;
                        case 5:
                            addedDevs.Add(new Industrial(newDevs[i]));
                            break;
                        case 6:
                            addedDevs.Add(new Multiboard(newDevs[i]));
                            break;
                        case 7:
                            addedDevs.Add(new Audio(newDevs[i]));
                            break;
                        case 0: //unknown
                        default:
                            break;
                    }
                }
            }
            _devices.AddRange(addedDevs);
            foreach (var dev in _devices)
                dev.UpdateUI();
            lbl_status.Text = "Ready.";
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
            UpdateDeviceDetails();
            Refresh();

            lbl_status.Text = "Ready.";
            var _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 1500;
            _refreshTimer.Tick += UpdateDeviceDetails;
            _refreshTimer.Start();
        }

        private void tv_DeviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is int)
            {
                _largeUi = true;
                foreach (var dev in _devices)
                {
                    if ((int)e.Node.Tag == dev.device_id)
                        dev.DisplayState = DisplayStates.Large;
                    else
                        dev.DisplayState = DisplayStates.None;
                }
            }
            else if (e.Node.Tag is string)
            {
                _largeUi = false;
                string tag = (string)e.Node.Tag;
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
            UpdatePanels();
        }

        private void UpdatePanels()
        {
            deviceFlowLayout.Controls.Clear();
            foreach (var dev in _devices)
            {
                if (dev.DisplayState == DisplayStates.Large)
                    deviceFlowLayout.Controls.Add(dev.UI_large);
                else if (dev.DisplayState == DisplayStates.Small)
                    deviceFlowLayout.Controls.Add(dev.UI_small);
            }
            flowLayoutPanel1_Resize(null, null);
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            deviceFlowLayout.AutoScroll = true;
            if (_largeUi)
            {
                if (deviceFlowLayout.Controls.Count < 1)
                    return;
                deviceFlowLayout.AutoScroll = false;

                // hey dont select that
                UserControl largeControl = (UserControl)deviceFlowLayout.Controls[0];
                largeControl.Width = deviceFlowLayout.ClientSize.Width - 4;
                largeControl.Height = deviceFlowLayout.ClientSize.Height - 4;
            } else
            {
                if (deviceFlowLayout.Controls.Count < 1)
                    return;
                int layoutWidth = deviceFlowLayout.ClientSize.Width;
                if (deviceFlowLayout.ClientSize.Width < 270 + 8)
                    return;
                int columnCount = layoutWidth / (270 + 4);
                if (columnCount < 1)
                    return;
                int newSize = (layoutWidth - (5 + 5*columnCount)) / columnCount;
                foreach (Control smallControl in deviceFlowLayout.Controls)
                {
                    smallControl.Width = newSize;
                }
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            UpdateDeviceDetails();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Really quit?", "Confirm Quit", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                foreach (Thread openThread in _openThreads)
                {
                    openThread.Abort();
                }
                //send msg to server - "disconnected from all devices"
            }
        }
        
    }
}
