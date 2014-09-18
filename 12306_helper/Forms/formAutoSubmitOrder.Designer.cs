namespace _12306_Helper.Forms
{
    partial class formAutoSubmitOrder
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAutoSubmitOrder));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblState1 = new System.Windows.Forms.Label();
            this.txtRandCode1 = new System.Windows.Forms.TextBox();
            this.randCode1 = new System.Windows.Forms.PictureBox();
            this.plInfoBoard = new System.Windows.Forms.Panel();
            this.lblTrainNoInfo = new System.Windows.Forms.Label();
            this.dgvPassenger = new System.Windows.Forms.DataGridView();
            this.xingming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xibie = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.piaozhong = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.zhengjian = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.zhengjianhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shoujihao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randCode1)).BeginInit();
            this.plInfoBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassenger)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblState1);
            this.panel1.Controls.Add(this.txtRandCode1);
            this.panel1.Controls.Add(this.randCode1);
            this.panel1.Controls.Add(this.plInfoBoard);
            this.panel1.Controls.Add(this.dgvPassenger);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(836, 247);
            this.panel1.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(634, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 40;
            this.label9.Text = "验证码";
            // 
            // lblState1
            // 
            this.lblState1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblState1.AutoSize = true;
            this.lblState1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblState1.Location = new System.Drawing.Point(21, 218);
            this.lblState1.Name = "lblState1";
            this.lblState1.Size = new System.Drawing.Size(0, 12);
            this.lblState1.TabIndex = 43;
            // 
            // txtRandCode1
            // 
            this.txtRandCode1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRandCode1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRandCode1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRandCode1.Location = new System.Drawing.Point(678, 212);
            this.txtRandCode1.MaxLength = 4;
            this.txtRandCode1.Name = "txtRandCode1";
            this.txtRandCode1.Size = new System.Drawing.Size(50, 23);
            this.txtRandCode1.TabIndex = 41;
            this.txtRandCode1.TextChanged += new System.EventHandler(this.txtRandCode1_TextChanged_1);
            this.txtRandCode1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRandCode1_KeyPress);
            // 
            // randCode1
            // 
            this.randCode1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.randCode1.Image = global::_12306_Helper.Properties.Resources.loading;
            this.randCode1.Location = new System.Drawing.Point(734, 208);
            this.randCode1.Name = "randCode1";
            this.randCode1.Size = new System.Drawing.Size(89, 32);
            this.randCode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.randCode1.TabIndex = 39;
            this.randCode1.TabStop = false;
            // 
            // plInfoBoard
            // 
            this.plInfoBoard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plInfoBoard.BackColor = System.Drawing.Color.White;
            this.plInfoBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plInfoBoard.Controls.Add(this.lblTrainNoInfo);
            this.plInfoBoard.ForeColor = System.Drawing.Color.Black;
            this.plInfoBoard.Location = new System.Drawing.Point(13, 13);
            this.plInfoBoard.Name = "plInfoBoard";
            this.plInfoBoard.Padding = new System.Windows.Forms.Padding(3);
            this.plInfoBoard.Size = new System.Drawing.Size(810, 59);
            this.plInfoBoard.TabIndex = 39;
            // 
            // lblTrainNoInfo
            // 
            this.lblTrainNoInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrainNoInfo.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.lblTrainNoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTrainNoInfo.Location = new System.Drawing.Point(17, 13);
            this.lblTrainNoInfo.Name = "lblTrainNoInfo";
            this.lblTrainNoInfo.Size = new System.Drawing.Size(773, 34);
            this.lblTrainNoInfo.TabIndex = 0;
            this.lblTrainNoInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvPassenger
            // 
            this.dgvPassenger.AllowUserToAddRows = false;
            this.dgvPassenger.AllowUserToDeleteRows = false;
            this.dgvPassenger.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvPassenger.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPassenger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPassenger.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPassenger.BackgroundColor = System.Drawing.Color.White;
            this.dgvPassenger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassenger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xingming,
            this.xibie,
            this.piaozhong,
            this.zhengjian,
            this.zhengjianhao,
            this.shoujihao});
            this.dgvPassenger.GridColor = System.Drawing.Color.Silver;
            this.dgvPassenger.Location = new System.Drawing.Point(13, 75);
            this.dgvPassenger.MultiSelect = false;
            this.dgvPassenger.Name = "dgvPassenger";
            this.dgvPassenger.RowHeadersVisible = false;
            this.dgvPassenger.RowTemplate.Height = 21;
            this.dgvPassenger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPassenger.Size = new System.Drawing.Size(810, 130);
            this.dgvPassenger.TabIndex = 37;
            // 
            // xingming
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.xingming.DefaultCellStyle = dataGridViewCellStyle2;
            this.xingming.HeaderText = "姓名";
            this.xingming.MaxInputLength = 10;
            this.xingming.Name = "xingming";
            // 
            // xibie
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.xibie.DefaultCellStyle = dataGridViewCellStyle3;
            this.xibie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xibie.HeaderText = "席别";
            this.xibie.Items.AddRange(new object[] {
            "二等座",
            "高级软卧",
            "软卧",
            "软座",
            "商务座",
            "特等座",
            "无座",
            "一等座",
            "硬卧",
            "硬座"});
            this.xibie.Name = "xibie";
            // 
            // piaozhong
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.piaozhong.DefaultCellStyle = dataGridViewCellStyle4;
            this.piaozhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.piaozhong.HeaderText = "票种";
            this.piaozhong.Items.AddRange(new object[] {
            "成人票",
            "儿童票",
            "学生票",
            "残军票"});
            this.piaozhong.Name = "piaozhong";
            // 
            // zhengjian
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.zhengjian.DefaultCellStyle = dataGridViewCellStyle5;
            this.zhengjian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zhengjian.HeaderText = "证件类型";
            this.zhengjian.Items.AddRange(new object[] {
            "二代身份证",
            "一代身份证",
            "港澳通行证",
            "台湾通行证",
            "护照"});
            this.zhengjian.Name = "zhengjian";
            // 
            // zhengjianhao
            // 
            this.zhengjianhao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.zhengjianhao.DefaultCellStyle = dataGridViewCellStyle6;
            this.zhengjianhao.HeaderText = "证件号";
            this.zhengjianhao.MaxInputLength = 18;
            this.zhengjianhao.Name = "zhengjianhao";
            // 
            // shoujihao
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.shoujihao.DefaultCellStyle = dataGridViewCellStyle7;
            this.shoujihao.HeaderText = "手机号";
            this.shoujihao.MaxInputLength = 11;
            this.shoujihao.Name = "shoujihao";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // formAutoSubmitOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(836, 247);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formAutoSubmitOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单提交";
            this.Load += new System.EventHandler(this.formAutoSubmitOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randCode1)).EndInit();
            this.plInfoBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassenger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblState1;
        private System.Windows.Forms.TextBox txtRandCode1;
        private System.Windows.Forms.PictureBox randCode1;
        private System.Windows.Forms.Panel plInfoBoard;
        private System.Windows.Forms.Label lblTrainNoInfo;
        private System.Windows.Forms.DataGridView dgvPassenger;
        private System.Windows.Forms.DataGridViewTextBoxColumn xingming;
        private System.Windows.Forms.DataGridViewComboBoxColumn xibie;
        private System.Windows.Forms.DataGridViewComboBoxColumn piaozhong;
        private System.Windows.Forms.DataGridViewComboBoxColumn zhengjian;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhengjianhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn shoujihao;
        private System.Windows.Forms.Timer timer2;
    }
}