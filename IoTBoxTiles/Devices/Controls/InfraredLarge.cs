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
    public partial class InfraredLarge : UserControl
    {
        private Infrared _device;

        public InfraredLarge(Infrared ir_device)
        {
            InitializeComponent();
            _device = ir_device;
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

        private void plugTitleCtrl_PowerCheckedChanged(object sender, EventArgs e)
        {
            // TODO: do stuff
            ((CheckBox)sender).Text = plugTitleCtrl.PowerChecked ? "POW" : "pow";
        }
    }
}
