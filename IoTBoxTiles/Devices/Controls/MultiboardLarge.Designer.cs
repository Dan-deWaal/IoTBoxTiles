namespace IoTBoxTiles.Devices.Controls
{
    partial class MultiboardLarge
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
            this.plug1Ctrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.currentLabel1 = new System.Windows.Forms.Label();
            this.currentLabel2 = new System.Windows.Forms.Label();
            this.currentLabel3 = new System.Windows.Forms.Label();
            this.currentLabel4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.plug2Ctrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.plug3Ctrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.plug4Ctrl = new IoTBoxTiles.Devices.Controls.Parts.PlugTitle();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // plugTitleCtrl
            // 
            this.plugTitleCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plugTitleCtrl.FriendlyName = "name";
            this.plugTitleCtrl.Location = new System.Drawing.Point(2, 2);
            this.plugTitleCtrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plugTitleCtrl.Name = "plugTitleCtrl";
            this.plugTitleCtrl.PowerChecked = false;
            this.plugTitleCtrl.Refreshing = false;
            this.plugTitleCtrl.Size = new System.Drawing.Size(476, 42);
            this.plugTitleCtrl.TabIndex = 0;
            this.plugTitleCtrl.PowerClicked += new System.EventHandler(this.plugTitleCtrl_PowerClicked);
            // 
            // plug1Ctrl
            // 
            this.plug1Ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plug1Ctrl.FriendlyName = "name";
            this.plug1Ctrl.Location = new System.Drawing.Point(56, 2);
            this.plug1Ctrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plug1Ctrl.Name = "plug1Ctrl";
            this.plug1Ctrl.PowerChecked = false;
            this.plug1Ctrl.Refreshing = false;
            this.plug1Ctrl.Size = new System.Drawing.Size(304, 42);
            this.plug1Ctrl.TabIndex = 1;
            this.plug1Ctrl.PowerClicked += new System.EventHandler(this.plug1Ctrl_PowerClicked);
            // 
            // currentLabel1
            // 
            this.currentLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentLabel1.Location = new System.Drawing.Point(3, 0);
            this.currentLabel1.Name = "currentLabel1";
            this.currentLabel1.Size = new System.Drawing.Size(48, 42);
            this.currentLabel1.TabIndex = 5;
            this.currentLabel1.Text = "label1";
            this.currentLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentLabel2
            // 
            this.currentLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentLabel2.Location = new System.Drawing.Point(3, 54);
            this.currentLabel2.Name = "currentLabel2";
            this.currentLabel2.Size = new System.Drawing.Size(48, 42);
            this.currentLabel2.TabIndex = 6;
            this.currentLabel2.Text = "label2";
            this.currentLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentLabel3
            // 
            this.currentLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentLabel3.Location = new System.Drawing.Point(3, 108);
            this.currentLabel3.Name = "currentLabel3";
            this.currentLabel3.Size = new System.Drawing.Size(48, 42);
            this.currentLabel3.TabIndex = 7;
            this.currentLabel3.Text = "label3";
            this.currentLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentLabel4
            // 
            this.currentLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentLabel4.Location = new System.Drawing.Point(3, 162);
            this.currentLabel4.Name = "currentLabel4";
            this.currentLabel4.Size = new System.Drawing.Size(48, 42);
            this.currentLabel4.TabIndex = 8;
            this.currentLabel4.Text = "label4";
            this.currentLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.Controls.Add(this.plug1Ctrl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.plug2Ctrl, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.plug3Ctrl, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.plug4Ctrl, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.currentLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.currentLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.currentLabel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.currentLabel4, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 64);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 218);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // plug2Ctrl
            // 
            this.plug2Ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plug2Ctrl.FriendlyName = "name";
            this.plug2Ctrl.Location = new System.Drawing.Point(56, 56);
            this.plug2Ctrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plug2Ctrl.Name = "plug2Ctrl";
            this.plug2Ctrl.PowerChecked = false;
            this.plug2Ctrl.Refreshing = false;
            this.plug2Ctrl.Size = new System.Drawing.Size(304, 42);
            this.plug2Ctrl.TabIndex = 2;
            this.plug2Ctrl.PowerClicked += new System.EventHandler(this.plug2Ctrl_PowerClicked);
            // 
            // plug3Ctrl
            // 
            this.plug3Ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plug3Ctrl.FriendlyName = "name";
            this.plug3Ctrl.Location = new System.Drawing.Point(56, 110);
            this.plug3Ctrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plug3Ctrl.Name = "plug3Ctrl";
            this.plug3Ctrl.PowerChecked = false;
            this.plug3Ctrl.Refreshing = false;
            this.plug3Ctrl.Size = new System.Drawing.Size(304, 42);
            this.plug3Ctrl.TabIndex = 3;
            this.plug3Ctrl.PowerClicked += new System.EventHandler(this.plug3Ctrl_PowerClicked);
            // 
            // plug4Ctrl
            // 
            this.plug4Ctrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plug4Ctrl.FriendlyName = "name";
            this.plug4Ctrl.Location = new System.Drawing.Point(56, 164);
            this.plug4Ctrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.plug4Ctrl.Name = "plug4Ctrl";
            this.plug4Ctrl.PowerChecked = false;
            this.plug4Ctrl.Refreshing = false;
            this.plug4Ctrl.Size = new System.Drawing.Size(304, 42);
            this.plug4Ctrl.TabIndex = 4;
            this.plug4Ctrl.PowerClicked += new System.EventHandler(this.plug4Ctrl_PowerClicked);
            // 
            // MultiboardLarge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.plugTitleCtrl);
            this.Name = "MultiboardLarge";
            this.Size = new System.Drawing.Size(480, 601);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Parts.PlugTitle plugTitleCtrl;
        private Parts.PlugTitle plug1Ctrl;
        private System.Windows.Forms.Label currentLabel1;
        private System.Windows.Forms.Label currentLabel2;
        private System.Windows.Forms.Label currentLabel3;
        private System.Windows.Forms.Label currentLabel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Parts.PlugTitle plug2Ctrl;
        private Parts.PlugTitle plug3Ctrl;
        private Parts.PlugTitle plug4Ctrl;
    }
}
