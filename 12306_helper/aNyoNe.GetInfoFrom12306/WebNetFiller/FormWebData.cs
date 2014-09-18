using System;
using System.Collections;
using System.Windows.Forms;

namespace aNyoNe.GetInfoFrom12306
{
    public partial class FormWebData : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWebData));
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lsvLinkValue = new System.Windows.Forms.ListView();
            this.paramName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.paramValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblParamType = new System.Windows.Forms.Label();
            this.lsvLinkInfo = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VALUE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMethod = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtBackData = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(804, 459);
            this.panel2.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.lblMethod);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.rtxtBackData);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 439);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lsvLinkValue);
            this.panel3.Controls.Add(this.lblParamType);
            this.panel3.Controls.Add(this.splitter1);
            this.panel3.Controls.Add(this.lsvLinkInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 391);
            this.panel3.TabIndex = 4;
            // 
            // lsvLinkValue
            // 
            this.lsvLinkValue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.paramName,
            this.paramValue});
            this.lsvLinkValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvLinkValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lsvLinkValue.FullRowSelect = true;
            this.lsvLinkValue.GridLines = true;
            this.lsvLinkValue.Location = new System.Drawing.Point(0, 179);
            this.lsvLinkValue.Name = "lsvLinkValue";
            this.lsvLinkValue.ShowItemToolTips = true;
            this.lsvLinkValue.Size = new System.Drawing.Size(256, 212);
            this.lsvLinkValue.TabIndex = 0;
            this.lsvLinkValue.UseCompatibleStateImageBehavior = false;
            this.lsvLinkValue.View = System.Windows.Forms.View.Details;
            // 
            // paramName
            // 
            this.paramName.Text = "参数";
            this.paramName.Width = 120;
            // 
            // paramValue
            // 
            this.paramValue.Text = "值";
            this.paramValue.Width = 133;
            // 
            // lblParamType
            // 
            this.lblParamType.BackColor = System.Drawing.Color.Transparent;
            this.lblParamType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblParamType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblParamType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblParamType.Location = new System.Drawing.Point(0, 161);
            this.lblParamType.Name = "lblParamType";
            this.lblParamType.Size = new System.Drawing.Size(256, 18);
            this.lblParamType.TabIndex = 3;
            this.lblParamType.Text = "提交的数据";
            this.lblParamType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lsvLinkInfo
            // 
            this.lsvLinkInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.VALUE});
            this.lsvLinkInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lsvLinkInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lsvLinkInfo.FullRowSelect = true;
            this.lsvLinkInfo.GridLines = true;
            this.lsvLinkInfo.Location = new System.Drawing.Point(0, 0);
            this.lsvLinkInfo.Name = "lsvLinkInfo";
            this.lsvLinkInfo.ShowItemToolTips = true;
            this.lsvLinkInfo.Size = new System.Drawing.Size(256, 157);
            this.lsvLinkInfo.TabIndex = 2;
            this.lsvLinkInfo.UseCompatibleStateImageBehavior = false;
            this.lsvLinkInfo.View = System.Windows.Forms.View.Details;
            this.lsvLinkInfo.SelectedIndexChanged += new System.EventHandler(this.lsvLinkInfo_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 84;
            // 
            // VALUE
            // 
            this.VALUE.Text = "链接";
            this.VALUE.Width = 169;
            // 
            // lblMethod
            // 
            this.lblMethod.BackColor = System.Drawing.Color.Transparent;
            this.lblMethod.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMethod.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMethod.Location = new System.Drawing.Point(0, 23);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(256, 23);
            this.lblMethod.TabIndex = 3;
            this.lblMethod.Text = "数据获取方式";
            this.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "发送的数据";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtxtBackData
            // 
            this.rtxtBackData.BackColor = System.Drawing.Color.White;
            this.rtxtBackData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtBackData.Location = new System.Drawing.Point(0, 23);
            this.rtxtBackData.Name = "rtxtBackData";
            this.rtxtBackData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtBackData.Size = new System.Drawing.Size(520, 414);
            this.rtxtBackData.TabIndex = 0;
            this.rtxtBackData.Text = "";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(520, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "返回的数据";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 157);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(256, 4);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // FormWebData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 459);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWebData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "网络数据包";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWebData_FormClosing);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private SplitContainer splitContainer1;
        private Label label2;
        private ListView lsvLinkValue;
        private ColumnHeader paramName;
        private ColumnHeader paramValue;
        private RichTextBox rtxtBackData;
        private Label lblMethod;
        private Label lblParamType;
        private Panel panel3;
        private Label label3;
        private ListView lsvLinkInfo;
        private ColumnHeader ID;
        private ColumnHeader VALUE;

        public static bool listen = false;
        private Splitter splitter1;
        private static Hashtable _netInfo = new Hashtable();

        public  void AddNetInfo(string id,string link,string referer,string method, string querystring, string postdata, string backdata)
        {
            _netInfo.Add(id,new NetInfoClass(link,referer,method,querystring,postdata,backdata));
            UpdateView(id,link, referer, method, querystring, postdata, backdata);
        }

        public FormWebData()
        {
            InitializeComponent();
            listen = true;
            NetBox.netForm = this;
        }

        private  void UpdateView(string id,string link,string referer,string method, string querystring, string postdata, string backdata)
        {
            if (method == "POST")
            {
                UpdateParamView(postdata);
            }
            else
            {
                UpdateParamView(querystring);
            }
            UpdateControls(id,method,link,referer,backdata);
        }

        private  void UpdateControls(string id,string method,string link,string referer,string backdata,bool flag=false)
        {
            DeterMineCall(() =>
            {
                lblMethod.Text = method;
                if (method == "POST")
                {
                    lblParamType.Text = "PostData";
                }
                else
                {
                    lblParamType.Text = "QueryString";
                }
                if (!flag)
                    UpdateLinkInfo(id,link);

                rtxtBackData.Text = String.Format("Referer:{0}\r\n\r\n返回数据\r\n{1}", referer, backdata);
            });
        }
        private void UpdateLinkInfo(string id,string value)
        {
            DeterMineCall(() =>
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add("id");
                    lvi.SubItems[0].Text = id;
                    lvi.SubItems.Add("value");
                    lvi.SubItems[1].Text = value;
                    lsvLinkInfo.Items.Insert(0, lvi);
                });
        }
        private  void UpdateParamView(string parm)
        {
            if (parm != "")
                DeterMineCall(() =>
                {
                    lsvLinkValue.Items.Clear();
                    string[] values = parm.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < values.Length; i++)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.SubItems.Add("paramName");
                        lvi.SubItems[0].Text = values[i].Split('=')[0];
                        lvi.SubItems.Add("paramValue");
                        lvi.SubItems[1].Text = values[i].Split('=')[1];
                        lsvLinkValue.Items.Insert(0, lvi);
                    }
                });
            else
                DeterMineCall(() =>
                {
                    lsvLinkValue.Items.Clear();
                });
        }

        private void DeterMineCall(MethodInvoker method)
        {
            if (InvokeRequired && !this.IsDisposed)
                Invoke(method);
            else
                method();
        }

        private void lsvLinkInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count > 0)
            {
                NetInfoClass nic = (NetInfoClass)_netInfo[((ListView)sender).SelectedItems[0].SubItems[0].Text];
                if (nic.QueryString == "")
                    UpdateParamView(nic.PostData);
                else
                    UpdateParamView(nic.QueryString);
                UpdateControls(((ListView)sender).SelectedItems[0].SubItems[0].Text, nic.Method, nic.LinkInfo, nic.Referer, nic.BackData, true);
            }
        }

        private void FormWebData_FormClosing(object sender, FormClosingEventArgs e)
        {
            listen = false;
        }
    }
}
