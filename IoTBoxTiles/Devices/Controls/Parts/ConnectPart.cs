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
    public partial class ConnectPart : UserControl
    {
        string _client;
        public ConnectPart()
        {
            InitializeComponent();
        }

        private void ResizeComponents(bool client)
        {
            Height = 64;
            connectChkBox.Left = 0;
            connectChkBox.Top = 0;
            connectChkBox.Height = client ? 42 - 1 : 64;
            connectChkBox.Width = Width;
            connectChkBox.Enabled = !client;

            alreadyConnLbl.Left = 0;
            alreadyConnLbl.Top = 42 + 1;
            alreadyConnLbl.Height = 64 - 42 - 1;
            alreadyConnLbl.Width = Width - 72 - 1;
            alreadyConnLbl.Visible = client;

            disconnectBtn.Left = Width - 72;
            disconnectBtn.Top = 42 + 1;
            disconnectBtn.Height = 64 - 42 - 1;
            disconnectBtn.Width = 72;
            disconnectBtn.Visible = client;

            connectChkBox.ForeColor = Color.White;
        }

        public bool ConnectChecked
        {
            get { return connectChkBox.Checked; }
            set { connectChkBox.Checked = value; }
        }

        public string Client
        {
            get { return _client; }
            set
            {
                ResizeComponents(value != null);
                _client = value;
                if (_client != null)
                    alreadyConnLbl.Text = "connected to " + value;
            }
        }
        
        public event EventHandler ConnectCheckedChanged
        {
            add { connectChkBox.CheckedChanged += value; }
            remove { connectChkBox.CheckedChanged += value; }
        }

        public event EventHandler DisconnectBtnClick
        {
            add { disconnectBtn.Click += value; }
            remove { disconnectBtn.Click -= value; }
        }

        private void ConnectPart_Resize(object sender, EventArgs e)
        {
            ResizeComponents(_client != null);
        }

        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            connectChkBox.ForeColor = Color.White;
        }
    }
}
