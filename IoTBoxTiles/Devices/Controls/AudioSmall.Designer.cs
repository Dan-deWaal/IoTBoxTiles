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
            this.friendlyNameLbl = new System.Windows.Forms.Label();
            this.powerChkBox = new System.Windows.Forms.CheckBox();
            this.connectChkBox = new System.Windows.Forms.CheckBox();
            this.alreadyConnLbl = new System.Windows.Forms.Label();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.speakerChkBox = new System.Windows.Forms.CheckBox();
            this.micChkBox = new System.Windows.Forms.CheckBox();
            this.speakerScrollBar = new System.Windows.Forms.VScrollBar();
            this.micScrollBar = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // friendlyNameLbl
            // 
            this.friendlyNameLbl.AutoSize = true;
            this.friendlyNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendlyNameLbl.Location = new System.Drawing.Point(40, 55);
            this.friendlyNameLbl.Name = "friendlyNameLbl";
            this.friendlyNameLbl.Size = new System.Drawing.Size(377, 39);
            this.friendlyNameLbl.TabIndex = 0;
            this.friendlyNameLbl.Text = "{audio_friendly_name}";
            // 
            // powerChkBox
            // 
            this.powerChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.powerChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.powerChkBox.Location = new System.Drawing.Point(492, 18);
            this.powerChkBox.Name = "powerChkBox";
            this.powerChkBox.Size = new System.Drawing.Size(128, 114);
            this.powerChkBox.TabIndex = 2;
            this.powerChkBox.Text = "pow";
            this.powerChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.powerChkBox.UseVisualStyleBackColor = true;
            this.powerChkBox.CheckedChanged += new System.EventHandler(this.powerChkBox_CheckedChanged);
            // 
            // connectChkBox
            // 
            this.connectChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.connectChkBox.Location = new System.Drawing.Point(17, 138);
            this.connectChkBox.Name = "connectChkBox";
            this.connectChkBox.Size = new System.Drawing.Size(603, 90);
            this.connectChkBox.TabIndex = 2;
            this.connectChkBox.Text = "Connect";
            this.connectChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connectChkBox.UseVisualStyleBackColor = true;
            // 
            // alreadyConnLbl
            // 
            this.alreadyConnLbl.AutoSize = true;
            this.alreadyConnLbl.Location = new System.Drawing.Point(11, 240);
            this.alreadyConnLbl.Name = "alreadyConnLbl";
            this.alreadyConnLbl.Size = new System.Drawing.Size(271, 32);
            this.alreadyConnLbl.TabIndex = 0;
            this.alreadyConnLbl.Text = "connected to {client}";
            this.alreadyConnLbl.Visible = false;
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectBtn.AutoSize = true;
            this.disconnectBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.disconnectBtn.Location = new System.Drawing.Point(458, 234);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(162, 42);
            this.disconnectBtn.TabIndex = 3;
            this.disconnectBtn.Text = "disconnect";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Visible = false;
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
            // AudioSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.micScrollBar);
            this.Controls.Add(this.speakerScrollBar);
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.connectChkBox);
            this.Controls.Add(this.micChkBox);
            this.Controls.Add(this.speakerChkBox);
            this.Controls.Add(this.powerChkBox);
            this.Controls.Add(this.alreadyConnLbl);
            this.Controls.Add(this.friendlyNameLbl);
            this.Name = "AudioSmall";
            this.Size = new System.Drawing.Size(640, 480);
            this.Load += new System.EventHandler(this.AudioSmall_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label friendlyNameLbl;
        private System.Windows.Forms.CheckBox powerChkBox;
        private System.Windows.Forms.CheckBox connectChkBox;
        private System.Windows.Forms.Label alreadyConnLbl;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.CheckBox speakerChkBox;
        private System.Windows.Forms.CheckBox micChkBox;
        private System.Windows.Forms.VScrollBar speakerScrollBar;
        private System.Windows.Forms.VScrollBar micScrollBar;
    }
}
