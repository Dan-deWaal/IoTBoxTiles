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
        private bool _enabled = true;

        public AudioSmall(Audio audio_device)
        {
            InitializeComponent();

            _device = audio_device;
        }

        public void UpdateUI(int width, int height)
        {
            this.Width = width - 5;
            this.Height = height - 5;
            UpdateUI();
        }

        public void UpdateUI()
        {
            // only enable controls if they're online
            foreach (Control control in Controls)
                control.Enabled = _device.online;
            _enabled = _device.online;
            
            // if device is online, update info
            if (_enabled)
            {
                friendlyNameLbl.Text = _device.friendly_name;
                powerChkBox.Checked = _device.plug_status;

                connectChkBox.Checked = _device.connected;
                // if not connected but has client id, another
                // client is currently connected
                if (_device.connected && _device.client_id != null)
                {
                    connectChkBox.Enabled = false;
                    // TODO: get client details from server
                    alreadyConnLbl.Text = String.Format(
                        "{} is connected", _device.client_id);
                    alreadyConnLbl.Visible = true;
                    disconnectBtn.Visible = true;

                }

                speakerChkBox.Enabled = _device.connected;
                speakerChkBox.Checked = _device.connected && _device.speaker_status;
                speakerScrollBar.Value = _device.connected ? _device.speaker_VU : 0;

                micChkBox.Enabled = _device.connected;
                micChkBox.Checked = _device.connected && _device.mic_status;
                micScrollBar.Value = _device.connected ? _device.mic_VU : 0;
            }
        }

        private void powerChkBox_CheckedChanged(object sender, EventArgs e)
        {
            // do stuff
            powerChkBox.Text = powerChkBox.Checked ? "POW" : "pow";
        }

        private void AudioSmall_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
