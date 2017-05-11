namespace IoTBoxTiles
{
    partial class DevicesForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevicesForm));
            this.deviceTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tv_DeviceList = new System.Windows.Forms.TreeView();
            this.deviceFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.deviceTableLayout.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deviceTableLayout
            // 
            this.deviceTableLayout.ColumnCount = 1;
            this.deviceTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.deviceTableLayout.Controls.Add(this.statusStrip1, 0, 1);
            this.deviceTableLayout.Controls.Add(this.splitContainer1, 0, 0);
            this.deviceTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceTableLayout.Location = new System.Drawing.Point(0, 0);
            this.deviceTableLayout.Margin = new System.Windows.Forms.Padding(5);
            this.deviceTableLayout.Name = "deviceTableLayout";
            this.deviceTableLayout.RowCount = 2;
            this.deviceTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.deviceTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.deviceTableLayout.Size = new System.Drawing.Size(2379, 1199);
            this.deviceTableLayout.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_status,
            this.toolStripStatusLabel1,
            this.toolStripDropDownButton1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1152);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(3, 0, 27, 0);
            this.statusStrip1.Size = new System.Drawing.Size(2379, 47);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_status
            // 
            this.lbl_status.Name = "lbl_status";
            this.lbl_status.Size = new System.Drawing.Size(96, 42);
            this.lbl_status.Text = "status";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(2075, 42);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ShowDropDownArrow = false;
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(120, 45);
            this.toolStripDropDownButton1.Text = "Refresh";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(58, 42);
            this.toolStripStatusLabel2.Text = "     ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tv_DeviceList);
            this.splitContainer1.Panel1MinSize = 320;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.deviceFlowLayout);
            this.splitContainer1.Panel2MinSize = 320;
            this.splitContainer1.Size = new System.Drawing.Size(2369, 1132);
            this.splitContainer1.SplitterDistance = 853;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // tv_DeviceList
            // 
            this.tv_DeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_DeviceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tv_DeviceList.FullRowSelect = true;
            this.tv_DeviceList.HideSelection = false;
            this.tv_DeviceList.Location = new System.Drawing.Point(0, 0);
            this.tv_DeviceList.Margin = new System.Windows.Forms.Padding(5);
            this.tv_DeviceList.Name = "tv_DeviceList";
            this.tv_DeviceList.Size = new System.Drawing.Size(853, 1132);
            this.tv_DeviceList.TabIndex = 0;
            this.tv_DeviceList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_DeviceList_AfterSelect);
            // 
            // deviceFlowLayout
            // 
            this.deviceFlowLayout.AutoScroll = true;
            this.deviceFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceFlowLayout.Location = new System.Drawing.Point(0, 0);
            this.deviceFlowLayout.Margin = new System.Windows.Forms.Padding(5);
            this.deviceFlowLayout.Name = "deviceFlowLayout";
            this.deviceFlowLayout.Size = new System.Drawing.Size(1508, 1132);
            this.deviceFlowLayout.TabIndex = 0;
            this.deviceFlowLayout.Resize += new System.EventHandler(this.flowLayoutPanel1_Resize);
            // 
            // DevicesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2379, 1199);
            this.Controls.Add(this.deviceTableLayout);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(1547, 827);
            this.Name = "DevicesForm";
            this.Text = "IoTTiles";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_LoadAsync);
            this.deviceTableLayout.ResumeLayout(false);
            this.deviceTableLayout.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel deviceTableLayout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel deviceFlowLayout;
        private System.Windows.Forms.TreeView tv_DeviceList;
        private System.Windows.Forms.ToolStripStatusLabel lbl_status;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}