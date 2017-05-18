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
    public partial class MultiboardLarge : UserControl
    {
        private Multiboard _device;

        public MultiboardLarge(Multiboard board_device)
        {
            InitializeComponent();
            _device = board_device;
        }

        public void UpdateUI()
        {
        }
    }
}
