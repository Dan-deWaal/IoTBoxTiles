﻿using System;
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
            _timer.Interval = 1000;
            _timer.Tick += HeartbeatTimer;
            _timer.Start();

            //login stuff
            lbl_LoginStatus.Hide();
            btn_login.Enabled = false;

            //enter key
            //txt_username.KeyDown += new KeyEventHandler(txt_Enter);
            //txt_username.PreviewKeyDown += txt_Enter;
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private async void login()
        {
            lbl_ServerStatus.Text = "Logging in...";
            _serverComm.Email = txt_username.Text;
            _serverComm.Password = txt_passwd.Text;
            Tuple<int, HttpResponseMessage> loginstat = await _serverComm.GetAsync(_serverComm.Login);
            switch (loginstat.Item1)
            {
                case 0: //server not connected
                    Console.WriteLine("Server Problem");
                    break;
                case 1: //success
                    Console.WriteLine("Success");
                    var jsonString = await loginstat.Item2.Content.ReadAsStringAsync(); // should never throw excptn because caught in servercomm.LoginAsync()
                    List<DeviceBase> devices = JsonConvert.DeserializeObject<List<DeviceBase>>(jsonString);
                    
                    DevicesForm frm = new IoTBoxTiles.DevicesForm(devices, txt_username.Text, txt_passwd.Text);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                    break;
                case 2: //fail
                    lbl_LoginStatus.Show();
                    Console.WriteLine("Not Success");
                    Err err = await loginstat.Item2.Content.ReadAsAsync<Err>(); // should never throw excptn because caught in servercomm.LoginAsync()
                    lbl_LoginStatus.Text = err.error;
                    break;
            }
        }
        
        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private async void HeartbeatTimer(object sender, EventArgs e)
        {
            Tuple<int, HttpResponseMessage> serverstat = await _serverComm.GetAsync(_serverComm.Heartbeat, false);
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
