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
        List<Device> devices;
        List<GroupBox> groups = new List<GroupBox>();
        String[] devtype = { "unknown", "SmartPlug", "Bluetooth", "USB", "Infrared", "Industrial", "Multiboard" };

        public Form2(List<Device> devs)
        {
            InitializeComponent();
            devices = devs;
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Devices:");
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
                //grp.Text = dev.friendly_name + "(" + devtype[dev.module_type] + ")";
                grp.Text = dev.friendly_name;
                grp.Name = dev.friendly_name;
                grp.Width = 240;
                grp.Height = 140;
                grp.Click += new System.EventHandler(this.groupClick);
                grp.Tag = dev.device_id;

                GroupBox single = new GroupBox();
                single.Text = dev.friendly_name;
                single.Name = dev.friendly_name;
                single.Dock = DockStyle.Fill;
                single.Tag = dev.device_id;

                switch (dev.module_type)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }

                groups.Add(grp);
                flowLayoutPanel1.Controls.Add(grp);
            }
            tv_DeviceList.Nodes[0].ExpandAll();
            tv_DeviceList.EndUpdate();
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
        
        private void groupClick(object sender, EventArgs e)
        {
            GroupBox grp = sender as GroupBox;
            Console.WriteLine(grp.Text);
        }

        private void tv_DeviceList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Console.WriteLine(e.Node.Tag);
        }
    }
}
