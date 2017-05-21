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
    public partial class InfraredSmall : UserControl
    {
        private Infrared _device;
        private List<Button> _smallButtons;

        public InfraredSmall(Infrared ir_device)
        {
            InitializeComponent();
            _smallButtons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            _device = ir_device;
        }

        public void UpdateUI()
        {
            plugTitleCtrl.FriendlyName = _device.friendly_name;
            plugTitleCtrl.PowerChecked = _device.plug_status;
            if (_device._repeater)
            {
                buttonLayout.Enabled = false;
            }
            else
            {
                buttonLayout.Enabled = true;
                for (int i = 0; i<9; i++)
                {
                    var butt_i = _device._buttons.FindIndex(button => button.id == i);
                    if (butt_i == -1)
                    {
                        _smallButtons[i].Enabled = false;
                        _smallButtons[i].Text = "";
                    } else
                    {
                        _smallButtons[i].Enabled = true;
                        _smallButtons[i].Text = _device._buttons[butt_i].name;
                        _smallButtons[i].Tag = _device._buttons[butt_i].id;
                        if (_device._buttons[butt_i].continuous)
                        {
                            _smallButtons[i].Click -= _device.irbuttonClick;
                            _smallButtons[i].MouseDown += _device.irbuttonDown;
                            _smallButtons[i].MouseUp += _device.irbuttonUp;
                        }
                        else
                        {
                            _smallButtons[i].Click += _device.irbuttonClick;
                            _smallButtons[i].MouseDown -= _device.irbuttonDown;
                            _smallButtons[i].MouseUp -= _device.irbuttonUp;
                        }
                    }
                }
            }
        }

        private void plugTitleCtrl_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void plugTitleCtrl_PowerClicked(object sender, EventArgs e)
        {
            _device.ChangePowerAsync(plugTitleCtrl);
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            var num = ((Button)sender).Tag;
            Console.WriteLine(num);
            //do something here.
        }
    }
}
