namespace _12306_Helper
{
    partial class formSelectTicket
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
                //this._autoBooker._NoticeEvent.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSelectTicket));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示过站信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSetSystemTime = new System.Windows.Forms.Label();
            this.lblServerTime = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tmUpdateServerTime = new System.Windows.Forms.Timer(this.components);
            this.notice = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmWatch = new System.Windows.Forms.Timer(this.components);
            this.cmsSelectPage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabAccount = new System.Windows.Forms.TabControl();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbtnNews = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSaleTime = new System.Windows.Forms.ToolStripButton();
            this.tsbtnHome = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeveloper = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAdvice = new System.Windows.Forms.ToolStripButton();
            this.tsbtnBug = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDiscus = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSupport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblVersion = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnServerSwitch = new System.Windows.Forms.ToolStripButton();
            this.tsbtnWebCatch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnLogout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslblSaleToday = new System.Windows.Forms.ToolStripLabel();
            this.lb_From_To = new System.Windows.Forms.ToolStripLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示过站信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // 显示过站信息ToolStripMenuItem
            // 
            this.显示过站信息ToolStripMenuItem.Name = "显示过站信息ToolStripMenuItem";
            this.显示过站信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.显示过站信息ToolStripMenuItem.Text = "显示过站信息";
            // 
            // lblSetSystemTime
            // 
            this.lblSetSystemTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSetSystemTime.AutoSize = true;
            this.lblSetSystemTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSetSystemTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSetSystemTime.Location = new System.Drawing.Point(428, 7);
            this.lblSetSystemTime.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.lblSetSystemTime.Name = "lblSetSystemTime";
            this.lblSetSystemTime.Size = new System.Drawing.Size(113, 12);
            this.lblSetSystemTime.TabIndex = 38;
            this.lblSetSystemTime.Text = "[双击校正系统时间]";
            this.lblSetSystemTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSetSystemTime.DoubleClick += new System.EventHandler(this.lblSetSystemTime_DoubleClick);
            // 
            // lblServerTime
            // 
            this.lblServerTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServerTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblServerTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblServerTime.Location = new System.Drawing.Point(88, 1);
            this.lblServerTime.Name = "lblServerTime";
            this.lblServerTime.Size = new System.Drawing.Size(341, 22);
            this.lblServerTime.TabIndex = 5;
            this.lblServerTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime.Location = new System.Drawing.Point(5, 1);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(77, 22);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "[服务器时间]";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            // 
            // tmUpdateServerTime
            // 
            this.tmUpdateServerTime.Interval = 1000;
            this.tmUpdateServerTime.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // notice
            // 
            this.notice.Icon = ((System.Drawing.Icon)(resources.GetObject("notice.Icon")));
            this.notice.Text = "12306 订票小助手 C# 版";
            this.notice.Click += new System.EventHandler(this.notice_Click);
            // 
            // tmWatch
            // 
            this.tmWatch.Interval = 1000;
            // 
            // cmsSelectPage
            // 
            this.cmsSelectPage.Name = "contextMenuStrip2";
            this.cmsSelectPage.Size = new System.Drawing.Size(61, 4);
            // 
            // tabAccount
            // 
            this.tabAccount.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAccount.Location = new System.Drawing.Point(0, 25);
            this.tabAccount.Margin = new System.Windows.Forms.Padding(0);
            this.tabAccount.Multiline = true;
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Padding = new System.Drawing.Point(0, 0);
            this.tabAccount.SelectedIndex = 0;
            this.tabAccount.Size = new System.Drawing.Size(1129, 561);
            this.tabAccount.TabIndex = 42;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNews,
            this.tsbtnSaleTime,
            this.tsbtnHome,
            this.tsbtnDeveloper,
            this.tsbtnAdvice,
            this.tsbtnBug,
            this.tsbtnDiscus,
            this.tsbtnSupport,
            this.toolStripSeparator4,
            this.lblVersion,
            this.toolStripSeparator2,
            this.tsbtnServerSwitch,
            this.tsbtnWebCatch,
            this.toolStripSeparator3,
            this.tsbtnLogout,
            this.toolStripSeparator1,
            this.tslblSaleToday,
            this.lb_From_To});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1129, 25);
            this.toolStrip2.TabIndex = 42;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbtnNews
            // 
            this.tsbtnNews.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnNews.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnNews.Image")));
            this.tsbtnNews.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNews.Name = "tsbtnNews";
            this.tsbtnNews.Size = new System.Drawing.Size(60, 22);
            this.tsbtnNews.Text = "最新动态";
            this.tsbtnNews.Click += new System.EventHandler(this.tsbtnNews_Click);
            // 
            // tsbtnSaleTime
            // 
            this.tsbtnSaleTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnSaleTime.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSaleTime.Image")));
            this.tsbtnSaleTime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSaleTime.Name = "tsbtnSaleTime";
            this.tsbtnSaleTime.Size = new System.Drawing.Size(84, 22);
            this.tsbtnSaleTime.Text = "起售时间查询";
            this.tsbtnSaleTime.Click += new System.EventHandler(this.tsbtnSaleTime_Click);
            // 
            // tsbtnHome
            // 
            this.tsbtnHome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnHome.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.tsbtnHome.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnHome.Image")));
            this.tsbtnHome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHome.Name = "tsbtnHome";
            this.tsbtnHome.Size = new System.Drawing.Size(72, 22);
            this.tsbtnHome.Text = "作者的小窝";
            this.tsbtnHome.Click += new System.EventHandler(this.tsbtnHome_Click);
            // 
            // tsbtnDeveloper
            // 
            this.tsbtnDeveloper.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnDeveloper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnDeveloper.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.tsbtnDeveloper.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeveloper.Image")));
            this.tsbtnDeveloper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeveloper.Name = "tsbtnDeveloper";
            this.tsbtnDeveloper.Size = new System.Drawing.Size(72, 22);
            this.tsbtnDeveloper.Text = "开发者讨论";
            this.tsbtnDeveloper.Click += new System.EventHandler(this.tsbtnDeveloper_Click);
            // 
            // tsbtnAdvice
            // 
            this.tsbtnAdvice.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnAdvice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnAdvice.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.tsbtnAdvice.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAdvice.Image")));
            this.tsbtnAdvice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdvice.Name = "tsbtnAdvice";
            this.tsbtnAdvice.Size = new System.Drawing.Size(60, 22);
            this.tsbtnAdvice.Text = "意见反馈";
            this.tsbtnAdvice.Click += new System.EventHandler(this.tsbtnAdvice_Click);
            // 
            // tsbtnBug
            // 
            this.tsbtnBug.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnBug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnBug.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.tsbtnBug.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnBug.Image")));
            this.tsbtnBug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnBug.Name = "tsbtnBug";
            this.tsbtnBug.Size = new System.Drawing.Size(62, 22);
            this.tsbtnBug.Text = "BUG反馈";
            this.tsbtnBug.Click += new System.EventHandler(this.tsbtnBug_Click);
            // 
            // tsbtnDiscus
            // 
            this.tsbtnDiscus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnDiscus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnDiscus.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Underline);
            this.tsbtnDiscus.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDiscus.Image")));
            this.tsbtnDiscus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDiscus.Name = "tsbtnDiscus";
            this.tsbtnDiscus.Size = new System.Drawing.Size(60, 22);
            this.tsbtnDiscus.Text = "常规讨论";
            this.tsbtnDiscus.ToolTipText = "常规讨论";
            this.tsbtnDiscus.Click += new System.EventHandler(this.tsbtnDiscus_Click);
            // 
            // tsbtnSupport
            // 
            this.tsbtnSupport.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbtnSupport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnSupport.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnSupport.ForeColor = System.Drawing.Color.Crimson;
            this.tsbtnSupport.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSupport.Image")));
            this.tsbtnSupport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSupport.Name = "tsbtnSupport";
            this.tsbtnSupport.Size = new System.Drawing.Size(60, 22);
            this.tsbtnSupport.Text = "捐助作者";
            this.tsbtnSupport.Click += new System.EventHandler(this.tsbtnSupport_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblVersion
            // 
            this.lblVersion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblVersion.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lblVersion.ForeColor = System.Drawing.Color.Crimson;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(55, 22);
            this.lblVersion.Text = "Version";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnServerSwitch
            // 
            this.tsbtnServerSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnServerSwitch.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnServerSwitch.Image")));
            this.tsbtnServerSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnServerSwitch.Name = "tsbtnServerSwitch";
            this.tsbtnServerSwitch.Size = new System.Drawing.Size(96, 22);
            this.tsbtnServerSwitch.Text = "自动切换服务器";
            this.tsbtnServerSwitch.ToolTipText = "开启后,自动选择最快的服务器进行解析,可防封IP";
            this.tsbtnServerSwitch.Click += new System.EventHandler(this.tsbtnServerSwitch_Click);
            // 
            // tsbtnWebCatch
            // 
            this.tsbtnWebCatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnWebCatch.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnWebCatch.Image")));
            this.tsbtnWebCatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnWebCatch.Name = "tsbtnWebCatch";
            this.tsbtnWebCatch.Size = new System.Drawing.Size(72, 22);
            this.tsbtnWebCatch.Text = "设置联系人";
            this.tsbtnWebCatch.ToolTipText = "简单的请求返回值捕捉";
            this.tsbtnWebCatch.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnLogout
            // 
            this.tsbtnLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnLogout.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLogout.Image")));
            this.tsbtnLogout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLogout.Name = "tsbtnLogout";
            this.tsbtnLogout.Size = new System.Drawing.Size(60, 22);
            this.tsbtnLogout.Text = "切换账号";
            this.tsbtnLogout.Click += new System.EventHandler(this.tsbtnLogout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslblSaleToday
            // 
            this.tslblSaleToday.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.tslblSaleToday.ForeColor = System.Drawing.Color.Purple;
            this.tslblSaleToday.Name = "tslblSaleToday";
            this.tslblSaleToday.Size = new System.Drawing.Size(56, 22);
            this.tslblSaleToday.Text = "今日起售";
            // 
            // lb_From_To
            // 
            this.lb_From_To.ActiveLinkColor = System.Drawing.Color.Purple;
            this.lb_From_To.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lb_From_To.ForeColor = System.Drawing.Color.Purple;
            this.lb_From_To.Name = "lb_From_To";
            this.lb_From_To.Size = new System.Drawing.Size(0, 22);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblSetSystemTime);
            this.panel5.Controls.Add(this.lblServerTime);
            this.panel5.Controls.Add(this.lblTime);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 586);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1129, 24);
            this.panel5.TabIndex = 38;
            // 
            // formSelectTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1129, 610);
            this.Controls.Add(this.tabAccount);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1070, 580);
            this.Name = "formSelectTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "12306 订票助手 C#版 BY：aNyoNe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formSelectTicket_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formSelectTicket_FormClosed);
            this.Load += new System.EventHandler(this.formSelectTicket_Load);
            this.Resize += new System.EventHandler(this.formSelectTicket_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer tmUpdateServerTime;
        private System.Windows.Forms.NotifyIcon notice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示过站信息ToolStripMenuItem;
        private System.Windows.Forms.Timer tmWatch;
        //private ScrollLabel scrollLabel1;
        private System.Windows.Forms.Label lblSetSystemTime;
        private System.Windows.Forms.TabControl tabAccount;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbtnNews;
        private System.Windows.Forms.ToolStripButton tsbtnSaleTime;
        private System.Windows.Forms.ToolStripButton tsbtnDeveloper;
        private System.Windows.Forms.ToolStripButton tsbtnAdvice;
        private System.Windows.Forms.ToolStripButton tsbtnBug;
        private System.Windows.Forms.ToolStripButton tsbtnDiscus;
        private System.Windows.Forms.ToolStripButton tsbtnSupport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblVersion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnServerSwitch;
        private System.Windows.Forms.ToolStripButton tsbtnWebCatch;
        private System.Windows.Forms.ContextMenuStrip cmsSelectPage;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripButton tsbtnHome;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnLogout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslblSaleToday;
        private System.Windows.Forms.ToolStripLabel lb_From_To;
    }
}