namespace IoTBoxTiles.Devices.Controls
{
    partial class AudioSmall
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
            this.sendChkBox = new System.Windows.Forms.CheckBox();
            this.receiveChkBox = new System.Windows.Forms.CheckBox();
            this.speakerScrollBar = new System.Windows.Forms.VScrollBar();
            this.micScrollBar = new System.Windows.Forms.VScrollBar();
            this.connectPart1 = new IoTBoxTiles.Devices.Controls.Parts.ConnectPart();
            this.plugTitleCtrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.SuspendLayout();
            // 
            // sendChkBox
            // 
            this.sendChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sendChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.sendChkBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(99)))), ((int)(((byte)(117)))));
            this.sendChkBox.Enabled = false;
            this.sendChkBox.FlatAppearance.BorderSize = 0;
            this.sendChkBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sendChkBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendChkBox.ForeColor = System.Drawing.Color.White;
            this.sendChkBox.Location = new System.Drawing.Point(22, 150);
            this.sendChkBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sendChkBox.Name = "sendChkBox";
            this.sendChkBox.Size = new System.Drawing.Size(103, 85);
            this.sendChkBox.TabIndex = 2;
            this.sendChkBox.Text = "Connect Device Speaker";
            this.sendChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sendChkBox.UseVisualStyleBackColor = false;
            this.sendChkBox.CheckedChanged += new System.EventHandler(this.audioCheckedChanged);
            // 
            // receiveChkBox
            // 
            this.receiveChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiveChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.receiveChkBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(99)))), ((int)(((byte)(117)))));
            this.receiveChkBox.Enabled = false;
            this.receiveChkBox.FlatAppearance.BorderSize = 0;
            this.receiveChkBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.receiveChkBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.receiveChkBox.ForeColor = System.Drawing.Color.White;
            this.receiveChkBox.Location = new System.Drawing.Point(170, 150);
            this.receiveChkBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.receiveChkBox.Name = "receiveChkBox";
            this.receiveChkBox.Size = new System.Drawing.Size(103, 85);
            this.receiveChkBox.TabIndex = 2;
            this.receiveChkBox.Text = "Connect PC Speaker";
            this.receiveChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.receiveChkBox.UseVisualStyleBackColor = false;
            this.receiveChkBox.CheckedChanged += new System.EventHandler(this.audioCheckedChanged);
            // 
            // speakerScrollBar
            // 
            this.speakerScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.speakerScrollBar.Enabled = false;
            this.speakerScrollBar.Location = new System.Drawing.Point(127, 150);
            this.speakerScrollBar.Name = "speakerScrollBar";
            this.speakerScrollBar.Size = new System.Drawing.Size(43, 85);
            this.speakerScrollBar.TabIndex = 4;
            // 
            // micScrollBar
            // 
            this.micScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.micScrollBar.Enabled = false;
            this.micScrollBar.Location = new System.Drawing.Point(275, 150);
            this.micScrollBar.Name = "micScrollBar";
            this.micScrollBar.Size = new System.Drawing.Size(43, 85);
            this.micScrollBar.TabIndex = 4;
            // 
            // connectPart1
            // 
            this.connectPart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectPart1.Client = null;
            this.connectPart1.ConnectChecked = false;
            this.connectPart1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.connectPart1.Location = new System.Drawing.Point(0, 56);
            this.connectPart1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.connectPart1.Name = "connectPart1";
            this.connectPart1.Size = new System.Drawing.Size(320, 64);
            this.connectPart1.TabIndex = 6;
            this.connectPart1.ConnectCheckedChanged += new System.EventHandler(this.connectPart1_ConnectCheckedChanged);
            this.connectPart1.DisconnectBtnClick += new System.EventHandler(this.connectPart1_DisconnectBtnClick);
            // 
            // plugTitleCtrl
            // 
            this.plugTitleCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.plugTitleCtrl.FriendlyName = "{audio_name}";
            this.plugTitleCtrl.Location = new System.Drawing.Point(0, 5);
            this.plugTitleCtrl.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.plugTitleCtrl.Name = "plugTitleCtrl";
            this.plugTitleCtrl.PowerChecked = false;
            this.plugTitleCtrl.Refreshing = false;
            this.plugTitleCtrl.Size = new System.Drawing.Size(320, 42);
            this.plugTitleCtrl.TabIndex = 5;
            this.plugTitleCtrl.PowerClicked += new System.EventHandler(this.plugTitleCtrl_PowerClicked);
            // 
            // AudioSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connectPart1);
            this.Controls.Add(this.plugTitleCtrl);
            this.Controls.Add(this.micScrollBar);
            this.Controls.Add(this.speakerScrollBar);
            this.Controls.Add(this.receiveChkBox);
            this.Controls.Add(this.sendChkBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AudioSmall";
            this.Size = new System.Drawing.Size(320, 248);
            this.Load += new System.EventHandler(this.AudioSmall_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox sendChkBox;
        private System.Windows.Forms.CheckBox receiveChkBox;
        private System.Windows.Forms.VScrollBar speakerScrollBar;
        private System.Windows.Forms.VScrollBar micScrollBar;
        private Parts.PlugTitle plugTitleCtrl;
        private Parts.ConnectPart connectPart1;
    }
}
