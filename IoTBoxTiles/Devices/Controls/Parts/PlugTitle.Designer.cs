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
            this.nameLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.nameLbl.Location = new System.Drawing.Point(3, 3);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(513, 128);
            this.nameLbl.TabIndex = 0;
            this.nameLbl.Text = "name";
            this.nameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // powerBox
            // 
            this.powerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.powerBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.powerBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(65)))), ((int)(((byte)(13)))));
            this.powerBox.FlatAppearance.BorderSize = 0;
            this.powerBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(149)))), ((int)(((byte)(77)))));
            this.powerBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(56)))), ((int)(((byte)(11)))));
            this.powerBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(70)))), ((int)(((byte)(26)))));
            this.powerBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.powerBox.Image = global::IoTBoxTiles.Properties.Resources.power_shadow;
            this.powerBox.Location = new System.Drawing.Point(345, 0);
            this.powerBox.Name = "powerBox";
            this.powerBox.Size = new System.Drawing.Size(174, 134);
            this.powerBox.TabIndex = 1;
            this.powerBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.powerBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.powerBox.UseVisualStyleBackColor = false;
            this.powerBox.CheckedChanged += new System.EventHandler(this.powerBox_CheckedChanged);
            this.powerBox.MouseEnter += new System.EventHandler(this.powerBox_MouseEnter);
            this.powerBox.MouseLeave += new System.EventHandler(this.powerBox_MouseLeave);
            // 
            // PlugTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.powerBox);
            this.Controls.Add(this.nameLbl);
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
