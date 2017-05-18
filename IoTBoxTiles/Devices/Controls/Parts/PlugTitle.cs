using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IoTBoxTiles.Properties;

namespace IoTBoxTiles.Devices.Controls.Parts
{
    public partial class PlugTitle : UserControl
    {
        private bool _refreshing = false;

        public PlugTitle()
        {
            InitializeComponent();
        }

        public bool Bold
        {
            set { nameLbl.Font = value ? new Font(nameLbl.Font, FontStyle.Bold) : new Font(nameLbl.Font, FontStyle.Regular); }
        }

        public bool Refreshing
        {
            get { return _refreshing; }
            set
            {
                _refreshing = value;
                if (_refreshing)
                    powerBox.Image = Resources.power_refresh_spinner;
                else
                    powerBox.Image = Resources.power_shadow;
            }
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

        public event EventHandler PowerClicked
        {
            add { powerBox.Click += value; }
            remove { powerBox.Click += value; }
        }

        private void PlugTitle_Resize(object sender, EventArgs e)
        {
            Height = 42;
            nameLbl.Left = 0;
            nameLbl.Top = 0;
            nameLbl.Height = Height;
            nameLbl.Width = Width;

            powerBox.Left = Width - 42;
            powerBox.Top = 0;
            powerBox.Height = 42;
            powerBox.Width = 42;
        }

        private void powerBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_refreshing)
                return;

            if (powerBox.Checked)
            {
                powerBox.FlatAppearance.MouseDownBackColor = Color.FromArgb(78, 115, 51);
                powerBox.FlatAppearance.MouseOverBackColor = Color.FromArgb(113, 164, 77);
            }
            else
            {
                powerBox.FlatAppearance.MouseDownBackColor = Color.FromArgb(139, 56, 11);
                powerBox.FlatAppearance.MouseOverBackColor = Color.FromArgb(182, 70, 26);
            }
        }

        private void powerBox_MouseEnter(object sender, EventArgs e)
        {
            if (!_refreshing)
                powerBox.Image = Resources.power_noshadow;
        }

        private void powerBox_MouseLeave(object sender, EventArgs e)
        {
            if (!_refreshing)
                powerBox.Image = Resources.power_shadow;
        }
    }
}
