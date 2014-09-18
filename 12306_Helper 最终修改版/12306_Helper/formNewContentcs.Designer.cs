namespace _12306_Helper
{
    partial class formNewContentcs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formNewContentcs));
            this.panel1 = new System.Windows.Forms.Panel();
            this.wbNewContent = new System.Windows.Forms.WebBrowser();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.wbNewContent);
            this.panel1.Location = new System.Drawing.Point(8, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 208);
            this.panel1.TabIndex = 18;
            // 
            // wbNewContent
            // 
            this.wbNewContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNewContent.IsWebBrowserContextMenuEnabled = false;
            this.wbNewContent.Location = new System.Drawing.Point(0, 0);
            this.wbNewContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNewContent.Name = "wbNewContent";
            this.wbNewContent.ScrollBarsEnabled = false;
            this.wbNewContent.Size = new System.Drawing.Size(468, 208);
            this.wbNewContent.TabIndex = 0;
            this.wbNewContent.WebBrowserShortcutsEnabled = false;
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.lblTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTop.Location = new System.Drawing.Point(0, 0);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(484, 26);
            this.lblTop.TabIndex = 17;
            this.lblTop.Text = "正在加载,请稍候...";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseDown);
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(460, 6);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(16, 16);
            this.lblClose.TabIndex = 20;
            this.lblClose.Text = "×";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // formNewContentcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(484, 243);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formNewContentcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "最新动态";
            this.Load += new System.EventHandler(this.formNewContentcs_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser wbNewContent;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblClose;
    }
}