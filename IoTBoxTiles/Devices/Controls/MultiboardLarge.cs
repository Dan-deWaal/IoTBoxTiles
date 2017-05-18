using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IoTBoxTiles.Devices.Controls.Parts;

namespace IoTBoxTiles.Devices.Controls
{
    public partial class MultiboardLarge : UserControl
    {
        private Multiboard _device;
        private List<PlugTitle> plugCtrls;
        private List<Label> currentLabels;

        public MultiboardLarge(Multiboard board_device)
        {
            InitializeComponent();
            _device = board_device;
            plugCtrls = new List<PlugTitle> { plug1Ctrl, plug2Ctrl, plug3Ctrl, plug4Ctrl };
            currentLabels = new List<Label> { currentLabel1, currentLabel2, currentLabel3, currentLabel4 };
        }

        public void UpdateUI()
        {
            plugTitleCtrl.FriendlyName = _device.friendly_name;
            plugTitleCtrl.PowerChecked = _device.plug_status;
            for (int i = 0; i < 4; i++)
            {
                plugCtrls[i].FriendlyName = _device._boards[i].Key;
                plugCtrls[i].PowerChecked = _device._boards[i].Value;
                plugCtrls[i].Bold = false;
                currentLabels[i].Text = _device.current_consumption.ToString() + " mA";
            }
        }

        private void MultiboardLarge_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void plugTitleCtrl_PowerClicked(object sender, EventArgs e)
        {
            _device.ChangePowerAsync(plugTitleCtrl);
        }
    }
}
