namespace _12306_Helper
{
    partial class formSelectTicket
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
                this.ctsListen.Dispose();
                this.ctsSwitch.Dispose();
                this._autoBooker._NoticeEvent.Dispose();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSelectTicket));
            this.lblTop = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lnkLinkToCommon = new System.Windows.Forms.LinkLabel();
            this.label23 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lnkLinkToAdvice = new System.Windows.Forms.LinkLabel();
            this.lnkLinkToBug = new System.Windows.Forms.LinkLabel();
            this.label19 = new System.Windows.Forms.Label();
            this.lnkLinkToMain = new System.Windows.Forms.LinkLabel();
            this.label20 = new System.Windows.Forms.Label();
            this.lnkLinkToDeveloper = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lnkStartTime = new System.Windows.Forms.LinkLabel();
            this.lblUser = new System.Windows.Forms.Label();
            this.lkOrderSelect = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDeleteCookies = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.lnkNewContent = new System.Windows.Forms.LinkLabel();
            this.plAllControl = new System.Windows.Forms.Panel();
            this.plQuickTrainInfo = new System.Windows.Forms.Panel();
            this.dgvQuickTrainInfo = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblQuickClose = new System.Windows.Forms.Label();
            this.lblQuickTrainInfo = new System.Windows.Forms.Label();
            this.dgvTrainView = new System.Windows.Forms.DataGridView();
            this.Station_train_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From_station_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_station_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arrive_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._9seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Pseat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Mseat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Oseat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._6seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._4seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._3seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._2seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._1seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._0seat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTicket = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Trainno4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示过站信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plCustom = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.chkCT = new System.Windows.Forms.CheckBox();
            this.chkFilterNoSeat = new System.Windows.Forms.CheckBox();
            this.chkCZ = new System.Windows.Forms.CheckBox();
            this.chkCC = new System.Windows.Forms.CheckBox();
            this.chkCQ = new System.Windows.Forms.CheckBox();
            this.chkCD = new System.Windows.Forms.CheckBox();
            this.chkCG = new System.Windows.Forms.CheckBox();
            this.chkCA = new System.Windows.Forms.CheckBox();
            this.chkCL = new System.Windows.Forms.CheckBox();
            this.chkCK = new System.Windows.Forms.CheckBox();
            this.lblTrainsCount = new System.Windows.Forms.Label();
            this.chkCustomFilter = new System.Windows.Forms.CheckBox();
            this.plSetup = new System.Windows.Forms.Panel();
            this.cboShijian = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbtnWangfan = new System.Windows.Forms.RadioButton();
            this.rbtnDan = new System.Windows.Forms.RadioButton();
            this.lblLastSelectTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.dtpRiqi = new System.Windows.Forms.DateTimePicker();
            this.cboTo = new System.Windows.Forms.ComboBox();
            this.txtChufaCheci = new System.Windows.Forms.TextBox();
            this.cboFrom = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkQuanbu = new System.Windows.Forms.CheckBox();
            this.chkDongche = new System.Windows.Forms.CheckBox();
            this.rbtnGuolu = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.chkZhida = new System.Windows.Forms.CheckBox();
            this.rbtnShifa = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkTekuai = new System.Windows.Forms.CheckBox();
            this.rbtnQuanbu = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.chkKuaisu = new System.Windows.Forms.CheckBox();
            this.chkQita = new System.Windows.Forms.CheckBox();
            this.lblAutoBook = new System.Windows.Forms.Label();
            this.plAutoBook = new System.Windows.Forms.Panel();
            this.flplPassengers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPassenger = new System.Windows.Forms.Label();
            this.flplTrainNo = new System.Windows.Forms.FlowLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.flplSeatType = new System.Windows.Forms.FlowLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.cboSeatType = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHitCache = new System.Windows.Forms.Label();
            this.lblServerTime = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.plRightBottom = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSelectTurn = new System.Windows.Forms.CheckBox();
            this.rbtnSeatTypeFirst = new System.Windows.Forms.RadioButton();
            this.rbtnTrainNoFirst = new System.Windows.Forms.RadioButton();
            this.AutoPicker = new System.Windows.Forms.DateTimePicker();
            this.btnAutoBook = new System.Windows.Forms.Button();
            this.lblRefreshTime = new System.Windows.Forms.Label();
            this.lblCostTime = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.numSelectSpan = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.fplTurnDates = new System.Windows.Forms.FlowLayoutPanel();
            this.flpTurnCheckBox = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox13 = new System.Windows.Forms.CheckBox();
            this.checkBox14 = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.checkBox20 = new System.Windows.Forms.CheckBox();
            this.lblAutoSwitch = new System.Windows.Forms.Label();
            this.plAutoSwitch = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.plSourceFrom = new System.Windows.Forms.Panel();
            this.rbtnWifeATM = new System.Windows.Forms.RadioButton();
            this.rbtnFishlee = new System.Windows.Forms.RadioButton();
            this.chkAllowSwitch = new System.Windows.Forms.CheckBox();
            this.lvSwitchStatus = new System.Windows.Forms.ListView();
            this.时间 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.信息 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInitHosts = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblMini = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tmUpdateServerTime = new System.Windows.Forms.Timer(this.components);
            this.notice = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblHide = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.tmWatch = new System.Windows.Forms.Timer(this.components);
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.plAllControl.SuspendLayout();
            this.plQuickTrainInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuickTrainInfo)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.plCustom.SuspendLayout();
            this.plSetup.SuspendLayout();
            this.panel4.SuspendLayout();
            this.plAutoBook.SuspendLayout();
            this.flplPassengers.SuspendLayout();
            this.flplTrainNo.SuspendLayout();
            this.flplSeatType.SuspendLayout();
            this.panel2.SuspendLayout();
            this.plRightBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectSpan)).BeginInit();
            this.fplTurnDates.SuspendLayout();
            this.flpTurnCheckBox.SuspendLayout();
            this.plAutoSwitch.SuspendLayout();
            this.plSourceFrom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.lblTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTop.Location = new System.Drawing.Point(0, 0);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(1070, 26);
            this.lblTop.TabIndex = 17;
            this.lblTop.Text = "查  票  --  抢  票     ";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTop_MouseDown);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Location = new System.Drawing.Point(7, 29);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1056, 21);
            this.panel5.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Controls.Add(this.lnkLinkToCommon);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.lnkLinkToAdvice);
            this.panel3.Controls.Add(this.lnkLinkToBug);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.lnkLinkToMain);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.lnkLinkToDeveloper);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.lnkStartTime);
            this.panel3.Controls.Add(this.lblUser);
            this.panel3.Controls.Add(this.lkOrderSelect);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblDeleteCookies);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lnkNewContent);
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1054, 19);
            this.panel3.TabIndex = 33;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label26.Location = new System.Drawing.Point(150, 4);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(11, 10);
            this.label26.TabIndex = 45;
            this.label26.Text = "|";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.ForeColor = System.Drawing.Color.Navy;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linkLabel1.Location = new System.Drawing.Point(83, 4);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 44;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "编辑联系人";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lnkLinkToCommon
            // 
            this.lnkLinkToCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkLinkToCommon.AutoSize = true;
            this.lnkLinkToCommon.BackColor = System.Drawing.Color.Transparent;
            this.lnkLinkToCommon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lnkLinkToCommon.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lnkLinkToCommon.Location = new System.Drawing.Point(687, 4);
            this.lnkLinkToCommon.Name = "lnkLinkToCommon";
            this.lnkLinkToCommon.Size = new System.Drawing.Size(53, 12);
            this.lnkLinkToCommon.TabIndex = 42;
            this.lnkLinkToCommon.TabStop = true;
            this.lnkLinkToCommon.Text = "常规讨论";
            this.lnkLinkToCommon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLinkToCommon_LinkClicked);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label23.Location = new System.Drawing.Point(744, 4);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(11, 10);
            this.label23.TabIndex = 43;
            this.label23.Text = "|";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label18.Location = new System.Drawing.Point(973, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 10);
            this.label18.TabIndex = 41;
            this.label18.Text = "|";
            // 
            // lnkLinkToAdvice
            // 
            this.lnkLinkToAdvice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkLinkToAdvice.AutoSize = true;
            this.lnkLinkToAdvice.BackColor = System.Drawing.Color.Transparent;
            this.lnkLinkToAdvice.ForeColor = System.Drawing.Color.Navy;
            this.lnkLinkToAdvice.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lnkLinkToAdvice.Location = new System.Drawing.Point(829, 4);
            this.lnkLinkToAdvice.Name = "lnkLinkToAdvice";
            this.lnkLinkToAdvice.Size = new System.Drawing.Size(53, 12);
            this.lnkLinkToAdvice.TabIndex = 38;
            this.lnkLinkToAdvice.TabStop = true;
            this.lnkLinkToAdvice.Text = "反馈建议";
            this.lnkLinkToAdvice.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLinkToAdvice_LinkClicked);
            // 
            // lnkLinkToBug
            // 
            this.lnkLinkToBug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkLinkToBug.AutoSize = true;
            this.lnkLinkToBug.BackColor = System.Drawing.Color.Transparent;
            this.lnkLinkToBug.ForeColor = System.Drawing.Color.Navy;
            this.lnkLinkToBug.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lnkLinkToBug.Location = new System.Drawing.Point(762, 4);
            this.lnkLinkToBug.Name = "lnkLinkToBug";
            this.lnkLinkToBug.Size = new System.Drawing.Size(47, 12);
            this.lnkLinkToBug.TabIndex = 35;
            this.lnkLinkToBug.TabStop = true;
            this.lnkLinkToBug.Text = "BUG提交";
            this.lnkLinkToBug.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLinkToBug_LinkClicked);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label19.Location = new System.Drawing.Point(889, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(11, 10);
            this.label19.TabIndex = 40;
            this.label19.Text = "|";
            // 
            // lnkLinkToMain
            // 
            this.lnkLinkToMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkLinkToMain.AutoSize = true;
            this.lnkLinkToMain.BackColor = System.Drawing.Color.Transparent;
            this.lnkLinkToMain.ForeColor = System.Drawing.Color.Navy;
            this.lnkLinkToMain.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lnkLinkToMain.Location = new System.Drawing.Point(989, 4);
            this.lnkLinkToMain.Name = "lnkLinkToMain";
            this.lnkLinkToMain.Size = new System.Drawing.Size(53, 12);
            this.lnkLinkToMain.TabIndex = 36;
            this.lnkLinkToMain.TabStop = true;
            this.lnkLinkToMain.Text = "关于软件";
            this.lnkLinkToMain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLinkToMain_LinkClicked);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label20.Location = new System.Drawing.Point(814, 4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(11, 10);
            this.label20.TabIndex = 39;
            this.label20.Text = "|";
            // 
            // lnkLinkToDeveloper
            // 
            this.lnkLinkToDeveloper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkLinkToDeveloper.AutoSize = true;
            this.lnkLinkToDeveloper.BackColor = System.Drawing.Color.Transparent;
            this.lnkLinkToDeveloper.ForeColor = System.Drawing.Color.Navy;
            this.lnkLinkToDeveloper.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lnkLinkToDeveloper.Location = new System.Drawing.Point(904, 4);
            this.lnkLinkToDeveloper.Name = "lnkLinkToDeveloper";
            this.lnkLinkToDeveloper.Size = new System.Drawing.Size(65, 12);
            this.lnkLinkToDeveloper.TabIndex = 37;
            this.lnkLinkToDeveloper.TabStop = true;
            this.lnkLinkToDeveloper.Text = "开发者讨论";
            this.lnkLinkToDeveloper.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLinkToDeveloper_LinkClicked);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label12.Location = new System.Drawing.Point(392, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 10);
            this.label12.TabIndex = 34;
            this.label12.Text = "|";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label11.Location = new System.Drawing.Point(320, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 10);
            this.label11.TabIndex = 33;
            this.label11.Text = "|";
            // 
            // lnkStartTime
            // 
            this.lnkStartTime.AutoSize = true;
            this.lnkStartTime.BackColor = System.Drawing.Color.Transparent;
            this.lnkStartTime.ForeColor = System.Drawing.Color.Navy;
            this.lnkStartTime.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lnkStartTime.Location = new System.Drawing.Point(163, 4);
            this.lnkStartTime.Name = "lnkStartTime";
            this.lnkStartTime.Size = new System.Drawing.Size(77, 12);
            this.lnkStartTime.TabIndex = 31;
            this.lnkStartTime.TabStop = true;
            this.lnkStartTime.Text = "开票时间查询";
            this.lnkStartTime.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkStartTime_LinkClicked);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblUser.Location = new System.Drawing.Point(411, 4);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 12);
            this.lblUser.TabIndex = 27;
            this.lblUser.Text = "    ";
            // 
            // lkOrderSelect
            // 
            this.lkOrderSelect.AutoSize = true;
            this.lkOrderSelect.BackColor = System.Drawing.Color.Transparent;
            this.lkOrderSelect.ForeColor = System.Drawing.Color.Navy;
            this.lkOrderSelect.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lkOrderSelect.Location = new System.Drawing.Point(12, 4);
            this.lkOrderSelect.Name = "lkOrderSelect";
            this.lkOrderSelect.Size = new System.Drawing.Size(53, 12);
            this.lkOrderSelect.TabIndex = 24;
            this.lkOrderSelect.TabStop = true;
            this.lkOrderSelect.Text = "订单查询";
            this.lkOrderSelect.Click += new System.EventHandler(this.lkOrderSelect_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label9.Location = new System.Drawing.Point(246, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 10);
            this.label9.TabIndex = 32;
            this.label9.Text = "|";
            // 
            // lblDeleteCookies
            // 
            this.lblDeleteCookies.AutoSize = true;
            this.lblDeleteCookies.BackColor = System.Drawing.Color.Transparent;
            this.lblDeleteCookies.ForeColor = System.Drawing.Color.Navy;
            this.lblDeleteCookies.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblDeleteCookies.Location = new System.Drawing.Point(334, 4);
            this.lblDeleteCookies.Name = "lblDeleteCookies";
            this.lblDeleteCookies.Size = new System.Drawing.Size(53, 12);
            this.lblDeleteCookies.TabIndex = 28;
            this.lblDeleteCookies.TabStop = true;
            this.lblDeleteCookies.Text = "更换帐号";
            this.lblDeleteCookies.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDeleteCookies_LinkClicked);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(69, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 10);
            this.label3.TabIndex = 32;
            this.label3.Text = "|";
            // 
            // lnkNewContent
            // 
            this.lnkNewContent.AutoSize = true;
            this.lnkNewContent.BackColor = System.Drawing.Color.Transparent;
            this.lnkNewContent.ForeColor = System.Drawing.Color.Navy;
            this.lnkNewContent.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lnkNewContent.Location = new System.Drawing.Point(263, 4);
            this.lnkNewContent.Name = "lnkNewContent";
            this.lnkNewContent.Size = new System.Drawing.Size(53, 12);
            this.lnkNewContent.TabIndex = 31;
            this.lnkNewContent.TabStop = true;
            this.lnkNewContent.Text = "最新动态";
            this.lnkNewContent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNewContent_LinkClicked);
            // 
            // plAllControl
            // 
            this.plAllControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plAllControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.plAllControl.Controls.Add(this.plQuickTrainInfo);
            this.plAllControl.Controls.Add(this.dgvTrainView);
            this.plAllControl.Controls.Add(this.panel1);
            this.plAllControl.Controls.Add(this.plSetup);
            this.plAllControl.Controls.Add(this.lblAutoBook);
            this.plAllControl.Controls.Add(this.plAutoBook);
            this.plAllControl.Controls.Add(this.fplTurnDates);
            this.plAllControl.Controls.Add(this.lblAutoSwitch);
            this.plAllControl.Controls.Add(this.plAutoSwitch);
            this.plAllControl.Location = new System.Drawing.Point(7, 52);
            this.plAllControl.Name = "plAllControl";
            this.plAllControl.Size = new System.Drawing.Size(1056, 520);
            this.plAllControl.TabIndex = 18;
            // 
            // plQuickTrainInfo
            // 
            this.plQuickTrainInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(255)))));
            this.plQuickTrainInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plQuickTrainInfo.Controls.Add(this.dgvQuickTrainInfo);
            this.plQuickTrainInfo.Controls.Add(this.panel8);
            this.plQuickTrainInfo.Location = new System.Drawing.Point(342, 86);
            this.plQuickTrainInfo.Name = "plQuickTrainInfo";
            this.plQuickTrainInfo.Padding = new System.Windows.Forms.Padding(5);
            this.plQuickTrainInfo.Size = new System.Drawing.Size(370, 191);
            this.plQuickTrainInfo.TabIndex = 47;
            this.plQuickTrainInfo.Visible = false;
            // 
            // dgvQuickTrainInfo
            // 
            this.dgvQuickTrainInfo.AllowUserToAddRows = false;
            this.dgvQuickTrainInfo.AllowUserToDeleteRows = false;
            this.dgvQuickTrainInfo.AllowUserToResizeColumns = false;
            this.dgvQuickTrainInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.dgvQuickTrainInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvQuickTrainInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvQuickTrainInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvQuickTrainInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuickTrainInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuickTrainInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuickTrainInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuickTrainInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvQuickTrainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuickTrainInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvQuickTrainInfo.Location = new System.Drawing.Point(5, 29);
            this.dgvQuickTrainInfo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.dgvQuickTrainInfo.MultiSelect = false;
            this.dgvQuickTrainInfo.Name = "dgvQuickTrainInfo";
            this.dgvQuickTrainInfo.ReadOnly = true;
            this.dgvQuickTrainInfo.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuickTrainInfo.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvQuickTrainInfo.RowTemplate.Height = 23;
            this.dgvQuickTrainInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuickTrainInfo.Size = new System.Drawing.Size(358, 155);
            this.dgvQuickTrainInfo.TabIndex = 37;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "station_no";
            this.Column1.HeaderText = "站序";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.DataPropertyName = "station_name";
            this.Column2.HeaderText = "站名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 52;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.DataPropertyName = "arrive_time";
            this.Column3.HeaderText = "到站时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 76;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.DataPropertyName = "start_time";
            this.Column4.HeaderText = "出发时间";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 76;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.DataPropertyName = "stopover_time";
            this.Column5.HeaderText = "停留时间";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 76;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "isEnabled";
            this.Column6.HeaderText = "能否预定";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            this.Column6.Width = 76;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(255)))));
            this.panel8.Controls.Add(this.lblQuickClose);
            this.panel8.Controls.Add(this.lblQuickTrainInfo);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(5, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(358, 24);
            this.panel8.TabIndex = 40;
            // 
            // lblQuickClose
            // 
            this.lblQuickClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuickClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(255)))));
            this.lblQuickClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQuickClose.ForeColor = System.Drawing.Color.White;
            this.lblQuickClose.Location = new System.Drawing.Point(320, 3);
            this.lblQuickClose.Name = "lblQuickClose";
            this.lblQuickClose.Size = new System.Drawing.Size(38, 16);
            this.lblQuickClose.TabIndex = 20;
            this.lblQuickClose.Text = "×";
            this.lblQuickClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuickClose.Click += new System.EventHandler(this.lblQuickClose_Click);
            this.lblQuickClose.MouseEnter += new System.EventHandler(this.lblQuickClose_MouseEnter);
            this.lblQuickClose.MouseLeave += new System.EventHandler(this.lblQuickClose_MouseLeave);
            // 
            // lblQuickTrainInfo
            // 
            this.lblQuickTrainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuickTrainInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQuickTrainInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblQuickTrainInfo.Location = new System.Drawing.Point(0, 0);
            this.lblQuickTrainInfo.Name = "lblQuickTrainInfo";
            this.lblQuickTrainInfo.Size = new System.Drawing.Size(358, 24);
            this.lblQuickTrainInfo.TabIndex = 0;
            this.lblQuickTrainInfo.Text = "过路车站";
            this.lblQuickTrainInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuickTrainInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblQuickTrainInfo_MouseDown);
            // 
            // dgvTrainView
            // 
            this.dgvTrainView.AllowUserToAddRows = false;
            this.dgvTrainView.AllowUserToDeleteRows = false;
            this.dgvTrainView.AllowUserToOrderColumns = true;
            this.dgvTrainView.AllowUserToResizeColumns = false;
            this.dgvTrainView.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            this.dgvTrainView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTrainView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTrainView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvTrainView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrainView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTrainView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Station_train_code,
            this.From_station_name,
            this.Start_time,
            this.To_station_name,
            this.Arrive_time,
            this.Cost_time,
            this._9seat,
            this._Pseat,
            this._Mseat,
            this._Oseat,
            this._6seat,
            this._4seat,
            this._3seat,
            this._2seat,
            this._1seat,
            this._0seat,
            this.BookTicket,
            this.Trainno4});
            this.dgvTrainView.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrainView.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgvTrainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrainView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dgvTrainView.Location = new System.Drawing.Point(0, 62);
            this.dgvTrainView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.dgvTrainView.MultiSelect = false;
            this.dgvTrainView.Name = "dgvTrainView";
            this.dgvTrainView.ReadOnly = true;
            this.dgvTrainView.RowHeadersVisible = false;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrainView.RowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvTrainView.RowTemplate.Height = 23;
            this.dgvTrainView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrainView.Size = new System.Drawing.Size(1056, 98);
            this.dgvTrainView.TabIndex = 36;
            this.dgvTrainView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrainView_CellClick);
            this.dgvTrainView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrainView_CellDoubleClick);
            this.dgvTrainView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTrainView_CellPainting);
            // 
            // Station_train_code
            // 
            this.Station_train_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Station_train_code.DataPropertyName = "Station_train_code";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Station_train_code.DefaultCellStyle = dataGridViewCellStyle7;
            this.Station_train_code.HeaderText = "车次";
            this.Station_train_code.Name = "Station_train_code";
            this.Station_train_code.ReadOnly = true;
            // 
            // From_station_name
            // 
            this.From_station_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.From_station_name.DataPropertyName = "From_station_name";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.From_station_name.DefaultCellStyle = dataGridViewCellStyle8;
            this.From_station_name.HeaderText = "发站";
            this.From_station_name.Name = "From_station_name";
            this.From_station_name.ReadOnly = true;
            this.From_station_name.Width = 52;
            // 
            // Start_time
            // 
            this.Start_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Start_time.DataPropertyName = "Start_time";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Start_time.DefaultCellStyle = dataGridViewCellStyle9;
            this.Start_time.HeaderText = "发车时间";
            this.Start_time.Name = "Start_time";
            this.Start_time.ReadOnly = true;
            this.Start_time.Width = 76;
            // 
            // To_station_name
            // 
            this.To_station_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.To_station_name.DataPropertyName = "To_station_name";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.To_station_name.DefaultCellStyle = dataGridViewCellStyle10;
            this.To_station_name.HeaderText = "到站";
            this.To_station_name.Name = "To_station_name";
            this.To_station_name.ReadOnly = true;
            this.To_station_name.Width = 52;
            // 
            // Arrive_time
            // 
            this.Arrive_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Arrive_time.DataPropertyName = "Arrive_time";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Arrive_time.DefaultCellStyle = dataGridViewCellStyle11;
            this.Arrive_time.HeaderText = "到站时间";
            this.Arrive_time.Name = "Arrive_time";
            this.Arrive_time.ReadOnly = true;
            this.Arrive_time.Width = 76;
            // 
            // Cost_time
            // 
            this.Cost_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cost_time.DataPropertyName = "Cost_time";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Cost_time.DefaultCellStyle = dataGridViewCellStyle12;
            this.Cost_time.HeaderText = "历时";
            this.Cost_time.Name = "Cost_time";
            this.Cost_time.ReadOnly = true;
            this.Cost_time.Width = 52;
            // 
            // _9seat
            // 
            this._9seat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._9seat.DataPropertyName = "_9seat";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            this._9seat.DefaultCellStyle = dataGridViewCellStyle13;
            this._9seat.HeaderText = "商务座";
            this._9seat.Name = "_9seat";
            this._9seat.ReadOnly = true;
            this._9seat.Width = 64;
            // 
            // _Pseat
            // 
            this._Pseat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._Pseat.DataPropertyName = "_Pseat";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            this._Pseat.DefaultCellStyle = dataGridViewCellStyle14;
            this._Pseat.HeaderText = "特等座";
            this._Pseat.Name = "_Pseat";
            this._Pseat.ReadOnly = true;
            this._Pseat.Width = 64;
            // 
            // _Mseat
            // 
            this._Mseat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._Mseat.DataPropertyName = "_Mseat";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            this._Mseat.DefaultCellStyle = dataGridViewCellStyle15;
            this._Mseat.HeaderText = "一等座";
            this._Mseat.Name = "_Mseat";
            this._Mseat.ReadOnly = true;
            this._Mseat.Width = 64;
            // 
            // _Oseat
            // 
            this._Oseat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._Oseat.DataPropertyName = "_Oseat";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            this._Oseat.DefaultCellStyle = dataGridViewCellStyle16;
            this._Oseat.HeaderText = "二等座";
            this._Oseat.Name = "_Oseat";
            this._Oseat.ReadOnly = true;
            this._Oseat.Width = 64;
            // 
            // _6seat
            // 
            this._6seat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._6seat.DataPropertyName = "_6seat";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            this._6seat.DefaultCellStyle = dataGridViewCellStyle17;
            this._6seat.HeaderText = "高级软卧";
            this._6seat.Name = "_6seat";
            this._6seat.ReadOnly = true;
            this._6seat.Width = 76;
            // 
            // _4seat
            // 
            this._4seat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._4seat.DataPropertyName = "_4seat";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            this._4seat.DefaultCellStyle = dataGridViewCellStyle18;
            this._4seat.HeaderText = "软卧";
            this._4seat.Name = "_4seat";
            this._4seat.ReadOnly = true;
            this._4seat.Width = 52;
            // 
            // _3seat
            // 
            this._3seat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._3seat.DataPropertyName = "_3seat";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            this._3seat.DefaultCellStyle = dataGridViewCellStyle19;
            this._3seat.HeaderText = "硬卧";
            this._3seat.Name = "_3seat";
            this._3seat.ReadOnly = true;
            this._3seat.Width = 52;
            // 
            // _2seat
            // 
            this._2seat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._2seat.DataPropertyName = "_2seat";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            this._2seat.DefaultCellStyle = dataGridViewCellStyle20;
            this._2seat.HeaderText = "软座";
            this._2seat.Name = "_2seat";
            this._2seat.ReadOnly = true;
            this._2seat.Width = 52;
            // 
            // _1seat
            // 
            this._1seat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._1seat.DataPropertyName = "_1seat";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            this._1seat.DefaultCellStyle = dataGridViewCellStyle21;
            this._1seat.HeaderText = "硬座";
            this._1seat.Name = "_1seat";
            this._1seat.ReadOnly = true;
            this._1seat.Width = 52;
            // 
            // _0seat
            // 
            this._0seat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._0seat.DataPropertyName = "_0seat";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            this._0seat.DefaultCellStyle = dataGridViewCellStyle22;
            this._0seat.HeaderText = "无座";
            this._0seat.Name = "_0seat";
            this._0seat.ReadOnly = true;
            this._0seat.Width = 52;
            // 
            // BookTicket
            // 
            this.BookTicket.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            this.BookTicket.DefaultCellStyle = dataGridViewCellStyle23;
            this.BookTicket.HeaderText = "";
            this.BookTicket.Name = "BookTicket";
            this.BookTicket.ReadOnly = true;
            this.BookTicket.Text = "预 定";
            this.BookTicket.UseColumnTextForButtonValue = true;
            this.BookTicket.Width = 60;
            // 
            // Trainno4
            // 
            this.Trainno4.DataPropertyName = "Trainno4";
            this.Trainno4.HeaderText = "车次ID";
            this.Trainno4.Name = "Trainno4";
            this.Trainno4.ReadOnly = true;
            this.Trainno4.Visible = false;
            this.Trainno4.Width = 64;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示过站信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 显示过站信息ToolStripMenuItem
            // 
            this.显示过站信息ToolStripMenuItem.Name = "显示过站信息ToolStripMenuItem";
            this.显示过站信息ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.显示过站信息ToolStripMenuItem.Text = "显示过站信息";
            this.显示过站信息ToolStripMenuItem.Click += new System.EventHandler(this.显示过站信息ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.plCustom);
            this.panel1.Controls.Add(this.lblTrainsCount);
            this.panel1.Controls.Add(this.chkCustomFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 20);
            this.panel1.TabIndex = 46;
            // 
            // plCustom
            // 
            this.plCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plCustom.Controls.Add(this.label10);
            this.plCustom.Controls.Add(this.chkCT);
            this.plCustom.Controls.Add(this.chkFilterNoSeat);
            this.plCustom.Controls.Add(this.chkCZ);
            this.plCustom.Controls.Add(this.chkCC);
            this.plCustom.Controls.Add(this.chkCQ);
            this.plCustom.Controls.Add(this.chkCD);
            this.plCustom.Controls.Add(this.chkCG);
            this.plCustom.Controls.Add(this.chkCA);
            this.plCustom.Controls.Add(this.chkCL);
            this.plCustom.Controls.Add(this.chkCK);
            this.plCustom.Enabled = false;
            this.plCustom.Location = new System.Drawing.Point(118, 1);
            this.plCustom.Margin = new System.Windows.Forms.Padding(0);
            this.plCustom.Name = "plCustom";
            this.plCustom.Size = new System.Drawing.Size(845, 18);
            this.plCustom.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(78)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(498, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 10);
            this.label10.TabIndex = 26;
            this.label10.Text = "|";
            // 
            // chkCT
            // 
            this.chkCT.AutoSize = true;
            this.chkCT.Checked = true;
            this.chkCT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCT.Location = new System.Drawing.Point(276, 2);
            this.chkCT.Name = "chkCT";
            this.chkCT.Size = new System.Drawing.Size(51, 16);
            this.chkCT.TabIndex = 21;
            this.chkCT.Text = "T字头";
            this.chkCT.UseVisualStyleBackColor = true;
            this.chkCT.CheckedChanged += new System.EventHandler(this.chkCChangeed);
            // 
            // chkFilterNoSeat
            // 
            this.chkFilterNoSeat.AutoSize = true;
            this.chkFilterNoSeat.Checked = true;
            this.chkFilterNoSeat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterNoSeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkFilterNoSeat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkFilterNoSeat.Location = new System.Drawing.Point(519, 2);
            this.chkFilterNoSeat.Name = "chkFilterNoSeat";
            this.chkFilterNoSeat.Size = new System.Drawing.Size(93, 16);
            this.chkFilterNoSeat.TabIndex = 29;
            this.chkFilterNoSeat.Text = "过滤无票车次";
            this.chkFilterNoSeat.UseVisualStyleBackColor = true;
            // 
            // chkCZ
            // 
            this.chkCZ.AutoSize = true;
            this.chkCZ.Checked = true;
            this.chkCZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCZ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCZ.Location = new System.Drawing.Point(219, 2);
            this.chkCZ.Name = "chkCZ";
            this.chkCZ.Size = new System.Drawing.Size(51, 16);
            this.chkCZ.TabIndex = 20;
            this.chkCZ.Text = "Z字头";
            this.chkCZ.UseVisualStyleBackColor = true;
            this.chkCZ.CheckedChanged += new System.EventHandler(this.chkCChangeed);
            // 
            // chkCC
            // 
            this.chkCC.AutoSize = true;
            this.chkCC.Checked = true;
            this.chkCC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCC.Location = new System.Drawing.Point(165, 2);
            this.chkCC.Name = "chkCC";
            this.chkCC.Size = new System.Drawing.Size(51, 16);
            this.chkCC.TabIndex = 19;
            this.chkCC.Text = "C字头";
            this.chkCC.UseVisualStyleBackColor = true;
            this.chkCC.CheckedChanged += new System.EventHandler(this.chkCChangeed);
            // 
            // chkCQ
            // 
            this.chkCQ.AutoSize = true;
            this.chkCQ.Checked = true;
            this.chkCQ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCQ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCQ.Location = new System.Drawing.Point(447, 2);
            this.chkCQ.Name = "chkCQ";
            this.chkCQ.Size = new System.Drawing.Size(45, 16);
            this.chkCQ.TabIndex = 27;
            this.chkCQ.Text = "其它";
            this.chkCQ.UseVisualStyleBackColor = true;
            this.chkCQ.CheckedChanged += new System.EventHandler(this.chkCChangeed);
            // 
            // chkCD
            // 
            this.chkCD.AutoSize = true;
            this.chkCD.Checked = true;
            this.chkCD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCD.Location = new System.Drawing.Point(111, 2);
            this.chkCD.Name = "chkCD";
            this.chkCD.Size = new System.Drawing.Size(51, 16);
            this.chkCD.TabIndex = 24;
            this.chkCD.Text = "D字头";
            this.chkCD.UseVisualStyleBackColor = true;
            this.chkCD.CheckedChanged += new System.EventHandler(this.chkCChangeed);
            // 
            // chkCG
            // 
            this.chkCG.AutoSize = true;
            this.chkCG.Checked = true;
            this.chkCG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCG.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCG.Location = new System.Drawing.Point(51, 2);
            this.chkCG.Name = "chkCG";
            this.chkCG.Size = new System.Drawing.Size(51, 16);
            this.chkCG.TabIndex = 23;
            this.chkCG.Text = "G动车";
            this.chkCG.UseVisualStyleBackColor = true;
            this.chkCG.CheckedChanged += new System.EventHandler(this.chkCChangeed);
            // 
            // chkCA
            // 
            this.chkCA.AutoSize = true;
            this.chkCA.Checked = true;
            this.chkCA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCA.Location = new System.Drawing.Point(3, 2);
            this.chkCA.Name = "chkCA";
            this.chkCA.Size = new System.Drawing.Size(45, 16);
            this.chkCA.TabIndex = 22;
            this.chkCA.Text = "全部";
            this.chkCA.UseVisualStyleBackColor = true;
            this.chkCA.Click += new System.EventHandler(this.chkCA_Click);
            // 
            // chkCL
            // 
            this.chkCL.AutoSize = true;
            this.chkCL.Checked = true;
            this.chkCL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCL.Location = new System.Drawing.Point(390, 2);
            this.chkCL.Name = "chkCL";
            this.chkCL.Size = new System.Drawing.Size(51, 16);
            this.chkCL.TabIndex = 26;
            this.chkCL.Text = "L字头";
            this.chkCL.UseVisualStyleBackColor = true;
            this.chkCL.CheckedChanged += new System.EventHandler(this.chkCChangeed);
            // 
            // chkCK
            // 
            this.chkCK.AutoSize = true;
            this.chkCK.Checked = true;
            this.chkCK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCK.Location = new System.Drawing.Point(333, 2);
            this.chkCK.Name = "chkCK";
            this.chkCK.Size = new System.Drawing.Size(51, 16);
            this.chkCK.TabIndex = 25;
            this.chkCK.Text = "K字头";
            this.chkCK.UseVisualStyleBackColor = true;
            this.chkCK.CheckedChanged += new System.EventHandler(this.chkCChangeed);
            // 
            // lblTrainsCount
            // 
            this.lblTrainsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrainsCount.AutoSize = true;
            this.lblTrainsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTrainsCount.Location = new System.Drawing.Point(968, 5);
            this.lblTrainsCount.Name = "lblTrainsCount";
            this.lblTrainsCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTrainsCount.Size = new System.Drawing.Size(71, 12);
            this.lblTrainsCount.TabIndex = 30;
            this.lblTrainsCount.Text = "共有 0 趟车";
            this.lblTrainsCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkCustomFilter
            // 
            this.chkCustomFilter.AutoSize = true;
            this.chkCustomFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCustomFilter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCustomFilter.Location = new System.Drawing.Point(11, 3);
            this.chkCustomFilter.Name = "chkCustomFilter";
            this.chkCustomFilter.Size = new System.Drawing.Size(105, 16);
            this.chkCustomFilter.TabIndex = 28;
            this.chkCustomFilter.Text = "启用自定义筛选";
            this.chkCustomFilter.UseVisualStyleBackColor = true;
            this.chkCustomFilter.CheckedChanged += new System.EventHandler(this.chkCustomFilter_CheckedChanged);
            // 
            // plSetup
            // 
            this.plSetup.Controls.Add(this.cboShijian);
            this.plSetup.Controls.Add(this.panel4);
            this.plSetup.Controls.Add(this.lblLastSelectTime);
            this.plSetup.Controls.Add(this.label1);
            this.plSetup.Controls.Add(this.btnSelectAll);
            this.plSetup.Controls.Add(this.btnChange);
            this.plSetup.Controls.Add(this.dtpRiqi);
            this.plSetup.Controls.Add(this.cboTo);
            this.plSetup.Controls.Add(this.txtChufaCheci);
            this.plSetup.Controls.Add(this.cboFrom);
            this.plSetup.Controls.Add(this.label8);
            this.plSetup.Controls.Add(this.chkQuanbu);
            this.plSetup.Controls.Add(this.chkDongche);
            this.plSetup.Controls.Add(this.rbtnGuolu);
            this.plSetup.Controls.Add(this.label4);
            this.plSetup.Controls.Add(this.chkZhida);
            this.plSetup.Controls.Add(this.rbtnShifa);
            this.plSetup.Controls.Add(this.label7);
            this.plSetup.Controls.Add(this.label5);
            this.plSetup.Controls.Add(this.chkTekuai);
            this.plSetup.Controls.Add(this.rbtnQuanbu);
            this.plSetup.Controls.Add(this.label6);
            this.plSetup.Controls.Add(this.chkKuaisu);
            this.plSetup.Controls.Add(this.chkQita);
            this.plSetup.Dock = System.Windows.Forms.DockStyle.Top;
            this.plSetup.ForeColor = System.Drawing.Color.Black;
            this.plSetup.Location = new System.Drawing.Point(0, 0);
            this.plSetup.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.plSetup.Name = "plSetup";
            this.plSetup.Padding = new System.Windows.Forms.Padding(3);
            this.plSetup.Size = new System.Drawing.Size(1056, 62);
            this.plSetup.TabIndex = 34;
            // 
            // cboShijian
            // 
            this.cboShijian.FormattingEnabled = true;
            this.cboShijian.Items.AddRange(new object[] {
            "00:00--24:00",
            "00:00--06:00",
            "06:00--12:00",
            "12:00--18:00",
            "18:00--24:00"});
            this.cboShijian.Location = new System.Drawing.Point(698, 8);
            this.cboShijian.Name = "cboShijian";
            this.cboShijian.Size = new System.Drawing.Size(97, 20);
            this.cboShijian.TabIndex = 44;
            this.cboShijian.Text = "00:00--24:00";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rbtnWangfan);
            this.panel4.Controls.Add(this.rbtnDan);
            this.panel4.Location = new System.Drawing.Point(11, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(108, 21);
            this.panel4.TabIndex = 43;
            // 
            // rbtnWangfan
            // 
            this.rbtnWangfan.AutoSize = true;
            this.rbtnWangfan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnWangfan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnWangfan.Location = new System.Drawing.Point(56, 3);
            this.rbtnWangfan.Name = "rbtnWangfan";
            this.rbtnWangfan.Size = new System.Drawing.Size(46, 16);
            this.rbtnWangfan.TabIndex = 5;
            this.rbtnWangfan.Text = "往返";
            this.rbtnWangfan.UseVisualStyleBackColor = true;
            // 
            // rbtnDan
            // 
            this.rbtnDan.AutoSize = true;
            this.rbtnDan.Checked = true;
            this.rbtnDan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnDan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnDan.Location = new System.Drawing.Point(3, 3);
            this.rbtnDan.Name = "rbtnDan";
            this.rbtnDan.Size = new System.Drawing.Size(46, 16);
            this.rbtnDan.TabIndex = 4;
            this.rbtnDan.TabStop = true;
            this.rbtnDan.Text = "单程";
            this.rbtnDan.UseVisualStyleBackColor = true;
            // 
            // lblLastSelectTime
            // 
            this.lblLastSelectTime.AutoSize = true;
            this.lblLastSelectTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLastSelectTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLastSelectTime.Location = new System.Drawing.Point(879, 11);
            this.lblLastSelectTime.Name = "lblLastSelectTime";
            this.lblLastSelectTime.Size = new System.Drawing.Size(0, 12);
            this.lblLastSelectTime.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(796, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "上次查询时间";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.ForeColor = System.Drawing.Color.Black;
            this.btnSelectAll.Location = new System.Drawing.Point(981, 5);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(69, 23);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "查询";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnChange
            // 
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChange.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChange.Location = new System.Drawing.Point(278, 7);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(31, 23);
            this.btnChange.TabIndex = 7;
            this.btnChange.Text = "<->";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // dtpRiqi
            // 
            this.dtpRiqi.CalendarForeColor = System.Drawing.Color.Magenta;
            this.dtpRiqi.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dtpRiqi.CalendarTitleForeColor = System.Drawing.Color.Magenta;
            this.dtpRiqi.CalendarTrailingForeColor = System.Drawing.Color.Fuchsia;
            this.dtpRiqi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRiqi.Location = new System.Drawing.Point(532, 7);
            this.dtpRiqi.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpRiqi.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpRiqi.Name = "dtpRiqi";
            this.dtpRiqi.Size = new System.Drawing.Size(101, 21);
            this.dtpRiqi.TabIndex = 9;
            // 
            // cboTo
            // 
            this.cboTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboTo.FormattingEnabled = true;
            this.cboTo.Location = new System.Drawing.Point(358, 8);
            this.cboTo.Name = "cboTo";
            this.cboTo.Size = new System.Drawing.Size(109, 20);
            this.cboTo.TabIndex = 8;
            this.cboTo.Text = "上海|SHH";
            // 
            // txtChufaCheci
            // 
            this.txtChufaCheci.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChufaCheci.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtChufaCheci.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtChufaCheci.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChufaCheci.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtChufaCheci.Location = new System.Drawing.Point(46, 35);
            this.txtChufaCheci.Name = "txtChufaCheci";
            this.txtChufaCheci.Size = new System.Drawing.Size(514, 21);
            this.txtChufaCheci.TabIndex = 12;
            // 
            // cboFrom
            // 
            this.cboFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboFrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboFrom.FormattingEnabled = true;
            this.cboFrom.Location = new System.Drawing.Point(161, 8);
            this.cboFrom.Name = "cboFrom";
            this.cboFrom.Size = new System.Drawing.Size(109, 20);
            this.cboFrom.TabIndex = 6;
            this.cboFrom.Text = "北京|BJP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(15, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "车次";
            // 
            // chkQuanbu
            // 
            this.chkQuanbu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkQuanbu.AutoSize = true;
            this.chkQuanbu.Checked = true;
            this.chkQuanbu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkQuanbu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkQuanbu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkQuanbu.Location = new System.Drawing.Point(569, 37);
            this.chkQuanbu.Name = "chkQuanbu";
            this.chkQuanbu.Size = new System.Drawing.Size(45, 16);
            this.chkQuanbu.TabIndex = 13;
            this.chkQuanbu.Text = "全部";
            this.chkQuanbu.UseVisualStyleBackColor = true;
            this.chkQuanbu.Click += new System.EventHandler(this.chkQuanbu_Click);
            // 
            // chkDongche
            // 
            this.chkDongche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDongche.AutoSize = true;
            this.chkDongche.Checked = true;
            this.chkDongche.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDongche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDongche.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkDongche.Location = new System.Drawing.Point(617, 37);
            this.chkDongche.Name = "chkDongche";
            this.chkDongche.Size = new System.Drawing.Size(51, 16);
            this.chkDongche.TabIndex = 14;
            this.chkDongche.Text = "D动车";
            this.chkDongche.UseVisualStyleBackColor = true;
            this.chkDongche.CheckedChanged += new System.EventHandler(this.chk_Click);
            // 
            // rbtnGuolu
            // 
            this.rbtnGuolu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnGuolu.AutoSize = true;
            this.rbtnGuolu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnGuolu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnGuolu.Location = new System.Drawing.Point(1006, 37);
            this.rbtnGuolu.Name = "rbtnGuolu";
            this.rbtnGuolu.Size = new System.Drawing.Size(46, 16);
            this.rbtnGuolu.TabIndex = 21;
            this.rbtnGuolu.Text = "过路";
            this.rbtnGuolu.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(120, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "出发地";
            // 
            // chkZhida
            // 
            this.chkZhida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkZhida.AutoSize = true;
            this.chkZhida.Checked = true;
            this.chkZhida.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkZhida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkZhida.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkZhida.Location = new System.Drawing.Point(677, 37);
            this.chkZhida.Name = "chkZhida";
            this.chkZhida.Size = new System.Drawing.Size(51, 16);
            this.chkZhida.TabIndex = 15;
            this.chkZhida.Text = "Z字头";
            this.chkZhida.UseVisualStyleBackColor = true;
            this.chkZhida.CheckedChanged += new System.EventHandler(this.chk_Click);
            // 
            // rbtnShifa
            // 
            this.rbtnShifa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnShifa.AutoSize = true;
            this.rbtnShifa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnShifa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnShifa.Location = new System.Drawing.Point(954, 37);
            this.rbtnShifa.Name = "rbtnShifa";
            this.rbtnShifa.Size = new System.Drawing.Size(46, 16);
            this.rbtnShifa.TabIndex = 20;
            this.rbtnShifa.Text = "始发";
            this.rbtnShifa.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(643, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "出发时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(313, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "目的地";
            // 
            // chkTekuai
            // 
            this.chkTekuai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTekuai.AutoSize = true;
            this.chkTekuai.Checked = true;
            this.chkTekuai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTekuai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTekuai.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTekuai.Location = new System.Drawing.Point(731, 37);
            this.chkTekuai.Name = "chkTekuai";
            this.chkTekuai.Size = new System.Drawing.Size(51, 16);
            this.chkTekuai.TabIndex = 1;
            this.chkTekuai.Text = "T字头";
            this.chkTekuai.UseVisualStyleBackColor = true;
            this.chkTekuai.CheckedChanged += new System.EventHandler(this.chk_Click);
            // 
            // rbtnQuanbu
            // 
            this.rbtnQuanbu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnQuanbu.AutoSize = true;
            this.rbtnQuanbu.Checked = true;
            this.rbtnQuanbu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnQuanbu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbtnQuanbu.Location = new System.Drawing.Point(901, 37);
            this.rbtnQuanbu.Name = "rbtnQuanbu";
            this.rbtnQuanbu.Size = new System.Drawing.Size(46, 16);
            this.rbtnQuanbu.TabIndex = 18;
            this.rbtnQuanbu.TabStop = true;
            this.rbtnQuanbu.Text = "全部";
            this.rbtnQuanbu.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(473, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "出发日期";
            // 
            // chkKuaisu
            // 
            this.chkKuaisu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkKuaisu.AutoSize = true;
            this.chkKuaisu.Checked = true;
            this.chkKuaisu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKuaisu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkKuaisu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkKuaisu.Location = new System.Drawing.Point(785, 37);
            this.chkKuaisu.Name = "chkKuaisu";
            this.chkKuaisu.Size = new System.Drawing.Size(51, 16);
            this.chkKuaisu.TabIndex = 1;
            this.chkKuaisu.Text = "K字头";
            this.chkKuaisu.UseVisualStyleBackColor = true;
            this.chkKuaisu.CheckedChanged += new System.EventHandler(this.chk_Click);
            // 
            // chkQita
            // 
            this.chkQita.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkQita.AutoSize = true;
            this.chkQita.Checked = true;
            this.chkQita.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkQita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkQita.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkQita.Location = new System.Drawing.Point(839, 37);
            this.chkQita.Name = "chkQita";
            this.chkQita.Size = new System.Drawing.Size(45, 16);
            this.chkQita.TabIndex = 8;
            this.chkQita.Text = "其它";
            this.chkQita.UseVisualStyleBackColor = true;
            this.chkQita.CheckedChanged += new System.EventHandler(this.chk_Click);
            // 
            // lblAutoBook
            // 
            this.lblAutoBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblAutoBook.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAutoBook.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAutoBook.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.lblAutoBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblAutoBook.Location = new System.Drawing.Point(0, 180);
            this.lblAutoBook.Name = "lblAutoBook";
            this.lblAutoBook.Size = new System.Drawing.Size(1056, 21);
            this.lblAutoBook.TabIndex = 44;
            this.lblAutoBook.Text = "自动预定设置";
            this.lblAutoBook.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAutoBook.Click += new System.EventHandler(this.lblAutoBook_Click);
            // 
            // plAutoBook
            // 
            this.plAutoBook.Controls.Add(this.flplPassengers);
            this.plAutoBook.Controls.Add(this.flplTrainNo);
            this.plAutoBook.Controls.Add(this.flplSeatType);
            this.plAutoBook.Controls.Add(this.panel2);
            this.plAutoBook.Controls.Add(this.plRightBottom);
            this.plAutoBook.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plAutoBook.Location = new System.Drawing.Point(0, 201);
            this.plAutoBook.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.plAutoBook.Name = "plAutoBook";
            this.plAutoBook.Size = new System.Drawing.Size(1056, 149);
            this.plAutoBook.TabIndex = 43;
            // 
            // flplPassengers
            // 
            this.flplPassengers.Controls.Add(this.lblPassenger);
            this.flplPassengers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flplPassengers.Location = new System.Drawing.Point(0, 0);
            this.flplPassengers.Name = "flplPassengers";
            this.flplPassengers.Size = new System.Drawing.Size(866, 67);
            this.flplPassengers.TabIndex = 37;
            // 
            // lblPassenger
            // 
            this.lblPassenger.AutoSize = true;
            this.lblPassenger.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPassenger.Location = new System.Drawing.Point(3, 5);
            this.lblPassenger.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.lblPassenger.Name = "lblPassenger";
            this.lblPassenger.Size = new System.Drawing.Size(41, 12);
            this.lblPassenger.TabIndex = 0;
            this.lblPassenger.Text = "乘客：";
            this.lblPassenger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flplTrainNo
            // 
            this.flplTrainNo.Controls.Add(this.label13);
            this.flplTrainNo.Controls.Add(this.label21);
            this.flplTrainNo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flplTrainNo.Location = new System.Drawing.Point(0, 67);
            this.flplTrainNo.Name = "flplTrainNo";
            this.flplTrainNo.Size = new System.Drawing.Size(866, 28);
            this.flplTrainNo.TabIndex = 38;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 24);
            this.label13.TabIndex = 1;
            this.label13.Text = "车次：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label21.Location = new System.Drawing.Point(50, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(154, 24);
            this.label21.TabIndex = 3;
            this.label21.Text = "[双击上面的车次添加]";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flplSeatType
            // 
            this.flplSeatType.Controls.Add(this.label14);
            this.flplSeatType.Controls.Add(this.cboSeatType);
            this.flplSeatType.Controls.Add(this.label22);
            this.flplSeatType.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flplSeatType.Location = new System.Drawing.Point(0, 95);
            this.flplSeatType.Name = "flplSeatType";
            this.flplSeatType.Size = new System.Drawing.Size(866, 26);
            this.flplSeatType.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 24);
            this.label14.TabIndex = 1;
            this.label14.Text = "席别：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSeatType
            // 
            this.cboSeatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeatType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSeatType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboSeatType.FormattingEnabled = true;
            this.cboSeatType.Items.AddRange(new object[] {
            "商务座",
            "特等座",
            "一等座",
            "二等座",
            "高级软卧",
            "软卧",
            "硬卧",
            "软座",
            "硬座",
            "无座"});
            this.cboSeatType.Location = new System.Drawing.Point(50, 2);
            this.cboSeatType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.cboSeatType.Name = "cboSeatType";
            this.cboSeatType.Size = new System.Drawing.Size(74, 20);
            this.cboSeatType.TabIndex = 2;
            this.cboSeatType.SelectedIndexChanged += new System.EventHandler(this.cboSeatType_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label22.Location = new System.Drawing.Point(130, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(138, 24);
            this.label22.TabIndex = 4;
            this.label22.Text = "[下拉选择你需要的席别]";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblHitCache);
            this.panel2.Controls.Add(this.lblServerTime);
            this.panel2.Controls.Add(this.lblTime);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 121);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(866, 28);
            this.panel2.TabIndex = 42;
            // 
            // lblHitCache
            // 
            this.lblHitCache.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHitCache.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblHitCache.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblHitCache.Location = new System.Drawing.Point(507, 4);
            this.lblHitCache.Name = "lblHitCache";
            this.lblHitCache.Size = new System.Drawing.Size(359, 24);
            this.lblHitCache.TabIndex = 6;
            this.lblHitCache.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblServerTime
            // 
            this.lblServerTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServerTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblServerTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblServerTime.Location = new System.Drawing.Point(84, 4);
            this.lblServerTime.Name = "lblServerTime";
            this.lblServerTime.Size = new System.Drawing.Size(417, 24);
            this.lblServerTime.TabIndex = 5;
            this.lblServerTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTime.Location = new System.Drawing.Point(1, 4);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(77, 24);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "[服务器时间]";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plRightBottom
            // 
            this.plRightBottom.Controls.Add(this.label2);
            this.plRightBottom.Controls.Add(this.chkSelectTurn);
            this.plRightBottom.Controls.Add(this.rbtnSeatTypeFirst);
            this.plRightBottom.Controls.Add(this.rbtnTrainNoFirst);
            this.plRightBottom.Controls.Add(this.AutoPicker);
            this.plRightBottom.Controls.Add(this.btnAutoBook);
            this.plRightBottom.Controls.Add(this.lblRefreshTime);
            this.plRightBottom.Controls.Add(this.lblCostTime);
            this.plRightBottom.Controls.Add(this.label17);
            this.plRightBottom.Controls.Add(this.label16);
            this.plRightBottom.Controls.Add(this.numSelectSpan);
            this.plRightBottom.Controls.Add(this.label15);
            this.plRightBottom.Dock = System.Windows.Forms.DockStyle.Right;
            this.plRightBottom.Location = new System.Drawing.Point(866, 0);
            this.plRightBottom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.plRightBottom.Name = "plRightBottom";
            this.plRightBottom.Size = new System.Drawing.Size(190, 149);
            this.plRightBottom.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(11, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 47;
            this.label2.Text = "蹲点抢票：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkSelectTurn
            // 
            this.chkSelectTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSelectTurn.AutoSize = true;
            this.chkSelectTurn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSelectTurn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSelectTurn.Location = new System.Drawing.Point(10, 127);
            this.chkSelectTurn.Name = "chkSelectTurn";
            this.chkSelectTurn.Size = new System.Drawing.Size(93, 16);
            this.chkSelectTurn.TabIndex = 46;
            this.chkSelectTurn.Text = "启用轮查功能";
            this.chkSelectTurn.UseVisualStyleBackColor = true;
            this.chkSelectTurn.Click += new System.EventHandler(this.chkSelectTurn_Click);
            // 
            // rbtnSeatTypeFirst
            // 
            this.rbtnSeatTypeFirst.AutoSize = true;
            this.rbtnSeatTypeFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnSeatTypeFirst.Location = new System.Drawing.Point(100, 5);
            this.rbtnSeatTypeFirst.Name = "rbtnSeatTypeFirst";
            this.rbtnSeatTypeFirst.Size = new System.Drawing.Size(70, 16);
            this.rbtnSeatTypeFirst.TabIndex = 45;
            this.rbtnSeatTypeFirst.Text = "席别优先";
            this.rbtnSeatTypeFirst.UseVisualStyleBackColor = true;
            // 
            // rbtnTrainNoFirst
            // 
            this.rbtnTrainNoFirst.AutoSize = true;
            this.rbtnTrainNoFirst.Checked = true;
            this.rbtnTrainNoFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnTrainNoFirst.Location = new System.Drawing.Point(12, 5);
            this.rbtnTrainNoFirst.Name = "rbtnTrainNoFirst";
            this.rbtnTrainNoFirst.Size = new System.Drawing.Size(70, 16);
            this.rbtnTrainNoFirst.TabIndex = 44;
            this.rbtnTrainNoFirst.TabStop = true;
            this.rbtnTrainNoFirst.Text = "车次优先";
            this.rbtnTrainNoFirst.UseVisualStyleBackColor = true;
            // 
            // AutoPicker
            // 
            this.AutoPicker.CustomFormat = "HH:mm:ss";
            this.AutoPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.AutoPicker.Location = new System.Drawing.Point(87, 95);
            this.AutoPicker.MinDate = new System.DateTime(2013, 5, 10, 0, 0, 0, 0);
            this.AutoPicker.Name = "AutoPicker";
            this.AutoPicker.ShowCheckBox = true;
            this.AutoPicker.ShowUpDown = true;
            this.AutoPicker.Size = new System.Drawing.Size(96, 21);
            this.AutoPicker.TabIndex = 43;
            this.AutoPicker.Value = new System.DateTime(2013, 5, 10, 0, 0, 0, 0);
            this.AutoPicker.ValueChanged += new System.EventHandler(this.AutoPicker_ValueChanged);
            // 
            // btnAutoBook
            // 
            this.btnAutoBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAutoBook.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAutoBook.Location = new System.Drawing.Point(115, 124);
            this.btnAutoBook.Name = "btnAutoBook";
            this.btnAutoBook.Size = new System.Drawing.Size(68, 23);
            this.btnAutoBook.TabIndex = 6;
            this.btnAutoBook.Text = "抢票";
            this.btnAutoBook.UseVisualStyleBackColor = true;
            this.btnAutoBook.Click += new System.EventHandler(this.btnAutoBook_Click);
            // 
            // lblRefreshTime
            // 
            this.lblRefreshTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRefreshTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRefreshTime.Location = new System.Drawing.Point(69, 72);
            this.lblRefreshTime.Name = "lblRefreshTime";
            this.lblRefreshTime.Size = new System.Drawing.Size(102, 20);
            this.lblRefreshTime.TabIndex = 7;
            this.lblRefreshTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCostTime
            // 
            this.lblCostTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCostTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCostTime.Location = new System.Drawing.Point(69, 47);
            this.lblCostTime.Name = "lblCostTime";
            this.lblCostTime.Size = new System.Drawing.Size(102, 20);
            this.lblCostTime.TabIndex = 6;
            this.lblCostTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(10, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 20);
            this.label17.TabIndex = 5;
            this.label17.Text = "刷新时间：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(10, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 20);
            this.label16.TabIndex = 4;
            this.label16.Text = "抢票用时：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numSelectSpan
            // 
            this.numSelectSpan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numSelectSpan.Location = new System.Drawing.Point(87, 23);
            this.numSelectSpan.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numSelectSpan.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numSelectSpan.Name = "numSelectSpan";
            this.numSelectSpan.Size = new System.Drawing.Size(96, 21);
            this.numSelectSpan.TabIndex = 3;
            this.numSelectSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSelectSpan.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numSelectSpan.ValueChanged += new System.EventHandler(this.numSelectSpan_ValueChanged);
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(10, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "查询间隔：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fplTurnDates
            // 
            this.fplTurnDates.Controls.Add(this.flpTurnCheckBox);
            this.fplTurnDates.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fplTurnDates.Location = new System.Drawing.Point(0, 350);
            this.fplTurnDates.Margin = new System.Windows.Forms.Padding(0);
            this.fplTurnDates.Name = "fplTurnDates";
            this.fplTurnDates.Size = new System.Drawing.Size(1056, 49);
            this.fplTurnDates.TabIndex = 45;
            this.fplTurnDates.Visible = false;
            // 
            // flpTurnCheckBox
            // 
            this.flpTurnCheckBox.Controls.Add(this.checkBox1);
            this.flpTurnCheckBox.Controls.Add(this.checkBox2);
            this.flpTurnCheckBox.Controls.Add(this.checkBox3);
            this.flpTurnCheckBox.Controls.Add(this.checkBox4);
            this.flpTurnCheckBox.Controls.Add(this.checkBox5);
            this.flpTurnCheckBox.Controls.Add(this.checkBox6);
            this.flpTurnCheckBox.Controls.Add(this.checkBox7);
            this.flpTurnCheckBox.Controls.Add(this.checkBox8);
            this.flpTurnCheckBox.Controls.Add(this.checkBox9);
            this.flpTurnCheckBox.Controls.Add(this.checkBox10);
            this.flpTurnCheckBox.Controls.Add(this.checkBox11);
            this.flpTurnCheckBox.Controls.Add(this.checkBox12);
            this.flpTurnCheckBox.Controls.Add(this.checkBox13);
            this.flpTurnCheckBox.Controls.Add(this.checkBox14);
            this.flpTurnCheckBox.Controls.Add(this.checkBox15);
            this.flpTurnCheckBox.Controls.Add(this.checkBox16);
            this.flpTurnCheckBox.Controls.Add(this.checkBox17);
            this.flpTurnCheckBox.Controls.Add(this.checkBox18);
            this.flpTurnCheckBox.Controls.Add(this.checkBox19);
            this.flpTurnCheckBox.Controls.Add(this.checkBox20);
            this.flpTurnCheckBox.Location = new System.Drawing.Point(3, 3);
            this.flpTurnCheckBox.Name = "flpTurnCheckBox";
            this.flpTurnCheckBox.Size = new System.Drawing.Size(1049, 46);
            this.flpTurnCheckBox.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(30, 3);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 16);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "2013-04-07";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox2.Location = new System.Drawing.Point(131, 3);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(81, 16);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "2013-04-07";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox3.Location = new System.Drawing.Point(232, 3);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(81, 16);
            this.checkBox3.TabIndex = 16;
            this.checkBox3.Text = "2013-04-07";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox4.Location = new System.Drawing.Point(333, 3);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(81, 16);
            this.checkBox4.TabIndex = 17;
            this.checkBox4.Text = "2013-04-07";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox5.AutoSize = true;
            this.checkBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox5.Location = new System.Drawing.Point(434, 3);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(81, 16);
            this.checkBox5.TabIndex = 18;
            this.checkBox5.Text = "2013-04-07";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox6.AutoSize = true;
            this.checkBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox6.Location = new System.Drawing.Point(535, 3);
            this.checkBox6.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(81, 16);
            this.checkBox6.TabIndex = 19;
            this.checkBox6.Text = "2013-04-07";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox7.AutoSize = true;
            this.checkBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox7.Location = new System.Drawing.Point(636, 3);
            this.checkBox7.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(81, 16);
            this.checkBox7.TabIndex = 20;
            this.checkBox7.Text = "2013-04-07";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox8.AutoSize = true;
            this.checkBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox8.Location = new System.Drawing.Point(737, 3);
            this.checkBox8.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(81, 16);
            this.checkBox8.TabIndex = 21;
            this.checkBox8.Text = "2013-04-07";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox9.AutoSize = true;
            this.checkBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox9.Location = new System.Drawing.Point(838, 3);
            this.checkBox9.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(81, 16);
            this.checkBox9.TabIndex = 22;
            this.checkBox9.Text = "2013-04-07";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox10.AutoSize = true;
            this.checkBox10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox10.Location = new System.Drawing.Point(939, 3);
            this.checkBox10.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(81, 16);
            this.checkBox10.TabIndex = 23;
            this.checkBox10.Text = "2013-04-07";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox11.AutoSize = true;
            this.checkBox11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox11.Location = new System.Drawing.Point(30, 25);
            this.checkBox11.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(81, 16);
            this.checkBox11.TabIndex = 24;
            this.checkBox11.Text = "2013-04-07";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox12.AutoSize = true;
            this.checkBox12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox12.Location = new System.Drawing.Point(131, 25);
            this.checkBox12.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(81, 16);
            this.checkBox12.TabIndex = 25;
            this.checkBox12.Text = "2013-04-07";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // checkBox13
            // 
            this.checkBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox13.AutoSize = true;
            this.checkBox13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox13.Location = new System.Drawing.Point(232, 25);
            this.checkBox13.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox13.Name = "checkBox13";
            this.checkBox13.Size = new System.Drawing.Size(81, 16);
            this.checkBox13.TabIndex = 26;
            this.checkBox13.Text = "2013-04-07";
            this.checkBox13.UseVisualStyleBackColor = true;
            // 
            // checkBox14
            // 
            this.checkBox14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox14.AutoSize = true;
            this.checkBox14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox14.Location = new System.Drawing.Point(333, 25);
            this.checkBox14.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox14.Name = "checkBox14";
            this.checkBox14.Size = new System.Drawing.Size(81, 16);
            this.checkBox14.TabIndex = 27;
            this.checkBox14.Text = "2013-04-07";
            this.checkBox14.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox15.AutoSize = true;
            this.checkBox15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox15.Location = new System.Drawing.Point(434, 25);
            this.checkBox15.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(81, 16);
            this.checkBox15.TabIndex = 28;
            this.checkBox15.Text = "2013-04-07";
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox16.AutoSize = true;
            this.checkBox16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox16.Location = new System.Drawing.Point(535, 25);
            this.checkBox16.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(81, 16);
            this.checkBox16.TabIndex = 29;
            this.checkBox16.Text = "2013-04-07";
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            this.checkBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox17.AutoSize = true;
            this.checkBox17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox17.Location = new System.Drawing.Point(636, 25);
            this.checkBox17.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(81, 16);
            this.checkBox17.TabIndex = 30;
            this.checkBox17.Text = "2013-04-07";
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // checkBox18
            // 
            this.checkBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox18.AutoSize = true;
            this.checkBox18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox18.Location = new System.Drawing.Point(737, 25);
            this.checkBox18.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(81, 16);
            this.checkBox18.TabIndex = 31;
            this.checkBox18.Text = "2013-04-07";
            this.checkBox18.UseVisualStyleBackColor = true;
            // 
            // checkBox19
            // 
            this.checkBox19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox19.AutoSize = true;
            this.checkBox19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox19.Location = new System.Drawing.Point(838, 25);
            this.checkBox19.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(81, 16);
            this.checkBox19.TabIndex = 32;
            this.checkBox19.Text = "2013-04-07";
            this.checkBox19.UseVisualStyleBackColor = true;
            // 
            // checkBox20
            // 
            this.checkBox20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox20.AutoSize = true;
            this.checkBox20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox20.Location = new System.Drawing.Point(939, 25);
            this.checkBox20.Margin = new System.Windows.Forms.Padding(17, 3, 3, 3);
            this.checkBox20.Name = "checkBox20";
            this.checkBox20.Size = new System.Drawing.Size(81, 16);
            this.checkBox20.TabIndex = 33;
            this.checkBox20.Text = "2013-04-07";
            this.checkBox20.UseVisualStyleBackColor = true;
            // 
            // lblAutoSwitch
            // 
            this.lblAutoSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblAutoSwitch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAutoSwitch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAutoSwitch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.lblAutoSwitch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblAutoSwitch.Location = new System.Drawing.Point(0, 399);
            this.lblAutoSwitch.Name = "lblAutoSwitch";
            this.lblAutoSwitch.Size = new System.Drawing.Size(1056, 21);
            this.lblAutoSwitch.TabIndex = 48;
            this.lblAutoSwitch.Text = "自动切换解析服务器";
            this.lblAutoSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAutoSwitch.Click += new System.EventHandler(this.lblAutoSwitch_Click);
            // 
            // plAutoSwitch
            // 
            this.plAutoSwitch.Controls.Add(this.label25);
            this.plAutoSwitch.Controls.Add(this.plSourceFrom);
            this.plAutoSwitch.Controls.Add(this.chkAllowSwitch);
            this.plAutoSwitch.Controls.Add(this.lvSwitchStatus);
            this.plAutoSwitch.Controls.Add(this.btnInitHosts);
            this.plAutoSwitch.Controls.Add(this.label24);
            this.plAutoSwitch.Controls.Add(this.richTextBox2);
            this.plAutoSwitch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plAutoSwitch.Location = new System.Drawing.Point(0, 420);
            this.plAutoSwitch.Name = "plAutoSwitch";
            this.plAutoSwitch.Size = new System.Drawing.Size(1056, 100);
            this.plAutoSwitch.TabIndex = 1;
            this.plAutoSwitch.Visible = false;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(138, 73);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(243, 24);
            this.label25.TabIndex = 50;
            this.label25.Text = "[将hosts文件恢复到最原始状态]";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // plSourceFrom
            // 
            this.plSourceFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plSourceFrom.Controls.Add(this.rbtnWifeATM);
            this.plSourceFrom.Controls.Add(this.rbtnFishlee);
            this.plSourceFrom.Location = new System.Drawing.Point(140, 49);
            this.plSourceFrom.Name = "plSourceFrom";
            this.plSourceFrom.Size = new System.Drawing.Size(241, 19);
            this.plSourceFrom.TabIndex = 49;
            this.plSourceFrom.Visible = false;
            // 
            // rbtnWifeATM
            // 
            this.rbtnWifeATM.AutoSize = true;
            this.rbtnWifeATM.Location = new System.Drawing.Point(113, 1);
            this.rbtnWifeATM.Name = "rbtnWifeATM";
            this.rbtnWifeATM.Size = new System.Drawing.Size(113, 16);
            this.rbtnWifeATM.TabIndex = 48;
            this.rbtnWifeATM.Text = "[老婆的ATM]的源";
            this.rbtnWifeATM.UseVisualStyleBackColor = true;
            // 
            // rbtnFishlee
            // 
            this.rbtnFishlee.AutoSize = true;
            this.rbtnFishlee.Checked = true;
            this.rbtnFishlee.Location = new System.Drawing.Point(7, 1);
            this.rbtnFishlee.Name = "rbtnFishlee";
            this.rbtnFishlee.Size = new System.Drawing.Size(101, 16);
            this.rbtnFishlee.TabIndex = 47;
            this.rbtnFishlee.TabStop = true;
            this.rbtnFishlee.Text = "[Fishlee]的源";
            this.rbtnFishlee.UseVisualStyleBackColor = true;
            // 
            // chkAllowSwitch
            // 
            this.chkAllowSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAllowSwitch.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAllowSwitch.AutoSize = true;
            this.chkAllowSwitch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAllowSwitch.Location = new System.Drawing.Point(11, 47);
            this.chkAllowSwitch.Name = "chkAllowSwitch";
            this.chkAllowSwitch.Size = new System.Drawing.Size(123, 22);
            this.chkAllowSwitch.TabIndex = 30;
            this.chkAllowSwitch.Text = "启用自动切换服务器";
            this.chkAllowSwitch.UseVisualStyleBackColor = true;
            this.chkAllowSwitch.CheckedChanged += new System.EventHandler(this.chkAllowSwitch_CheckedChanged);
            // 
            // lvSwitchStatus
            // 
            this.lvSwitchStatus.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvSwitchStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSwitchStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lvSwitchStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvSwitchStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.时间,
            this.信息});
            this.lvSwitchStatus.ForeColor = System.Drawing.Color.Black;
            this.lvSwitchStatus.FullRowSelect = true;
            this.lvSwitchStatus.Location = new System.Drawing.Point(394, 3);
            this.lvSwitchStatus.MultiSelect = false;
            this.lvSwitchStatus.Name = "lvSwitchStatus";
            this.lvSwitchStatus.Size = new System.Drawing.Size(657, 94);
            this.lvSwitchStatus.TabIndex = 46;
            this.lvSwitchStatus.UseCompatibleStateImageBehavior = false;
            this.lvSwitchStatus.View = System.Windows.Forms.View.Details;
            // 
            // 时间
            // 
            this.时间.Text = "时间";
            this.时间.Width = 70;
            // 
            // 信息
            // 
            this.信息.Text = "信息";
            this.信息.Width = 550;
            // 
            // btnInitHosts
            // 
            this.btnInitHosts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInitHosts.ForeColor = System.Drawing.Color.Black;
            this.btnInitHosts.Location = new System.Drawing.Point(11, 74);
            this.btnInitHosts.Name = "btnInitHosts";
            this.btnInitHosts.Size = new System.Drawing.Size(123, 23);
            this.btnInitHosts.TabIndex = 45;
            this.btnInitHosts.Text = "初始化hosts文件";
            this.btnInitHosts.UseVisualStyleBackColor = true;
            this.btnInitHosts.Click += new System.EventHandler(this.btnInitHosts_Click);
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label24.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label24.Location = new System.Drawing.Point(387, 7);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(1, 86);
            this.label24.TabIndex = 41;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.ForeColor = System.Drawing.Color.Black;
            this.richTextBox2.Location = new System.Drawing.Point(11, 6);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(370, 35);
            this.richTextBox2.TabIndex = 40;
            this.richTextBox2.Text = "这里会根据运行环境的网络状态，自动选择最快的缓存服务器去解析12306,退出后自动恢复hosts文件";
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblClose.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClose.ForeColor = System.Drawing.Color.White;
            this.lblClose.Location = new System.Drawing.Point(1047, 6);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(16, 16);
            this.lblClose.TabIndex = 19;
            this.lblClose.Text = "×";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // lblMini
            // 
            this.lblMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMini.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblMini.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMini.ForeColor = System.Drawing.Color.White;
            this.lblMini.Location = new System.Drawing.Point(1009, 6);
            this.lblMini.Name = "lblMini";
            this.lblMini.Size = new System.Drawing.Size(16, 16);
            this.lblMini.TabIndex = 20;
            this.lblMini.Text = "－";
            this.lblMini.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMini.Click += new System.EventHandler(this.lblMini_Click);
            this.lblMini.MouseEnter += new System.EventHandler(this.lblMini_MouseEnter);
            this.lblMini.MouseLeave += new System.EventHandler(this.lblMini_MouseLeave);
            // 
            // lblMax
            // 
            this.lblMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblMax.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMax.ForeColor = System.Drawing.Color.White;
            this.lblMax.Location = new System.Drawing.Point(1028, 6);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(16, 16);
            this.lblMax.TabIndex = 21;
            this.lblMax.Text = "□";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMax.Click += new System.EventHandler(this.lblMax_Click);
            this.lblMax.MouseEnter += new System.EventHandler(this.lblMax_MouseEnter);
            this.lblMax.MouseLeave += new System.EventHandler(this.lblMax_MouseLeave);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tmUpdateServerTime
            // 
            this.tmUpdateServerTime.Interval = 1000;
            this.tmUpdateServerTime.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // notice
            // 
            this.notice.Icon = ((System.Drawing.Icon)(resources.GetObject("notice.Icon")));
            this.notice.Text = "12306 订票小助手 C# 版";
            this.notice.Click += new System.EventHandler(this.notice_Click);
            // 
            // lblHide
            // 
            this.lblHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblHide.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Bold);
            this.lblHide.ForeColor = System.Drawing.Color.White;
            this.lblHide.Location = new System.Drawing.Point(988, 6);
            this.lblHide.Name = "lblHide";
            this.lblHide.Size = new System.Drawing.Size(16, 16);
            this.lblHide.TabIndex = 29;
            this.lblHide.Text = "▽";
            this.lblHide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHide.Click += new System.EventHandler(this.lblHide_Click);
            this.lblHide.MouseEnter += new System.EventHandler(this.lblHide_MouseEnter);
            this.lblHide.MouseLeave += new System.EventHandler(this.lblHide_MouseLeave);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("宋体", 8F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblVersion.Location = new System.Drawing.Point(586, 10);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(47, 11);
            this.lblVersion.TabIndex = 30;
            this.lblVersion.Text = "Version";
            this.lblVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblVersion_MouseDown);
            // 
            // tmWatch
            // 
            this.tmWatch.Interval = 1000;
            this.tmWatch.Tick += new System.EventHandler(this.tmWatch_Tick);
            // 
            // formSelectTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1070, 580);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblHide);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMini);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.plAllControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1070, 580);
            this.Name = "formSelectTicket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "余票查询";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formSelectTicket_FormClosing);
            this.Load += new System.EventHandler(this.formSelectTicket_Load);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.plAllControl.ResumeLayout(false);
            this.plQuickTrainInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuickTrainInfo)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.plCustom.ResumeLayout(false);
            this.plCustom.PerformLayout();
            this.plSetup.ResumeLayout(false);
            this.plSetup.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.plAutoBook.ResumeLayout(false);
            this.flplPassengers.ResumeLayout(false);
            this.flplPassengers.PerformLayout();
            this.flplTrainNo.ResumeLayout(false);
            this.flplSeatType.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.plRightBottom.ResumeLayout(false);
            this.plRightBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectSpan)).EndInit();
            this.fplTurnDates.ResumeLayout(false);
            this.flpTurnCheckBox.ResumeLayout(false);
            this.flpTurnCheckBox.PerformLayout();
            this.plAutoSwitch.ResumeLayout(false);
            this.plAutoSwitch.PerformLayout();
            this.plSourceFrom.ResumeLayout(false);
            this.plSourceFrom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel plAllControl;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMini;
        private System.Windows.Forms.Panel plSetup;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.DateTimePicker dtpRiqi;
        private System.Windows.Forms.ComboBox cboTo;
        private System.Windows.Forms.TextBox txtChufaCheci;
        private System.Windows.Forms.ComboBox cboFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbtnDan;
        private System.Windows.Forms.CheckBox chkQuanbu;
        private System.Windows.Forms.RadioButton rbtnWangfan;
        private System.Windows.Forms.CheckBox chkDongche;
        private System.Windows.Forms.RadioButton rbtnGuolu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkZhida;
        private System.Windows.Forms.RadioButton rbtnShifa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkTekuai;
        private System.Windows.Forms.RadioButton rbtnQuanbu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkKuaisu;
        private System.Windows.Forms.CheckBox chkQita;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.DataGridView dgvTrainView;
        private System.Windows.Forms.Label lblLastSelectTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel plRightBottom;
        private System.Windows.Forms.Label lblRefreshTime;
        private System.Windows.Forms.Label lblCostTime;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numSelectSpan;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.FlowLayoutPanel flplTrainNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.FlowLayoutPanel flplPassengers;
        private System.Windows.Forms.Label lblPassenger;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblServerTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnAutoBook;
        private System.Windows.Forms.DateTimePicker AutoPicker;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Label lblAutoBook;
        private System.Windows.Forms.Panel plAutoBook;
        public System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.RadioButton rbtnSeatTypeFirst;
        private System.Windows.Forms.RadioButton rbtnTrainNoFirst;
        private System.Windows.Forms.FlowLayoutPanel flplSeatType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboSeatType;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer tmUpdateServerTime;
        private System.Windows.Forms.LinkLabel lkOrderSelect;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.LinkLabel lblDeleteCookies;
        private System.Windows.Forms.CheckBox chkSelectTurn;
        private System.Windows.Forms.FlowLayoutPanel fplTurnDates;
        private System.Windows.Forms.FlowLayoutPanel flpTurnCheckBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox13;
        private System.Windows.Forms.CheckBox checkBox14;
        private System.Windows.Forms.CheckBox checkBox15;
        private System.Windows.Forms.CheckBox checkBox16;
        private System.Windows.Forms.CheckBox checkBox17;
        private System.Windows.Forms.CheckBox checkBox18;
        private System.Windows.Forms.CheckBox checkBox19;
        private System.Windows.Forms.CheckBox checkBox20;
        private System.Windows.Forms.Label lblHitCache;
        private System.Windows.Forms.ComboBox cboShijian;
        private System.Windows.Forms.NotifyIcon notice;
        private System.Windows.Forms.Label lblHide;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Station_train_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn From_station_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_station_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arrive_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn _9seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Pseat;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Mseat;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Oseat;
        private System.Windows.Forms.DataGridViewTextBoxColumn _6seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn _4seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn _3seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn _2seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn _1seat;
        private System.Windows.Forms.DataGridViewTextBoxColumn _0seat;
        private System.Windows.Forms.DataGridViewButtonColumn BookTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trainno4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkCQ;
        private System.Windows.Forms.CheckBox chkCL;
        private System.Windows.Forms.CheckBox chkCK;
        private System.Windows.Forms.CheckBox chkCA;
        private System.Windows.Forms.CheckBox chkCG;
        private System.Windows.Forms.CheckBox chkCD;
        private System.Windows.Forms.CheckBox chkCC;
        private System.Windows.Forms.CheckBox chkCZ;
        private System.Windows.Forms.CheckBox chkCT;
        private System.Windows.Forms.CheckBox chkCustomFilter;
        private System.Windows.Forms.CheckBox chkFilterNoSeat;
        private System.Windows.Forms.Label lblTrainsCount;
        private System.Windows.Forms.Panel plCustom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel lnkStartTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel lnkNewContent;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel plQuickTrainInfo;
        private System.Windows.Forms.DataGridView dgvQuickTrainInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示过站信息ToolStripMenuItem;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblQuickTrainInfo;
        private System.Windows.Forms.Label lblQuickClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.LinkLabel lnkLinkToCommon;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.LinkLabel lnkLinkToAdvice;
        private System.Windows.Forms.LinkLabel lnkLinkToBug;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.LinkLabel lnkLinkToMain;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.LinkLabel lnkLinkToDeveloper;
        private System.Windows.Forms.Panel plAutoSwitch;
        public System.Windows.Forms.Label lblAutoSwitch;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnInitHosts;
        private System.Windows.Forms.CheckBox chkAllowSwitch;
        private System.Windows.Forms.ListView lvSwitchStatus;
        private System.Windows.Forms.ColumnHeader 时间;
        private System.Windows.Forms.ColumnHeader 信息;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Timer tmWatch;
        private System.Windows.Forms.Panel plSourceFrom;
        private System.Windows.Forms.RadioButton rbtnWifeATM;
        private System.Windows.Forms.RadioButton rbtnFishlee;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label26;
    }
}