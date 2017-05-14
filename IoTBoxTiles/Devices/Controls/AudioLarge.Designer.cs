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
            this.plugTitle1 = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.SuspendLayout();
            // 
            // plugTitle1
            // 
            this.plugTitle1.FriendlyName = "name";
            this.plugTitle1.Location = new System.Drawing.Point(3, 3);
            this.plugTitle1.Name = "plugTitle1";
            this.plugTitle1.PowerChecked = false;
            this.plugTitle1.Size = new System.Drawing.Size(843, 139);
            this.plugTitle1.TabIndex = 0;
            // 
            // AudioLarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plugTitle1);
            this.Name = "AudioLarge";
            this.Size = new System.Drawing.Size(849, 885);
            this.ResumeLayout(false);

        }

        #endregion

        private Parts.PlugTitle plugTitle1;
    }
}
