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
    public partial class AudioLarge : UserControl
    {
        private Audio _device;

        public AudioLarge(Audio audio_device)
        {
            InitializeComponent();

            _device = audio_device;
        }

        public void UpdateUI()
        {
            plugTitleCtrl.FriendlyName = _device.friendly_name;
            plugTitleCtrl.PowerChecked = _device.plug_status;
            //connectPart1.ConnectChecked = _device.connected;
        }

        private void AudioLarge_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
