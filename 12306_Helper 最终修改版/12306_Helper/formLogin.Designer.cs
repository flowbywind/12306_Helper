namespace _12306_Helper
{
    partial class formLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRandCode = new System.Windows.Forms.TextBox();
            this.lblInfomation = new System.Windows.Forms.Label();
            this.randCode = new System.Windows.Forms.PictureBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblTop = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkUserInfo = new System.Windows.Forms.CheckBox();
            this.btnSwitchServer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.randCode)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(94, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(116, 21);
            this.txtName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名";
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.White;
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Location = new System.Drawing.Point(94, 59);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(116, 21);
            this.txtPwd.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "密  码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "验证码";
            // 
            // txtRandCode
            // 
            this.txtRandCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRandCode.Location = new System.Drawing.Point(94, 86);
            this.txtRandCode.MaxLength = 4;
            this.txtRandCode.Name = "txtRandCode";
            this.txtRandCode.Size = new System.Drawing.Size(50, 21);
            this.txtRandCode.TabIndex = 9;
            this.txtRandCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRandCode_KeyPress);
            // 
            // lblInfomation
            // 
            this.lblInfomation.ForeColor = System.Drawing.Color.Red;
            this.lblInfomation.Location = new System.Drawing.Point(3, 3);
            this.lblInfomation.Name = "lblInfomation";
            this.lblInfomation.Size = new System.Drawing.Size(257, 19);
            this.lblInfomation.TabIndex = 12;
            this.lblInfomation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // randCode
            // 
            this.randCode.Location = new System.Drawing.Point(150, 86);
            this.randCode.Name = "randCode";
            this.randCode.Size = new System.Drawing.Size(60, 20);
            this.randCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.randCode.TabIndex = 10;
            this.randCode.TabStop = false;
            this.randCode.Click += new System.EventHandler(this.randCode_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Location = new System.Drawing.Point(137, 115);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 13;
            this.btCancel.Text = "取 消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.Location = new System.Drawing.Point(44, 115);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "登 录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.lblTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTop.Location = new System.Drawing.Point(0, 0);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(269, 29);
            this.lblTop.TabIndex = 15;
            this.lblTop.Text = "登  录";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.chkUserInfo);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSwitchServer);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.randCode);
            this.panel1.Controls.Add(this.txtRandCode);
            this.panel1.Controls.Add(this.lblInfomation);
            this.panel1.Location = new System.Drawing.Point(6, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 169);
            this.panel1.TabIndex = 16;
            // 
            // chkUserInfo
            // 
            this.chkUserInfo.AutoSize = true;
            this.chkUserInfo.Checked = true;
            this.chkUserInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserInfo.Location = new System.Drawing.Point(49, 145);
            this.chkUserInfo.Name = "chkUserInfo";
            this.chkUserInfo.Size = new System.Drawing.Size(96, 16);
            this.chkUserInfo.TabIndex = 15;
            this.chkUserInfo.Text = "记住登录信息";
            this.chkUserInfo.UseVisualStyleBackColor = true;
            // 
            // btnSwitchServer
            // 
            this.btnSwitchServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSwitchServer.Location = new System.Drawing.Point(44, 171);
            this.btnSwitchServer.Name = "btnSwitchServer";
            this.btnSwitchServer.Size = new System.Drawing.Size(166, 23);
            this.btnSwitchServer.TabIndex = 14;
            this.btnSwitchServer.Text = "打开服务器自动切换";
            this.btnSwitchServer.UseVisualStyleBackColor = true;
            this.btnSwitchServer.Click += new System.EventHandler(this.btnSwitchServer_Click);
            // 
            // formLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(269, 206);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(269, 236);
            this.MinimumSize = new System.Drawing.Size(269, 206);
            this.Name = "formLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.formLogin_Load);
            this.Shown += new System.EventHandler(this.formLogin_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.randCode)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRandCode;
        private System.Windows.Forms.Label lblInfomation;
        private System.Windows.Forms.PictureBox randCode;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkUserInfo;
        private System.Windows.Forms.Button btnSwitchServer;
    }
}