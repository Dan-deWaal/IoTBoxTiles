namespace IoTBoxTiles.Devices.Controls.Parts
{
    partial class PlugTitle
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
            this.nameLbl = new System.Windows.Forms.Label();
            this.powerBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // nameLbl
            // 
            this.nameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(3, 3);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(379, 128);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "name";
            this.nameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // powerBox
            // 
            this.powerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.powerBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.powerBox.Location = new System.Drawing.Point(388, 3);
            this.powerBox.Name = "powerBox";
            this.powerBox.Size = new System.Drawing.Size(128, 128);
            this.powerBox.TabIndex = 1;
            this.powerBox.Text = "pow";
            this.powerBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.powerBox.UseVisualStyleBackColor = true;
            // 
            // PlugTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nameLbl);
            this.Controls.Add(this.powerBox);
            this.Name = "PlugTitle";
            this.Size = new System.Drawing.Size(519, 134);
            this.Resize += new System.EventHandler(this.PlugTitle_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.CheckBox powerBox;
    }
}
