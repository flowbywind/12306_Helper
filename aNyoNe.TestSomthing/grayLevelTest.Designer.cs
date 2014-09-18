namespace aNyoNe.TestSomthing
{
    partial class grayLevelTest
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuFileOpen = new System.Windows.Forms.Button();
            this.menuFileSave = new System.Windows.Forms.Button();
            this.menu2Gray = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Location = new System.Drawing.Point(176, 478);
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.Size = new System.Drawing.Size(75, 23);
            this.menuFileOpen.TabIndex = 0;
            this.menuFileOpen.Text = "选择图片";
            this.menuFileOpen.UseVisualStyleBackColor = true;
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Location = new System.Drawing.Point(314, 478);
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.Size = new System.Drawing.Size(75, 23);
            this.menuFileSave.TabIndex = 0;
            this.menuFileSave.Text = "保存图片";
            this.menuFileSave.UseVisualStyleBackColor = true;
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menu2Gray
            // 
            this.menu2Gray.Location = new System.Drawing.Point(455, 478);
            this.menu2Gray.Name = "menu2Gray";
            this.menu2Gray.Size = new System.Drawing.Size(75, 23);
            this.menu2Gray.TabIndex = 0;
            this.menu2Gray.Text = "黑白处理";
            this.menu2Gray.UseVisualStyleBackColor = true;
            this.menu2Gray.Click += new System.EventHandler(this.menu2Gray_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(37, 24);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(609, 422);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择图片";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grayLevelTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 533);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menu2Gray);
            this.Controls.Add(this.menuFileSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuFileOpen);
            this.Name = "grayLevelTest";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button menuFileOpen;
        private System.Windows.Forms.Button menuFileSave;
        private System.Windows.Forms.Button menu2Gray;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button button1;

    }
}

