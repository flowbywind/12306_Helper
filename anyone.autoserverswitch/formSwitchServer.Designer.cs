namespace aNyoNe.AutoServerSwitch
{
    partial class formSwitchServer
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
                ctsSwitch.Dispose();
                ctsListen.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("测试中", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("未测试", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("正常", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("速度过慢>1000(ms)", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("超时", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("不可用", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("封禁", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSwitchServer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStopSwitch = new System.Windows.Forms.Button();
            this.lvServerList = new System.Windows.Forms.ListView();
            this.ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.validCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.failedCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.brokenCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serverspeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.localspeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInitHosts = new System.Windows.Forms.Button();
            this.lvSwitch = new System.Windows.Forms.ListView();
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.information = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noticeSwitch = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出自动切换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnStopSwitch);
            this.panel1.Controls.Add(this.btnInitHosts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(764, 539);
            this.panel1.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(398, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "助手目录下会生成本地hosts文件备份";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(147, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 12);
            this.label1.TabIndex = 54;
            this.label1.Text = "测试完毕后，可手动双击进行切换";
            // 
            // btnStopSwitch
            // 
            this.btnStopSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStopSwitch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnStopSwitch.Location = new System.Drawing.Point(18, 12);
            this.btnStopSwitch.Name = "btnStopSwitch";
            this.btnStopSwitch.Size = new System.Drawing.Size(123, 23);
            this.btnStopSwitch.TabIndex = 53;
            this.btnStopSwitch.Text = "启动自动切换服务器";
            this.btnStopSwitch.UseVisualStyleBackColor = true;
            this.btnStopSwitch.Click += new System.EventHandler(this.btnStopSwitch_Click);
            // 
            // lvServerList
            // 
            this.lvServerList.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvServerList.BackColor = System.Drawing.Color.White;
            this.lvServerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvServerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ip,
            this.validCount,
            this.failedCount,
            this.brokenCount,
            this.serverspeed,
            this.localspeed,
            this.status});
            this.lvServerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvServerList.FullRowSelect = true;
            listViewGroup1.Header = "测试中";
            listViewGroup1.Name = "test";
            listViewGroup2.Header = "未测试";
            listViewGroup2.Name = "testing";
            listViewGroup3.Header = "正常";
            listViewGroup3.Name = "normal";
            listViewGroup4.Header = "速度过慢>1000(ms)";
            listViewGroup4.Name = "low";
            listViewGroup5.Header = "超时";
            listViewGroup5.Name = "timeout";
            listViewGroup6.Header = "不可用";
            listViewGroup6.Name = "notvalid";
            listViewGroup7.Header = "封禁";
            listViewGroup7.Name = "breakout";
            this.lvServerList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7});
            this.lvServerList.Location = new System.Drawing.Point(0, 0);
            this.lvServerList.Name = "lvServerList";
            this.lvServerList.Size = new System.Drawing.Size(740, 307);
            this.lvServerList.TabIndex = 0;
            this.lvServerList.UseCompatibleStateImageBehavior = false;
            this.lvServerList.View = System.Windows.Forms.View.Details;
            this.lvServerList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvServerList_ColumnClick);
            this.lvServerList.DoubleClick += new System.EventHandler(this.lvServerList_DoubleClick);
            // 
            // ip
            // 
            this.ip.Text = "地址";
            this.ip.Width = 110;
            // 
            // validCount
            // 
            this.validCount.Text = "报告使用数";
            this.validCount.Width = 100;
            // 
            // failedCount
            // 
            this.failedCount.Text = "报告失效数";
            this.failedCount.Width = 100;
            // 
            // brokenCount
            // 
            this.brokenCount.Text = "报告封禁数";
            this.brokenCount.Width = 100;
            // 
            // serverspeed
            // 
            this.serverspeed.Text = "报告平均速度(ms)";
            this.serverspeed.Width = 120;
            // 
            // localspeed
            // 
            this.localspeed.Text = "本机速度(ms)";
            this.localspeed.Width = 100;
            // 
            // status
            // 
            this.status.Text = "本机状态";
            this.status.Width = 120;
            // 
            // btnInitHosts
            // 
            this.btnInitHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInitHosts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnInitHosts.Location = new System.Drawing.Point(626, 12);
            this.btnInitHosts.Name = "btnInitHosts";
            this.btnInitHosts.Size = new System.Drawing.Size(123, 23);
            this.btnInitHosts.TabIndex = 52;
            this.btnInitHosts.Text = "还原hosts文件";
            this.btnInitHosts.UseVisualStyleBackColor = true;
            this.btnInitHosts.Click += new System.EventHandler(this.btnInitHosts_Click);
            // 
            // lvSwitch
            // 
            this.lvSwitch.BackColor = System.Drawing.Color.White;
            this.lvSwitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvSwitch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.time,
            this.information});
            this.lvSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSwitch.FullRowSelect = true;
            this.lvSwitch.Location = new System.Drawing.Point(0, 0);
            this.lvSwitch.Name = "lvSwitch";
            this.lvSwitch.Size = new System.Drawing.Size(740, 175);
            this.lvSwitch.TabIndex = 1;
            this.lvSwitch.UseCompatibleStateImageBehavior = false;
            this.lvSwitch.View = System.Windows.Forms.View.Details;
            // 
            // time
            // 
            this.time.Text = "时间";
            this.time.Width = 80;
            // 
            // information
            // 
            this.information.Text = "信息";
            this.information.Width = 656;
            // 
            // noticeSwitch
            // 
            this.noticeSwitch.ContextMenuStrip = this.contextMenuStrip1;
            this.noticeSwitch.Icon = ((System.Drawing.Icon)(resources.GetObject("noticeSwitch.Icon")));
            this.noticeSwitch.Text = "服务器自动切换";
            this.noticeSwitch.Click += new System.EventHandler(this.notice_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出自动切换ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // 退出自动切换ToolStripMenuItem
            // 
            this.退出自动切换ToolStripMenuItem.Name = "退出自动切换ToolStripMenuItem";
            this.退出自动切换ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.退出自动切换ToolStripMenuItem.Text = "退出自动切换";
            this.退出自动切换ToolStripMenuItem.Click += new System.EventHandler(this.退出自动切换ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvSwitch);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvServerList);
            this.splitContainer1.Size = new System.Drawing.Size(740, 486);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 55;
            // 
            // formSwitchServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(764, 539);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formSwitchServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动切换服务器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formSwitchServer_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formSwitchServer_FormClosed);
            this.Resize += new System.EventHandler(this.formSwitchServer_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvSwitch;
        private System.Windows.Forms.ListView lvServerList;
        private System.Windows.Forms.Button btnInitHosts;
        private System.Windows.Forms.ColumnHeader ip;
        private System.Windows.Forms.ColumnHeader validCount;
        private System.Windows.Forms.ColumnHeader failedCount;
        private System.Windows.Forms.ColumnHeader brokenCount;
        private System.Windows.Forms.ColumnHeader serverspeed;
        private System.Windows.Forms.ColumnHeader localspeed;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader information;
        private System.Windows.Forms.NotifyIcon noticeSwitch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出自动切换ToolStripMenuItem;
        private System.Windows.Forms.Button btnStopSwitch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}