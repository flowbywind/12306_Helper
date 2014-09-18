namespace _12306_Helper
{
    partial class ControlPassengers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPassenger = new System.Windows.Forms.DataGridView();
            this.ischeck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Passenger_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatCodeName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TicketCodeName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Passenger_id_type_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Passenger_id_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassenger)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPassenger
            // 
            this.dgvPassenger.AllowUserToAddRows = false;
            this.dgvPassenger.AllowUserToDeleteRows = false;
            this.dgvPassenger.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvPassenger.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPassenger.BackgroundColor = System.Drawing.Color.White;
            this.dgvPassenger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPassenger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ischeck,
            this.Passenger_name,
            this.SeatCodeName,
            this.TicketCodeName,
            this.Passenger_id_type_name,
            this.Passenger_id_no,
            this.Mobile_no});
            this.dgvPassenger.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPassenger.GridColor = System.Drawing.Color.Silver;
            this.dgvPassenger.Location = new System.Drawing.Point(0, 0);
            this.dgvPassenger.MultiSelect = false;
            this.dgvPassenger.Name = "dgvPassenger";
            this.dgvPassenger.RowHeadersVisible = false;
            this.dgvPassenger.RowTemplate.Height = 21;
            this.dgvPassenger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPassenger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPassenger.Size = new System.Drawing.Size(812, 291);
            this.dgvPassenger.TabIndex = 38;
            this.dgvPassenger.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPassenger_CellClick);
            this.dgvPassenger.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPassenger_CellContentClick);
            this.dgvPassenger.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPassenger_CellPainting);
            // 
            // ischeck
            // 
            this.ischeck.DataPropertyName = "IsCheck";
            this.ischeck.HeaderText = "";
            this.ischeck.Name = "ischeck";
            this.ischeck.Width = 30;
            // 
            // Passenger_name
            // 
            this.Passenger_name.DataPropertyName = "Passenger_name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Passenger_name.DefaultCellStyle = dataGridViewCellStyle2;
            this.Passenger_name.HeaderText = "姓名";
            this.Passenger_name.MaxInputLength = 10;
            this.Passenger_name.Name = "Passenger_name";
            this.Passenger_name.ReadOnly = true;
            // 
            // SeatCodeName
            // 
            this.SeatCodeName.DataPropertyName = "SeatCodeName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.SeatCodeName.DefaultCellStyle = dataGridViewCellStyle3;
            this.SeatCodeName.DisplayStyleForCurrentCellOnly = true;
            this.SeatCodeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SeatCodeName.HeaderText = "席别";
            this.SeatCodeName.Items.AddRange(new object[] {
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
            this.SeatCodeName.Name = "SeatCodeName";
            // 
            // TicketCodeName
            // 
            this.TicketCodeName.DataPropertyName = "TicketCodeName";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.TicketCodeName.DefaultCellStyle = dataGridViewCellStyle4;
            this.TicketCodeName.DisplayStyleForCurrentCellOnly = true;
            this.TicketCodeName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TicketCodeName.HeaderText = "票种";
            this.TicketCodeName.Items.AddRange(new object[] {
            "成人票",
            "儿童票",
            "学生票",
            "残军票"});
            this.TicketCodeName.Name = "TicketCodeName";
            // 
            // Passenger_id_type_name
            // 
            this.Passenger_id_type_name.DataPropertyName = "Passenger_id_type_name";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Passenger_id_type_name.DefaultCellStyle = dataGridViewCellStyle5;
            this.Passenger_id_type_name.DisplayStyleForCurrentCellOnly = true;
            this.Passenger_id_type_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Passenger_id_type_name.HeaderText = "证件类型";
            this.Passenger_id_type_name.Items.AddRange(new object[] {
            "二代身份证",
            "一代身份证",
            "港澳通行证",
            "台湾通行证",
            "护照"});
            this.Passenger_id_type_name.Name = "Passenger_id_type_name";
            // 
            // Passenger_id_no
            // 
            this.Passenger_id_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Passenger_id_no.DataPropertyName = "Passenger_id_no";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Passenger_id_no.DefaultCellStyle = dataGridViewCellStyle6;
            this.Passenger_id_no.HeaderText = "证件号";
            this.Passenger_id_no.MaxInputLength = 18;
            this.Passenger_id_no.Name = "Passenger_id_no";
            this.Passenger_id_no.ReadOnly = true;
            // 
            // Mobile_no
            // 
            this.Mobile_no.DataPropertyName = "Mobile_no";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Mobile_no.DefaultCellStyle = dataGridViewCellStyle7;
            this.Mobile_no.HeaderText = "手机号";
            this.Mobile_no.MaxInputLength = 11;
            this.Mobile_no.Name = "Mobile_no";
            this.Mobile_no.ReadOnly = true;
            this.Mobile_no.Width = 135;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(643, 294);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(152, 23);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "关  闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(16, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(621, 23);
            this.label1.TabIndex = 40;
            this.label1.Text = "请确保在此选择的联系人坐席是[车次席别设置]中的坐席子集，否则会自动改为默认坐席。";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ControlPassengers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvPassenger);
            this.Name = "ControlPassengers";
            this.Size = new System.Drawing.Size(812, 320);
            this.Load += new System.EventHandler(this.ControlPassengers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPassenger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPassenger;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ischeck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passenger_name;
        private System.Windows.Forms.DataGridViewComboBoxColumn SeatCodeName;
        private System.Windows.Forms.DataGridViewComboBoxColumn TicketCodeName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Passenger_id_type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passenger_id_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile_no;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
    }
}
