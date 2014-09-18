#define CHECK
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using aNyoNe.GetInfoFrom12306;
using System.Collections;
using System.Net;
using System.Threading;
using PopupControl;
using aNyoNe.AutoServerSwitch;
using System.Drawing.Drawing2D;
using _12306_Helper.Forms;

namespace _12306_Helper
{
    public partial class TicketMain : UserControl
    {
        Popup pop;
        ToolTip ttt;
        Dictionary<string, string> tmpStationName = new Dictionary<string, string>();
        string includeCode = string.Empty;
        bool isInitConfig = false;
        
        string trainClassType = "";
        int selectPassengerCount = 0;
        public bool _IsAutoWork = false;
        public int SafeTime { get; set; }//订单提交安全期
        DateTime startTime;
        List<ConfigList> configList;
        ConfigList config = new ConfigList(); //配置文件
        private List<QuickTrainData> quickTrainData = new List<QuickTrainData>();
        private Hashtable turnDateTable = new Hashtable();//存放轮查日期
        public List<string> _QuickAddSeatType = new List<string>();//存放坐席类别
        public List<string> _QuickAddTrainData = new List<string>();//存放火车车次
        private AutoBooker _autoBooker;//抢票
        IList<JsonTrainData> tmpTrainData = new List<JsonTrainData>(); //临时的车次列表
        public BindingList<JsonTrainData> _BindingData;
        public List<Nomal_Passengers> _passengersData=new List<Nomal_Passengers>();
        SelectTicketAction selectAction = new SelectTicketAction();
        GetPassengerAction passengerAction = new GetPassengerAction();
        HTML_Translation translation = new HTML_Translation();
        CDNSwitcher cdnSwitcher = new CDNSwitcher();
        Hashtable customColumn;
        Hashtable sortTable;
        private List<JsonTrainData> _trainData;
        private Hashtable _QuickPassengers = new Hashtable();//存放乘客
        public static TicketMain FormThis { get; private set; }
        private  CookieContainer cookieContainer = new CookieContainer();

        public CookieContainer FormCookie
        { set { if (cookieContainer != null)cookieContainer = value; else cookieContainer = new CookieContainer(); } }
        private string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private Control _frame = null;
        public Control Frame
        {
            set { try { this._frame = value; } catch { throw new ArgumentException(); } }
            get{ return this._frame;}
        }

        private ConfigList _config = new ConfigList();
        /// <summary>
        /// 当前标签页的配置信息
        /// </summary>
        public ConfigList Config {
            get
            {
                if (_config != null)
                {
                    _config.User = _userName;
                    _config.From = cboFrom.Text;
                    _config.To = cboTo.Text;
                    _config.Date = dtpRiqi.Value;
                    _config.Time = cboShijian.Text;
                    if(this.AutoPicker.Checked)
                        _config.WatchTime =this.AutoPicker.Value;
                    if (chkSelectTurn.Checked)
                    {
                        _config.Turn = true;
                        _config.TurnDates = turnDateTable;
                    }
                    else
                    {
                        _config.Turn = false;
                        _config.TurnDates = new Hashtable();
                    }

                    var cfgPassenger = new Hashtable();
                    foreach (var passenger in _passengersData.Where(x => x.IsCheck).Select(x => x).ToList<Nomal_Passengers>())
                    {
                        cfgPassenger.Add(string.Format("{0}|{1}", passenger.Passenger_name, passenger.Passenger_id_no), passenger);
                    }
                    _config.Passengers = cfgPassenger;//_QuickPassengers;
                    _config.SeatTypes = _QuickAddSeatType;
                    _config.TrainNos = _QuickAddTrainData;
                    return _config;
                }
                else
                {
                    _config=new ConfigList();
                    _config.User = _userName;
                    _config.From = cboFrom.Text;
                    _config.To = cboTo.Text;
                    _config.Date = dtpRiqi.Value;
                    _config.Time = cboShijian.Text;
                    if (this.AutoPicker.Checked)
                        _config.WatchTime = this.AutoPicker.Value;
                    if (chkSelectTurn.Checked)
                    {
                        _config.Turn = true;
                        _config.TurnDates = turnDateTable;
                    }
                    else
                    {
                        _config.Turn = false;
                        _config.TurnDates = new Hashtable();
                    }
                    var cfgPassenger = new Hashtable();
                    foreach (var passenger in _passengersData.Where(x => x.IsCheck).Select(x => x).ToList<Nomal_Passengers>())
                    {
                        cfgPassenger.Add(string.Format("{0}|{1}", passenger.Passenger_name, passenger.Passenger_id_no), passenger);
                    }
                    _config.Passengers = cfgPassenger;//_QuickPassengers;
                    _config.SeatTypes = _QuickAddSeatType;
                    _config.TrainNos = _QuickAddTrainData;
                    return _config;
                }
            }
            set
            {
                _config = value;
                _config.Init = true;
            }
        }

        ~TicketMain()
        {
            GC.Collect();
            GC.Collect();
        }

        public TicketMain(CookieContainer cookie,List<Nomal_Passengers> passenger, ConfigList cfg = null,Control frame=null)
        {
            InitializeComponent();
            this._frame = frame;
            var buttonColumn = new DataGridViewDisableButtonColumn();
            buttonColumn.Name = "BookTicket";
            buttonColumn.DataPropertyName = "buttonTextInfo";
            buttonColumn.HeaderText = "预 订";
            buttonColumn.Width = 110;
            buttonColumn.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = DataGridViewContentAlignment.MiddleCenter };
            dgvTrainView.Columns.Add(buttonColumn);
            var trainno = new DataGridViewTextBoxColumn();

            if (passenger != null)
                _passengersData.AddRange(passenger);// = passenger;
            else if (this._frame != null && ((TicketFrame)frame).Passengers.Count != 0)
            {
                _passengersData.AddRange(((TicketFrame)frame).Passengers);
            }


            trainno.Name = "train_no";
            trainno.DataPropertyName = "train_no";
            trainno.Visible = false;
            dgvTrainView.Columns.Add(trainno);
            //加载配置
            if (cfg != null && !cfg.Init)
            {
                _config = cfg;
                _config.Init = true;
                DeterMineCall(() =>
                {
                    _userName = _config.User;
                    cboFrom.Text = _config.From;
                    cboTo.Text = _config.To;
                    dtpRiqi.Value = _config.Date;
                    cboShijian.Text = _config.Time;
                    if (_config.Watched)
                    {
                        AutoPicker.Value = DateTime.Now;
                        AutoPicker.Checked = true;
                    }
                    if (_config.Turn == true)
                    {
                        chkSelectTurn.Checked = true;
                        turnDateTable = _config.TurnDates;
                    }
                    else
                    {
                        chkSelectTurn.Checked = false;
                    }
                    _QuickPassengers = _config.Passengers;
                    //_QuickAddSeatType = _config.SeatTypes;
                    //_QuickAddTrainData = _config.TrainNos;
                });
            }

            ttt = new ToolTip() { IsBalloon = true };
            InitCityCode();
            cookieContainer = cookie;
            InitColumns();
            InitSortInfo();
            configList = new List<ConfigList>();
            //dgvQuickTrainInfo.AutoGenerateColumns = false;
            FormThis = this;
            _trainData = new List<JsonTrainData>();
            _BindingData = new BindingList<JsonTrainData>(_trainData);
            SafeTime = ((TicketFrame)(_frame)).SafeTime;//默认的订单提交安全期
            //_passengersData = new List<Nomal_Passengers>();
            //cboFrom.GotFocus += cboFrom_GotFocus;
            //cboTo.GotFocus += cboTo_GotFocus;
            cboFrom.TextUpdate += new EventHandler(cboFrom_TextUpdate);
            cboTo.TextUpdate += new EventHandler(cboTo_TextUpdate);
            _autoBooker = new AutoBooker(this);
        }
        
        private void InitCityCode()
        {
            var tmp = CityTelcode.StationNames.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
            tmpStationName.Clear();
            for (int i = 0; i < tmp.Length; i++)
            {
                string[] t = tmp[i].Split('|');
                tmpStationName.Add(t[1], t[2]);
            }
        }
        private void InitColumns()
        {
            customColumn = new Hashtable();
            customColumn.Add("_9seat",true);
            customColumn.Add("_Pseat", true);
            customColumn.Add("_Mseat", true);
            customColumn.Add("_Oseat", true);
            customColumn.Add("_6seat", true);
            customColumn.Add("_4seat", true);
            customColumn.Add("_3seat", true);
            customColumn.Add("_2seat", true);
            customColumn.Add("_1seat", true);
            customColumn.Add("_0seat", true);
        }
        private void InitSortInfo()
        {
            sortTable = new Hashtable();
            sortTable.Add("Train_no", SortOrder.None);
            sortTable.Add("Start_time", SortOrder.None);
            sortTable.Add("Arrive_time", SortOrder.None);
            sortTable.Add("Lishi", SortOrder.None);

            sortTable.Add("Swz_num", SortOrder.None);
            sortTable.Add("Tz_num", SortOrder.None);
            sortTable.Add("Zy_num", SortOrder.None);
            sortTable.Add("Ze_num", SortOrder.None);
            sortTable.Add("Gr_num", SortOrder.None);
            sortTable.Add("Rw_num", SortOrder.None);
            sortTable.Add("Yw_num", SortOrder.None);
            sortTable.Add("Rz_num", SortOrder.None);
            sortTable.Add("Yz_num", SortOrder.None);
            sortTable.Add("Wz_num", SortOrder.None);
        }

