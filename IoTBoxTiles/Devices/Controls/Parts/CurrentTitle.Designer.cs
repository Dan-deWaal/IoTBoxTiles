namespace IoTBoxTiles.Devices.Controls.Parts
{
    partial class CurrentTitle
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
            this.currentLabel = new System.Windows.Forms.Label();
            this.mALabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentLabel
            // 
            this.currentLabel.Location = new System.Drawing.Point(0, 0);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(100, 23);
            this.currentLabel.TabIndex = 0;
            this.currentLabel.Text = "current";
            this.currentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mALabel
            // 
            this.mALabel.Location = new System.Drawing.Point(106, 0);
            this.mALabel.Name = "mALabel";
            this.mALabel.Size = new System.Drawing.Size(33, 23);
            this.mALabel.TabIndex = 1;
            this.mALabel.Text = "mA";
            this.mALabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mALabel);
            this.Controls.Add(this.currentLabel);
            this.Name = "CurrentTitle";
            this.Size = new System.Drawing.Size(133, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.Label mALabel;
    }
}
