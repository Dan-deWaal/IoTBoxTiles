namespace IoTBoxTiles.Devices.Controls
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
            this.SuspendLayout();
            // 
            // plugTitleCtrl
            // 
            this.plugTitleCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plugTitleCtrl.FriendlyName = "name";
            this.plugTitleCtrl.Location = new System.Drawing.Point(3, 3);
            this.plugTitleCtrl.Name = "plugTitleCtrl";
            this.plugTitleCtrl.PowerChecked = false;
            this.plugTitleCtrl.Size = new System.Drawing.Size(955, 48);
            this.plugTitleCtrl.TabIndex = 0;
            // 
            // connectPartCtrl
            // 
            this.connectPartCtrl.Client = null;
            this.connectPartCtrl.ConnectChecked = false;
            this.connectPartCtrl.Location = new System.Drawing.Point(3, 111);
            this.connectPartCtrl.Name = "connectPartCtrl";
            this.connectPartCtrl.Size = new System.Drawing.Size(513, 64);
            this.connectPartCtrl.TabIndex = 1;
            // 
            // AudioLarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.connectPartCtrl);
            this.Controls.Add(this.plugTitleCtrl);
            this.Name = "AudioLarge";
            this.Size = new System.Drawing.Size(961, 892);
            this.Load += new System.EventHandler(this.AudioLarge_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Parts.PlugTitle plugTitleCtrl;
        private Parts.ConnectPart connectPartCtrl;
    }
}