        //初始化用户配置文件
        private void InitConfig()
        {
            if (isInitConfig)
            {
                DeterMineCall(() =>
                {
                    selectPassengerCount = 0;
                    foreach (var v in config.Passengers.Keys)
                    {
                        for (int i = 1; i < flplPassengers.Controls.Count; i++)
                        {
                            if (v.ToString().Contains(flplPassengers.Controls[i].Text) && v.ToString().Split('|')[1] == ((Nomal_Passengers)(flplPassengers.Controls[i].Tag)).Passenger_id_no)
                            {
                                ((CheckBox)flplPassengers.Controls[i]).Checked = true;
                            }
                        }
                    }
                });
            }
            else
            {
                isInitConfig = true;
                DeterMineCall(() =>
                {
                    if (_config != null&&_config.Init==true)
                    {
                        config = _config;
                    }
                    else
                    {
                        var cfgList = new List<ConfigList>();
                        var path = System.IO.Directory.GetCurrentDirectory() + "\\data\\" + _userName;
                        if (System.IO.Directory.Exists(path))
                            cfgList = LocalCookie.ReadConfigFromDisk_ConfigList(path + "\\config.cfg");
                        foreach (var c in cfgList.Where(x=>x.ParentName=="defaultPage"))
                        {
                            _config=config = (ConfigList) c;
                        }
                    }
                    SetConfigToControl(config);
                });
            }
        }

        /// <summary>
        /// 设置当前查询页的初始配置
        /// </summary>
        /// <param name="cfg"></param>
        public void SetConfigToControl(ConfigList cfg)
        {
            cboFrom.Text = cfg.From.IndexOf("|") > -1 ? cfg.From.Split('|')[0] : cfg.From;
            cboTo.Text = cfg.To.IndexOf("|") > -1 ? cfg.To.Split('|')[0] : cfg.To;
            dtpRiqi.Value = cfg.Date >= DateTime.Now ? cfg.Date : DateTime.Now;
            cboShijian.Text = cfg.Time;
            customColumn = cfg.CustomColumn;
            if (customColumn == null)
                InitColumns();
            string flag = "";
            foreach (var v in customColumn.Keys)
            {
                dgvTrainView.Columns[v.ToString()].Visible = (bool)customColumn[v];
                flag = v.ToString().Substring(1, 1);
                ((CheckBox)plCostomColumn.Controls["seat" + flag]).Checked = (bool)customColumn[v];
            }

            if (cfg.Turn)
            {
                TurnDatesInit();
                chkSelectTurn.Checked = true;
                fplTurnDates.Visible = true;

                foreach (var v in cfg.TurnDates.Keys)
                {
                    for (int i = 0; i < flpTurnCheckBox.Controls.Count; i++)
                    {
                        if (flpTurnCheckBox.Controls[i].Text == v.ToString())
                        {
                            ((CheckBox)flpTurnCheckBox.Controls[i]).Checked = true;
                            turnDateTable.Add(v, cfg.TurnDates[v]);
                        }
                    }
                }
            }

            foreach (var v in cfg.Passengers.Keys)
            {
                for (int i = 1; i < flplPassengers.Controls.Count; i++)
                {
                    if (v.ToString().Contains(flplPassengers.Controls[i].Text) && v.ToString().Split('|')[1] == ((Nomal_Passengers)(flplPassengers.Controls[i].Tag)).Passenger_id_no)
                    {
                        ((CheckBox)flplPassengers.Controls[i]).Tag = cfg.Passengers[v];
                        ((CheckBox)flplPassengers.Controls[i]).Checked = true;
                    }
                }
            }
            UpdateAutoPassengersList();
            for (int i = 0; i < cfg.SeatTypes.Count; i++)
            {
                QuickAddSeatType(cfg.SeatTypes[i]);
            }
            
            for (int i = 0; i < cfg.TrainNos.Count; i++)
            {
                QuikAddTrainInfo(cfg.TrainNos[i]);
            }

            InitAutoSubmitPassengersSeat();
        }

