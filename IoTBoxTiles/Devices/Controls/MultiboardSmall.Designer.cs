namespace IoTBoxTiles.Devices.Controls
{
    partial class MultiboardSmall
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
            this.plug4Ctrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.plug3Ctrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.plug2Ctrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.plug1Ctrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.plugTitleCtrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.SuspendLayout();
            // 
            // plug4Ctrl
            // 
            this.plug4Ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plug4Ctrl.FriendlyName = "name";
            this.plug4Ctrl.Location = new System.Drawing.Point(62, 193);
            this.plug4Ctrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plug4Ctrl.Name = "plug4Ctrl";
            this.plug4Ctrl.PowerChecked = false;
            this.plug4Ctrl.Refreshing = false;
            this.plug4Ctrl.Size = new System.Drawing.Size(196, 42);
            this.plug4Ctrl.TabIndex = 4;
            // 
            // plug3Ctrl
            // 
            this.plug3Ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plug3Ctrl.FriendlyName = "name";
            this.plug3Ctrl.Location = new System.Drawing.Point(62, 147);
            this.plug3Ctrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plug3Ctrl.Name = "plug3Ctrl";
            this.plug3Ctrl.PowerChecked = false;
            this.plug3Ctrl.Refreshing = false;
            this.plug3Ctrl.Size = new System.Drawing.Size(196, 42);
            this.plug3Ctrl.TabIndex = 3;
            // 
            // plug2Ctrl
            // 
            this.plug2Ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plug2Ctrl.FriendlyName = "name";
            this.plug2Ctrl.Location = new System.Drawing.Point(62, 101);
            this.plug2Ctrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plug2Ctrl.Name = "plug2Ctrl";
            this.plug2Ctrl.PowerChecked = false;
            this.plug2Ctrl.Refreshing = false;
            this.plug2Ctrl.Size = new System.Drawing.Size(196, 42);
            this.plug2Ctrl.TabIndex = 2;
            // 
            // plug1Ctrl
            // 
            this.plug1Ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plug1Ctrl.FriendlyName = "name";
            this.plug1Ctrl.Location = new System.Drawing.Point(62, 55);
            this.plug1Ctrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plug1Ctrl.Name = "plug1Ctrl";
            this.plug1Ctrl.PowerChecked = false;
            this.plug1Ctrl.Refreshing = false;
            this.plug1Ctrl.Size = new System.Drawing.Size(196, 42);
            this.plug1Ctrl.TabIndex = 1;
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
            this.plugTitleCtrl.Size = new System.Drawing.Size(318, 42);
            this.plugTitleCtrl.TabIndex = 0;
            this.plugTitleCtrl.PowerClicked += new System.EventHandler(this.plugTitleCtrl_PowerClicked);
            // 
            // MultiboardSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plug4Ctrl);
            this.Controls.Add(this.plug3Ctrl);
            this.Controls.Add(this.plug2Ctrl);
            this.Controls.Add(this.plug1Ctrl);
            this.Controls.Add(this.plugTitleCtrl);
            this.Name = "MultiboardSmall";
            this.Size = new System.Drawing.Size(320, 248);
            this.Load += new System.EventHandler(this.MultiboardSmall_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Parts.PlugTitle plugTitleCtrl;
        private Parts.PlugTitle plug1Ctrl;
        private Parts.PlugTitle plug2Ctrl;
        private Parts.PlugTitle plug3Ctrl;
        private Parts.PlugTitle plug4Ctrl;
    }
}
