namespace _12306_Helper.Controls
{
    partial class LoginMain
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cboName = new System.Windows.Forms.ComboBox();
            this.chkUserInfo = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.lblClearList = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.randCode = new System.Windows.Forms.PictureBox();
            this.txtRandCode = new System.Windows.Forms.TextBox();
            this.lblInfomation = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randCode)).BeginInit();
            this.SuspendLayout();
            // 
            // cboName
            // 
            this.cboName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(87, 31);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(168, 20);
            this.cboName.TabIndex = 0;
            // 
            // chkUserInfo
            // 
            this.chkUserInfo.AutoSize = true;
            this.chkUserInfo.Checked = true;
            this.chkUserInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserInfo.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chkUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkUserInfo.Location = new System.Drawing.Point(41, 142);
            this.chkUserInfo.Name = "chkUserInfo";
            this.chkUserInfo.Size = new System.Drawing.Size(75, 21);
            this.chkUserInfo.TabIndex = 5;
            this.chkUserInfo.Text = "记住账号";
            this.chkUserInfo.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogin.Location = new System.Drawing.Point(66, 114);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "登 录";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btCancel.Location = new System.Drawing.Point(188, 114);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "取 消";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // lblClearList
            // 
            this.lblClearList.AutoSize = true;
            this.lblClearList.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClearList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblClearList.Location = new System.Drawing.Point(144, 146);
            this.lblClearList.Name = "lblClearList";
            this.lblClearList.Size = new System.Drawing.Size(113, 12);
            this.lblClearList.TabIndex = 14;
            this.lblClearList.Text = "[双击清空账号列表]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名";
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.White;
            this.txtPwd.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txtPwd.Location = new System.Drawing.Point(87, 58);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(168, 23);
            this.txtPwd.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblClearList);
            this.panel1.Controls.Add(this.cboName);
            this.panel1.Controls.Add(this.chkUserInfo);
            this.panel1.Controls.Add(this.txtPwd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.randCode);
            this.panel1.Controls.Add(this.txtRandCode);
            this.panel1.Controls.Add(this.lblInfomation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 184);
            this.panel1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(38, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "密  码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(38, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "验证码";
            // 
            // randCode
            // 
            this.randCode.Image = global::_12306_Helper.Properties.Resources.loading;
            this.randCode.Location = new System.Drawing.Point(172, 84);
            this.randCode.Name = "randCode";
            this.randCode.Size = new System.Drawing.Size(83, 26);
            this.randCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.randCode.TabIndex = 10;
            this.randCode.TabStop = false;
            // 
            // txtRandCode
            // 
            this.txtRandCode.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.txtRandCode.Location = new System.Drawing.Point(87, 85);
            this.txtRandCode.MaxLength = 4;
            this.txtRandCode.Name = "txtRandCode";
            this.txtRandCode.Size = new System.Drawing.Size(75, 25);
            this.txtRandCode.TabIndex = 2;
            // 
            // lblInfomation
            // 
            this.lblInfomation.ForeColor = System.Drawing.Color.Red;
            this.lblInfomation.Location = new System.Drawing.Point(3, 3);
            this.lblInfomation.Name = "lblInfomation";
            this.lblInfomation.Size = new System.Drawing.Size(288, 19);
            this.lblInfomation.TabIndex = 12;
            this.lblInfomation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "LoginMain";
            this.Size = new System.Drawing.Size(309, 184);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboName;
        private System.Windows.Forms.CheckBox chkUserInfo;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lblClearList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox randCode;
        private System.Windows.Forms.TextBox txtRandCode;
        private System.Windows.Forms.Label lblInfomation;
    }
}
