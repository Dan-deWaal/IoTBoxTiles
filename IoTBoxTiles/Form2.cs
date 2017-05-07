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

namespace IoTBoxTiles
{
    public partial class Form2 : Form
    {
        List<DeviceList> devicelist = new List<DeviceList>();
        List<Device> devices = new List<Device>();
        private ServerComm servercomm = new ServerComm();
        private string username, passwd;
        private bool large_ui;

        //this should be obtained from the server
        String[] devtype = { "unknown", "SmartPlug", "Bluetooth", "USB", "Infrared", "Industrial", "Multiboard", "Audio" };

        public Form2(List<DeviceList> devs, string u, string p)
        {
            InitializeComponent();
            devicelist = devs;
            username = u;
            passwd = p;
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
            foreach (var dev in devices)
            {
                if (dev.online)
                {
                    tv_DeviceList.Nodes[0].Nodes[0].Nodes.Add(dev.friendly_name);
                    tv_DeviceList.Nodes[0].Nodes[0].LastNode.Tag = dev.friendly_name;
                }
                else
                {
                    tv_DeviceList.Nodes[0].Nodes[1].Nodes.Add(dev.friendly_name);
                    tv_DeviceList.Nodes[0].Nodes[1].LastNode.Tag = dev.friendly_name;
                }
            }
            tv_DeviceList.Nodes[0].ExpandAll();
            tv_DeviceList.EndUpdate();
        }

        private void createDevices()
        {
            Console.WriteLine("Creating Device Objects...");
            devices.Clear();
            foreach (var dev in devicelist)
            {
                switch (dev.module_type)
                {
                    case 0: //unknown
                        break;
                    case 1: // *** Smartplug ***
                        SmartPlug smartplug = new SmartPlug();
                        devices.Add(smartplug);
                        smartplug.device_id = dev.device_id;
                        smartplug.friendly_name = dev.friendly_name;
                        smartplug.module_type = dev.module_type;
                        smartplug.online = dev.online;
                        smartplug.url = dev.url;
                        break;
                    case 2: // *** Bluetooth ***
                        Bluetooth bluetooth = new Bluetooth();
                        devices.Add(bluetooth);
                        bluetooth.device_id = dev.device_id;
                        bluetooth.friendly_name = dev.friendly_name;
                        bluetooth.module_type = dev.module_type;
                        bluetooth.online = dev.online;
                        bluetooth.url = dev.url;
                        break;
                    case 3: // *** USB ***
                        USB usb = new USB();
                        devices.Add(usb);
                        usb.device_id = dev.device_id;
                        usb.friendly_name = dev.friendly_name;
                        usb.module_type = dev.module_type;
                        usb.online = dev.online;
                        usb.url = dev.url;
                        break;
                    case 4: // *** Infrared ***
                        Infrared infrared = new Infrared();
                        devices.Add(infrared);
                        infrared.device_id = dev.device_id;
                        infrared.friendly_name = dev.friendly_name;
                        infrared.module_type = dev.module_type;
                        infrared.online = dev.online;
                        infrared.url = dev.url;
                        break;
                    case 5: // *** Industrial ***
                        Industrial industrial = new Industrial();
                        devices.Add(industrial);
                        industrial.device_id = dev.device_id;
                        industrial.friendly_name = dev.friendly_name;
                        industrial.module_type = dev.module_type;
                        industrial.online = dev.online;
                        industrial.url = dev.url;
                        break;
                    case 6: // *** Multiboard ***
                        Multiboard multiboard = new Multiboard();
                        devices.Add(multiboard);
                        multiboard.device_id = dev.device_id;
                        multiboard.friendly_name = dev.friendly_name;
                        multiboard.module_type = dev.module_type;
                        multiboard.online = dev.online;
                        multiboard.url = dev.url;
                        break;
                    case 7: // *** Audio ***
                        Audio audio = new Audio();
                        devices.Add(audio);
                        audio.device_id = dev.device_id;
                        audio.friendly_name = dev.friendly_name;
                        audio.module_type = dev.module_type;
                        audio.online = dev.online;
                        audio.url = dev.url;
                        break;
                    default:
                        break;
                }
            }
        }

        private async void updateBasicDetails()
        {
            lbl_status.Text = "Downloading devices...  ";
            Tuple<int, HttpResponseMessage> devdetails = await servercomm.GetAsync(servercomm.details, username, passwd);
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

        private void Form2_Load(object sender, EventArgs e)
        {
            createDevices();
            buildTreeView();
            //updateBasicDetails();
            refresh();
            
            lbl_status.Text = "Ready.";
        }

        private void tv_DeviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Console.WriteLine(e.Node.Tag);
            String tag = e.Node.Tag.ToString();
            if (tag.Equals("Devices"))
            {
                large_ui = false;
                foreach (var dev in devices)
                {
                    dev.show_small = true;
                    dev.show_large = false;
                }
            }
            else if (tag.Equals("Online"))
            {
                large_ui = false;
                foreach (var dev in devices)
                {
                    if (dev.online)
                    {
                        dev.show_small = true;
                    }
                    else
                    {
                        dev.show_small = false;
                    }
                    dev.show_large = false;
                }
            }
            else if (tag.Equals("Offline"))
            {
                large_ui = false;
                foreach (var dev in devices)
                {
                    if (dev.online)
                    {
                        dev.show_small = false;
                    }
                    else
                    {
                        dev.show_small = true;
                    }
                    dev.show_large = false;
                }
            }
            else
            {
                large_ui = true;
                foreach (var dev in devices)
                {
                    if (tag.Equals(dev.friendly_name))
                    {
                        dev.show_large = true;
                    }
                    else
                    {
                        dev.show_large = false;
                    }
                    dev.show_small = false;
                }
            }
            updatePanels();
        }

        private void updatePanels()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var dev in devices)
            {
                if (dev.show_large)
                {
                    flowLayoutPanel1.Controls.Add(dev.UI_large);
                }
                if (dev.show_small)
                {
                    flowLayoutPanel1.Controls.Add(dev.UI_small);
                }
            }
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            if (large_ui)
            {
                try
                {
                    Panel large_panel = (Panel)tableLayoutPanel1.Controls.Find("UILargePanel", true).First();
                    large_panel.Width = control.Size.Width - 20;
                    large_panel.Height = control.Size.Height - 20;
                }
                catch
                {

                }
            }
        }

        private void refresh()
        {
            foreach (var dev in devices)
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
                        au.updateLargeUI();
                        au.updateSmallUI();
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
