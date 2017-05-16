﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTBoxTiles.Devices.Controls
{
    public partial class InfraredLarge : UserControl
    {
        private Infrared _device;
        private List<Label> _feedbackNames;
        private List<PictureBox> _feedbackImages;

        public InfraredLarge(Infrared ir_device)
        {
            InitializeComponent();
            _feedbackNames = new List<Label> { feedbackName1, feedbackName2, feedbackName3, feedbackName4 };
            _feedbackImages = new List<PictureBox> { feedbackBox1, feedbackBox2, feedbackBox3, feedbackBox4 };
            _device = ir_device;
        }

        public void UpdateUI()
        {
            //title & power
            plugTitleCtrl.FriendlyName = _device.friendly_name;
            plugTitleCtrl.PowerChecked = _device.plug_status;
            //feedback
            for (int i=0; i<4; i++)
            {
                _feedbackNames[i].Text = _device._feedback[i].Key;
                if (_device._feedback[i].Value)
                {
                    _feedbackImages[i].BackColor = Color.Blue;
                }
                else
                {
                    _feedbackImages[i].BackColor = Color.Red;
                }
            }
            //repeater toggle
            repeaterToggle.Checked = _device._repeater;
            //buttons

        }

        private void plugTitleCtrl_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void plugTitleCtrl_PowerCheckedChanged(object sender, EventArgs e)
        {
            // TODO: do stuff
            ((CheckBox)sender).Text = plugTitleCtrl.PowerChecked ? "POW" : "pow";
        }

        private void repeaterToggle_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
