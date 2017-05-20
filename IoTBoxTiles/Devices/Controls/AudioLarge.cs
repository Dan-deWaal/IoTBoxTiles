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
            connectPartCtrl.ConnectChecked = _device.connected;
            currentTitle1.setValue(_device.current_consumption);
        }

        private void AudioLarge_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void plugTitleCtrl_PowerClicked(object sender, EventArgs e)
        {
            _device.ChangePowerAsync(plugTitleCtrl);
        }

        private void connectPartCtrl_ConnectCheckedChanged(object sender, EventArgs e)
        {
            // TODO: replace with working code
            connectPartCtrl.Client = "test";
        }

        private void connectPartCtrl_DisconnectBtnClick(object sender, EventArgs e)
        {
            // TODO: replace with working code
            connectPartCtrl.Client = null;
        }
    }
}
