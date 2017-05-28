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
            this.speakerChkBox = new System.Windows.Forms.CheckBox();
            this.micChkBox = new System.Windows.Forms.CheckBox();
            this.speakerScrollBar = new System.Windows.Forms.VScrollBar();
            this.micScrollBar = new System.Windows.Forms.VScrollBar();
            this.connectPart1 = new IoTBoxTiles.Devices.Controls.Parts.ConnectPart();
            this.plugTitleCtrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.SuspendLayout();
            // 
            // speakerChkBox
            // 
            this.speakerChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.speakerChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.speakerChkBox.Enabled = false;
            this.speakerChkBox.FlatAppearance.BorderSize = 0;
            this.speakerChkBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(124)))), ((int)(((byte)(141)))));
            this.speakerChkBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speakerChkBox.Location = new System.Drawing.Point(22, 150);
            this.speakerChkBox.Margin = new System.Windows.Forms.Padding(2);
            this.speakerChkBox.Name = "speakerChkBox";
            this.speakerChkBox.Size = new System.Drawing.Size(103, 85);
            this.speakerChkBox.TabIndex = 2;
            this.speakerChkBox.Text = "Connect Device Speaker";
            this.speakerChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.speakerChkBox.UseVisualStyleBackColor = true;
            this.speakerChkBox.CheckedChanged += new System.EventHandler(this.speakerChkBox_Click);
            // 
            // micChkBox
            // 
            this.micChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.micChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.micChkBox.Enabled = false;
            this.micChkBox.FlatAppearance.BorderSize = 0;
            this.micChkBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(124)))), ((int)(((byte)(141)))));
            this.micChkBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.micChkBox.Location = new System.Drawing.Point(170, 150);
            this.micChkBox.Margin = new System.Windows.Forms.Padding(2);
            this.micChkBox.Name = "micChkBox";
            this.micChkBox.Size = new System.Drawing.Size(103, 85);
            this.micChkBox.TabIndex = 2;
            this.micChkBox.Text = "Connect PC Speaker";
            this.micChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.micChkBox.UseVisualStyleBackColor = true;
            this.micChkBox.CheckedChanged += new System.EventHandler(this.micChkBox_CheckedChanged);
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
            this.connectPart1.Location = new System.Drawing.Point(0, 56);
            this.connectPart1.Margin = new System.Windows.Forms.Padding(1);
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
            this.plugTitleCtrl.Margin = new System.Windows.Forms.Padding(1);
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
            this.Controls.Add(this.micChkBox);
            this.Controls.Add(this.speakerChkBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AudioSmall";
            this.Size = new System.Drawing.Size(320, 248);
            this.Load += new System.EventHandler(this.AudioSmall_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox speakerChkBox;
        private System.Windows.Forms.CheckBox micChkBox;
        private System.Windows.Forms.VScrollBar speakerScrollBar;
        private System.Windows.Forms.VScrollBar micScrollBar;
        private Parts.PlugTitle plugTitleCtrl;
        private Parts.ConnectPart connectPart1;
    }
}
