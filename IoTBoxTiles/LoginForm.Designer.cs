namespace IoTBoxTiles
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.loginTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_LoginStatus = new System.Windows.Forms.Label();
            this.link_signup = new System.Windows.Forms.LinkLabel();
            this.link_forgot = new System.Windows.Forms.LinkLabel();
            this.lbl_passwd = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.txt_passwd = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.pic_logo = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_ServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.loginTablePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginTablePanel
            // 
            this.loginTablePanel.ColumnCount = 3;
            this.loginTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.loginTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 640F));
            this.loginTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.loginTablePanel.Controls.Add(this.panel1, 1, 1);
            this.loginTablePanel.Controls.Add(this.pic_logo, 0, 0);
            this.loginTablePanel.Controls.Add(this.statusStrip1, 0, 2);
            this.loginTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginTablePanel.Location = new System.Drawing.Point(0, 0);
            this.loginTablePanel.Margin = new System.Windows.Forms.Padding(8);
            this.loginTablePanel.Name = "loginTablePanel";
            this.loginTablePanel.RowCount = 3;
            this.loginTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.loginTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.loginTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.loginTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.loginTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.loginTablePanel.Size = new System.Drawing.Size(2102, 1037);
            this.loginTablePanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_LoginStatus);
            this.panel1.Controls.Add(this.link_signup);
            this.panel1.Controls.Add(this.link_forgot);
            this.panel1.Controls.Add(this.lbl_passwd);
            this.panel1.Controls.Add(this.lbl_username);
            this.panel1.Controls.Add(this.txt_passwd);
            this.panel1.Controls.Add(this.txt_username);
            this.panel1.Controls.Add(this.btn_login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(739, 350);
            this.panel1.Margin = new System.Windows.Forms.Padding(8);
            this.panel1.MinimumSize = new System.Drawing.Size(624, 337);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 337);
            this.panel1.TabIndex = 0;
            // 
            // lbl_LoginStatus
            // 
            this.lbl_LoginStatus.AutoSize = true;
            this.lbl_LoginStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbl_LoginStatus.Location = new System.Drawing.Point(162, 16);
            this.lbl_LoginStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_LoginStatus.Name = "lbl_LoginStatus";
            this.lbl_LoginStatus.Size = new System.Drawing.Size(160, 32);
            this.lbl_LoginStatus.TabIndex = 6;
            this.lbl_LoginStatus.Text = "login status";
            // 
            // link_signup
            // 
            this.link_signup.AutoSize = true;
            this.link_signup.Location = new System.Drawing.Point(326, 250);
            this.link_signup.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.link_signup.Name = "link_signup";
            this.link_signup.Size = new System.Drawing.Size(112, 32);
            this.link_signup.TabIndex = 5;
            this.link_signup.TabStop = true;
            this.link_signup.Text = "Sign up";
            this.link_signup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // link_forgot
            // 
            this.link_forgot.AutoSize = true;
            this.link_forgot.Location = new System.Drawing.Point(262, 293);
            this.link_forgot.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.link_forgot.Name = "link_forgot";
            this.link_forgot.Size = new System.Drawing.Size(225, 32);
            this.link_forgot.TabIndex = 4;
            this.link_forgot.TabStop = true;
            this.link_forgot.Text = "Forgot password";
            this.link_forgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // lbl_passwd
            // 
            this.lbl_passwd.AutoSize = true;
            this.lbl_passwd.Location = new System.Drawing.Point(8, 132);
            this.lbl_passwd.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbl_passwd.Name = "lbl_passwd";
            this.lbl_passwd.Size = new System.Drawing.Size(147, 32);
            this.lbl_passwd.TabIndex = 4;
            this.lbl_passwd.Text = "Password:";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(60, 74);
            this.lbl_username.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(95, 32);
            this.lbl_username.TabIndex = 4;
            this.lbl_username.Text = "Email:";
            // 
            // txt_passwd
            // 
            this.txt_passwd.Location = new System.Drawing.Point(168, 126);
            this.txt_passwd.Margin = new System.Windows.Forms.Padding(8);
            this.txt_passwd.Name = "txt_passwd";
            this.txt_passwd.Size = new System.Drawing.Size(442, 38);
            this.txt_passwd.TabIndex = 2;
            this.txt_passwd.UseSystemPasswordChar = true;
            this.txt_passwd.TextChanged += new System.EventHandler(this.login_text_changed);
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(168, 64);
            this.txt_username.Margin = new System.Windows.Forms.Padding(8);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(442, 38);
            this.txt_username.TabIndex = 1;
            this.txt_username.TextChanged += new System.EventHandler(this.login_text_changed);
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(244, 188);
            this.btn_login.Margin = new System.Windows.Forms.Padding(8);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(266, 54);
            this.btn_login.TabIndex = 3;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pic_logo
            // 
            this.pic_logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_logo.BackgroundImage")));
            this.pic_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loginTablePanel.SetColumnSpan(this.pic_logo, 3);
            this.pic_logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_logo.Location = new System.Drawing.Point(6, 6);
            this.pic_logo.Margin = new System.Windows.Forms.Padding(6);
            this.pic_logo.Name = "pic_logo";
            this.pic_logo.Size = new System.Drawing.Size(2090, 330);
            this.pic_logo.TabIndex = 1;
            this.pic_logo.TabStop = false;
            this.pic_logo.Click += new System.EventHandler(this.pic_logo_Click);
            // 
            // statusStrip1
            // 
            this.loginTablePanel.SetColumnSpan(this.statusStrip1, 3);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbl_ServerStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 991);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(2102, 46);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(195, 41);
            this.toolStripStatusLabel1.Text = "Server Status:";
            // 
            // lbl_ServerStatus
            // 
            this.lbl_ServerStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_ServerStatus.Name = "lbl_ServerStatus";
            this.lbl_ServerStatus.Size = new System.Drawing.Size(221, 41);
            this.lbl_ServerStatus.Text = "Not Connected";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(2102, 1037);
            this.Controls.Add(this.loginTablePanel);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.MinimumSize = new System.Drawing.Size(1556, 849);
            this.Name = "LoginForm";
            this.Text = "IoTTiles";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.loginTablePanel.ResumeLayout(false);
            this.loginTablePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_logo)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel loginTablePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_passwd;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_passwd;
        private System.Windows.Forms.LinkLabel link_forgot;
        private System.Windows.Forms.PictureBox pic_logo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.LinkLabel link_signup;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_ServerStatus;
        private System.Windows.Forms.Label lbl_LoginStatus;
    }
}

