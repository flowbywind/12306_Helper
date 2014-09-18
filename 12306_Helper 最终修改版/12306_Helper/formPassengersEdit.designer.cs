namespace _12306_Helper
{
    partial class formPassengersEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPassengersEdit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPassenger = new System.Windows.Forms.DataGridView();
            this.passenger_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passenger_type_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.passenger_id_type_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.card_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plStudent = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboIDType = new System.Windows.Forms.ComboBox();
            this.txtIDCode = new System.Windows.Forms.TextBox();
            this.txtMobileNO = new System.Windows.Forms.TextBox();
            this.cboTicketType = new System.Windows.Forms.ComboBox();
            this.txtPassengerName = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblMini = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassenger)).BeginInit();
            this.plStudent.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.dgvPassenger);
            this.panel1.Controls.Add(this.plStudent);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(5, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 390);
            this.panel1.TabIndex = 0;
            // 
            // dgvPassenger
            // 
            this.dgvPassenger.AllowUserToAddRows = false;
            this.dgvPassenger.AllowUserToDeleteRows = false;
            this.dgvPassenger.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.dgvPassenger.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPassenger.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPassenger.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvPassenger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassenger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.passenger_name,
            this.passenger_type_name,
            this.passenger_id_type_name,
            this.card_no,
            this.mobile_no});
            this.dgvPassenger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPassenger.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvPassenger.Location = new System.Drawing.Point(0, 110);
            this.dgvPassenger.MultiSelect = false;
            this.dgvPassenger.Name = "dgvPassenger";
            this.dgvPassenger.ReadOnly = true;
            this.dgvPassenger.RowHeadersVisible = false;
            this.dgvPassenger.RowTemplate.Height = 21;
            this.dgvPassenger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPassenger.Size = new System.Drawing.Size(802, 280);
            this.dgvPassenger.TabIndex = 38;
            this.dgvPassenger.DataSourceChanged += new System.EventHandler(this.dgvPassenger_DataSourceChanged);
            this.dgvPassenger.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPassenger_CellClick);
            // 
            // passenger_name
            // 
            this.passenger_name.DataPropertyName = "passenger_name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.passenger_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.passenger_name.HeaderText = "姓名";
            this.passenger_name.MaxInputLength = 10;
            this.passenger_name.Name = "passenger_name";
            this.passenger_name.ReadOnly = true;
            // 
            // passenger_type_name
            // 
            this.passenger_type_name.DataPropertyName = "passenger_type_name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.passenger_type_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.passenger_type_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passenger_type_name.HeaderText = "票种";
            this.passenger_type_name.Items.AddRange(new object[] {
            "成人",
            "儿童",
            "学生",
            "残军"});
            this.passenger_type_name.Name = "passenger_type_name";
            this.passenger_type_name.ReadOnly = true;
            // 
            // passenger_id_type_name
            // 
            this.passenger_id_type_name.DataPropertyName = "passenger_id_type_name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.passenger_id_type_name.DefaultCellStyle = dataGridViewCellStyle4;
            this.passenger_id_type_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passenger_id_type_name.HeaderText = "证件类型";
            this.passenger_id_type_name.Items.AddRange(new object[] {
            "二代身份证",
            "一代身份证",
            "港澳通行证",
            "台湾通行证",
            "护照"});
            this.passenger_id_type_name.Name = "passenger_id_type_name";
            this.passenger_id_type_name.ReadOnly = true;
            // 
            // card_no
            // 
            this.card_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.card_no.DataPropertyName = "card_no";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.card_no.DefaultCellStyle = dataGridViewCellStyle5;
            this.card_no.HeaderText = "证件号";
            this.card_no.MaxInputLength = 18;
            this.card_no.Name = "card_no";
            this.card_no.ReadOnly = true;
            // 
            // mobile_no
            // 
            this.mobile_no.DataPropertyName = "mobile_no";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.mobile_no.DefaultCellStyle = dataGridViewCellStyle6;
            this.mobile_no.HeaderText = "手机号";
            this.mobile_no.MaxInputLength = 11;
            this.mobile_no.Name = "mobile_no";
            this.mobile_no.ReadOnly = true;
            // 
            // plStudent
            // 
            this.plStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plStudent.Controls.Add(this.textBox8);
            this.plStudent.Controls.Add(this.textBox7);
            this.plStudent.Controls.Add(this.textBox6);
            this.plStudent.Controls.Add(this.textBox5);
            this.plStudent.Controls.Add(this.textBox1);
            this.plStudent.Controls.Add(this.textBox4);
            this.plStudent.Controls.Add(this.textBox3);
            this.plStudent.Controls.Add(this.textBox2);
            this.plStudent.Controls.Add(this.comboBox4);
            this.plStudent.Controls.Add(this.comboBox3);
            this.plStudent.Controls.Add(this.label1);
            this.plStudent.Controls.Add(this.label2);
            this.plStudent.Controls.Add(this.label7);
            this.plStudent.Controls.Add(this.label3);
            this.plStudent.Controls.Add(this.label6);
            this.plStudent.Controls.Add(this.label10);
            this.plStudent.Controls.Add(this.label9);
            this.plStudent.Controls.Add(this.label8);
            this.plStudent.Controls.Add(this.label4);
            this.plStudent.Controls.Add(this.label5);
            this.plStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.plStudent.Location = new System.Drawing.Point(0, 43);
            this.plStudent.Name = "plStudent";
            this.plStudent.Size = new System.Drawing.Size(802, 67);
            this.plStudent.TabIndex = 39;
            this.plStudent.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(695, 34);
            this.textBox6.MaxLength = 11;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(94, 21);
            this.textBox6.TabIndex = 26;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(570, 34);
            this.textBox5.MaxLength = 11;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(96, 21);
            this.textBox5.TabIndex = 25;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(404, 8);
            this.textBox1.MaxLength = 18;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 21);
            this.textBox1.TabIndex = 23;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(404, 34);
            this.textBox4.MaxLength = 11;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(99, 21);
            this.textBox4.TabIndex = 22;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(41, 35);
            this.textBox3.MaxLength = 11;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(77, 21);
            this.textBox3.TabIndex = 22;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(570, 8);
            this.textBox2.MaxLength = 11;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(219, 21);
            this.textBox2.TabIndex = 22;
            // 
            // comboBox4
            // 
            this.comboBox4.Enabled = false;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(288, 35);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(56, 20);
            this.comboBox4.TabIndex = 19;
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox3.Location = new System.Drawing.Point(157, 36);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(56, 20);
            this.comboBox3.TabIndex = 19;
            this.comboBox3.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "学校所在省份";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(539, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "班级";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(232, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "入学年份";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "院系";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "学制";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(672, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "至";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(514, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "优惠区间";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(349, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "优惠卡号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "学校";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "学号";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.cboIDType);
            this.panel3.Controls.Add(this.txtIDCode);
            this.panel3.Controls.Add(this.txtMobileNO);
            this.panel3.Controls.Add(this.cboTicketType);
            this.panel3.Controls.Add(this.txtPassengerName);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Controls.Add(this.label33);
            this.panel3.Controls.Add(this.label34);
            this.panel3.Controls.Add(this.label35);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(802, 43);
            this.panel3.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(665, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(58, 23);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboIDType
            // 
            this.cboIDType.FormattingEnabled = true;
            this.cboIDType.Items.AddRange(new object[] {
            "二代身份证",
            "一代身份证",
            "港澳通行证",
            "台湾通行证",
            "护照"});
            this.cboIDType.Location = new System.Drawing.Point(273, 11);
            this.cboIDType.Name = "cboIDType";
            this.cboIDType.Size = new System.Drawing.Size(84, 20);
            this.cboIDType.TabIndex = 24;
            this.cboIDType.Text = "二代身份证";
            // 
            // txtIDCode
            // 
            this.txtIDCode.Location = new System.Drawing.Point(403, 11);
            this.txtIDCode.MaxLength = 18;
            this.txtIDCode.Name = "txtIDCode";
            this.txtIDCode.Size = new System.Drawing.Size(123, 21);
            this.txtIDCode.TabIndex = 23;
            // 
            // txtMobileNO
            // 
            this.txtMobileNO.Location = new System.Drawing.Point(575, 11);
            this.txtMobileNO.MaxLength = 11;
            this.txtMobileNO.Name = "txtMobileNO";
            this.txtMobileNO.Size = new System.Drawing.Size(80, 21);
            this.txtMobileNO.TabIndex = 22;
            // 
            // cboTicketType
            // 
            this.cboTicketType.Enabled = false;
            this.cboTicketType.FormattingEnabled = true;
            this.cboTicketType.Items.AddRange(new object[] {
            "成人",
            "儿童",
            "学生",
            "残军"});
            this.cboTicketType.Location = new System.Drawing.Point(158, 11);
            this.cboTicketType.Name = "cboTicketType";
            this.cboTicketType.Size = new System.Drawing.Size(56, 20);
            this.cboTicketType.TabIndex = 19;
            this.cboTicketType.Text = "成人";
            this.cboTicketType.SelectedIndexChanged += new System.EventHandler(this.cboTicketType_SelectedIndexChanged);
            // 
            // txtPassengerName
            // 
            this.txtPassengerName.Location = new System.Drawing.Point(42, 11);
            this.txtPassengerName.MaxLength = 20;
            this.txtPassengerName.Name = "txtPassengerName";
            this.txtPassengerName.Size = new System.Drawing.Size(77, 21);
            this.txtPassengerName.TabIndex = 18;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 16);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 12);
            this.label30.TabIndex = 17;
            this.label30.Text = "姓名";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(530, 15);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 12);
            this.label31.TabIndex = 16;
            this.label31.Text = "手机号";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(360, 15);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(41, 12);
            this.label33.TabIndex = 14;
            this.label33.Text = "证件号";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(217, 15);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.TabIndex = 13;
            this.label34.Text = "证件类型";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(123, 16);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(29, 12);
            this.label35.TabIndex = 12;
            this.label35.Text = "票种";
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.lblTop.ForeColor = System.Drawing.Color.Blue;
            this.lblTop.Location = new System.Drawing.Point(0, 0);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(813, 29);
            this.lblTop.TabIndex = 49;
            this.lblTop.Text = "编 辑 联 系 人";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseDown);
            // 
            // lblMini
            // 
            this.lblMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblMini.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMini.ForeColor = System.Drawing.Color.White;
            this.lblMini.Location = new System.Drawing.Point(773, 6);
            this.lblMini.Name = "lblMini";
            this.lblMini.Size = new System.Drawing.Size(16, 16);
            this.lblMini.TabIndex = 53;
            this.lblMini.Text = "－";
            this.lblMini.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMini.Click += new System.EventHandler(this.lblMini_Click);
            this.lblMini.MouseEnter += new System.EventHandler(this.lblMini_MouseEnter);
            this.lblMini.MouseLeave += new System.EventHandler(this.lblMini_MouseLeave);
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(791, 6);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(16, 16);
            this.lblClose.TabIndex = 52;
            this.lblClose.Text = "×";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(732, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(92, 9);
            this.textBox7.MaxLength = 11;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(85, 21);
            this.textBox7.TabIndex = 27;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(221, 9);
            this.textBox8.MaxLength = 11;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(135, 21);
            this.textBox8.TabIndex = 28;
            // 
            // formPassengersEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(813, 427);
            this.Controls.Add(this.lblMini);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formPassengersEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formPassengersEdit";
            this.Load += new System.EventHandler(this.formPassengersEdit_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassenger)).EndInit();
            this.plStudent.ResumeLayout(false);
            this.plStudent.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboIDType;
        private System.Windows.Forms.TextBox txtIDCode;
        private System.Windows.Forms.TextBox txtMobileNO;
        private System.Windows.Forms.ComboBox cboTicketType;
        private System.Windows.Forms.TextBox txtPassengerName;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblMini;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.DataGridView dgvPassenger;
        private System.Windows.Forms.DataGridViewTextBoxColumn passenger_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn passenger_type_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn passenger_id_type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn card_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile_no;
        private System.Windows.Forms.Panel plStudent;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;

    }
}