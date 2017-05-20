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

        public float? CurrentVal
        {
            set
            {
                if (value == null)
                {
                    currentLabel.Text = "0";
                }
                else currentLabel.Text = value.ToString();

            }
        }

        public Font CurrentFont
        {
            get
            {
                return currentLabel.Font;
            }
            set
            {
                currentLabel.Font = value;
                mALabel.Font = value;
            }
        }
    }
}
