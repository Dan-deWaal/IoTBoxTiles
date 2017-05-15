namespace IoTBoxTiles.Devices.Controls
{
    partial class USBLarge
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
            this.plugTitle1 = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.connectPart1 = new IoTBoxTiles.Devices.Controls.Parts.ConnectPart();
            this.SuspendLayout();
            // 
            // plugTitle1
            // 
            this.plugTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plugTitle1.FriendlyName = "name";
            this.plugTitle1.Location = new System.Drawing.Point(0, 0);
            this.plugTitle1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plugTitle1.Name = "plugTitle1";
            this.plugTitle1.PowerChecked = false;
            this.plugTitle1.Size = new System.Drawing.Size(478, 48);
            this.plugTitle1.TabIndex = 0;
            // 
            // connectPart1
            // 
            this.connectPart1.Client = null;
            this.connectPart1.ConnectChecked = false;
            this.connectPart1.Location = new System.Drawing.Point(0, 52);
            this.connectPart1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectPart1.Name = "connectPart1";
            this.connectPart1.Size = new System.Drawing.Size(318, 64);
            this.connectPart1.TabIndex = 1;
            // 
            // USBLarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connectPart1);
            this.Controls.Add(this.plugTitle1);
            this.Name = "USBLarge";
            this.Size = new System.Drawing.Size(480, 460);
            this.ResumeLayout(false);

        }

        #endregion

        private Parts.PlugTitle plugTitle1;
        private Parts.ConnectPart connectPart1;
    }
}
