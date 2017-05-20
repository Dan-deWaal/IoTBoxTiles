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
    public partial class IndustrialSmall : UserControl
    {
        private Industrial _device;

        public IndustrialSmall(Industrial ind_device)
        {
            InitializeComponent();
            _device = ind_device;
        }

        public void UpdateUI()
        {
            plugTitleCtrl.FriendlyName = _device.friendly_name;
            plugTitleCtrl.PowerChecked = _device.plug_status;
        }
        
        private void plugTitleCtrl_PowerClicked(object sender, EventArgs e)
        {
            _device.ChangePowerAsync(plugTitleCtrl);
        }

        private void IndustrialSmall_Load(object sender, EventArgs e)
        {
            UpdateUI();
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
