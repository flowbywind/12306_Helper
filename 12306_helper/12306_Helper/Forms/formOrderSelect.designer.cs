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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formOrderSelect));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnGoIE = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.dgvUnfinisedOrder = new System.Windows.Forms.DataGridView();
            this.TrainDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrainCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrainStationInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TicketPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassengerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderLoseTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelectOrder = new System.Windows.Forms.Button();
            this.dtStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtEndDate = new System.Windows.Forms.DateTimePicker();
            this.cboSelectMode = new System.Windows.Forms.ComboBox();
            this.txtQueryParam = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.flCompletedOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnfinisedOrder)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.btnGoIE);
            this.panel1.Controls.Add(this.btnCancelOrder);
            this.panel1.Controls.Add(this.dgvUnfinisedOrder);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.flCompletedOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 463);
            this.panel1.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInfo.Location = new System.Drawing.Point(33, 18);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(167, 12);
            this.lblInfo.TabIndex = 14;
            this.lblInfo.Text = "未完成的订单 | 失败的假订单";
            // 
            // btnGoIE
            // 
            this.btnGoIE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoIE.BackColor = System.Drawing.Color.Transparent;
            this.btnGoIE.Location = new System.Drawing.Point(657, 10);
            this.btnGoIE.Name = "btnGoIE";
            this.btnGoIE.Size = new System.Drawing.Size(75, 23);
            this.btnGoIE.TabIndex = 0;
            this.btnGoIE.Text = "登录到IE";
            this.btnGoIE.UseVisualStyleBackColor = false;
            this.btnGoIE.Click += new System.EventHandler(this.btnGoIE_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelOrder.Location = new System.Drawing.Point(739, 10);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(75, 23);
            this.btnCancelOrder.TabIndex = 1;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvUnfinisedOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUnfinisedOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUnfinisedOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnfinisedOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUnfinisedOrder.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUnfinisedOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUnfinisedOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnfinisedOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrainDate,
            this.TrainCode,
            this.TrainStationInfo,
            this.SeatType,
            this.TicketType,
            this.TicketPrice,
            this.PassengerName,
            this.Status,
            this.OrderLoseTime});
            this.dgvUnfinisedOrder.GridColor = System.Drawing.Color.Silver;
            this.dgvUnfinisedOrder.Location = new System.Drawing.Point(12, 36);
            this.dgvUnfinisedOrder.Name = "dgvUnfinisedOrder";
            this.dgvUnfinisedOrder.ReadOnly = true;
            this.dgvUnfinisedOrder.RowHeadersVisible = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvUnfinisedOrder.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvUnfinisedOrder.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgvUnfinisedOrder.RowTemplate.Height = 23;
            this.dgvUnfinisedOrder.Size = new System.Drawing.Size(822, 125);
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
            this.TrainDate.Width = 78;
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
            this.TrainCode.Width = 54;
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
            // SeatType
            // 
            this.SeatType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SeatType.DataPropertyName = "SeatType";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SeatType.DefaultCellStyle = dataGridViewCellStyle6;
            this.SeatType.HeaderText = "席别信息";
            this.SeatType.Name = "SeatType";
            this.SeatType.ReadOnly = true;
            this.SeatType.Width = 78;
            // 
            // TicketType
            // 
            this.TicketType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TicketType.DataPropertyName = "TicketType";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TicketType.DefaultCellStyle = dataGridViewCellStyle7;
            this.TicketType.HeaderText = "票种";
            this.TicketType.Name = "TicketType";
            this.TicketType.ReadOnly = true;
            this.TicketType.Width = 54;
            // 
            // TicketPrice
            // 
            this.TicketPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TicketPrice.DataPropertyName = "TicketPrice";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TicketPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.TicketPrice.HeaderText = "票价";
            this.TicketPrice.Name = "TicketPrice";
            this.TicketPrice.ReadOnly = true;
            this.TicketPrice.Width = 54;
            // 
            // PassengerName
            // 
            this.PassengerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PassengerName.DataPropertyName = "PassengerName";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PassengerName.DefaultCellStyle = dataGridViewCellStyle9;
            this.PassengerName.HeaderText = "乘车人";
            this.PassengerName.Name = "PassengerName";
            this.PassengerName.ReadOnly = true;
            this.PassengerName.Width = 66;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status.DataPropertyName = "Status";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Status.DefaultCellStyle = dataGridViewCellStyle10;
            this.Status.HeaderText = "状态";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 54;
            // 
            // OrderLoseTime
            // 
            this.OrderLoseTime.DataPropertyName = "OrderLoseTime";
            this.OrderLoseTime.HeaderText = "过期时间";
            this.OrderLoseTime.Name = "OrderLoseTime";
            this.OrderLoseTime.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSelectOrder);
            this.panel2.Controls.Add(this.dtStartDate);
            this.panel2.Controls.Add(this.dtEndDate);
            this.panel2.Controls.Add(this.cboSelectMode);
            this.panel2.Controls.Add(this.txtQueryParam);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Location = new System.Drawing.Point(12, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(822, 59);
            this.panel2.TabIndex = 8;
            // 
            // btnSelectOrder
            // 
            this.btnSelectOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectOrder.Location = new System.Drawing.Point(702, 6);
            this.btnSelectOrder.Name = "btnSelectOrder";
            this.btnSelectOrder.Size = new System.Drawing.Size(92, 44);
            this.btnSelectOrder.TabIndex = 6;
            this.btnSelectOrder.Text = "查询";
            this.btnSelectOrder.UseVisualStyleBackColor = true;
            this.btnSelectOrder.Click += new System.EventHandler(this.btnSelectOrder_Click);
            // 
            // dtStartDate
            // 
            this.dtStartDate.Location = new System.Drawing.Point(311, 6);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(140, 21);
            this.dtStartDate.TabIndex = 3;
            // 
            // dtEndDate
            // 
            this.dtEndDate.Location = new System.Drawing.Point(531, 6);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(144, 21);
            this.dtEndDate.TabIndex = 4;
            // 
            // cboSelectMode
            // 
            this.cboSelectMode.FormattingEnabled = true;
            this.cboSelectMode.Items.AddRange(new object[] {
            "按订票日期查询",
            "按乘车日期查询"});
            this.cboSelectMode.Location = new System.Drawing.Point(110, 6);
            this.cboSelectMode.Name = "cboSelectMode";
            this.cboSelectMode.Size = new System.Drawing.Size(121, 20);
            this.cboSelectMode.TabIndex = 2;
            this.cboSelectMode.Text = "按订票日期查询";
            this.cboSelectMode.SelectedIndexChanged += new System.EventHandler(this.cboSelectMode_SelectedIndexChanged);
            // 
            // txtQueryParam
            // 
            this.txtQueryParam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtQueryParam.Location = new System.Drawing.Point(29, 29);
            this.txtQueryParam.Name = "txtQueryParam";
            this.txtQueryParam.Size = new System.Drawing.Size(646, 21);
            this.txtQueryParam.TabIndex = 5;
            this.txtQueryParam.Text = "订单号/车次/乘车人";
            this.txtQueryParam.Enter += new System.EventHandler(this.txtQueryParam_Enter);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(27, 9);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(77, 12);
            this.label29.TabIndex = 5;
            this.label29.Text = "查询日期类型";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(472, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 1;
            this.label25.Text = "结束日期";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(251, 9);
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
            this.flCompletedOrder.BackColor = System.Drawing.Color.White;
            this.flCompletedOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flCompletedOrder.Location = new System.Drawing.Point(12, 232);
            this.flCompletedOrder.Name = "flCompletedOrder";
            this.flCompletedOrder.Size = new System.Drawing.Size(822, 219);
            this.flCompletedOrder.TabIndex = 13;
            // 
            // formOrderSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(846, 463);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formOrderSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个人订单";
            this.Load += new System.EventHandler(this.formOrderSelect_Load);
            this.Shown += new System.EventHandler(this.formOrderSelect_Shown);
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
        private System.Windows.Forms.DateTimePicker dtStartDate;
        private System.Windows.Forms.DateTimePicker dtEndDate;
        private System.Windows.Forms.ComboBox cboSelectMode;
        private System.Windows.Forms.TextBox txtQueryParam;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridView dgvUnfinisedOrder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.FlowLayoutPanel flCompletedOrder;
        private System.Windows.Forms.Button btnGoIE;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainStationInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassengerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderLoseTime;
    }
}