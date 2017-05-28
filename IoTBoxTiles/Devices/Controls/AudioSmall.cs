using System;
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
            plugTitleCtrl.FriendlyName = _device.friendly_name;
            plugTitleCtrl.PowerChecked = _device.plug_status;
            connectPart1.ConnectChecked = _device.connected;
            // only enable controls if they're online
            foreach (Control control in Controls)
                control.Enabled = _device.online;
            
            // if device is online, update info
            if (_device.online && _device.connected)
            {
                sendChkBox.Enabled = _device._willRecv;
                sendChkBox.Checked = _device._willRecv && sendChkBox.Checked;
                speakerScrollBar.Enabled = false;
                speakerScrollBar.Value = _device.connected ? _device.speaker_VU : 0;

                receiveChkBox.Enabled = _device._willSend;
                receiveChkBox.Checked = _device._willSend && receiveChkBox.Checked;
                micScrollBar.Enabled = false;
                micScrollBar.Value = _device.connected ? _device.mic_VU : 0;
            }
            else
            {
                sendChkBox.Enabled = sendChkBox.Checked = false;
                receiveChkBox.Enabled = receiveChkBox.Checked = false;
                speakerScrollBar.Enabled = micScrollBar.Enabled = false;
            }
        }

        private void AudioSmall_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void connectPart1_ConnectCheckedChanged(object sender, EventArgs e)
        {
            _device.connectAudio();
            UpdateUI();
        }

        private void connectPart1_DisconnectBtnClick(object sender, EventArgs e)
        {
            _device.disconnectAudio();
            UpdateUI();
        }

        private void plugTitleCtrl_PowerClicked(object sender, EventArgs e)
        {
            _device.ChangePowerAsync(plugTitleCtrl);
        }

        private void audioCheckedChanged(object sender, EventArgs e)
        {
            _device.UpdateAudioConnectionsAsync(sendChkBox, receiveChkBox);
        }
    }
}
