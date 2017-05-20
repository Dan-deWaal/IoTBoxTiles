namespace IoTBoxTiles.Devices.Controls
{
    partial class SmartPlugSmall
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
            this.currentTitle1 = new IoTBoxTiles.Devices.Controls.Parts.CurrentTitle();
            this.plugTitleCtrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.SuspendLayout();
            // 
            // currentTitle1
            // 
            this.currentTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.currentTitle1.Location = new System.Drawing.Point(181, 222);
            this.currentTitle1.Name = "currentTitle1";
            this.currentTitle1.Size = new System.Drawing.Size(133, 23);
            this.currentTitle1.TabIndex = 1;
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
            this.plugTitleCtrl.Refreshing = false;
            this.plugTitleCtrl.Size = new System.Drawing.Size(314, 42);
            this.plugTitleCtrl.TabIndex = 0;
            this.plugTitleCtrl.PowerClicked += new System.EventHandler(this.plugTitleCtrl_PowerClicked);
            this.plugTitleCtrl.Load += new System.EventHandler(this.plugTitleCtrl_Load);
            // 
            // SmartPlugSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.currentTitle1);
            this.Controls.Add(this.plugTitleCtrl);
            this.Name = "SmartPlugSmall";
            this.Size = new System.Drawing.Size(320, 248);
            this.ResumeLayout(false);

        }

        #endregion

        private Parts.PlugTitle plugTitleCtrl;
        private Parts.CurrentTitle currentTitle1;
    }
}
