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
            foreach (var dev in devicelist)
            {
                if (dev.online)
                {
                    tv_DeviceList.Nodes[0].Nodes[0].Nodes.Add(dev.friendly_name);
                }
                else
                {
                    tv_DeviceList.Nodes[0].Nodes[1].Nodes.Add(dev.friendly_name);
                }
            }
            tv_DeviceList.Nodes[0].ExpandAll();
            tv_DeviceList.EndUpdate();
        }

        private void createDevices()
        {
            Console.WriteLine("Creating Device Objects...");
            foreach (var dev in devicelist)
            {
                switch (dev.module_type)
                {
                    case 0: //unknown
                        break;
                    case 1: // *** Smartplug ***
                        SmartPlug smartplug = new SmartPlug();
                        devices.Add(smartplug);
                        break;
                    case 2: // *** Bluetooth ***
                        Bluetooth bluetooth = new Bluetooth();
                        devices.Add(bluetooth);
                        break;
                    case 3: // *** USB ***
                        USB usb = new USB();
                        devices.Add(usb);
                        break;
                    case 4: // *** Infrared ***
                        Infrared infrared = new Infrared();
                        devices.Add(infrared);
                        break;
                    case 5: // *** Industrial ***
                        Industrial industrial = new Industrial();
                        devices.Add(industrial);
                        break;
                    case 6: // *** Multiboard ***
                        Multiboard multiboard = new Multiboard();
                        devices.Add(multiboard);
                        break;
                    case 7: // *** Audio ***
                        Audio audio = new Audio();
                        devices.Add(audio);
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

        private async void Form2_Load(object sender, EventArgs e)
        {
            buildTreeView();
            createDevices();
            updateBasicDetails();

            //lbl_status.Text = "Downloading devices..."; //maybe add a progress bar?

            foreach (var dev in devicelist)
            {
                Console.WriteLine(dev.friendly_name);
                Console.WriteLine(dev.device_id.ToString());
                Console.WriteLine(dev.url);
                //Console.WriteLine("");


                

                GroupBox grp = new GroupBox();
                grp.Text = dev.friendly_name + "(" + devtype[dev.module_type] + ")";
                grp.Name = dev.friendly_name;
                grp.Width = 240;
                grp.Height = 140;
                grp.Click += new System.EventHandler(this.groupClick);
                grp.Tag = dev.online.ToString() + ":" + dev.device_id.ToString();

                GroupBox single = new GroupBox();
                //Panel single = new Panel();
                single.Text = dev.friendly_name;
                single.Name = dev.friendly_name;
                //single.Dock = DockStyle.Fill;
                single.Width = 300;
                single.Height = 400;
                single.Tag = dev.device_id;
                
                lbl_status.Text = "Downloading devices...  "+dev.friendly_name;
                Tuple<int, HttpResponseMessage> inddevreq = await servercomm.GetAsync(dev.url, username, passwd);
                switch (inddevreq.Item1)
                {
                    case 0: //server not connected
                        Console.WriteLine("Server Problem");
                        lbl_status.Text = "Server Problem";
                        break;
                    case 1: //success
                        var jsonString = await inddevreq.Item2.Content.ReadAsStringAsync();
                        switch (dev.module_type)
                        {
                            case 0: //unknown
                                break;
                            case 1: // *** Smartplug ***
                                    //Small: Power Toggle
                                    //Big: Current Consumption
                                SmartPlug smartplug = JsonConvert.DeserializeObject<SmartPlug>(jsonString);
                                ind_devices.Add(smartplug);
                                TableLayoutPanel table1 = new TableLayoutPanel();
                                table1.Dock = DockStyle.Fill;
                                table1.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 0);
                                table1.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 0);
                                grp.Controls.Add(table1);
                                TableLayoutPanel table2 = new TableLayoutPanel();
                                table2.Dock = DockStyle.Fill;
                                table2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                                table2.Controls.Add(new Label() { Name = "Title", Text = smartplug.friendly_name }, 0, 0);
                                table2.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 1);
                                table2.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 1);
                                table2.Controls.Add(new Label() { Name = "DevId", Text = "device_id : " + smartplug.device_id.ToString() }, 0, 2);
                                table2.Controls.Add(new Label() { Name = "FirstConn", Text = "first_connected : " + smartplug.first_connected.ToString() }, 0, 3);
                                table2.Controls.Add(new Label() { Name = "IP", Text = "ip_address : " + smartplug.ip_address.ToString() }, 0, 4);
                                table2.Controls.Add(new Label() { Name = "LastCheck", Text = "last_checked : " + smartplug.last_checked.ToString() }, 0, 5);
                                table2.Controls.Add(new Label() { Name = "ModType", Text = "module_type : " + smartplug.module_type.ToString() }, 0, 6);
                                table2.Controls.Add(new Label() { Name = "UserID", Text = "user_id : " + smartplug.user_id.ToString() }, 0, 7);
                                single.Controls.Add(table2);
                                break;
                            case 2: // *** Bluetooth ***
                                    //Small: Power Toggle, Connect
                                    //Big: Current Consumption
                                Bluetooth bluetooth = JsonConvert.DeserializeObject<Bluetooth>(jsonString);
                                ind_devices.Add(bluetooth);
                                TableLayoutPanel table3 = new TableLayoutPanel();
                                table3.Dock = DockStyle.Fill;
                                table3.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 0);
                                table3.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 0);
                                table3.Controls.Add(new CheckBox() { Name = "Connected", Text = "Connected" }, 0, 1);
                                grp.Controls.Add(table3);
                                TableLayoutPanel table4 = new TableLayoutPanel();
                                table4.Dock = DockStyle.Fill;
                                table4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                                table4.Controls.Add(new Label() { Name = "Title", Text = bluetooth.friendly_name }, 0, 0);
                                table4.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 1);
                                table4.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 1);
                                table4.Controls.Add(new CheckBox() { Name = "Connected", Text = "Connected" }, 0, 2);
                                table4.Controls.Add(new Label() { Name = "DevId", Text = "device_id : " + bluetooth.device_id.ToString() }, 0, 3);
                                table4.Controls.Add(new Label() { Name = "FirstConn", Text = "first_connected : " + bluetooth.first_connected.ToString() }, 0, 4);
                                table4.Controls.Add(new Label() { Name = "IP", Text = "ip_address : " + bluetooth.ip_address.ToString() }, 0, 5);
                                table4.Controls.Add(new Label() { Name = "LastCheck", Text = "last_checked : " + bluetooth.last_checked.ToString() }, 0, 6);
                                table4.Controls.Add(new Label() { Name = "ModType", Text = "module_type : " + bluetooth.module_type.ToString() }, 0, 7);
                                table4.Controls.Add(new Label() { Name = "UserID", Text = "user_id : " + bluetooth.user_id.ToString() }, 0, 8);
                                single.Controls.Add(table4);
                                break;
                            case 3: // *** USB ***
                                    //Small: Power Toggle, Connect
                                    //Big: Current Consumption
                                USB usb = JsonConvert.DeserializeObject<USB>(jsonString);
                                ind_devices.Add(usb);
                                TableLayoutPanel table5 = new TableLayoutPanel();
                                table5.Dock = DockStyle.Fill;
                                table5.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 0);
                                table5.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 0);
                                table5.Controls.Add(new CheckBox() { Name = "Connected", Text = "Connected" }, 0, 1);
                                grp.Controls.Add(table5);
                                TableLayoutPanel table6 = new TableLayoutPanel();
                                table6.Dock = DockStyle.Fill;
                                table6.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                                table6.Controls.Add(new Label() { Name = "Title", Text = usb.friendly_name }, 0, 0);
                                table6.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 1);
                                table6.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 1);
                                table6.Controls.Add(new CheckBox() { Name = "Connected", Text = "Connected" }, 0, 2);
                                table6.Controls.Add(new Label() { Name = "DevId", Text = "device_id : " + usb.device_id.ToString() }, 0, 3);
                                table6.Controls.Add(new Label() { Name = "FirstConn", Text = "first_connected : " + usb.first_connected.ToString() }, 0, 4);
                                table6.Controls.Add(new Label() { Name = "IP", Text = "ip_address : " + usb.ip_address.ToString() }, 0, 5);
                                table6.Controls.Add(new Label() { Name = "LastCheck", Text = "last_checked : " + usb.last_checked.ToString() }, 0, 6);
                                table6.Controls.Add(new Label() { Name = "ModType", Text = "module_type : " + usb.module_type.ToString() }, 0, 7);
                                table6.Controls.Add(new Label() { Name = "UserID", Text = "user_id : " + usb.user_id.ToString() }, 0, 8);
                                single.Controls.Add(table6);
                                break;
                            case 4: // *** Infrared ***
                                    //Small: Power Toggle, Common buttons, Feedback
                                    //Big: Current Consumption, Feedback, Repeater Toggle, Change Common buttons, All buttons
                                Infrared infrared = JsonConvert.DeserializeObject<Infrared>(jsonString);
                                ind_devices.Add(infrared);
                                TableLayoutPanel table7 = new TableLayoutPanel();
                                table7.Dock = DockStyle.Fill;
                                table7.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 0);
                                table7.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 0);
                                table7.Controls.Add(new Label() { Name = "Feedback", Text = "Feedback: Off" }, 0, 1);
                                table7.Controls.Add(new Button() { Name = "Button1", Text = "Button1" }, 0, 2);
                                table7.Controls.Add(new Button() { Name = "Button2", Text = "Button2" }, 1, 2);
                                table7.Controls.Add(new Button() { Name = "Button3", Text = "Button3" }, 0, 3);
                                table7.Controls.Add(new Button() { Name = "Button4", Text = "Button4" }, 1, 3);
                                grp.Controls.Add(table7);
                                TableLayoutPanel table8 = new TableLayoutPanel();
                                table8.Dock = DockStyle.Fill;
                                table8.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                                table8.Controls.Add(new Label() { Name = "Title", Text = infrared.friendly_name }, 0, 0);
                                table8.Controls.Add(new CheckBox() { Name = "Power", Text = "Power" }, 0, 1);
                                table8.Controls.Add(new Label() { Name = "Current", Text = "0 mA" }, 1, 1);
                                table8.Controls.Add(new CheckBox() { Name = "Repeater", Text = "Repeater" }, 0, 2);
                                table8.Controls.Add(new Label() { Name = "Feedback", Text = "Feedback: Off" }, 1, 2);
                                for (int i = 0; i < 12; i++)
                                {
                                    table8.Controls.Add(new Button() { Name = "Button"+i, Text = "Button"+i }, i % 3, (i / 3) + 3);
                                }
                                table8.Controls.Add(new Label() { Name = "DevId", Text = "device_id : " + infrared.device_id.ToString() }, 0, 7);
                                table8.Controls.Add(new Label() { Name = "FirstConn", Text = "first_connected : " + infrared.first_connected.ToString() }, 0, 8);
                                table8.Controls.Add(new Label() { Name = "IP", Text = "ip_address : " + infrared.ip_address.ToString() }, 0, 9);
                                table8.Controls.Add(new Label() { Name = "LastCheck", Text = "last_checked : " + infrared.last_checked.ToString() }, 0, 10);
                                table8.Controls.Add(new Label() { Name = "ModType", Text = "module_type : " + infrared.module_type.ToString() }, 0, 11);
                                table8.Controls.Add(new Label() { Name = "UserID", Text = "user_id : " + infrared.user_id.ToString() }, 0, 12);
                                single.Controls.Add(table8);
                                break;
                            case 5: // *** Industrial ***
                                    //Small: Power Toggle, Connect, COM Port
                                    //Big: Current Consumption, Serial Monitor, Monitor settings
                                break;
                            case 6: // *** Multiboard ***
                                    //Small: Power Toggle, 4 x Power Toggle w/ names
                                    //Big: Current Consumption, 5 x Current Consumption, Naming
                                break;
                            case 7: // *** Audio ***
                                    //Small: Power Toggle, Connect Speaker, Connect Mic
                                    //Big: Current Consumption, VU Meters, Connect to IoTBoxAudio, Connect to SIP
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2: //fail
                        Console.WriteLine("Failed");
                        lbl_status.Text = "Failed";
                        break;
                }
                

                groups.Add(grp);
                singles.Add(single);
            }
            

            Console.WriteLine("");
            lbl_status.Text = "Ready.";
        }
        
        private void groupClick(object sender, EventArgs e)
        {
            GroupBox grp = sender as GroupBox;
            Console.WriteLine(grp.Text);
        }

        private void tv_DeviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            shownGroups.Clear();
            //Console.WriteLine(e.Node.Tag);
            String tag = e.Node.Tag.ToString();
            if (tag.Equals("Devices"))
            {
                foreach (GroupBox gb in groups)
                {
                    shownGroups.Add(gb);
                    //Console.WriteLine("Added: " + gb.Tag.ToString());
                }
            }
            else if (tag.Equals("Online"))
            {
                //Console.WriteLine("Online::");
                foreach (GroupBox gb in groups)
                {
                    int i = gb.Tag.ToString().IndexOf(":");
                    if (gb.Tag.ToString().Substring(0, i).Equals("True"))
                    {
                        shownGroups.Add(gb);
                        //Console.WriteLine("Added: " + gb.Tag.ToString());
                    }
                }
            }
            else if (tag.Equals("Offline"))
            {
                //Console.WriteLine("Offline::");
                foreach (GroupBox gb in groups)
                {
                    int i = gb.Tag.ToString().IndexOf(":");
                    if (gb.Tag.ToString().Substring(0, i).Equals("False"))
                    {
                        shownGroups.Add(gb);
                    }
                }
            }
            else
            {
                //Console.WriteLine("Single");
                foreach (GroupBox s in singles)
                {
                    //Console.WriteLine(tag + " == " + s.Tag.ToString());
                    if (tag.Equals(s.Tag.ToString()))
                    {
                        shownGroups.Add(s);
                    }
                }
            }
            flowLayoutPanel1.Controls.Clear();
            foreach (GroupBox gb in shownGroups)
            {
                flowLayoutPanel1.Controls.Add(gb);
            }

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
