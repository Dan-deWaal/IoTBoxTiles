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
    public partial class AudioSmall : UserControl
    {
        private Audio _device;

        public AudioSmall(Audio audio_device)
        {
            InitializeComponent();

            _device = audio_device;
        }
        
        public void UpdateUI()
        {
            // only enable controls if they're online
            foreach (Control control in Controls)
                control.Enabled = _device.online;
            
            // if device is online, update info
            if (_device.online)
            {
                speakerChkBox.Enabled = _device.connected;
                speakerChkBox.Checked = _device.connected && _device.speaker_status;
                speakerScrollBar.Enabled = false;
                speakerScrollBar.Value = _device.connected ? _device.speaker_VU : 0;

                micChkBox.Enabled = _device.connected;
                micChkBox.Checked = _device.connected && _device.mic_status;
                micScrollBar.Enabled = false;
                micScrollBar.Value = _device.connected ? _device.mic_VU : 0;
            }
        }

        private void AudioSmall_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void plugTitleCtrl_PowerCheckedChanged(object sender, EventArgs e)
        {
            // TODO: do stuff
            ((CheckBox)sender).Text = plugTitleCtrl.PowerChecked ? "POW" : "pow";
        }

        private void connectPart1_ConnectCheckedChanged(object sender, EventArgs e)
        {
            // TODO: replace with working code
            connectPart1.Client = "test";
        }

        private void connectPart1_DisconnectBtnClick(object sender, EventArgs e)
        {
            // TODO: replace with working code
            connectPart1.Client = null;
        }
    }
}
