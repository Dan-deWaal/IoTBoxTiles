using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace IoTBoxTiles
{
    public partial class LoginForm : Form
    {
        private System.Windows.Forms.Timer _timer;
        private ServerComm _serverComm = ServerComm.Instance;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //add links
            link_forgot.Links.Add(0, 15, "https://iot.duality.co.nz/password-reset");
            link_signup.Links.Add(0, 8, "https://iot.duality.co.nz/sign-up");

            //start timer
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 5000;
            _timer.Tick += HeartbeatTimer;
            _timer.Start();
            HeartbeatTimer(null, null);
            
            //login stuff
            lbl_LoginStatus.Hide();
            btn_login.Enabled = false;
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private async void login()
        {
            btn_login.Enabled = false;
            lbl_ServerStatus.Text = "Logging in...";
            _serverComm.Email = txt_username.Text;
            _serverComm.Password = txt_passwd.Text;
            var loginstat = await _serverComm.GetAsync(_serverComm.Root + "/user/devices/list");
            switch (loginstat.Item1)
            {
                case ServerResponse.NotConnected: //server not connected
                    Console.WriteLine("Server Problem");
                    break;
                case ServerResponse.Connected: //success
                    Console.WriteLine("Success");
                    var jsonString = await loginstat.Item2.Content.ReadAsStringAsync(); // should never throw excptn because caught in servercomm.LoginAsync()
                    List<DeviceBase> devices = JsonConvert.DeserializeObject<List<DeviceBase>>(jsonString);
                    
                    DevicesForm frm = new DevicesForm(devices);
                    _timer.Stop();
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                    break;
                case ServerResponse.ServerFailure: //fail
                    lbl_LoginStatus.Show();
                    Console.WriteLine("Not Success");
                    Err err = await loginstat.Item2.Content.ReadAsAsync<Err>(); // should never throw excptn because caught in servercomm.LoginAsync()
                    lbl_LoginStatus.Text = err.error;
                    break;
            }
            btn_login.Enabled = true;
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private async void HeartbeatTimer(object sender, EventArgs e)
        {
            var serverstat = await _serverComm.GetAsync(_serverComm.Root + "/heartbeat", false);
            switch (serverstat.Item1)
            {
                case ServerResponse.NotConnected:
                    lbl_ServerStatus.Text = "Not Connected";
                    break;
                case ServerResponse.Connected:
                    lbl_ServerStatus.Text = "Connected";
                    break;
                case ServerResponse.ServerFailure:
                    lbl_ServerStatus.Text = "Server Failure";
                    break;
            }
        }

        private void login_text_changed(object sender, EventArgs e)
        {
            btn_login.Enabled = txt_username.Text.Length > 0 && txt_passwd.Text.Length > 0;
        }

        // ************************************************************* remove ***
        private void pic_logo_Click(object sender, EventArgs e)                 //*
        {                                                                       //*      
            txt_username.Text = "hunter2@example.com";                          //*
            txt_passwd.Text = "12345678";                                       //*
        }                                                                       //*
        // ************************************************************************
    }
}
