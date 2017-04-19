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
    public partial class Form1 : Form
    {
        static public List<Device> devices = null;

        private System.Windows.Forms.Timer timer;

        private ServerComm servercomm = new ServerComm();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //add links
            link_forgot.Links.Add(0, 15, "https://iot.duality.co.nz/password-reset");
            link_signup.Links.Add(0, 8, "https://iot.duality.co.nz/sign-up");

            //start timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += HeartbeatTimer;
            timer.Start();

            //login stuff
            lbl_LoginStatus.Hide();
            btn_login.Enabled = false;

            //enter key
            //txt_username.KeyDown += new KeyEventHandler(txt_Enter);
            //txt_username.PreviewKeyDown += txt_Enter;
        }

        /*void txt_Enter(object sender, KeyEventHandler e)
        {
            if (e. == Keys.Enter)
            {
                login();
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private async void login()
        {
            lbl_ServerStatus.Text = "Logging in...";
            Tuple<int, HttpResponseMessage> loginstat = await servercomm.GetAsync(servercomm.urlBuilder("login"), txt_username.Text, txt_passwd.Text);
            switch (loginstat.Item1)
            {
                case 0: //server not connected
                    Console.WriteLine("Server Problem");
                    break;
                case 1: //success
                    Console.WriteLine("Success");
                    var jsonString = await loginstat.Item2.Content.ReadAsStringAsync(); // should never throw excptn because caught in servercomm.LoginAsync()
                    devices = JsonConvert.DeserializeObject<List<Device>>(jsonString);

                    Form2 frm = new IoTBoxTiles.Form2(devices);
                    frm.Show();
                    this.Hide();
                    break;
                case 2: //fail
                    lbl_LoginStatus.Show();
                    Console.WriteLine("Not Success");
                    Err err = await loginstat.Item2.Content.ReadAsAsync<Err>(); // should never throw excptn because caught in servercomm.LoginAsync()
                    lbl_LoginStatus.Text = err.error;
                    break;
            }
        }
        
        private void link_forgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void link_signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }
        
        private async void HeartbeatTimer(object sender, EventArgs e)
        {
            Tuple<int, HttpResponseMessage> serverstat = await servercomm.GetAsync(servercomm.urlBuilder("heartbeat"));
            switch (serverstat.Item1)
            {
                case 0:
                    lbl_ServerStatus.Text = "Not Connected";
                    break;
                case 1:
                    lbl_ServerStatus.Text = "Connected";
                    break;
                case 2:
                    lbl_ServerStatus.Text = "Server Failure";
                    break;
            }
        }
        
        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            if (txt_username.Text.Length > 0 && txt_passwd.Text.Length > 0)
            {
                btn_login.Enabled = true;
            }
            else
            {
                btn_login.Enabled = false;
            }
        }

        // ************************************************************* remove ***
        private void pic_logo_Click(object sender, EventArgs e)                 //*
        {                                                                       //*      
            txt_username.Text = "hunter2@example.com";                          //*
            txt_passwd.Text = "12345678";                                       //*
        }                                                                       //*
        // ************************************************************************

        private void txt_passwd_TextChanged_1(object sender, EventArgs e)
        {
            if (txt_username.Text.Length > 0 && txt_passwd.Text.Length > 0)
            {
                btn_login.Enabled = true;
            }
            else
            {
                btn_login.Enabled = false;
            }
        }

        
    }
    
}
