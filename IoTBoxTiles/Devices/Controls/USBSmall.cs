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
    public partial class USBSmall : UserControl
    {
        private USB _device;

        public USBSmall(USB usb_device)
        {
            InitializeComponent();
            _device = usb_device;
        }

        public void UpdateUI()
        {
            // only enable controls if they're online
            foreach (Control control in Controls)
                control.Enabled = _device.online;

            // if device is online, update info
            if (_device.online)
            {
                //
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
