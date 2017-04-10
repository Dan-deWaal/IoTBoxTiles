﻿using System;
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

        }
    }
}