        private void UpdateAutoPassengersList()
        {
            bool b = false;
            lsvAutoPassengers.Items.Clear();
            var autoPassengers = _passengersData.Where(x => x.IsCheck).Select(x => x).ToList<Nomal_Passengers>();
            for (int i = 0; i < autoPassengers.Count; i++)
            {
                if (autoPassengers[i].SeatCodeName == "")
                {
                    b = true;
                    MessageBox.Show(string.Format("联系人 [{0}] 没有选择席别,可能造成提交失败切可能引发重新登录的可能",autoPassengers[i].Passenger_name),"提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    lblError.Visible = true;
                }
                lsvAutoPassengers.Items.Add(string.Format("姓名:{0}       证件号:{1}         席别:{2}          票种:{3}",
                    autoPassengers[i].Passenger_name, autoPassengers[i].Passenger_id_no, autoPassengers[i].SeatCodeName, autoPassengers[i].TicketCodeName));
            }
            if (!b)
                lblError.Visible = false;
        }

        private void GetPassengersFromServer()
        {
            var modifyAction = new ModifyPassengerAction();
            modifyAction.GetPassenger((strPassengers) =>
            {
                var returnString = translation.TranslationHtmlEx(strPassengers);
                if (returnString["data"]["normal_passengers"] == null)
                {
                    DeterMineCall(() =>
                    {
                        MessageBox.Show("获取联系人失败!" + returnString["data"]["exMsg"].ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.DoEvents();
                    });
                    return;
                }

                translation.TranslationPassengerJson(strPassengers, (passengerSource) =>
                {
                    _passengersData=passengerSource;
                    if (((TicketFrame)this._frame).Passengers.Count != _passengersData.Count)
                        ((TicketFrame)this._frame).Passengers = _passengersData;
                    
                    GetPassengers();
                    //InitConfigEx();
                });

            }, cookieContainer);
        }


        private void InitAutoSubmitPassengersSeat()
        { 
            if (_passengersData!=null&&_config!=null&&_config.SeatTypes.Count>0)
                for (int i = 0; i < _passengersData.Count; i++)
                {
                    if (!_config.Passengers.ContainsValue(_passengersData[i]))
                    {
                        _passengersData[i].SeatCode = DatasList.SeatType[_config.SeatTypes[0]].ToString();
                        _passengersData[i].SeatCodeName = _config.SeatTypes[0];
                    }
                }
        }

        private void GetPassengers()
        {
            //string strPassengers = new LogInfo().ReadStringFromTxt(_user, "JsonPassengers");
            //translation.TranslationPassengerJson(strPassengers, (passengerSource) =>
            //{
            
                DeterMineCall(() =>
                {
                    //if (flplPassengers.Controls.Count>1)
                    //    while (flplPassengers.Controls.Count > 1)
                    //    {
                    //        flplPassengers.Controls.RemoveAt(1);
                    //    }
                    //_passengersData = passengerSource;
                    flplPassengers.Controls.Clear();
                    int j = 0;

                    foreach (Nomal_Passengers passenger in _passengersData)
                    {
                        if (passenger.Information!="") continue;
                        var chk = new CheckBox() 
                        { 
                            AutoSize = true, 
                            Tag = passenger,
                            TabIndex = _passengersData.IndexOf(passenger), 
                            Name = "checkbox" + j, 
                            Text = passenger.Passenger_name,
                            Checked = passenger.IsCheck,
                            //Enabled=CheckPassengerStatus(passenger),
                            ForeColor = Color.FromArgb(64, 64, 64), 
                            FlatStyle = FlatStyle.Flat 
                        };

                        flplPassengers.Controls.Add(chk);
                        chk.CheckedChanged += (ss, ee) =>
                        {
                            if (chk.Checked)
                            {
                                int selectPassengerCount = _passengersData.Where(x => x.IsCheck).Select(x => x).ToList().Count;
                                if (selectPassengerCount == 5)
                                { MessageBox.Show("已经是订票的最大人数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); chk.Checked = false; return; }
                                _passengersData[chk.TabIndex].IsCheck = true;
                                _passengersData[chk.TabIndex].IsCheck = true;
                                _passengersData[chk.TabIndex].SeatCode = ((Nomal_Passengers)chk.Tag).SeatCode;
                                _passengersData[chk.TabIndex].SeatCodeName = ((Nomal_Passengers)chk.Tag).SeatCodeName == "" ? _config.SeatTypes.Count > 0 ? _config.SeatTypes[0] : "硬卧" : ((Nomal_Passengers)chk.Tag).SeatCodeName;
                                _passengersData[chk.TabIndex].TicketCode = ((Nomal_Passengers)chk.Tag).TicketCode;
                                _passengersData[chk.TabIndex].TicketCodeName = ((Nomal_Passengers)chk.Tag).TicketCodeName;
                                try
                                {
                                    if (!_QuickPassengers.ContainsKey(String.Format("{0}|{1}", chk.Text, ((Nomal_Passengers)chk.Tag).Passenger_id_no)) && !_QuickPassengers.ContainsValue(chk.Tag))
                                        _QuickPassengers.Add(String.Format("{0}|{1}", chk.Text, ((Nomal_Passengers)chk.Tag).Passenger_id_no), chk.Tag);
                                }
                                catch { }
                                //selectPassengerCount++;
                            }
                            else
                            {
                                    
                                _passengersData[chk.TabIndex].IsCheck = false;
                                _QuickPassengers.Remove(String.Format("{0}|{1}", chk.Text, ((Nomal_Passengers)chk.Tag).Passenger_id_no));
                                //selectPassengerCount--;
                            }
                            UpdateAutoPassengersList();
                        };
                        j++;
                    }
                    flplPassengers.AutoScroll = true;
                    flplPassengers.VerticalScroll.Enabled = true;
                    flplPassengers.VerticalScroll.Visible = true;
                    flplPassengers.VerticalScroll.Minimum = 0;
                    flplPassengers.VerticalScroll.Maximum = 100;
                    if(flplPassengers.Controls.Count<=0)
                        MessageBox.Show("联系人加载失败或该账号没有联系人,请重新加载,或尝试重新登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (_config != null && config.Init)
                        SetConfigToControl(_config);
                    else
                        InitConfig();
                });

            //});
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string tmp = cboFrom.Text;
            cboFrom.Text = cboTo.Text;
            cboTo.Text = tmp;
        }
        //开始查询
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            //plQuickTrainInfo.Visible = false;
            this.Parent.Text = String.Format("{0:MM.dd}[{1}->{2}]", dtpRiqi.Value, cboFrom.Text, cboTo.Text);
            
            InitSortInfo();
            if (!(cboFrom.Text != "" && tmpStationName.ContainsKey(cboFrom.Text)))
            { 
                //MessageBox.Show("请正确输入始发站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                ttt.SetToolTip(cboFrom, "请正确输入始发站"); 
                ttt.Show("请正确输入始发站",cboFrom,2500);
                return; 
            }

            if (!(cboTo.Text != "" && tmpStationName.ContainsKey(cboTo.Text)))
            { 
                //MessageBox.Show("请正确输入到站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ttt.SetToolTip(cboTo, "请正确输入到站"); 
                ttt.Show("请正确输入到站", cboTo, 2500);
                return; 
            }

            if (dtpRiqi.Value.Date < DateTime.Now.Date) 
            { 
                //MessageBox.Show("查询日期错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ttt.SetToolTip(dtpRiqi, "查询日期错误"); 
                ttt.Show("查询日期错误", dtpRiqi, 2500);
                return;
            }
            plSetup.Enabled = false;
            btnSelectAll.Text = "正在查询";
            Application.DoEvents();
            if (!_IsAutoWork)
            {
                var t = new System.Windows.Forms.Timer();
                t.Interval = 1000 * 30;
                t.Start();
                t.Tick += (o, arg) =>
                {
                    t.Stop();
                    if (plSetup.Enabled == false)
                        DeterMineCall(() =>
                        {
                            MessageBox.Show("查询长时间未返回结果.助手已重新初始化按钮状态.", "查询超时", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            plSetup.Enabled = true;
                        });
                };
            }
            if (chkInterval.Checked)
            {
                lsvTrainData.Items.Clear();
                int count = dtEndInterval.Value.DayOfYear - dtpRiqi.Value.DayOfYear;
                if (count < 0)
                {
                    MessageBox.Show(this, "请正确填写出发日期和截止日期，截止日期必须大于等于出发日期", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    plSetup.Enabled = true;
                    btnSelectAll.Text = "查询";
                    return;
                }
                if (count > 20)
                {
                    MessageBox.Show(this, "为了尽可能的防止被封，最多支持20天的跨度查询，请重新设置截止日期", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    plSetup.Enabled = true;
                    btnSelectAll.Text = "查询";
                    return;
                }
                for (int i = 0; i <= count; i++)
                {
                    BeginGetQueryStringEx(dtpRiqi.Value.AddDays(i).ToString("yyyy-MM-dd"));
                    BeginSelectTicketEx(dtpRiqi.Value.AddDays(i).ToString("MM.dd"));
                }
            }
            else
            {
                BeginGetQueryString(dtpRiqi.Value.Date.ToString("yyyy-MM-dd"));
                BeginSelectTicket();
            }
        }
        /// <summary>
        /// 拼接查询参数
        /// </summary>
        private void BeginGetQueryString(string date)
        {
            includeCode = chkIncludeStudent.Checked ? "0X00" : "ADULT";
            selectAction.QueryString = String.Format("leftTicketDTO.train_date={0}&leftTicketDTO.from_station={1}&leftTicketDTO.to_station={2}&purpose_codes={3}&leftTicketDTO.to_station_name={4}&leftTicketDTO.from_station_name={5}&pre_step_flag=index&flag=dc&_json_att=&back_train_date={6}",
                                                date, tmpStationName[cboFrom.Text], tmpStationName[cboTo.Text], includeCode, System.Web.HttpUtility.UrlEncode(cboTo.Text), System.Web.HttpUtility.UrlEncode(cboFrom.Text), date);
        }
        /// <summary>
        /// 拼接查询参数 不可预订
        /// </summary>
        private void BeginGetQueryStringEx(string date)
        {
            includeCode = chkIncludeStudent.Checked ? "0X00" : "ADULT";
            selectAction.QueryString = String.Format("purpose_codes={0}&queryDate={1}&from_station={2}&to_station={3}",
                                                includeCode, date, tmpStationName[cboFrom.Text], tmpStationName[cboTo.Text]);
        }

        /// <summary>
        /// 余票查询方法（可预订）
        /// </summary>
        private void BeginSelectTicket()
        {
            try
            {
                string htmlList = "";
                selectAction.GetLeftTickets((resultList) =>
                {
                    //if (resultList == "")
                    //{
                    //    MessageBox.Show("查询失败...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    DeterMineCall(() =>
                    //    {
                    //        btnSelectAll.Enabled = true;
                    //    });
                    //    return;
                    //}
                    if (resultList == "-1" || resultList == string.Empty)
                    {
                        DeterMineCall(() =>
                        {
                            plSetup.Enabled = true;
                            btnSelectAll.Text = "查询";
                            return;
                        });
                    }
                    if (resultList.StartsWith("-10"))
                    {
                        #region 备用解决方案(1)
                        //cookieContainer = LocalCookie.ReadCookiesFromDisk(AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg");
                        ////GetPassengers();
                        //if (msgFlag)
                        //{
                        //    if (MessageBox.Show("12306说你登录时间过长,需要重新登录\r\n\r\n选择\"是\",程序将重新启动\r\n选择\"否\",忽略此提示,等待恢复会自动重新获取数据,你也可以选择查询其他日期的车次,如果在恢复期间出现缓存数据,这些数据只能参考,不能预订,因为实际还没有恢复登录状态,请注意下方的缓存过期时间.(此提示以后不会出现)", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //    {
                        //        DeterMineCall(() =>
                        //        {
                        //            Application.Restart();
                        //        });
                        //    }
                        //    else
                        //    {
                        //        msgFlag = false;
                        //    }
                        //}
                        //Action a = () =>
                        //{
                        //    dgvTrainView.DataSource = null;
                        //    lblLastSelectTime.Text = "已被弹出,等待恢复";
                        //    plSetup.Enabled = true;
                        //    btnSelectAll.Text = "查询";
                        //};
                        //if (InvokeRequired)
                        //    Invoke(a);

                        //return;
                        #endregion

                        #region 备用解决方案(2)
                        //if (MessageBox.Show("12306说你登录时间过长,需要重新登录\r\n选择\"是\",清除Cookie信息并重新登录\r\n选择\"否\",使用原始Cookie登录", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        //    if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg"))
                        //        System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg");
                        //}
                        //DeterMineCall(() =>
                        //{
                        //    Application.Restart();
                        //});
                        #endregion

                        #region 备用解决方案(3)
                        MessageBox.Show("12306说你登录时间过长,需要重新登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "data\\" + _userName + "\\usrCookie.cfg"))
                            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "data\\" + _userName + "\\usrCookie.cfg");
                        DeterMineCall(() =>
                        {
                            Application.Restart();
                        });
                        #endregion
                    }
                    if (resultList != null && resultList != string.Empty)
                    {
                        htmlList = resultList;
                        translation.TranslationJson(htmlList, (listSource) =>
                        {
                            _trainData = listSource;
                            Action ac = () =>
                            {
                                DgvDataBind(_trainData);
                            };
                            if (InvokeRequired)
                                Invoke(ac);
                        });
                    }
                    else
                    {
                        Action a = () =>
                        {
                            dgvTrainView.DataSource = null;
                            plSetup.Enabled = true;
                            btnSelectAll.Text = "查询";
                        };
                        if (InvokeRequired)
                            Invoke(a);
                        DrawNullDataString(dgvTrainView);
                    }
                },
                    (expires) =>
                    {
                        UpdateCacheExpires(expires);
                    },
                cookieContainer);
                //加上这个貌似会减少缓存碰撞的几率
                selectAction.GetLeftTicketsEx(cookieContainer);
            }
            catch
            {
                plSetup.Enabled = true;
                btnSelectAll.Text = "查询";
            }
        }
        /// <summary>
        /// 余票查询（不可预订）
        /// </summary>
        private void BeginSelectTicketEx(string date)
        {
            try
            {
                string htmlList = "";
                selectAction.GetLeftTicketsEx((resultList) =>
                {
                    //if (resultList == "")
                    //{
                    //    MessageBox.Show("查询失败...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    DeterMineCall(() =>
                    //    {
                    //        btnSelectAll.Enabled = true;
                    //    });
                    //    return;
                    //}
                    if (resultList.StartsWith("-10"))
                    {
                        #region 备用解决方案(1)
                        //cookieContainer = LocalCookie.ReadCookiesFromDisk(AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg");
                        ////GetPassengers();
                        //if (msgFlag)
                        //{
                        //    if (MessageBox.Show("12306说你登录时间过长,需要重新登录\r\n\r\n选择\"是\",程序将重新启动\r\n选择\"否\",忽略此提示,等待恢复会自动重新获取数据,你也可以选择查询其他日期的车次,如果在恢复期间出现缓存数据,这些数据只能参考,不能预订,因为实际还没有恢复登录状态,请注意下方的缓存过期时间.(此提示以后不会出现)", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //    {
                        //        DeterMineCall(() =>
                        //        {
                        //            Application.Restart();
                        //        });
                        //    }
                        //    else
                        //    {
                        //        msgFlag = false;
                        //    }
                        //}
                        //Action a = () =>
                        //{
                        //    dgvTrainView.DataSource = null;
                        //    lblLastSelectTime.Text = "已被弹出,等待恢复";
                        //    plSetup.Enabled = true;
                        //    btnSelectAll.Text = "查询";
                        //};
                        //if (InvokeRequired)
                        //    Invoke(a);

                        //return;
                        #endregion

                        #region 备用解决方案(2)
                        //if (MessageBox.Show("12306说你登录时间过长,需要重新登录\r\n选择\"是\",清除Cookie信息并重新登录\r\n选择\"否\",使用原始Cookie登录", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        //    if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg"))
                        //        System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg");
                        //}
                        //DeterMineCall(() =>
                        //{
                        //    Application.Restart();
                        //});
                        #endregion

                        #region 备用解决方案(3)
                        MessageBox.Show("12306说你登录时间过长,需要重新登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg"))
                            System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg");
                        DeterMineCall(() =>
                        {
                            Application.Restart();
                        });
                        #endregion
                    }
                    if (resultList != null && resultList != string.Empty)
                    {
                        htmlList = resultList;
                        translation.TranslationJsonEx(htmlList, (listSource) =>
                        {
                            _trainData = listSource;
                            Action ac = () =>
                            {
                                ListViewDataBind(_trainData, date, new ListViewGroup(date));
                            };
                            if (InvokeRequired)
                                Invoke(ac);
                        });
                    }
                    else
                    {
                        Action a = () =>
                        {

                            lsvTrainData.Items.Clear();
                            plSetup.Enabled = true;
                            btnSelectAll.Text = "查询";
                        };
                        if (InvokeRequired)
                            Invoke(a);
                        DrawNullDataString(lsvTrainData);
                    }
                },
                cookieContainer);
            }
            catch
            {
                plSetup.Enabled = true;
                btnSelectAll.Text = "查询";
            }
        }

        private void ListViewDataBind(List<JsonTrainData> data, string date, ListViewGroup lvg)
        {
            lsvTrainData.Groups.Add(lvg);
            var traindata = data;
            //if (chkCustomFilter.Checked)
            //{
                traindata = CustomFilter(traindata);
            //}

            foreach (JsonTrainData td in traindata)
            {
                var lvi = new ListViewItem();
                lvi.SubItems[0].Text = date;
                lvi.SubItems.Add(td.QueryLeftNewDto.Station_train_code);
                lvi.SubItems.Add(td.QueryLeftNewDto.From_station_name);
                lvi.SubItems.Add(td.QueryLeftNewDto.Start_time);
                lvi.SubItems.Add(td.QueryLeftNewDto.To_station_name);
                lvi.SubItems.Add(td.QueryLeftNewDto.Arrive_time);
                lvi.SubItems.Add(td.QueryLeftNewDto.Lishi);
                lvi.UseItemStyleForSubItems = false;
                //lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Gg_num));
                //lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Qt_num));
                //lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Yb_num));
                lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Swz_num));
                lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Tz_num));
                lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Zy_num));
                lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Ze_num));
                lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Gr_num));
                lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Rw_num));
                lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Yw_num));
                lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Rz_num));
                lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Yz_num));
                lvi.SubItems.Add(MatchSubItem(td.QueryLeftNewDto.Wz_num));

                lvi.SubItems.Add(td.ButtonTextInfo.Replace("<br/>", ""));
                lvi.Group = lvg;

                lsvTrainData.Items.Add(lvi);
            }
            AutoTrainNoSource();
            plSetup.Enabled = true;
            btnSelectAll.Text = "查询";
        }

        private ListViewItem.ListViewSubItem MatchSubItem(string data)
        {
            var lvs = new ListViewItem.ListViewSubItem() { Text = data };
            if (System.Text.RegularExpressions.Regex.IsMatch(lvs.Text, "^\\d+$"))
            {
                lvs.ForeColor = Color.FromArgb(0x00, 0x66, 0x33);
            }
            else if (lvs.Text == "无")
            {
                lvs.ForeColor = Color.Red;
            }
            return lvs;
        }
        //绑定查询结果到datagridview
        public void DgvDataBind(List<JsonTrainData> data)
        {
            //if (chkCustomFilter.Checked)
            //{
            //    if (chkFilterNoSeat.Checked)
            //    {
            //        data = data.Where(x => x.QueryLeftNewDto.CanWebBuy=="Y").Select(x => x).ToList();
            //    }
                data=CustomFilter(data);
            //}
            lblTrainsCount.Text =string.Format("共有 {0} 趟车" ,data.Count);
            _BindingData = new BindingList<JsonTrainData>(data);
            var source = new BindingList<QueryLeftNewDTO>();
            foreach (var v in _BindingData)
            {
                var ql = new QueryLeftNewDTO();
                ql = v.QueryLeftNewDto;
                ql.ButtonTextInfo = v.ButtonTextInfo.Replace("<br/>", "");
                ql.SecretStr = v.SecretStr;
                source.Add(ql);
            }
            dgvTrainView.DataSource = source;
            dgvTrainView.Refresh();
            lblLastSelectTime.Text = DateTime.Now.ToLongTimeString();
            AutoTrainNoSource();
            plSetup.Enabled = true;
            btnSelectAll.Text = "查询";
        }
        //为有票的单元格着色
        private void dgvTrainView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.Value != null && e.ColumnIndex > 5 && e.ColumnIndex != 16)
                    if (System.Text.RegularExpressions.Regex.IsMatch(e.Value.ToString(), "^\\d+$") ||
                        e.Value.ToString() == "有")
                    {
                        e.CellStyle.BackColor = Color.FromArgb(255, 192, 255);
                    }
                    else if (e.Value.ToString() == "无")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                    }
                if (e.ColumnIndex == 16)
                {
                    var buttonCell =
                        (DataGridViewDisableButtonCell)dgvTrainView.Rows[e.RowIndex].Cells["BookTicket"];
                    var item = dgvTrainView.Rows[e.RowIndex].DataBoundItem as QueryLeftNewDTO;
                    if (item.CanWebBuy == "N")
                        buttonCell.Enabled = false;
                }
            }
            else
                //如果是Column
                if (e.RowIndex == -1)
                {
                    AddCustomCellStyle(e);
                    e.Handled = true;
                    //如果是Rowheader
                }
                else if (e.ColumnIndex < 0 && e.RowIndex >= 0)
                {

                    AddCustomCellStyle(e);
                    e.Handled = true;
                }
            
        }
        private void AddCustomCellStyle(DataGridViewCellPaintingEventArgs e)
        {
            // 绘制背景色
            using (LinearGradientBrush backbrush =
                new LinearGradientBrush(e.CellBounds,
                    ProfessionalColors.MenuItemPressedGradientBegin,
                    ProfessionalColors.MenuItemPressedGradientMiddle    
                    , LinearGradientMode.Vertical))
            {

                Rectangle border = e.CellBounds;
                border.Width += 2;
                border.X -= 1;
                //填充绘制效果
                e.Graphics.FillRectangle(backbrush, border);
                //绘制Column、Row的Text信息
                e.PaintContent(e.CellBounds);
                //绘制边框
                ControlPaint.DrawBorder3D(e.Graphics, border, Border3DStyle.Etched);
            }//, Border3DStyle.Etched
        }
        //自定义过滤
        private List<JsonTrainData> CustomFilter(List<JsonTrainData> data)
        {
            try
            {
                data = data.Where(
                    x => string.Compare(x.QueryLeftNewDto.Start_time, cboShijian.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[0]) >= 0)
                    .Select(x => x)
                    .Where(x =>
                        string.Compare(cboShijian.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[1], x.QueryLeftNewDto.Start_time) >= 0)
                    .Select(x => x).ToList<JsonTrainData>();
            }
            catch { }
            if (!chkCA.Checked)
            {
                tmpTrainData = data;
                var tmpData = new List<JsonTrainData>();
                if (chkCG.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.QueryLeftNewDto.Station_train_code.StartsWith("G")).Select(x => x).ToList<JsonTrainData>()).ToList();
                if (chkCD.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.QueryLeftNewDto.Station_train_code.StartsWith("D")).Select(x => x).ToList<JsonTrainData>()).ToList();
                if (chkCC.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.QueryLeftNewDto.Station_train_code.StartsWith("C")).Select(x => x).ToList<JsonTrainData>()).ToList();
                if (chkCZ.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.QueryLeftNewDto.Station_train_code.StartsWith("Z")).Select(x => x).ToList<JsonTrainData>()).ToList();
                if (chkCT.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.QueryLeftNewDto.Station_train_code.StartsWith("T")).Select(x => x).ToList<JsonTrainData>()).ToList();
                if (chkCK.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.QueryLeftNewDto.Station_train_code.StartsWith("K")).Select(x => x).ToList<JsonTrainData>()).ToList();
                if (chkCL.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.QueryLeftNewDto.Station_train_code.StartsWith("L")).Select(x => x).ToList<JsonTrainData>()).ToList();
                if (chkCQ.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => !System.Text.RegularExpressions.Regex.IsMatch(x.QueryLeftNewDto.Station_train_code, "[A-Z]")).Select(x => x).ToList<JsonTrainData>()).ToList();
                return tmpData;
            }
            else
                return data;
        }
        //添加查找列表信息源
        public void AutoTrainNoSource()
        {
            var acCollection = new AutoCompleteStringCollection();
            foreach (JsonTrainData train in _trainData)
            {
                acCollection.Add(String.Format("{0} {1} {2} → {3} {4}   历时:{5} | {6}", train.QueryLeftNewDto.Station_train_code, train.QueryLeftNewDto.From_station_name, train.QueryLeftNewDto.Start_time, train.QueryLeftNewDto.To_station_name, train.QueryLeftNewDto.Arrive_time, train.QueryLeftNewDto.Lishi, train.QueryLeftNewDto.Station_train_code));
            }
            txtChufaCheci.AutoCompleteCustomSource = acCollection;
            txtChufaCheci.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        //点击预定按钮
        private void dgvTrainView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                //plQuickTrainInfo.Visible = false;
                if (dgvTrainView.Columns[e.ColumnIndex].Name == "BookTicket" && ((DataGridViewDisableButtonCell)dgvTrainView.Rows[e.RowIndex].Cells[e.ColumnIndex]).Enabled == true)
                {
                    this.dgvTrainView.Enabled = false;
                    var data = dgvTrainView.Rows[e.RowIndex].DataBoundItem as QueryLeftNewDTO;
                    var defaultSeat = _QuickAddSeatType.Intersect((from p in data.SeatOwener.Keys select p).ToList());
                    if (defaultSeat.ToList().Count > 0)
                        RunBook(data, defaultSeat.ToList()[0] ?? string.Empty, true);
                    else
                        RunBook(data);
                    this.dgvTrainView.Enabled = true;
                }
            }
        }

        //开始预定
        public void RunBook(QueryLeftNewDTO data, string seat = "", bool boo = false)
        {
            DeterMineCall(() =>
            {
                if (!chkAutoSubmit.Checked)
                {
                    if (data.CanWebBuy == "Y")
                    {
                        string postData = "";

                        postData += GetPostDataString(data);
                        if (seat != "")
                        {
                            AutoWorkFinished();
                            var form = new formSubmitOrder(this,_userName, postData, data, _passengersData, dtpRiqi.Value.Date.ToString("yyyy-MM-dd"), cookieContainer, String.Format("{0:MM.dd} [{1}->{2}]", dtpRiqi.Value, cboFrom.Text, cboTo.Text), seat, boo);
                            //this.Visible = true;
                            //this.WindowState = FormWindowState.Normal;
                            form.ShowDialog();
                        }
                        else
                        {
                            AutoWorkFinished();
                            var form1 = new formSubmitOrder(this,_userName, postData, data, _passengersData, dtpRiqi.Value.Date.ToString("yyyy-MM-dd"), cookieContainer, String.Format("{0:MM.dd} [{1}->{2}]", dtpRiqi.Value, cboFrom.Text, cboTo.Text));
                            //this.Visible = true;
                            //this.WindowState = FormWindowState.Normal;
                            form1.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "该车次无票可定", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else //自动提交
                {
                    if (data.CanWebBuy == "Y")
                    {
                        var passengers = new List<Nomal_Passengers>();
                        passengers.AddRange(_passengersData.Where(x => x.IsCheck).Select(x => x).ToList<Nomal_Passengers>());
                        var orderData = new OrderData_Otn(data, passengers, true, "", "", chkIncludeStudent.Checked ? "0x00" : "ADULT");
                        string postData = "";
                        postData += GetAutoSubmitPostDataString(data, passengers, orderData);
                        AutoWorkFinished();
                        var form1 = new formAutoSubmitOrder(orderData, _userName, postData, data, _passengersData, dtpRiqi.Value.Date.ToString("yyyy-MM-dd"), cookieContainer, String.Format("{0:MM.dd} [{1}->{2}]", dtpRiqi.Value, cboFrom.Text, cboTo.Text));
                        //this.Visible = true;
                        //this.WindowState = FormWindowState.Normal;
                        form1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(this, "该车次无票可定", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            });
        }
        //生成PostData
        public string GetPostDataString(QueryLeftNewDTO data)
        {
            //data.Train_date = trainDate.ToString("yyyy-MM-dd");
            //string postData = string.Format("arrive_time={0}&from_station_name={1}&from_station_no={2}&from_station_telecode={3}&from_station_telecode_name={4}&include_student={5}&lishi={6}&locationCode={7}&mmStr={8}&round_start_time_str={9}&round_train_date={10}&seattype_num={11}&single_round_type={12}&start_time_str={13}&station_train_code={14}&to_station_name={15}&to_station_no={16}&to_station_telecode={17}&to_station_telecode_name={18}&train_class_arr={19}&train_date={20}&train_pass_type={21}&train_start_time={22}&trainno4={23}&ypInfoDetail={24}",
            //                                    data.Arrive_time.Replace(":", "%3A"), translation.UtfEncode(data.From_station_name), data.From_station_no, data.From_station_telecode, translation.UtfEncode(data.From_station_telecode_name), data.Include_student,
            //                                    data.Cost_time.Replace(":", "%3A"), data.LocationCode, data.mmStr, cboShijian.Text.Replace(":", "%3A"), data.Train_date, data.seattype_num,
            //                                    data.single_round_type, cboShijian.Text.Replace(":", "%3A"), data.Station_train_code, translation.UtfEncode(data.To_station_name), data.To_station_no, data.To_station_telecode,
            //                                    translation.UtfEncode(data.To_station_telecode_name), trainClassType, data.Train_date, rbtnQuanbu.Checked ? "QB" : rbtnShifa.Checked ? "SF" : "GL", data.Start_time.Replace(":", "%3A"), data.Trainno4, data.ypInfoDetail);   
            string postData = string.Format("secretStr={0}&train_date={1}&back_train_date={2}&tour_flag=dc&purpose_codes={3}&query_from_station_name={4}&query_to_station_name={5}&undefined",
                data.SecretStr, data.Start_train_date.Substring(0, 4) + "-" + data.Start_train_date.Substring(4, 2) + "-" + data.Start_train_date.Substring(6, 2), DateTime.Now.ToString("yyyy-MM-dd"), chkIncludeStudent.Checked ? "0x00" : "ADULT", System.Web.HttpUtility.UrlEncode(data.Start_station_name), System.Web.HttpUtility.UrlEncode(data.End_station_name));
            return postData;
        }

        //生成autoSubmit PostData
        public string GetAutoSubmitPostDataString(QueryLeftNewDTO data, List<Nomal_Passengers> passengers, OrderData_Otn orderData)
        {
            string postData = string.Format("secretStr={0}&train_date={1}&tour_flag={2}&purpose_codes={3}&query_from_station_name={4}&query_to_station_name={5}&&cancel_flag={6}&bed_level_order_num={7}&passengerTicketStr={8}&oldPassengerStr={9}",
                data.SecretStr, data.Start_train_date.Substring(0, 4) + "-" + data.Start_train_date.Substring(4, 2) + "-" + data.Start_train_date.Substring(6, 2),
                 "dc", chkIncludeStudent.Checked ? "0x00" : "ADULT", System.Web.HttpUtility.UrlEncode(data.Start_station_name),
                 System.Web.HttpUtility.UrlEncode(data.End_station_name), orderData.Cancel_flag, orderData.Bed_level_order_num, orderData.PassengerTicketStr, orderData.OldPassengerStr);
            return postData;
        }
        //抢票栏隐藏与显示
        private void lblAutoBook_Click(object sender, EventArgs e)
        {
            plAutoBook.Visible = !plAutoBook.Visible;
            if (plAutoBook.Visible && chkSelectTurn.Checked)
                fplTurnDates.Visible = true;
            else
                fplTurnDates.Visible = false;
        }
        //双击添加车次到抢票栏为复选框
        private void dgvTrainView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var data = dgvTrainView.Rows[e.RowIndex].DataBoundItem as QueryLeftNewDTO;
            this.QuikAddTrainInfo(data.Station_train_code);
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            ttt.SetToolTip(flplTrainNo, "车次已经添加");
            ttt.Show(string.Format("车次{0}已经添加", data.Station_train_code), flplTrainNo, 2500);
        }
        //添加火车车次复选框
        private void QuikAddTrainInfo(string code)
        {
            plAutoBook.Visible = true;
            if (!_QuickAddTrainData.Contains(code))
            {
                _QuickAddTrainData.Add(code);
                //_TrainCode.Add(data.Station_train_code);
                CheckBox chk = new CheckBox()
                {
                    Checked = true,
                    AutoCheck = true,
                    Text = code,
                    FlatStyle = FlatStyle.Flat,
                    AutoSize = true,
                    ForeColor=Color.FromArgb(64,64,64)
                };
                chk.Click += (ss, ee) => {
                    if (chk.Checked == false)
                    {
                        _QuickAddTrainData.Remove(chk.Text);
                        //_TrainCode.Remove(chk.Text);
                        flplTrainNo.Controls.Remove(chk);
                    }
                };
                flplTrainNo.Controls.Add(chk);
            }
        }
        //添加坐席到抢票设置列表
        private void cboSeatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuickAddSeatType(cboSeatType.Text);
        }
        private void QuickAddSeatType(string seatName)
        {
            if (DatasList.SeatType.ContainsKey(seatName) && !_QuickAddSeatType.Contains(seatName))
            {
                _QuickAddSeatType.Add(seatName);
                //_SeatType.Add(seatName);
                CheckBox chk = new CheckBox()
                {
                    Checked = true,
                    AutoCheck = true,
                    Text = seatName,
                    FlatStyle = FlatStyle.Flat,
                    AutoSize = true,
                    ForeColor=Color.FromArgb(64,64,64)
                };
                chk.Click += (ss, ee) =>
                {
                    if (chk.Checked == false)
                    {
                        _QuickAddSeatType.Remove(chk.Text);
                        //_SeatType.Remove(chk.Text);
                        flplSeatType.Controls.Remove(chk);
                    }
                };
                flplSeatType.Controls.Add(chk);
                if (_QuickAddSeatType.Count > 0)
                {
                    for (int i = 0; i < _passengersData.Count; i++)
                    {
                        _passengersData[i].SeatCodeName = seatName;
                        _passengersData[i].SeatCode = DatasList.SeatType[seatName].ToString();
                    }
                }
            }
        }
        //抢票
        private void btnAutoBook_Click(object sender, EventArgs e)
        {
            if (!_IsAutoWork && btnAutoBook.Text == "抢票")
            {
                if (_QuickPassengers.Count == 0)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[0];
                    ttt.SetToolTip(flplPassengers, "提示");
                    ttt.Show("请选择联系人！", flplPassengers, 2500);
                    return;
                } 
                if (_QuickAddTrainData.Count == 0)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                    ttt.SetToolTip(flplTrainNo, "提示");
                    ttt.Show("请选择车次！", flplTrainNo, 2500);
                    return;
                }
                if (_QuickAddSeatType.Count == 0)
                {
                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                    ttt.SetToolTip(flplSeatType, "提示");
                    ttt.Show("请选择席别！如果您勾选了自动提交，请尽量保持一致", flplSeatType, 2500);
                    return;
                }
                if (chkAutoSubmit.Checked)
                {
                    if (lsvAutoPassengers.Items.Count < 0 || lblError.Visible != false)
                    {
                        tabControl1.SelectedTab = tabControl1.TabPages[2];
                        ttt.SetToolTip(lsvAutoPassengers, "提示");
                        ttt.Show("请选择自动提交的联系人并将相应联系人的席别和票种选好！", lsvAutoPassengers, 2500);
                    }
                }

                flpTurnCheckBox.Enabled = false;
                btnAutoBook.Text = "取消";
                lblAutoBook.Text = "自动预定设置 - 自动抢票中";
                Application.DoEvents();
                startTime = DateTime.Now;
                AutoWorkerParam();
                if (AutoPicker.Checked)
                {
                    _autoBooker.PauseWorking = true;
                    AutoPicker.Enabled = false;
                    tmWatch.Start();
                }
                else
                {
                    _autoBooker.PauseWorking = false;
                    _autoBooker.ThreadProcStart();
                    lblRefreshTime.Text = startTime.ToLongTimeString();
                }
                Dosomething();
            }
            else
            {
                AutoWorkFinished();
            }
        }
        private void Dosomething()
        {
            lblCostTime.Text = "00:00:00";
            timer2.Start();
            _IsAutoWork = true;
        }
        public void AutoWorkFinished()
        {
            DeterMineCall(() =>
            {
                if (_autoBooker._Thread!=null&&(_autoBooker._Thread.ThreadState == ThreadState.Running || _autoBooker._Thread.ThreadState == ThreadState.Suspended))
                _autoBooker._Thread.Abort();
                _autoBooker.PauseWorking = true;
                _IsAutoWork = false;
                AutoPicker.Enabled = true;
                timer2.Stop();
                btnAutoBook.Text = "抢票";
                lblAutoBook.Text = "自动预定设置";
                flpTurnCheckBox.Enabled = true;
                Application.DoEvents();
            });
        }
        //初始化自动刷新的参数
        private void AutoWorkerParam()
        {
            _autoBooker.cookieContainer = cookieContainer;
            _autoBooker.PassengerData = _passengersData;
            _autoBooker.SeatType = _QuickAddSeatType;
            _autoBooker.SeatTypeFirst = rbtnSeatTypeFirst.Checked;
            _autoBooker.TrainCode = _QuickAddTrainData;
            _autoBooker.TrainDate = dtpRiqi.Value;
            if (chkSelectTurn.Checked)
            {
                _autoBooker.TurnDates.Clear();
                int i = 0;
                foreach (var v in turnDateTable.Keys)
                {
                    _autoBooker.TurnDates.Add(i, (DateTime)turnDateTable[v]);
                    i++;
                }
            }
            _autoBooker.from_station_telecode = tmpStationName[cboFrom.Text];
            _autoBooker.to_station_telecode = tmpStationName[cboTo.Text];
            _autoBooker.purpose_codes = chkIncludeStudent.Checked ? "0X00" : "ADULT";
            //_autoBooker.train_no = checiID;
            //_autoBooker.trainPassType = rbtnQuanbu.Checked ? "QB" : rbtnShifa.Checked ? "SF" : "GL";
            _autoBooker.trainClass = trainClassType;
            _autoBooker.start_time_str = cboShijian.Text.Replace(":","%3A");
            //_autoBooker.PauseWorking = false;
            _autoBooker.Period=Convert.ToInt16(numSelectSpan.Value);
            try
            {
                _autoBooker.lessCount = Convert.ToInt32(cboLessCount.Text);
            }
            catch { _autoBooker.lessCount = 1; }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (_autoBooker.IsPauseWork)
                AutoWorkFinished();
            UpdateRefreshTime();
            if (!_autoBooker.IsPauseWork)
                lblRefreshTime.Text = _autoBooker.LastSelectTime;
        }
        //更新刷新时间和用时
        private void UpdateRefreshTime()
        {
            string timespan = DateTime.Now.Subtract(startTime).ToString();
            lblCostTime.Text = timespan.Contains(".") ? timespan.Substring(0, timespan.LastIndexOf(".")) : timespan;//String.Format("{0}:{1}:{2}", hh, mm, ss);
        }

        //刷新间隔设置
        private void numSelectSpan_ValueChanged(object sender, EventArgs e)
        {
            _autoBooker.Period = Convert.ToInt16(numSelectSpan.Value<numSelectSpan.Minimum?numSelectSpan.Minimum:numSelectSpan.Value);
        }

        //更新缓存过期时间
        public void UpdateCacheExpires(object expires)
        {
            DeterMineCall(() =>
            {
                if (expires.ToString() != "false")
                {
                    DateTime dt = Convert.ToDateTime(expires);
                    lblHitCache.Text = String.Format("这是缓存数据 缓存时间:{0:HH:mm:ss} 预计过期时间:{1:HH:mm:ss}", dt, dt.AddMinutes(1));
                    if (chkAutoCDN.Checked)
                    {
                        if (CDNSwitcher.CDN_List.Count > 0)
                            cdnSwitcher.AutoSwitchCDN(null, (str) =>
                            {
                                lblSwitchState.Text = str;
                            });
                        else
                            lblSwitchState.Text = "没有可以用来切换的CDN服务器列表，请先获取。";
                    }
                }
                else
                {
                    lblHitCache.Text = "";
                    lblSwitchState.Text = "";
                }
            });
        }

        //更新日期
        public void UpdateSelectDate(DateTime dt)
        {
            DeterMineCall(() => {
                dtpRiqi.Value = dt;
                Application.DoEvents();
            });
        }

        //委托
        private void DeterMineCall(MethodInvoker method)
        {
            if (InvokeRequired&&!this.IsDisposed)
                Invoke(method);
            else
                method();
        }

        private void DeleteUserInfo()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "data\\" + _userName + "\\usrCookie.cfg";
            //string path1 = AppDomain.CurrentDomain.BaseDirectory + "config.cfg";
            //string path2 = AppDomain.CurrentDomain.BaseDirectory + "usr.cfg";
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                //if (System.IO.File.Exists(path1))
                //{
                //    System.IO.File.Delete(path1);
                //} 
                //if (System.IO.File.Exists(path2))
                //{
                //    System.IO.File.Delete(path2);
                //}
            }
            catch { }
        }

        //启用关闭轮查
        private void chkSelectTurn_Click(object sender, EventArgs e)
        {
            if (chkSelectTurn.Checked)
            {
                TurnDatesInit();
                fplTurnDates.Visible = true;
            }
            else
            {
                _autoBooker.TurnDates.Clear();
                fplTurnDates.Visible = false;
            }
        }

        //初始化轮查复选框
        private void TurnDatesInit()
        {
            int seed = 0;
            turnDateTable.Clear();
            foreach (Control trol in flpTurnCheckBox.Controls)
            {
                CheckBox ck = (CheckBox)trol;
                ck.Checked = false;
                ck.Text = DateTime.Now.AddDays(seed).ToString("yyyy-MM-dd");
                ck.Tag = DateTime.Now.AddDays(seed);
                ck.Click += (ss,ee) => {
                    DeterMineCall(() =>
                    {
                        lock (turnDateTable)
                        {
                            try
                            {
                                if (ck.Checked)
                                    turnDateTable.Add(ck.Text, ck.Tag);
                                else
                                {
                                    foreach (var v in turnDateTable.Keys)
                                    {
                                        if (v.ToString() == ck.Text)
                                        {
                                            turnDateTable.Remove(ck.Text);
                                            break;
                                        }
                                    }
                                }
                            }
                            catch { }
                        }
                    });
                };
                seed++;
            }
        }

        private void chkCA_Click(object sender, EventArgs e)
        {
            if (chkCA.Checked)
            {
                chkCG.Checked = true;
                chkCD.Checked = true;
                chkCC.Checked = true;
                chkCZ.Checked = true;
                chkCT.Checked = true;
                chkCK.Checked = true;
                chkCL.Checked = true;
                chkCQ.Checked = true;
            }
            else
            {
                chkCG.Checked = false;
                chkCD.Checked = false;
                chkCC.Checked = false;
                chkCZ.Checked = false;
                chkCT.Checked = false;
                chkCK.Checked = false;
                chkCL.Checked = false;
                chkCQ.Checked = false;
            }
        }
        private void chkCChangeed(object sender, EventArgs e)
        {
            if (chkCG.Checked && chkCD.Checked && chkCC.Checked && chkCZ.Checked && chkCT.Checked && chkCK.Checked && chkCL.Checked && chkCQ.Checked)
                chkCA.Checked = true;
            else
                chkCA.Checked = false;
        }

        private void 显示过站信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dgvQuickTrainInfo.DataSource = null;
            if (dgvTrainView.SelectedRows.Count > 0)
            {
                Rectangle rect = dgvTrainView.GetCellDisplayRectangle(1, dgvTrainView.SelectedRows[0].Cells[0].RowIndex, true);
                var data = dgvTrainView.SelectedRows[0].DataBoundItem as QueryLeftNewDTO;
                pop = new Popup(new TrainDeatils(cookieContainer, String.Format("{0} : {1} - {2}",
                    data.Station_train_code, data.From_station_name,
                    data.To_station_name), data.From_station_name,
                    data.To_station_name, data.Train_no,
                    data.From_station_telecode, data.To_station_telecode,
                    dtpRiqi.Value.ToString("yyyy-MM-dd")));
                pop.AutoClose = true;
                pop.FocusOnOpen = true;
                pop.ShowingAnimation = PopupAnimations.TopToBottom | PopupAnimations.Slide;
                pop.HidingAnimation = PopupAnimations.BottomToTop | PopupAnimations.Slide;
                pop.Show(dgvTrainView, rect);
            }
        }
      
        //蹲点监控
        private void tmWatch_Tick(object sender, EventArgs e)
        {
            var ts = new TimeSpan();
            ts = AutoPicker.Value.Subtract(ConfigLocalDateTime.tmpTime);
            lblRefreshTime.Text = String.Format("倒计时:{0:#0}秒", ts.TotalSeconds);
            if (ts.TotalSeconds <= 60)
            {
                //isGetServerTime = false;//距离还有一分钟时，开启精确计时
            }
            if (ts.TotalSeconds <= 0)
            {
                _autoBooker.PauseWorking = false;
                _autoBooker.ThreadProcStart();
                tmWatch.Stop();
            }
        }

        private void seat2_Click(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            switch (cb.Name)
            {
                case "seat9":
                    {
                        dgvTrainView.Columns["_9seat"].Visible = cb.Checked;
                        customColumn["_9seat"] = cb.Checked;
                        break;
                    }
                case "seatP":
                    {
                        dgvTrainView.Columns["_Pseat"].Visible = cb.Checked;
                        customColumn["_Pseat"] = cb.Checked;
                        break;
                    }
                case "seatM":
                    {
                        dgvTrainView.Columns["_Mseat"].Visible = cb.Checked;
                        customColumn["_Mseat"] = cb.Checked;
                        break;
                    }
                case "seatO":
                    {
                        dgvTrainView.Columns["_Oseat"].Visible = cb.Checked;
                        customColumn["_Oseat"] = cb.Checked;
                        break;
                    }
                case "seat6":
                    {
                        dgvTrainView.Columns["_6seat"].Visible = cb.Checked;
                        customColumn["_6seat"] = cb.Checked;
                        break;
                    }
                case "seat4":
                    {
                        dgvTrainView.Columns["_4seat"].Visible = cb.Checked;
                        customColumn["_4seat"] = cb.Checked;
                        break;
                    }
                case "seat3":
                    {
                        dgvTrainView.Columns["_3seat"].Visible = cb.Checked;
                        customColumn["_3seat"] = cb.Checked;
                        break;
                    }
                case "seat2":
                    {
                        dgvTrainView.Columns["_2seat"].Visible = cb.Checked;
                        customColumn["_2seat"] = cb.Checked;
                        break;
                    }
                case "seat1":
                    {
                        dgvTrainView.Columns["_1seat"].Visible = cb.Checked;
                        customColumn["_1seat"] = cb.Checked;
                        break;
                    }
                case "seat0":
                    {
                        dgvTrainView.Columns["_0seat"].Visible = cb.Checked;
                        customColumn["_0seat"] = cb.Checked;
                        break;
                    }
            }
        }

        //排序
        private void dgvTrainView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var datas = (BindingList<JsonTrainData>)SortClass.SortTrainDataSource(_BindingData, sortTable, e.ColumnIndex);
                var source = new BindingList<QueryLeftNewDTO>();
                foreach (var v in datas)
                {
                    var ql = new QueryLeftNewDTO();
                    ql = v.QueryLeftNewDto;
                    ql.ButtonTextInfo = v.ButtonTextInfo.Replace("<br/>", "");
                    ql.SecretStr = v.SecretStr;
                    source.Add(ql);
                }
                this.dgvTrainView.DataSource = source;
            }
        }

        private void cboLessCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cboLessCount.Text = Convert.ToInt32(cboLessCount.Text) < 1 ? "1" : Convert.ToInt32(cboLessCount.Text) > 5 ? "5" : cboLessCount.Text;
            }
            catch { cboLessCount.Text = "1"; }
        }

        private void tsbtnOrderSelect_Click(object sender, EventArgs e)
        {
            var form = new formOrderSelect(this.cookieContainer);
            form.ShowDialog();
        }

        private void tsbtnEditPassenger_Click(object sender, EventArgs e)
        {
            var editPassengers = new formPassengersEdit(cookieContainer);
            editPassengers.Show();
        }

        /// <summary>
        /// 在datagridview上画字符串
        /// </summary>
        /// <param name="dgv"></param>
        private void DrawNullDataString(Control dgv)
        {
            var font = new Font("微软雅黑", 30f);
            var brush=Brushes.AntiqueWhite;
            var point = new PointF((dgv.Width / 2 - 300), dgv.Height / 2 - 15);
            dgv.CreateGraphics().DrawString("当前设置的条件下没有查询到车次", font, brush, point);
        }

        private void btnDatePrev_Click(object sender, EventArgs e)
        {
            dtpRiqi.Value = dtpRiqi.Value.AddDays(-1) < dtpRiqi.MinDate ? dtpRiqi.MinDate : dtpRiqi.Value.AddDays(-1);
        }

        private void btnDateNext_Click(object sender, EventArgs e)
        {
            dtpRiqi.Value = dtpRiqi.Value.AddDays(1) > dtpRiqi.MaxDate ? dtpRiqi.MaxDate : dtpRiqi.Value.AddDays(1);
        }

        private void TicketMain_Load(object sender, EventArgs e)
        {
            dtpRiqi.MinDate = DateTime.Now;
            dtpRiqi.MaxDate = DateTime.Now.AddDays(40);
            AutoPicker.MinDate = DateTime.Now;
            AutoPicker.MaxDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            AutoPicker.Checked = false;

            selectAction.RedirectMy12306((o) => {
                if (o.ToString().Replace(" ", "").IndexOf("_is_active='Y'") == -1)
                { MessageBox.Show("您的用户尚未激活，请你登录邮箱激活帐号车票预订\r\n或者重新发送激活邮件","提示",MessageBoxButtons.OK,MessageBoxIcon.Information); return; }
                if (o.ToString().Replace(" ", "").IndexOf("_is_needModifyPassword='Y'") > -1)
                { MessageBox.Show("您设置的密码安全级别较低，强烈建议您修改密码"); return; }
                if (o.ToString().Replace(" ", "").IndexOf("notify_TWO_1='Y'") > -1)
                { MessageBox.Show("您的身份信息核验未通过\r\n详见《铁路互联网购票身份核验须知》", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (o.ToString().Replace(" ", "").IndexOf("notify_TWO_2='Y'") > -1)
                { MessageBox.Show("身份信息经过核验但未通过，需修改本网站所填写的身份信息内容与二代居民身份证原件完全一致，\r\n保存后状态仍显示“待核验”时，需持二代居民身份证原件到车站售票窗口或铁路客票代售点办理核验\r\n详见《铁路互联网购票身份核验须知》.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (o.ToString().Replace(" ", "").IndexOf("notify_THREE='Y'") > -1)
                { MessageBox.Show("您的身份信息未经核验，需持二代居民身份证原件到车站售票窗口或铁路客票代售点办理核验\r\n详见《铁路互联网购票身份核验须知》", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (o.ToString().Replace(" ", "").IndexOf("notify_FOUR='Y'") > -1)
                { MessageBox.Show("本网站不再支持一代居民身份证，请更改为二代居民身份证。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (o.ToString().Replace(" ", "").IndexOf("notify_FIVE='Y'") > -1)
                { MessageBox.Show("您的身份信息未经核验，需持在本网站填写的有效身份证件原件到车站售票窗口办理预核验\r\n详见《铁路互联网购票身份核验须知》", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            }, cookieContainer);

            var li = CityTelcode.StationNames.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
            var lii = (from p in li where p.IndexOf(cboFrom.Text) > -1 select p.Split('|')[1]).ToArray();
            cboFrom.Items.AddRange(lii);
            cboTo.Items.AddRange(lii);

            dgvTrainView.AutoGenerateColumns = false;

            DeterMineCall(() =>
            {
                if (_passengersData == null || _passengersData.Count <= 0)
                    GetPassengersFromServer();
                else
                {
                    GetPassengers();
                }
            });
        }

        private void chkInterval_CheckedChanged(object sender, EventArgs e)
        {
            plInterval.Visible = chkInterval.Checked;
            lsvTrainData.Visible = chkInterval.Checked;
            dtEndInterval.Value = dtpRiqi.Value;
        }
        
        private void cboFrom_TextUpdate(object sender, EventArgs e)
        {

            cboFrom.Items.Clear(); 
            cboFrom.SelectionStart = cboFrom.Text.Length;
            var li = CityTelcode.StationNames.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
            var tmp = (from p in li where p.IndexOf(cboFrom.Text) > -1 select p).ToArray();
            var liii = (from pp in tmp select pp.Split('|')[1]).ToArray();
            cboFrom.Items.AddRange(liii);
            if (!cboFrom.DroppedDown) cboFrom.DroppedDown = true;
            this.Cursor = cboFrom.Cursor;
        }

        private void cboTo_TextUpdate(object sender, EventArgs e)
        {
            cboTo.Items.Clear();
            cboTo.SelectionStart = cboTo.Text.Length;
            var li = CityTelcode.StationNames.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
            var tmp = (from p in li where p.IndexOf(cboTo.Text) > -1 select p).ToArray();
            var liii = (from pp in tmp select pp.Split('|')[1]).ToArray();
            cboTo.Items.AddRange(liii);
            if (!cboFrom.DroppedDown) cboTo.DroppedDown = true;
            this.Cursor = this.DefaultCursor;
        }

        private void tsbtnNewSelectPage_Click(object sender, EventArgs e)
        {
            var tabSelectPage = (TabControl)(this.Parent.Parent);
            System.Windows.Forms.ContextMenuStrip cmsSelectPage = tabSelectPage.ContextMenuStrip;

            var tp = new TabPage()
            {
                Text = "新的查询页",
                Margin = new Padding(0),
                Name = "selectPage" + (DateTime.Now-Convert.ToDateTime("1970-01-01")).Ticks,
                Padding = new Padding(0)
            };

            var tsmi = new ToolStripMenuItem("关闭 " + tp.Text);
            var tsi = (ToolStripItem)tsmi;

            tp.TextChanged += (a, b) => { tsi.Text = "关闭 " + tp.Text; };
            tsi.Click += (s, a) => { tabSelectPage.TabPages.Remove(tp); cmsSelectPage.Items.Remove(tsi); };
            var pas = new List<Nomal_Passengers>();
            CloneJsonTrainList(_passengersData, pas);
            var cfg = _config.CloneConfigList();
            cfg.Init = false;
            tp.Controls.Add(new TicketMain(cookieContainer, pas, cfg,_frame) { Dock = DockStyle.Fill });

            tabSelectPage.TabPages.Add(tp);
            tabSelectPage.SelectedTab = tp;
            cmsSelectPage.Items.Add(tsi);
        }

        private void CloneJsonTrainList(List<Nomal_Passengers> list1, List<Nomal_Passengers> list2)
        {
            if (list1 != null)
            for (int i = 0; i < list1.Count; i++)
            {
                list2.Add(list1[i].CloneNomalPassengers());
            }
        }

        private void chkCG_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Name != "chkFilterNoSeat")
                chkCA.Checked = false;
            var list = new List<JsonTrainData>();
            CloneJsonTrainList(_trainData, list);
            //if (chkCustomFilter.Checked)
            //{
            if (chkFilterNoSeat.Checked)
            {
                list = list.Where(x => x.QueryLeftNewDto.CanWebBuy == "Y").Select(x => x).ToList();
            }
            list = CustomFilter(list);
            //}
            lblTrainsCount.Text = string.Format("共有 {0} 趟车", list.Count);
            _BindingData = new BindingList<JsonTrainData>(list);

            var source = new BindingList<QueryLeftNewDTO>();
            foreach (var v in _BindingData)
            {
                var ql = new QueryLeftNewDTO();
                ql = v.QueryLeftNewDto;
                ql.ButtonTextInfo = v.ButtonTextInfo.Replace("<br/>", "");
                ql.SecretStr = v.SecretStr;
                source.Add(ql);
            }
            dgvTrainView.DataSource = source;
            dgvTrainView.Refresh();
        }

        private void CloneJsonTrainList(List<JsonTrainData> list1, List<JsonTrainData> list2)
        {
            if (list1 != null)
            for (int i = 0; i < list1.Count; i++)
            {
                list2.Add(list1[i].CloneJsonTrainData());
            }
        }

        private void chkCG_Click(object sender, EventArgs e)
        {
            if (chkCG.Checked && chkCD.Checked && chkCC.Checked && chkCZ.Checked && chkCT.Checked && chkCK.Checked && chkCL.Checked && chkCQ.Checked)
                chkCA.Checked = true;
            else
                chkCA.Checked = false;
        }

        private void cboShijian_SelectedIndexChanged(object sender, EventArgs e)
        {
            var data = new List<JsonTrainData>();
            CloneJsonTrainList(_trainData, data);
            try
            {
                data = data.Where(
                    x => string.Compare(x.QueryLeftNewDto.Start_time, cboShijian.Text.Split('-')[0]) >= 0)
                    .Select(x => x)
                    .Where(x =>
                        string.Compare(cboShijian.Text.Split('-')[1], x.QueryLeftNewDto.Start_time) >= 0)
                    .Select(x => x).ToList<JsonTrainData>();
            }
            catch { }
            lblTrainsCount.Text = string.Format("共有 {0} 趟车", data.Count);
            _BindingData = new BindingList<JsonTrainData>(data);

            var source = new BindingList<QueryLeftNewDTO>();
            foreach (var v in _BindingData)
            {
                var ql = new QueryLeftNewDTO();
                ql = v.QueryLeftNewDto;
                ql.ButtonTextInfo = v.ButtonTextInfo.Replace("<br/>", "");
                ql.SecretStr = v.SecretStr;
                source.Add(ql);
            }
            dgvTrainView.DataSource = source;
            dgvTrainView.Refresh();
        }

        private void dgvTrainView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
                        //是否是选中状态
            if ((e.State & DataGridViewElementStates.Selected) ==
                        DataGridViewElementStates.Selected)
            {
                // 计算选中区域Size
                int width = dgvTrainView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);// +dgvTrainView.Width - 2;

                Rectangle rowBounds = new Rectangle(
                  0, e.RowBounds.Top, width,
                    e.RowBounds.Height - 1);

                // 绘制选中背景色
                using (LinearGradientBrush backbrush =
                    new LinearGradientBrush(rowBounds,
                        Color.Wheat,
                        Color.BurlyWood, 90.0f))
                {
                    e.Graphics.FillRectangle(backbrush, rowBounds);
                    e.PaintCellsContent(rowBounds);
                    e.Handled = true;
                }

            }
        }

        private void dgvTrainView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int width = dgvTrainView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);// +dgvTrainView.Width - 2;
            Rectangle rowBounds = new Rectangle(
                   0, e.RowBounds.Top, width, e.RowBounds.Height - 1);

            if (dgvTrainView.CurrentCellAddress.Y == e.RowIndex)
            {
                //设置选中边框
                e.DrawFocus(rowBounds, true);
            }
        }

        private void btnPassengerReload_Click(object sender, EventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(GetPassengers));
        }

        private void btnAutoSubmitSet_Click(object sender, EventArgs e)
        {
            pop = new Popup(new ControlPassengers(_passengersData, _QuickPassengers));
            pop.AutoClose = false;
            pop.ShowingAnimation = pop.HidingAnimation = PopupAnimations.Blend;
            pop.Show(formSelectTicket.FormThis.Location.X + formSelectTicket.FormThis.Width / 2 - pop.Width / 2,
                formSelectTicket.FormThis.Location.X + formSelectTicket.FormThis.Height / 2 - pop.Height / 2);
            pop.Closed += (ss, ee) =>
            {
                GetPassengers();
                UpdateAutoPassengersList();
            };
        }

        private void chkAutoSubmit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoSubmit.Checked && lsvAutoPassengers.Items.Count <= 0)
            {
                MessageBox.Show("请先到[自动提交设置]中设置自动提交联系人信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                chkAutoSubmit.Checked = false;
            }
        }
    }
}
