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
            this.plugTitleCtrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.connectPart1 = new IoTBoxTiles.Devices.Controls.Parts.ConnectPart();
            this.SuspendLayout();
            // 
            // speakerChkBox
            // 
            this.speakerChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.speakerChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.speakerChkBox.Enabled = false;
            this.speakerChkBox.Location = new System.Drawing.Point(47, 290);
            this.speakerChkBox.Name = "speakerChkBox";
            this.speakerChkBox.Size = new System.Drawing.Size(206, 165);
            this.speakerChkBox.TabIndex = 2;
            this.speakerChkBox.Text = "Connect Speaker";
            this.speakerChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.speakerChkBox.UseVisualStyleBackColor = true;
            // 
            // micChkBox
            // 
            this.micChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.micChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.micChkBox.Enabled = false;
            this.micChkBox.Location = new System.Drawing.Point(341, 290);
            this.micChkBox.Name = "micChkBox";
            this.micChkBox.Size = new System.Drawing.Size(206, 165);
            this.micChkBox.TabIndex = 2;
            this.micChkBox.Text = "Connect Microphone";
            this.micChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.micChkBox.UseVisualStyleBackColor = true;
            // 
            // speakerScrollBar
            // 
            this.speakerScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.speakerScrollBar.Enabled = false;
            this.speakerScrollBar.Location = new System.Drawing.Point(260, 290);
            this.speakerScrollBar.Name = "speakerScrollBar";
            this.speakerScrollBar.Size = new System.Drawing.Size(43, 165);
            this.speakerScrollBar.TabIndex = 4;
            // 
            // micScrollBar
            // 
            this.micScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.micScrollBar.Enabled = false;
            this.micScrollBar.Location = new System.Drawing.Point(550, 290);
            this.micScrollBar.Name = "micScrollBar";
            this.micScrollBar.Size = new System.Drawing.Size(43, 165);
            this.micScrollBar.TabIndex = 4;
            // 
            // plugTitleCtrl
            // 
            this.plugTitleCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.plugTitleCtrl.FriendlyName = "{audio_name}";
            this.plugTitleCtrl.Location = new System.Drawing.Point(3, 15);
            this.plugTitleCtrl.Name = "plugTitleCtrl";
            this.plugTitleCtrl.PowerChecked = false;
            this.plugTitleCtrl.Size = new System.Drawing.Size(634, 101);
            this.plugTitleCtrl.TabIndex = 5;
            this.plugTitleCtrl.PowerCheckedChanged += new System.EventHandler(this.plugTitleCtrl_PowerCheckedChangedAsync);
            // 
            // connectPart1
            // 
            this.connectPart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectPart1.Client = null;
            this.connectPart1.ConnectChecked = false;
            this.connectPart1.Location = new System.Drawing.Point(3, 122);
            this.connectPart1.Name = "connectPart1";
            this.connectPart1.Size = new System.Drawing.Size(634, 162);
            this.connectPart1.TabIndex = 6;
            this.connectPart1.ConnectCheckedChanged += new System.EventHandler(this.connectPart1_ConnectCheckedChanged);
            this.connectPart1.DisconnectBtnClick += new System.EventHandler(this.connectPart1_DisconnectBtnClick);
            // 
            // AudioSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connectPart1);
            this.Controls.Add(this.plugTitleCtrl);
            this.Controls.Add(this.micScrollBar);
            this.Controls.Add(this.speakerScrollBar);
            this.Controls.Add(this.micChkBox);
            this.Controls.Add(this.speakerChkBox);
            this.Name = "AudioSmall";
            this.Size = new System.Drawing.Size(640, 480);
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
