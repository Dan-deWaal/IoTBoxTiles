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
    public partial class SmartPlugLarge : UserControl
    {
        private SmartPlug _device;

        public SmartPlugLarge(SmartPlug sm_device)
        {
            InitializeComponent();

            _device = sm_device;
        }

        public void UpdateUI()
        {
            plugTitleCtrl.FriendlyName = _device.friendly_name;
            plugTitleCtrl.PowerChecked = _device.plug_status;
        }

        private void plugTitleCtrl_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void plugTitleCtrl_PowerClicked(object sender, EventArgs e)
        {
            _device.ChangePowerAsync(plugTitleCtrl);
        }
    }
}
