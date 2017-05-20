using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IoTBoxTiles.Devices.Controls.Parts
{
    public partial class CurrentTitle : UserControl
    {
        public CurrentTitle()
        {
            InitializeComponent();
        }

        public void setValue(float? val)
        {
            if (val == null)
            {
                val = 0;
            }
            currentLabel.Text = val.ToString();
        }
    }
}
