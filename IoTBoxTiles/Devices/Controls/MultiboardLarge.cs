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
            currentTitle1.CurrentVal = _device.current_consumption;
            for (int i = 0; i < 4; i++)
            {
                plugCtrls[i].FriendlyName = _device._boards[i].Key;
                plugCtrls[i].PowerChecked = _device._boards[i].Value;
                plugCtrls[i].Bold = false;
                if (_device.current_consumption == null)
                {
                    currentLabels[i].Text = "0 mA";
                } else
                {
                    currentLabels[i].Text = _device.current_consumption.ToString() + " mA";
                }
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

        private void plug1Ctrl_PowerClicked(object sender, EventArgs e)
        {
            _device._boards[0] = new KeyValuePair<string, bool>(_device._boards[0].Key, plug1Ctrl.PowerChecked);
            //var newEntry = new KeyValuePair<Tkey, Tvalue>(oldEntry.Key, newValue);
        }

        private void plug2Ctrl_PowerClicked(object sender, EventArgs e)
        {
            _device._boards[1] = new KeyValuePair<string, bool>(_device._boards[1].Key, plug2Ctrl.PowerChecked);
        }

        private void plug3Ctrl_PowerClicked(object sender, EventArgs e)
        {
            _device._boards[2] = new KeyValuePair<string, bool>(_device._boards[2].Key, plug3Ctrl.PowerChecked);
        }

        private void plug4Ctrl_PowerClicked(object sender, EventArgs e)
        {
            _device._boards[3] = new KeyValuePair<string, bool>(_device._boards[3].Key, plug4Ctrl.PowerChecked);
        }

        private void MultiboardLarge_Load_1(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
