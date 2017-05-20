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
        private List<Label> _feedbackNames;
        private List<PictureBox> _feedbackImages;

        public InfraredLarge(Infrared ir_device)
        {
            InitializeComponent();
            _feedbackNames = new List<Label> { feedbackName1, feedbackName2, feedbackName3, feedbackName4 };
            _feedbackImages = new List<PictureBox> { feedbackBox1, feedbackBox2, feedbackBox3, feedbackBox4 };
            _device = ir_device;
        }

        public void UpdateUI()
        {
            //title & power
            plugTitleCtrl.FriendlyName = _device.friendly_name;
            plugTitleCtrl.PowerChecked = _device.plug_status;
            //current
            currentTitle1.setValue(_device.current_consumption);
            //feedback
            for (int i=0; i<4; i++)
            {
                _feedbackNames[i].Text = _device._feedback[i].Key;
                if (_device._feedback[i].Value)
                {
                    _feedbackImages[i].BackColor = Color.Blue;
                }
                else
                {
                    _feedbackImages[i].BackColor = Color.Red;
                }
            }
            //repeater toggle
            repeaterToggle.Checked = _device._repeater;
            //buttons
            buttonsFlowLayout.Controls.Clear();
            foreach(Infrared.IRButton butt in _device._buttons)
            {
                var x = new Button() { Name = "irbutton"+butt.id.ToString(), Text = butt.name, Tag = butt.id };
                x.Click += new EventHandler(IRButton_click);
                buttonsFlowLayout.Controls.Add(x);
            }
        }

        private void IRButton_click(object sender, EventArgs e)
        {
            Console.WriteLine(((Button)sender).Tag);
        }

        private void plugTitleCtrl_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void plugTitleCtrl_PowerClicked(object sender, EventArgs e)
        {
            _device.ChangePowerAsync(plugTitleCtrl);
        }

        private void repeaterToggle_CheckedChanged(object sender, EventArgs e)
        {
            _device._repeater = repeaterToggle.Checked;
            if (repeaterToggle.Checked)
            {
                repeaterToggle.Text = "Rptr On";
            } else
            {
                repeaterToggle.Text = "Rptr Off";
            }
            
        }
    }
}
