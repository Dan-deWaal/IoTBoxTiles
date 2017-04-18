using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTBoxTiles
{
    public partial class Form2 : Form
    {
        List<Device> devices = new List<Device>();
        List<GroupBox> groups = new List<GroupBox>();
        List<GroupBox> singles = new List<GroupBox>();
        List<GroupBox> shownGroups = new List<GroupBox>();

        //this should be obtained from the server
        String[] devtype = { "unknown", "SmartPlug", "Bluetooth", "USB", "Infrared", "Industrial", "Multiboard" };

        public Form2(List<Device> devs)
        {
            InitializeComponent();
            devices = devs;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Devices:");
            //tv_ == treeview_
            tv_DeviceList.BeginUpdate();
            tv_DeviceList.Nodes.Add("Devices");
            tv_DeviceList.Nodes[0].Tag = "Devices";
            tv_DeviceList.Nodes[0].Nodes.Add("Online");
            tv_DeviceList.Nodes[0].Nodes[0].Tag = "Online";
            tv_DeviceList.Nodes[0].Nodes.Add("Offline");
            tv_DeviceList.Nodes[0].Nodes[1].Tag = "Offline";
            foreach (var dev in devices)
            {
                Console.WriteLine(dev.friendly_name);
                Console.WriteLine(dev.device_id.ToString());
                if (dev.online)
                {
                    tv_DeviceList.Nodes[0].Nodes[0].Nodes.Add(dev.friendly_name);
                    tv_DeviceList.Nodes[0].Nodes[0].LastNode.Tag = dev.device_id.ToString();
                }
                else
                {
                    tv_DeviceList.Nodes[0].Nodes[1].Nodes.Add(dev.friendly_name);
                    tv_DeviceList.Nodes[0].Nodes[1].LastNode.Tag = dev.device_id.ToString();
                }

                GroupBox grp = new GroupBox();
                grp.Text = dev.friendly_name + "(" + devtype[dev.module_type] + ")";
                grp.Name = dev.friendly_name;
                grp.Width = 240;
                grp.Height = 140;
                grp.Click += new System.EventHandler(this.groupClick);
                grp.Tag = dev.online.ToString() + ":" + dev.device_id.ToString();

                GroupBox single = new GroupBox();
                single.Text = dev.friendly_name;
                single.Name = dev.friendly_name;
                //single.Dock = DockStyle.Fill;
                single.Width = 300;
                single.Height = 200;
                single.Tag = dev.device_id;

                switch (dev.module_type)
                {
                    case 0: //unknown
                        break;
                    case 1: //Smartplug only
                        //Small: Power Toggle
                        //Big: Current Consumption
                        break;
                    case 2: //Bluetooth
                        //Small: Power Toggle, Connect
                        //Big: Current Consumption
                        break;
                    case 3: //USB
                        //Small: Power Toggle, Connect
                        //Big: Current Consumption
                        break;
                    case 4: //Infrared
                        //Small: Power Toggle, Common buttons
                        //Big: Current Consumption, Repeater Toggle, Change Common buttons, All buttons
                        break;
                    case 5: //Industrial
                        //Small: Power Toggle, Connect, COM Port
                        //Big: Current Consumption, Serial Monitor, Monitor settings
                        break;
                    case 6: //Multiboard
                        //Small: Power Toggle, 4 x Power Toggle w/ names
                        //Big: Current Consumption, 5 x Current Consumption, Naming
                        break;
                    case 7: //Audio
                        //Small: Power Toggle, Connect Speaker, Connect Mic
                        //Big: Current Consumption, VU Meters, Connect to IoTBoxAudio, Connect to SIP
                        break;
                    default:
                        break;
                }

                groups.Add(grp);
                singles.Add(single);
            }
            tv_DeviceList.Nodes[0].ExpandAll();
            tv_DeviceList.EndUpdate();
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
                Console.WriteLine("Single");
                foreach (GroupBox s in singles)
                {
                    Console.WriteLine(tag + " == " + s.Tag.ToString());
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
