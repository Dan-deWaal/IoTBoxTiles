namespace IoTBoxTiles.Devices.Controls.Parts
{
    partial class ConnectPart
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
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.connectChkBox = new System.Windows.Forms.CheckBox();
            this.alreadyConnLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.disconnectBtn.Location = new System.Drawing.Point(462, 109);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(165, 47);
            this.disconnectBtn.TabIndex = 6;
            this.disconnectBtn.Text = "disconnect";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            // 
            // connectChkBox
            // 
            this.connectChkBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectChkBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.connectChkBox.Location = new System.Drawing.Point(0, 0);
            this.connectChkBox.Name = "connectChkBox";
            this.connectChkBox.Size = new System.Drawing.Size(627, 106);
            this.connectChkBox.TabIndex = 5;
            this.connectChkBox.Text = "Connect";
            this.connectChkBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connectChkBox.UseVisualStyleBackColor = true;
            // 
            // alreadyConnLbl
            // 
            this.alreadyConnLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alreadyConnLbl.Location = new System.Drawing.Point(3, 109);
            this.alreadyConnLbl.Name = "alreadyConnLbl";
            this.alreadyConnLbl.Size = new System.Drawing.Size(453, 47);
            this.alreadyConnLbl.TabIndex = 4;
            this.alreadyConnLbl.Text = "connected to {client}";
            this.alreadyConnLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConnectPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.disconnectBtn);
            this.Controls.Add(this.connectChkBox);
            this.Controls.Add(this.alreadyConnLbl);
            this.Name = "ConnectPart";
            this.Size = new System.Drawing.Size(627, 156);
            this.Resize += new System.EventHandler(this.ConnectPart_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.CheckBox connectChkBox;
        private System.Windows.Forms.Label alreadyConnLbl;
    }
}
