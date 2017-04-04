using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace IoTBoxTiles
{
    public partial class Form1 : Form
    {
        static HttpClient client = new HttpClient();
        static HttpResponseMessage heartbeatResponse, loginResponse;
        private static System.Timers.Timer heartbeatTimer;
        int c = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            heartbeatTimer.Enabled = false;
            lbl_ServerStatus.Text = "Logging in...";
            await GetLoginAsync(txt_username.Text, txt_passwd.Text);
            Console.WriteLine(await loginResponse.Content.ReadAsStringAsync());


            //on success:
            Form2 frm = new IoTBoxTiles.Form2();
            frm.Show();
            //this.Hide();
        }

        static async Task GetLoginAsync(string email, string pass)
        {
            client.DefaultRequestHeaders.Add("email", email);
            client.DefaultRequestHeaders.Add("password", pass);
            loginResponse = await client.GetAsync(@"https://iot.duality.co.nz/api/1/user/devices");
        }

        private void link_forgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void link_signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //add links
            link_forgot.Links.Add(0,15, "https://iot.duality.co.nz/password-reset");
            link_signup.Links.Add(0, 7, "https://iot.duality.co.nz/signup");

            //start timer
            heartbeatTimer = new System.Timers.Timer(1000);
            heartbeatTimer.Elapsed += HeartbeatTimer_Elapsed;
            heartbeatTimer.Enabled = true; //start timer

            //login stuff
            lbl_LoginStatus.Hide();
            btn_login.Enabled = false;
        }

        private void HeartbeatTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //throw new NotImplementedException();
            GetHeartbeatAsync();
            c++;
            try
            {
                if (heartbeatResponse.IsSuccessStatusCode)
                {
                    //Console.WriteLine(c + ": Connected");
                    lbl_ServerStatus.Text = "Connected";
                }
                else
                {
                    //Console.WriteLine(c + ": Server Failure");
                    lbl_ServerStatus.Text = "Server Failure";
                }
            }
            catch
            {
                //Console.WriteLine(c + ": Not Connected");
                lbl_ServerStatus.Text = "Not Connected";
            }
            
        }

        static async Task GetHeartbeatAsync()
        {
            heartbeatResponse = await client.GetAsync(@"https://iot.duality.co.nz/api/1/heartbeat");
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
