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
    public partial class USBLarge : UserControl
    {
        private USB _device;

        public USBLarge(USB usb_device)
        {
            InitializeComponent();

            _device = usb_device;
        }

        public void UpdateUI()
        {
            plugTitleCtrl.FriendlyName = _device.friendly_name;
            plugTitleCtrl.PowerChecked = _device.plug_status;
            connectPart1.ConnectChecked = _device.connected;
            connectPart1.Client = _device.client_name;
            currentTitle1.CurrentVal = _device.current_consumption;
        }

        private void plugTitleCtrl_PowerClicked(object sender, EventArgs e)
        {
            _device.ChangePowerAsync(plugTitleCtrl);
        }

        private void connectPart1_ConnectCheckedChanged(object sender, EventArgs e)
        {
            _device.connectUSB();
            UpdateUI();
        }

        private void connectPart1_DisconnectBtnClick(object sender, EventArgs e)
        {
            _device.disconnectUSB();
            UpdateUI();
        }

        private void USBLarge_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
