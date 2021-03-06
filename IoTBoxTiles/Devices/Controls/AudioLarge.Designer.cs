﻿namespace IoTBoxTiles.Devices.Controls
{
    partial class AudioLarge
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
            this.connectPartCtrl = new IoTBoxTiles.Devices.Controls.Parts.ConnectPart();
            this.currentTitle1 = new IoTBoxTiles.Devices.Controls.Parts.CurrentTitle();
            this.SuspendLayout();
            // 
            // plugTitleCtrl
            // 
            this.plugTitleCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plugTitleCtrl.FriendlyName = "name";
            this.plugTitleCtrl.Location = new System.Drawing.Point(2, 2);
            this.plugTitleCtrl.Margin = new System.Windows.Forms.Padding(1);
            this.plugTitleCtrl.Name = "plugTitleCtrl";
            this.plugTitleCtrl.PowerChecked = false;
            this.plugTitleCtrl.Refreshing = false;
            this.plugTitleCtrl.Size = new System.Drawing.Size(478, 42);
            this.plugTitleCtrl.TabIndex = 0;
            // 
            // connectPartCtrl
            // 
            this.connectPartCtrl.Client = null;
            this.connectPartCtrl.ConnectChecked = false;
            this.connectPartCtrl.Location = new System.Drawing.Point(2, 57);
            this.connectPartCtrl.Margin = new System.Windows.Forms.Padding(1);
            this.connectPartCtrl.Name = "connectPartCtrl";
            this.connectPartCtrl.Size = new System.Drawing.Size(256, 64);
            this.connectPartCtrl.TabIndex = 1;
            this.connectPartCtrl.ConnectCheckedChanged += new System.EventHandler(this.connectPartCtrl_ConnectCheckedChanged);
            this.connectPartCtrl.DisconnectBtnClick += new System.EventHandler(this.connectPartCtrl_DisconnectBtnClick);
            // 
            // currentTitle1
            // 
            this.currentTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.currentTitle1.Location = new System.Drawing.Point(344, 434);
            this.currentTitle1.Name = "currentTitle1";
            this.currentTitle1.Size = new System.Drawing.Size(133, 23);
            this.currentTitle1.TabIndex = 2;
            // 
            // AudioLarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.currentTitle1);
            this.Controls.Add(this.connectPartCtrl);
            this.Controls.Add(this.plugTitleCtrl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AudioLarge";
            this.Size = new System.Drawing.Size(480, 460);
            this.Load += new System.EventHandler(this.AudioLarge_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Parts.PlugTitle plugTitleCtrl;
        private Parts.ConnectPart connectPartCtrl;
        private Parts.CurrentTitle currentTitle1;
    }
}
