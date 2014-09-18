namespace _12306_Helper
{
    partial class OrderControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OrderDetail = new System.Windows.Forms.Panel();
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
            this.lblOrderInfo = new System.Windows.Forms.Label();
            this.OrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnfinisedOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // OrderDetail
            // 
            this.OrderDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.OrderDetail.Controls.Add(this.dgvUnfinisedOrder);
            this.OrderDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrderDetail.Location = new System.Drawing.Point(0, 24);
            this.OrderDetail.Name = "OrderDetail";
            this.OrderDetail.Size = new System.Drawing.Size(745, 0);
            this.OrderDetail.TabIndex = 54;
            this.OrderDetail.Visible = false;
            // 
            // dgvUnfinisedOrder
            // 
            this.dgvUnfinisedOrder.AllowUserToAddRows = false;
            this.dgvUnfinisedOrder.AllowUserToDeleteRows = false;
            this.dgvUnfinisedOrder.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.dgvUnfinisedOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUnfinisedOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnfinisedOrder.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvUnfinisedOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
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
            this.Status});
            this.dgvUnfinisedOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnfinisedOrder.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvUnfinisedOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvUnfinisedOrder.Name = "dgvUnfinisedOrder";
            this.dgvUnfinisedOrder.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUnfinisedOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvUnfinisedOrder.RowHeadersVisible = false;
            this.dgvUnfinisedOrder.RowTemplate.Height = 24;
            this.dgvUnfinisedOrder.Size = new System.Drawing.Size(745, 0);
            this.dgvUnfinisedOrder.TabIndex = 7;
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
            // lblOrderInfo
            // 
            this.lblOrderInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblOrderInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOrderInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrderInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblOrderInfo.Location = new System.Drawing.Point(0, 0);
            this.lblOrderInfo.Name = "lblOrderInfo";
            this.lblOrderInfo.Size = new System.Drawing.Size(745, 24);
            this.lblOrderInfo.TabIndex = 55;
            this.lblOrderInfo.Text = "   订单号：";
            this.lblOrderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOrderInfo.Click += new System.EventHandler(this.lblTop_Click);
            // 
            // OrderControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.OrderDetail);
            this.Controls.Add(this.lblOrderInfo);
            this.Name = "OrderControl";
            this.Size = new System.Drawing.Size(745, 24);
            this.Load += new System.EventHandler(this.OrderControl_Load);
            this.OrderDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnfinisedOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel OrderDetail;
        private System.Windows.Forms.Label lblOrderInfo;
        private System.Windows.Forms.DataGridView dgvUnfinisedOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainStationInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrainNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassengerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}
