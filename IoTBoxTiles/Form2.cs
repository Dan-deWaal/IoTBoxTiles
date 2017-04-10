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
        String[] devname = { "SmartPlug", "Bluetooth", "USB", "Infrared", "RS232", "Multiboard" };

        public Form2(List<Device> devs)
        {
            InitializeComponent();
            devices = devs;
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Devices:");
            foreach (var dev in devices)
            {
                Console.WriteLine(dev.friendly_name);
                ListViewItem lvi = new ListViewItem(dev.friendly_name);
                if (dev.module_type >= 0 && dev.module_type < devname.Length)
                {
                    lvi.SubItems.Add(devname[dev.module_type]);
                }
                else
                {
                    lvi.SubItems.Add("unknown");
                }
                //Fix to Icons
                lvi.SubItems.Add(dev.online.ToString());
                lvi.SubItems.Add(dev.connected.ToString());
                lv_deviceList.Items.Add(lvi);

                GroupBox grp = new GroupBox();
                grp.Text = dev.friendly_name;
                grp.Name = dev.friendly_name;
                grp.Click += new System.EventHandler(this.groupClick);
                groups.Add(grp);
                flowLayoutPanel1.Controls.Add(grp);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //flowLayoutPanel1.Container.Add(new GroupBox());
        }

        private void groupClick(object sender, EventArgs e)
        {
            GroupBox grp = sender as GroupBox;
            Console.WriteLine(grp.Text);
        }
    }
}
