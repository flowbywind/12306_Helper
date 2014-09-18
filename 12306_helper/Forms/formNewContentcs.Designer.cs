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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.wbNewContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.panel1.Size = new System.Drawing.Size(783, 444);
            this.panel1.TabIndex = 18;
            // 
            // wbNewContent
            // 
            this.wbNewContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbNewContent.IsWebBrowserContextMenuEnabled = false;
            this.wbNewContent.Location = new System.Drawing.Point(20, 10);
            this.wbNewContent.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbNewContent.Name = "wbNewContent";
            this.wbNewContent.Size = new System.Drawing.Size(753, 424);
            this.wbNewContent.TabIndex = 0;
            this.wbNewContent.WebBrowserShortcutsEnabled = false;
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.Transparent;
            this.lblTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTop.Font = new System.Drawing.Font("宋体", 9F);
            this.lblTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTop.Location = new System.Drawing.Point(0, 444);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(783, 18);
            this.lblTop.TabIndex = 17;
            this.lblTop.Text = "正在加载,请稍候...";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formNewContentcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(783, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formNewContentcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "最新动态";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formNewContentcs_FormClosing);
            this.Load += new System.EventHandler(this.formNewContentcs_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser wbNewContent;
        private System.Windows.Forms.Label lblTop;
    }
}