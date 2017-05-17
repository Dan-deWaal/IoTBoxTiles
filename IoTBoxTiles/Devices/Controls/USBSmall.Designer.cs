namespace IoTBoxTiles.Devices.Controls
{
    partial class USBSmall
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
            this.connectPart1 = new IoTBoxTiles.Devices.Controls.Parts.ConnectPart();
            this.SuspendLayout();
            // 
            // plugTitleCtrl
            // 
            this.plugTitleCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plugTitleCtrl.FriendlyName = "name";
            this.plugTitleCtrl.Location = new System.Drawing.Point(0, 0);
            this.plugTitleCtrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plugTitleCtrl.Name = "plugTitleCtrl";
            this.plugTitleCtrl.PowerChecked = false;
            this.plugTitleCtrl.Size = new System.Drawing.Size(316, 48);
            this.plugTitleCtrl.TabIndex = 0;
            // 
            // connectPart1
            // 
            this.connectPart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectPart1.Client = null;
            this.connectPart1.ConnectChecked = false;
            this.connectPart1.Location = new System.Drawing.Point(2, 52);
            this.connectPart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectPart1.Name = "connectPart1";
            this.connectPart1.Size = new System.Drawing.Size(314, 64);
            this.connectPart1.TabIndex = 1;
            this.connectPart1.ConnectCheckedChanged += new System.EventHandler(this.connectPart1_ConnectCheckedChanged);
            // 
            // USBSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connectPart1);
            this.Controls.Add(this.plugTitleCtrl);
            this.Name = "USBSmall";
            this.Size = new System.Drawing.Size(320, 248);
            this.ResumeLayout(false);

        }

        #endregion

        private Parts.PlugTitle plugTitleCtrl;
        private Parts.ConnectPart connectPart1;
    }
}
