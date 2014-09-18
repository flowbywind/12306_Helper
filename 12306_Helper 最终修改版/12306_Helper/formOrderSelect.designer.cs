namespace _12306_Helper
{
    partial class formOrderSelect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formOrderSelect));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGoIE = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.dgvUnfinisedOrder = new System.Windows.Forms.DataGridView();
            this.TrainDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrainCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrainStationInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrainNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassengerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelectOrder = new System.Windows.Forms.Button();
            this.txtPassengerName = new System.Windows.Forms.TextBox();
            this.txtTrainCode = new System.Windows.Forms.TextBox();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.cboSelectMode = new System.Windows.Forms.ComboBox();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.flCompletedOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMini = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnfinisedOrder)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGoIE);
            this.panel1.Controls.Add(this.btnCancelOrder);
            this.panel1.Controls.Add(this.dgvUnfinisedOrder);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.flCompletedOrder);
            this.panel1.Location = new System.Drawing.Point(5, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 432);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "未完成的订单 | 失败的假订单";
            // 
            // btnGoIE
            // 
            this.btnGoIE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoIE.BackColor = System.Drawing.Color.Transparent;
            this.btnGoIE.Location = new System.Drawing.Point(605, 9);
            this.btnGoIE.Name = "btnGoIE";
            this.btnGoIE.Size = new System.Drawing.Size(75, 23);
            this.btnGoIE.TabIndex = 9;
            this.btnGoIE.Text = "登录到IE";
            this.btnGoIE.UseVisualStyleBackColor = false;
            this.btnGoIE.Click += new System.EventHandler(this.btnGoIE_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelOrder.Location = new System.Drawing.Point(687, 9);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(75, 23);
            this.btnCancelOrder.TabIndex = 9;
            this.btnCancelOrder.Text = "取消订单";
            this.btnCancelOrder.UseVisualStyleBackColor = false;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // dgvUnfinisedOrder
            // 
            this.dgvUnfinisedOrder.AllowUserToAddRows = false;
            this.dgvUnfinisedOrder.AllowUserToDeleteRows = false;
            this.dgvUnfinisedOrder.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.dgvUnfinisedOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUnfinisedOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUnfinisedOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnfinisedOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUnfinisedOrder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUnfinisedOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUnfinisedOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnfinisedOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrainDate,
            this.TrainCode,
            this.TrainStationInfo,
            this.TrainNo,
            this.SeatType,
            this.TicketType,
            this.TicketPrice,
            this.PassengerName,
            this.Status,
            this.StatusInfo});
            this.dgvUnfinisedOrder.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvUnfinisedOrder.Location = new System.Drawing.Point(5, 36);
            this.dgvUnfinisedOrder.Name = "dgvUnfinisedOrder";
            this.dgvUnfinisedOrder.ReadOnly = true;
            this.dgvUnfinisedOrder.RowHeadersVisible = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUnfinisedOrder.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvUnfinisedOrder.RowTemplate.Height = 23;
            this.dgvUnfinisedOrder.Size = new System.Drawing.Size(766, 125);
            this.dgvUnfinisedOrder.TabIndex = 6;
            // 
            // TrainDate
            // 
            this.TrainDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TrainDate.DataPropertyName = "TrainDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TrainDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.TrainDate.HeaderText = "发车日期";
            this.TrainDate.Name = "TrainDate";
            this.TrainDate.ReadOnly = true;
            this.TrainDate.Width = 76;
            // 
            // TrainCode
            // 
            this.TrainCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TrainCode.DataPropertyName = "TrainCode";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TrainCode.DefaultCellStyle = dataGridViewCellStyle4;
            this.TrainCode.HeaderText = "车次";
            this.TrainCode.Name = "TrainCode";
            this.TrainCode.ReadOnly = true;
            this.TrainCode.Width = 52;
            // 
            // TrainStationInfo
            // 
            this.TrainStationInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TrainStationInfo.DataPropertyName = "TrainStationInfo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TrainStationInfo.DefaultCellStyle = dataGridViewCellStyle5;
            this.TrainStationInfo.HeaderText = "发到站";
            this.TrainStationInfo.Name = "TrainStationInfo";
            this.TrainStationInfo.ReadOnly = true;
            // 
            // TrainNo
            // 
            this.TrainNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TrainNo.DataPropertyName = "TrainNo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TrainNo.DefaultCellStyle = dataGridViewCellStyle6;
            this.TrainNo.HeaderText = "座位信息";
            this.TrainNo.Name = "TrainNo";
            this.TrainNo.ReadOnly = true;
            this.TrainNo.Width = 76;
            // 
            // SeatType
            // 
            this.SeatType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SeatType.DataPropertyName = "SeatType";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SeatType.DefaultCellStyle = dataGridViewCellStyle7;
            this.SeatType.HeaderText = "席别";
            this.SeatType.Name = "SeatType";
            this.SeatType.ReadOnly = true;
            this.SeatType.Width = 52;
            // 
            // TicketType
            // 
            this.TicketType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TicketType.DataPropertyName = "TicketType";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TicketType.DefaultCellStyle = dataGridViewCellStyle8;
            this.TicketType.HeaderText = "票种";
            this.TicketType.Name = "TicketType";
            this.TicketType.ReadOnly = true;
            this.TicketType.Width = 52;
            // 
            // TicketPrice
            // 
            this.TicketPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TicketPrice.DataPropertyName = "TicketPrice";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TicketPrice.DefaultCellStyle = dataGridViewCellStyle9;
            this.TicketPrice.HeaderText = "票价";
            this.TicketPrice.Name = "TicketPrice";
            this.TicketPrice.ReadOnly = true;
            this.TicketPrice.Width = 52;
            // 
            // PassengerName
            // 
            this.PassengerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PassengerName.DataPropertyName = "PassengerName";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PassengerName.DefaultCellStyle = dataGridViewCellStyle10;
            this.PassengerName.HeaderText = "乘车人";
            this.PassengerName.Name = "PassengerName";
            this.PassengerName.ReadOnly = true;
            this.PassengerName.Width = 64;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status.DataPropertyName = "Status";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Status.DefaultCellStyle = dataGridViewCellStyle11;
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 52;
            // 
            // StatusInfo
            // 
            this.StatusInfo.DataPropertyName = "StatusInfo";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.StatusInfo.DefaultCellStyle = dataGridViewCellStyle12;
            this.StatusInfo.HeaderText = "详细信息";
            this.StatusInfo.Name = "StatusInfo";
            this.StatusInfo.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnSelectOrder);
            this.panel2.Controls.Add(this.txtPassengerName);
            this.panel2.Controls.Add(this.txtTrainCode);
            this.panel2.Controls.Add(this.dtStartDate);
            this.panel2.Controls.Add(this.dtEndDate);
            this.panel2.Controls.Add(this.cboSelectMode);
            this.panel2.Controls.Add(this.txtOrderID);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Location = new System.Drawing.Point(5, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 59);
            this.panel2.TabIndex = 8;
            // 
            // btnSelectOrder
            // 
            this.btnSelectOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectOrder.Location = new System.Drawing.Point(682, 31);
            this.btnSelectOrder.Name = "btnSelectOrder";
            this.btnSelectOrder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectOrder.TabIndex = 12;
            this.btnSelectOrder.Text = "查询";
            this.btnSelectOrder.UseVisualStyleBackColor = true;
            this.btnSelectOrder.Click += new System.EventHandler(this.btnSelectOrder_Click);
            // 
            // txtPassengerName
            // 
            this.txtPassengerName.Location = new System.Drawing.Point(519, 29);
            this.txtPassengerName.Name = "txtPassengerName";
            this.txtPassengerName.Size = new System.Drawing.Size(144, 21);
            this.txtPassengerName.TabIndex = 11;
            // 
            // txtTrainCode
            // 
            this.txtTrainCode.Location = new System.Drawing.Point(299, 29);
            this.txtTrainCode.Name = "txtTrainCode";
            this.txtTrainCode.Size = new System.Drawing.Size(140, 21);
            this.txtTrainCode.TabIndex = 10;
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(299, 6);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(140, 21);
            this.dtStartDate.TabIndex = 9;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(519, 6);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(144, 21);
            this.dtEndDate.TabIndex = 8;
            // 
            // cboSelectMode
            // 
            this.cboSelectMode.FormattingEnabled = true;
            this.cboSelectMode.Items.AddRange(new object[] {
            "按订票日期查询",
            "按订票车次查询"});
            this.cboSelectMode.Location = new System.Drawing.Point(98, 6);
            this.cboSelectMode.Name = "cboSelectMode";
            this.cboSelectMode.Size = new System.Drawing.Size(121, 20);
            this.cboSelectMode.TabIndex = 7;
            this.cboSelectMode.Text = "按订票日期查询";
            this.cboSelectMode.SelectedIndexChanged += new System.EventHandler(this.cboSelectMode_SelectedIndexChanged);
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(98, 29);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.Size = new System.Drawing.Size(121, 21);
            this.txtOrderID.TabIndex = 6;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(15, 9);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(77, 12);
            this.label29.TabIndex = 5;
            this.label29.Text = "查询日期类型";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(239, 33);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 12);
            this.label28.TabIndex = 4;
            this.label28.Text = "车次";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(460, 32);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 12);
            this.label27.TabIndex = 3;
            this.label27.Text = "乘客姓名";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(38, 33);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 12);
            this.label26.TabIndex = 2;
            this.label26.Text = "订单号";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(460, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 1;
            this.label25.Text = "结束日期";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(239, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "起始日期";
            // 
            // flCompletedOrder
            // 
            this.flCompletedOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flCompletedOrder.AutoScroll = true;
            this.flCompletedOrder.Location = new System.Drawing.Point(5, 238);
            this.flCompletedOrder.Name = "flCompletedOrder";
            this.flCompletedOrder.Size = new System.Drawing.Size(766, 188);
            this.flCompletedOrder.TabIndex = 13;
            // 
            // lblMini
            // 
            this.lblMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblMini.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMini.ForeColor = System.Drawing.Color.White;
            this.lblMini.Location = new System.Drawing.Point(744, 6);
            this.lblMini.Name = "lblMini";
            this.lblMini.Size = new System.Drawing.Size(16, 16);
            this.lblMini.TabIndex = 50;
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
            this.lblClose.Location = new System.Drawing.Point(765, 6);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(16, 16);
            this.lblClose.TabIndex = 49;
            this.lblClose.Text = "×";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.lblTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTop.Location = new System.Drawing.Point(0, 0);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(787, 29);
            this.lblTop.TabIndex = 48;
            this.lblTop.Text = " 订 单 查 询";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseDown);
            // 
            // formOrderSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(787, 463);
            this.Controls.Add(this.lblMini);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formOrderSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人订单";
            this.Load += new System.EventHandler(this.formOrderSelect_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnfinisedOrder)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSelectOrder;
        private System.Windows.Forms.TextBox txtPassengerName;
        private System.Windows.Forms.TextBox txtTrainCode;
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.ComboBox cboSelectMode;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView dgvUnfinisedOrder;
        private System.Windows.Forms.Label lblMini;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.FlowLayoutPanel flCompletedOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainStationInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassengerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusInfo;
        private System.Windows.Forms.Button btnGoIE;
        private System.Windows.Forms.Label label1;
    }
}