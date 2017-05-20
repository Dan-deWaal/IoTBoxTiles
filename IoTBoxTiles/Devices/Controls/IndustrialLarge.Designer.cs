namespace IoTBoxTiles.Devices.Controls
{
    partial class IndustrialLarge
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.plugTitleCtrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.currentTitle1 = new IoTBoxTiles.Devices.Controls.Parts.CurrentTitle();
            this.connectPart1 = new IoTBoxTiles.Devices.Controls.Parts.ConnectPart();
            this.PortLabel = new System.Windows.Forms.Label();
            this.SettingsLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // plugTitleCtrl
            // 
            this.plugTitleCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plugTitleCtrl.FriendlyName = "name";
            this.plugTitleCtrl.Location = new System.Drawing.Point(0, 2);
            this.plugTitleCtrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plugTitleCtrl.Name = "plugTitleCtrl";
            this.plugTitleCtrl.PowerChecked = false;
            this.plugTitleCtrl.Refreshing = false;
            this.plugTitleCtrl.Size = new System.Drawing.Size(480, 42);
            this.plugTitleCtrl.TabIndex = 0;
            this.plugTitleCtrl.PowerClicked += new System.EventHandler(this.plugTitleCtrl_PowerClicked);
            // 
            // currentTitle1
            // 
            this.currentTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.currentTitle1.Location = new System.Drawing.Point(344, 434);
            this.currentTitle1.Name = "currentTitle1";
            this.currentTitle1.Size = new System.Drawing.Size(133, 23);
            this.currentTitle1.TabIndex = 1;
            // 
            // connectPart1
            // 
            this.connectPart1.Client = null;
            this.connectPart1.ConnectChecked = false;
            this.connectPart1.Location = new System.Drawing.Point(2, 48);
            this.connectPart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectPart1.Name = "connectPart1";
            this.connectPart1.Size = new System.Drawing.Size(309, 64);
            this.connectPart1.TabIndex = 2;
            this.connectPart1.ConnectCheckedChanged += new System.EventHandler(this.connectPart1_ConnectCheckedChanged);
            this.connectPart1.DisconnectBtnClick += new System.EventHandler(this.connectPart1_DisconnectBtnClick);
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(3, 134);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(81, 17);
            this.PortLabel.TabIndex = 3;
            this.PortLabel.Text = "Port: COM3";
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.Location = new System.Drawing.Point(3, 151);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(149, 17);
            this.SettingsLabel.TabIndex = 3;
            this.SettingsLabel.Text = "Settings: 9600, 8, N, 1";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 171);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(471, 257);
            this.textBox1.TabIndex = 4;
            // 
            // IndustrialLarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SettingsLabel);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.connectPart1);
            this.Controls.Add(this.currentTitle1);
            this.Controls.Add(this.plugTitleCtrl);
            this.Name = "IndustrialLarge";
            this.Size = new System.Drawing.Size(480, 460);
            this.Load += new System.EventHandler(this.IndustrialLarge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Parts.PlugTitle plugTitleCtrl;
        private Parts.CurrentTitle currentTitle1;
        private Parts.ConnectPart connectPart1;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label SettingsLabel;
        private System.Windows.Forms.TextBox textBox1;
    }
}
