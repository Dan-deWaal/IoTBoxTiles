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
    public partial class PlugTitle : UserControl
    {
        public PlugTitle()
        {
            InitializeComponent();
        }

        public string FriendlyName
        {
            get { return nameLbl.Text; }
            set { nameLbl.Text = value; }
        }

        public bool PowerChecked
        {
            get { return powerBox.Checked; }
            set { powerBox.Checked = value; }
        }

        public event EventHandler PowerCheckedChanged
        {
            add { powerBox.CheckedChanged += value; }
            remove { powerBox.CheckedChanged += value; }
        }

        private void PlugTitle_Resize(object sender, EventArgs e)
        {
            Height = 48;
            nameLbl.Left = 0;
            nameLbl.Top = 0;
            nameLbl.Height = Height;
            nameLbl.Width = Width - 48 - 3;

            powerBox.Left = Width - 48;
            powerBox.Top = 0;
            powerBox.Height = 48;
            powerBox.Width = 48;
        }
    }
}
