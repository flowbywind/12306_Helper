using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;
using System.Linq;
using PingMock;
using System.Threading;

namespace _12306_Helper
{
    public partial class formSelectTicket : Form
    {
        private object locker = new object();
        public static bool switchisalive = false;
        public string user = "";
        string checiID = "";
        string trainClassType = "";
        int selectPassengerCount = 0;
        int switchSeed = 0;//服务器切换标志位
        IPAddress ipAddress = null;//本地解析12306的服务器地址
        public bool _IsAutoWork = false;
        public int SafeTime { get; set; }//订单提交安全期
        DateTime startTime;
        bool listenFlag = false;//监听标志
        bool switchEnable = true;
        HostAction hostAction;
        Object_IP localhost = new Object_IP();//本地解析服务器
        public static bool hostEnable = true;
        List<Object_IP> dnsList = new List<Object_IP>();//缓存服务器列表
        List<Object_IP> dnsListTmp = new List<Object_IP>();//缓存服务器列表
        CancellationTokenSource ctsSwitch = new CancellationTokenSource();
        CancellationTokenSource ctsListen = new CancellationTokenSource();
        ConfigList config = new ConfigList(); //配置文件
        private List<QuickTrainData> quickTrainData = new List<QuickTrainData>();
        private Hashtable turnDateTable = new Hashtable();//存放轮查日期
        public static Hashtable _QuickPassengers = new Hashtable();//存放乘客
        public List<string> _QuickAddSeatType = new List<string>();//存放坐席类别
        public List<string> _QuickAddTrainData = new List<string>();//存放火车车次

        public AutoBooker _autoBooker = new AutoBooker();//抢票
        DateTime ServerTime = DateTime.Now;//记录服务器时间
        public static formSelectTicket FormThis { get; private set; }
        public static List<TrainData> _trainData ;
        IList<TrainData> tmpTrainData = new List<TrainData>(); //临时的车次列表
        public BindingList<TrainData> _BindingData;
        public List<PassengersData> _passengersData;
        public static CookieContainer cookieContainer = new CookieContainer();
        FormShowStyle formStyle = new FormShowStyle();
        AutoCompleteStringCollection acCollection;
        SelectTicketAction selectAction = new SelectTicketAction();
        GetPassengerAction passengerAction = new GetPassengerAction();
        HTML_Translation translation = new HTML_Translation();
        public formSelectTicket()
        {           
            InitializeComponent();
            InitHostPath();
            formStyle.MakeShadow(this.Handle);
            dgvQuickTrainInfo.AutoGenerateColumns = false;
            FormThis = this;
            _trainData = new List<TrainData>();
            _BindingData = new BindingList<TrainData>(_trainData);
            SafeTime = 5;//默认的订单提交安全期
            switchisalive = formLogin.switchOpen;
        }
        private void InitHostPath()
        {
            try
            {
                hostAction = new HostAction(Environment.SystemDirectory + "\\drivers\\etc\\hosts");
            }
            catch {
                hostEnable = false;
            }
        }
        //初始化用户配置文件
        private void InitConfig()
        {
            DeterMineCall(() =>
            {
                lblVersion.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
                config = LocalCookie.ReadConfigFromDisk_ConfigList(System.IO.Directory.GetCurrentDirectory() + "\\config.cfg");
                if (config.User == user)
                {
                    cboFrom.Text = config.From;
                    cboTo.Text = config.To;
                    dtpRiqi.Value = config.Date>=DateTime.Now?config.Date:DateTime.Now;
                    cboShijian.Text = config.Time;

                    if (config.Turn)
                    {
                        TurnDatesInit();
                        chkSelectTurn.Checked = true;
                        fplTurnDates.Visible = true;

                        foreach (var v in config.TurnDates.Keys)
                        {
                            for (int i = 0; i < flpTurnCheckBox.Controls.Count; i++)
                            {
                                if (flpTurnCheckBox.Controls[i].Text == v.ToString())
                                {
                                    ((CheckBox)flpTurnCheckBox.Controls[i]).Checked = true;
                                    turnDateTable.Add(v, config.TurnDates[v]);
                                }
                            }
                        }
                    }

                    foreach (var v in config.Passengers.Keys)
                    {
                        for (int i = 1; i < flplPassengers.Controls.Count; i++)
                        {
                            if (v.ToString().Contains(flplPassengers.Controls[i].Text))
                            {
                                ((CheckBox)flplPassengers.Controls[i]).Checked = true;
                            }
                        }
                    }

                    for (int i = 0; i < config.SeatTypes.Count; i++)
                    {
                        QuickAddSeatType(config.SeatTypes[i]);
                    }

                    for (int i = 0; i < config.TrainNos.Count; i++)
                    {
                        QuikAddTrainInfo(config.TrainNos[i]);
                    }
                }
            });
        }
        bool passFlag = false;
        //初始化窗体
        private void formSelectTicket_Load(object sender, EventArgs e)
        {
            formStyle.ShowForm(this.Handle, 500);
            if (!hostEnable)
                chkAllowSwitch.Enabled = false;
            dtpRiqi.MinDate = DateTime.Now.AddDays(-1) ;
            dtpRiqi.MaxDate = DateTime.Now.AddDays(20);
            AutoPicker.MinDate = DateTime.Now;
            AutoPicker.MaxDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            AutoPicker.Checked = false;

            acCollection = GetCityTelCode();
            cboFrom.AutoCompleteCustomSource = acCollection;
            cboFrom.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboTo.AutoCompleteCustomSource = acCollection;
            cboTo.AutoCompleteSource = AutoCompleteSource.CustomSource;

            dgvTrainView.AutoGenerateColumns = false;
            dgvTrainView.DataSource = _BindingData;
            lblPassenger.Text = "正在加载联系人...";
            Application.DoEvents();

            passengerAction.GetPassengersAll((str) => {
                if (str == "获取信息失败"||str==string.Empty)
                {
                    if (!passFlag)
                    {
                        passFlag = true;
                        DeterMineCall(() =>
                        {
                            formSelectTicket_Load(sender, e);
                        });
                        return;
                    }
                    MessageBox.Show("信息获取失败，请重试", "获取联系人列表", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                    return; 
                }
                if(str==null)
                { MessageBox.Show("获取联系人失败，点击确定，重启程序修复此问题", "获取联系人列表", MessageBoxButtons.OK, MessageBoxIcon.Information); DeleteUserInfo(); Application.Restart(); }
                translation.TranslationHtml(str, (passengerSource) =>
                {
                    _passengersData = passengerSource;
                    for (int i = 1; i < flplPassengers.Controls.Count; i++)
                    {
                        flplPassengers.Controls.RemoveAt(i);
                    }
                    int j = 0;
                    DeterMineCall(() =>
                    {
                        foreach (PassengersData passenger in _passengersData)
                        {
                            CheckBox chk = new CheckBox();
                            chk.AutoSize = true;
                            chk.Tag = passenger;
                            chk.TabIndex=_passengersData.IndexOf(passenger);
                            chk.Name = "checkbox" + j.ToString();
                            chk.Text = passenger.Passenger_name;
                            chk.Checked = false;
                            chk.FlatStyle = FlatStyle.Flat;
                            flplPassengers.Controls.Add(chk);
                            chk.CheckedChanged += (ss, ee) => {
                                if (chk.Checked)
                                {
                                    if (selectPassengerCount == 5)
                                    { MessageBox.Show("已经是订票的最大人数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); chk.Checked = false; return; }
                                    _passengersData[chk.TabIndex].Checked = true;
                                    try
                                    {
                                        _QuickPassengers.Add(chk.Text + "|" + ((PassengersData)chk.Tag).Passenger_id_no, chk.Tag);
                                    }
                                    catch { }
                                    selectPassengerCount++;
                                }
                                else
                                {
                                    _passengersData[chk.TabIndex].Checked = false;
                                    _QuickPassengers.Remove(chk.Text + "|" + ((PassengersData)chk.Tag).Passenger_id_no);
                                    selectPassengerCount--;
                                }
                            };
                            j++;
                        }
                        flplPassengers.AutoScroll = true;
                        flplPassengers.VerticalScroll.Enabled = true;
                        flplPassengers.VerticalScroll.Visible = true;
                        flplPassengers.VerticalScroll.Minimum = 0;
                        flplPassengers.VerticalScroll.Maximum = 100;
                        lblPassenger.Text = "乘客：";
                    });
                    InitConfig();
                });
            }, cookieContainer);
            
            lblUser.Text = "登录账号：" + user;
            notice.Text = "12306 订票小助手 C# 版\r\n登录账号：" + user;
            tmUpdateServerTime.Start();
        }

        #region CacheServerAction
        /// <summary>
        /// 开启加载缓存服务器的线程
        /// </summary>
        private void StartGetDnsList()
        {
            if (switchEnable)
            {
                DeterMineCall(() =>
                {
                    lvSwitchStatus.Items.Clear();
                });
                ctsSwitch = new CancellationTokenSource();
                ThreadPool.QueueUserWorkItem(new WaitCallback(SwitchMethods), ctsSwitch.Token);
            }
        }

        /// <summary>
        /// 获取可用的缓存服务器列表
        /// </summary>
        private void SwitchMethods(object token)
        {
            CancellationToken ct = (CancellationToken)token;
            if (ct.IsCancellationRequested)
            {
                return;
            }
            GetIPInfoList getlist = new GetIPInfoList();
            dnsList.Clear();
            if (dnsList.Count <= 0)
            {
                string address = "";
                DeterMineCall(() => {
                    AddListViewItem("正在解析服务器IP并上报到服务器以便共享.....", Color.Navy, "");
                    ipAddress = Dns.GetHostAddresses("dynamic.12306.cn").FirstOrDefault<IPAddress>();
                    if (ipAddress != null)
                    {
                        address = ipAddress.ToString();                  
                        string str = "";
                        try
                        {
                            WebClient webClient = new WebClient();
                            str = webClient.DownloadString(string.Concat(Properties.Resources.ServerUpload, address));
                        }
                        catch (Exception exception)
                        {
                        }
                        if (str != "ok")
                        {
                            AddListViewItem("服务器IP上报失败.....", Color.Red, "");
                        }
                        else
                        {
                            AddListViewItem("服务器IP上报成功", Color.Green, "");
                        }
                    }
                    else
                    {
                        AddListViewItem("服务器IP上报失败.....", Color.Red, "");
                    }
                });

                DeterMineCall(() =>
                {
                    AddListViewItem("开始测试服务器速度...", Color.Navy, "");
                });
                getlist.GetSourceItem((item) =>
                {
                    if (ct.IsCancellationRequested)
                    {
                        return;
                    }
                    lock (locker)
                    {
                        DeterMineCall(() =>
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.SubItems.Add("时间");
                            lvi.SubItems.Add("信息");
                            lvi.SubItems[0].Text = DateTime.Now.ToLongTimeString();
                            if (!item.IsForbidden)
                            {
                                if (!item.IsNotValid)
                                {
                                    if (item.Speed.Value.TotalSeconds > 1)
                                    {
                                        dnsList.Remove(item);
                                        lvi.ForeColor =Color.FromArgb(192, 64, 0);
                                        lvi.SubItems[1].Text = string.Format("服务器 [{0}] 响应速度过低, 放弃使用. (响应速度={1}秒)", item.Ip, item.Speed.Value.TotalSeconds.ToString("#0.00"));
                                    }
                                    else
                                    {
                                        dnsList.Add(item);
                                        lvi.ForeColor = Color.Green;
                                        lvi.SubItems[1].Text = string.Format("服务器 [{0}] 正常. (响应速度={1}秒)", item.Ip, item.Speed.Value.TotalSeconds.ToString("#0.00"));
                                    }
                                }
                                else
                                {
                                    dnsList.Remove(item);
                                    lvi.ForeColor = Color.Red;
                                    lvi.SubItems[1].Text = string.Format("服务器 [{0}] 当前不可用. ({1})", item.Ip, item.Message);
                                }
                            }
                            else
                            {
                                dnsList.Remove(item);
                                lvi.ForeColor = Color.Red;
                                lvi.SubItems[1].Text = string.Format("服务器 [{0}] 已禁止了您的IP. ({1})", item.Ip, item.Message);
                            }
                            lvSwitchStatus.Items.Insert(0, lvi);
                        });
                    }
                }, Properties.Resources.GetDnsInterface);
                //rbtnFishlee.Checked? Properties.Resources.GetDnsInterface:Properties.Resources.GetDnsInterfaceATM
                switchSeed = 0;
                //排序
                if (ct.IsCancellationRequested)
                {
                    return;
                }
                dnsListTmp = dnsList;
                getlist.SortList((list) =>
                {
                    AddListViewItem("服务器测试完毕...共得到可用服务器{0}个", Color.Navy, new object[] { dnsListTmp.Count });
                    dnsListTmp = list;
                }, dnsListTmp, PingMock.GetIPInfoList.SortOrder.Ascending);
                switchSeed = 0;

                //开启监控线程
                if (!listenFlag)
                {
                    ListenLocalHost();
                }
                Thread.Sleep(60*60*1000);
                StartGetDnsList();
            }
        }
        /// <summary>
        /// 添加ListView行
        /// </summary>
        /// <param name="str">显示文本</param>
        /// <param name="color">文本颜色</param>
        /// <param name="param">参数，没有填""</param>
        private void AddListViewItem(string str, Color color, params object[] param)
        {
            DeterMineCall(() =>
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add("时间");
                lvi.SubItems.Add("信息");
                lvi.SubItems[0].Text = DateTime.Now.ToLongTimeString();
                lvi.SubItems[1].Text = string.Format(str, param);
                lvi.ForeColor = color;
                lvSwitchStatus.Items.Insert(0, lvi);
            });
        }
        /// <summary>
        /// 启动监听线程
        /// </summary>
        private void ListenLocalHost()
        {
            listenFlag = true;
            ctsListen = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(new WaitCallback(ListenMethod), ctsListen.Token);
        }

        /// <summary>
        /// 监听方法
        /// </summary>
        private void ListenMethod(object token)
        {
            CancellationToken ct = (CancellationToken)token;
            if (ct.IsCancellationRequested)
            {
                return;
            }
            lock (locker)
            {
                Object_IP localhost = new Object_IP();
                string hostLine = hostAction.GetCacheServerIP(Properties.Resources.domain);
                if (ipAddress != null)
                {
                    localhost.Ip = ipAddress.ToString();
                    ipAddress = null;
                }
                else
                {
                    localhost.Ip = hostLine == "" ? Properties.Resources.domain : hostLine.Replace(" " + Properties.Resources.domain, "");
                }
                localhost.HttpSetSpeed();
                hostAction.AddDnsResolve(localhost.Ip, Properties.Resources.domain);
                
                if (localhost.Speed == null)
                {
                    AddListViewItem("服务器 [{0}] 操作超时，正在切换... ", Color.FromArgb(192, 0, 192), localhost.Ip);
                    ServerSwitch(ct, localhost, (obj) => localhost = obj);
                }
                else
                {
                    if (localhost.Speed.Value.TotalSeconds > 1)//小于1秒,为正常速度
                    {
                        AddListViewItem("服务器 [{0}] 速度过慢,响应速度={1}秒，正在切换... ", Color.FromArgb(192, 0, 192), localhost.Ip, localhost.Speed.Value.TotalSeconds.ToString("#0.00"));
                        ServerSwitch(ct, localhost, (obj) => localhost = obj);
                    }
                    else
                    {
                        AddListViewItem("服务器 [{0}] 正常,响应速度={1}秒", Color.FromArgb(192, 0, 192), localhost.Ip, localhost.Speed.Value.TotalSeconds.ToString("#0.00"));
                    }
                }
            }
            System.Threading.Thread.Sleep(10000);
            ListenMethod(token);
        }
        /// <summary>
        /// 切换服务器
        /// </summary>
        /// <param name="objp">切换前的服务器</param>
        /// <param name="callback">切换后的服务器</param>
        private void ServerSwitch(CancellationToken token, Object_IP objp,Action<Object_IP> callback)
        {
            DeterMineCall(() =>
            {
                for (int i = switchSeed; i < dnsListTmp.Count; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    objp.Ip = dnsListTmp[i].Ip;
                    objp.HttpSetSpeed();
                    switchSeed++;
  
                    if (objp.Speed != null)
                    {
                        hostAction.AddDnsResolve(objp.Ip, Properties.Resources.domain);
                        callback(objp);
                        break;
                    }  
                }
                if (objp.Speed != null)
                {
                    AddListViewItem("切换完成 [{0}] ,响应速度={1}秒", Color.Green, new object[] { objp.Ip, objp.Speed.Value.TotalMilliseconds.ToString("#0.00") });
                }
            });
        }
        #endregion

        //加载下拉框数据源
        private AutoCompleteStringCollection GetCityTelCode()
        {
            AutoCompleteStringCollection acColletction = new AutoCompleteStringCollection();
            for (int i = 0; i < CityTelcode.cityTelcode.Length; i++)
            {
                acColletction.Add(CityTelcode.cityTelcode[i]);
            }
            return acColletction;
        }

        private void lblTop_MouseDown(object sender, MouseEventArgs e)
        {
            formStyle.MoveForm(this.Handle);
        }

        private void lblMini_MouseEnter(object sender, EventArgs e)
        {
            lblMini.BackColor = Color.FromArgb(192, 192, 255); 
        }

        private void lblMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(128, 128, 255);
        }

        private void lblMini_MouseLeave(object sender, EventArgs e)
        {
            lblMini.BackColor = Color.FromArgb(128, 128, 255);
        }

        private void lblHide_MouseEnter(object sender, EventArgs e)
        {
            lblHide.BackColor = Color.FromArgb(192, 192, 255); 
        }

        private void lblHide_MouseLeave(object sender, EventArgs e)
        {
            lblHide.BackColor = Color.FromArgb(128, 128, 255);
        }
        private void lblClose_Click(object sender, EventArgs e)
        {
            formStyle.HideForm(this.Handle, 500);
            Application.Exit();
        }

        private void lblMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void lblMax_MouseEnter(object sender, EventArgs e)
        {
            lblMax.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void lblMax_MouseLeave(object sender, EventArgs e)
        {
            lblMax.BackColor = Color.FromArgb(128, 128, 255);
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
            plQuickTrainInfo.Visible = false;
            if (!(cboFrom.Text != "" &&cboFrom.Text.IndexOf("|")>-1&& acCollection.IndexOf(cboFrom.Text)>-1))
            { MessageBox.Show("请正确输入始发站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (!(cboTo.Text != "" && cboTo.Text.IndexOf("|") > -1 && acCollection.IndexOf(cboFrom.Text) > -1))
            { MessageBox.Show("请正确输入到站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            if (dtpRiqi.Value.Date < DateTime.Now.Date) 
            { MessageBox.Show("查询日期错误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            plSetup.Enabled = false;
            btnSelectAll.Text = "正在查询";
            Application.DoEvents();

            trainClassType = "";
            checiID = "";
            
            if (txtChufaCheci.Text != "")
            {
                if (txtChufaCheci.Text.Split('|').Length == 2)
                    checiID = System.Text.RegularExpressions.Regex.Match(txtChufaCheci.Text.Split('|')[1].Replace(" ", ""), @"[0-9A-Z]{12}").ToString();
            }
            else
                checiID = "";
            if (chkQuanbu.Checked) trainClassType = "QB%23D%23Z%23T%23K%23QT%23";
            else
            {
                if (chkDongche.Checked) trainClassType += "D%23";
                if (chkZhida.Checked) trainClassType += "Z%23";
                if (chkTekuai.Checked) trainClassType += "T%23";
                if (chkKuaisu.Checked) trainClassType += "K%23";
                if (chkQita.Checked) trainClassType += "QT%23";
            }
            selectAction.QueryString = string.Format("&orderRequest.train_date={0}&orderRequest.from_station_telecode={1}&orderRequest.to_station_telecode={2}&orderRequest.train_no={3}&trainPassType={4}&trainClass={5}&includeStudent=00&seatTypeAndNum=&orderRequest.start_time_str={6}",
                                                dtpRiqi.Value.Date.ToString("yyyy-MM-dd"), cboFrom.Text.Split('|')[1], cboTo.Text.Split('|')[1], checiID, rbtnQuanbu.Checked ? "QB" : rbtnShifa.Checked ? "SF" : "GL", trainClassType, cboShijian.Text.Replace(":","%3A"));
            string htmlList = "";
            try
            {
                selectAction.GetLeftTickets((resultList) =>
                {
                    if (resultList == "获取信息失败" || resultList == string.Empty)
                    {
                        DeterMineCall(() => 
                        { 
                            plSetup.Enabled = true;
                            btnSelectAll.Text = "查询";
                            return; 
                        });
                    }
                    if (resultList != null && resultList != string.Empty)
                    {
                        htmlList = resultList;
                        translation.TranslationHtml(htmlList, (listSource) =>
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
                    }
                }, (expires) => 
                {
                    UpdateCacheExpires(expires);
                }, cookieContainer);
            }
            catch
            {
                plSetup.Enabled = true;
                btnSelectAll.Text = "查询";
            }
        }
        //绑定查询结果到datagridview
        public void DgvDataBind(List<TrainData> data)
        {
            if (chkCustomFilter.Checked)
            {
                if (chkFilterNoSeat.Checked)
                {
                    data = data.Where(x => x.Bookable).Select(x => x).ToList();
                }
                data=CustomFilter(data);
            }
            lblTrainsCount.Text =string.Format("共有 {0} 趟车" ,data.Count.ToString());
            _BindingData = new BindingList<TrainData>(data);
            dgvTrainView.DataSource = _BindingData;
            dgvTrainView.Refresh();
            lblLastSelectTime.Text = DateTime.Now.ToLongTimeString();
            AutoTrainNoSource();
            plSetup.Enabled = true;
            btnSelectAll.Text = "查询";
        }
        //为有票的单元格着色
        private void dgvTrainView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value.ToString() == "有" || (e.ColumnIndex > 5 && System.Text.RegularExpressions.Regex.IsMatch(e.Value.ToString(), "\\d+")))
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 192, 255);
            }
        }
        //自定义过滤
        private List<TrainData> CustomFilter(List<TrainData> data)
        {
            tmpTrainData = data;
            var tmpData = new List<TrainData>();
            if (!chkCA.Checked)
            {
                if (chkCG.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.Station_train_code.StartsWith("G")).Select(x => x).ToList<TrainData>()).ToList();
                if (chkCD.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.Station_train_code.StartsWith("D")).Select(x => x).ToList<TrainData>()).ToList();
                if (chkCC.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.Station_train_code.StartsWith("C")).Select(x => x).ToList<TrainData>()).ToList();
                if (chkCZ.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.Station_train_code.StartsWith("Z")).Select(x => x).ToList<TrainData>()).ToList();
                if (chkCT.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.Station_train_code.StartsWith("T")).Select(x => x).ToList<TrainData>()).ToList();
                if (chkCK.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.Station_train_code.StartsWith("K")).Select(x => x).ToList<TrainData>()).ToList();
                if (chkCL.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => x.Station_train_code.StartsWith("L")).Select(x => x).ToList<TrainData>()).ToList();
                if (chkCQ.Checked)
                    tmpData = tmpData.Concat(tmpTrainData.Where(x => !System.Text.RegularExpressions.Regex.IsMatch(x.Station_train_code, "[A-Z]")).Select(x => x).ToList<TrainData>()).ToList();
                return tmpData;
            }
            else
                return data;
        }
        //添加查找列表信息源
        public void AutoTrainNoSource()
        {
            AutoCompleteStringCollection acCollection = new AutoCompleteStringCollection();
            foreach (TrainData train in _trainData)
            {
                acCollection.Add(train.Station_train_code + " " + train.From_station_name + " " + train.Start_time + " → " + train.To_station_name + " " + train.Arrive_time + "   历时:" + train.Cost_time + " | " + train.Trainno4);
            }
            txtChufaCheci.AutoCompleteCustomSource = acCollection;
            txtChufaCheci.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        //筛选列车类型
        private void chkQuanbu_Click(object sender, EventArgs e)
        {
            if (chkQuanbu.Checked)
            {
                chkDongche.Checked = true;
                chkKuaisu.Checked = true;
                chkQita.Checked = true;
                chkTekuai.Checked = true;
                chkZhida.Checked = true;
            }
            else
            {
                chkDongche.Checked = false;
                chkKuaisu.Checked = false;
                chkQita.Checked = false;
                chkTekuai.Checked = false;
                chkZhida.Checked = false;
            }
        }
        //筛选列车类型
        private void chk_Click(object sender, EventArgs e)
        {
            if (chkDongche.Checked && chkKuaisu.Checked && chkQita.Checked && chkTekuai.Checked && chkZhida.Checked)
                chkQuanbu.Checked = true;
            else
                chkQuanbu.Checked = false;
        }
        //点击预定按钮
        private void dgvTrainView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                plQuickTrainInfo.Visible = false;
                if (dgvTrainView.Columns[e.ColumnIndex].Name == "BookTicket")
                {
                    this.dgvTrainView.Enabled = false;
                    var data = dgvTrainView.Rows[e.RowIndex].DataBoundItem as TrainData;
                    RunBook(data);
                    this.dgvTrainView.Enabled = true;
                }
            }
        }
        //过滤余票
        //public bool CheckLeftTicketEnough(TrainData data, string seat = "")
        //{
        //    if (seat != "" && Convert.ToInt16(data.SeatOwener[seat]) > selectPassengerCount)
        //    {
        //        return true;
        //    }
        //    else if (seat == "")
        //    {
        //        foreach (string v in data.SeatOwener.Keys)
        //        {
        //            if (Convert.ToInt16(data.SeatOwener[v]) > selectPassengerCount)
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //    else
        //        return false;
        //}
        //开始预定
        public void RunBook(TrainData data,string seat="")
        {
            DeterMineCall(() =>
            {
                if (data.Bookable)
                {
                    string postData = GetPostDataString(data, dtpRiqi.Value.Date);
                    if (seat != "")
                    {
                        StopListenning();
                        var form = new formSubmitOrder(postData, data, _passengersData, dtpRiqi.Value.Date.ToString("yyyy-MM-dd"), cookieContainer, seat);
                        this.Visible = true;
                        form.ShowDialog();
                        notice.ShowBalloonTip(5 * 1000, "提示", "抢到票啦！赶紧预定吧.", ToolTipIcon.Info);
                    }
                    else
                    {
                        StopListenning();
                        var form1 = new formSubmitOrder(postData, data, _passengersData, dtpRiqi.Value.Date.ToString("yyyy-MM-dd"), cookieContainer);
                        this.Visible = true;
                        form1.ShowDialog();
                        notice.ShowBalloonTip(5 * 1000, "提示", "抢到票啦！赶紧预定吧.", ToolTipIcon.Info);
                    }
                }
                else
                {
                    MessageBox.Show(this, "该车次无票可定", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
        }
        //生成PostData
        public string GetPostDataString(TrainData data,DateTime trainDate)
        {
            data.Train_date = trainDate.ToString("yyyy-MM-dd");
            string postData = string.Format("arrive_time={0}&from_station_name={1}&from_station_no={2}&from_station_telecode={3}&from_station_telecode_name={4}&include_student={5}&lishi={6}&locationCode={7}&mmStr={8}&round_start_time_str={9}&round_train_date={10}&seattype_num={11}&single_round_type={12}&start_time_str={13}&station_train_code={14}&to_station_name={15}&to_station_no={16}&to_station_telecode={17}&to_station_telecode_name={18}&train_class_arr={19}&train_date={20}&train_pass_type={21}&train_start_time={22}&trainno4={23}&ypInfoDetail={24}",
                                                data.Arrive_time.Replace(":", "%3A"), translation.UtfEncode(data.From_station_name), data.From_station_no, data.From_station_telecode, translation.UtfEncode(data.From_station_telecode_name), data.Include_student,
                                                data.Cost_time.Replace(":", "%3A"), data.LocationCode, data.mmStr, cboShijian.Text.Replace(":", "%3A"), data.Train_date, data.seattype_num,
                                                data.single_round_type, cboShijian.Text.Replace(":", "%3A"), data.Station_train_code, translation.UtfEncode(data.To_station_name), data.To_station_no, data.To_station_telecode,
                                                translation.UtfEncode(data.To_station_telecode_name), trainClassType, data.Train_date, rbtnQuanbu.Checked ? "QB" : rbtnShifa.Checked ? "SF" : "GL", data.Start_time.Replace(":", "%3A"), data.Trainno4, data.ypInfoDetail);
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
            var data = dgvTrainView.Rows[e.RowIndex].DataBoundItem as TrainData;
            this.QuikAddTrainInfo(data.Station_train_code);
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
                    AutoSize = true
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
                    AutoSize = true
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
            }
        }
        //抢票
        private void btnAutoBook_Click(object sender, EventArgs e)
        {
            if (!_IsAutoWork && btnAutoBook.Text == "抢票")
            {
                if (_QuickPassengers.Count == 0)
                {
                    MessageBox.Show(this, "请选择联系人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                } 
                if (_QuickAddTrainData.Count == 0)
                {
                    MessageBox.Show(this, "请选择车次！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (_QuickAddSeatType.Count == 0)
                {
                    MessageBox.Show(this, "请选择席别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                flpTurnCheckBox.Enabled = false;
                btnAutoBook.Text = "取消";
                lblAutoBook.Text = "自动预定设置 - 自动抢票中";
                Application.DoEvents();

                AutoWorkerParam();
                if (AutoPicker.Checked)
                {
                    tmWatch.Start();
                }
                else
                {
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
            startTime = DateTime.Now;
            lblCostTime.Text = "0:0:0";
            timer2.Start();
            _IsAutoWork = true;
        }
        public void AutoWorkFinished()
        {
            _autoBooker._Thread.Abort();
            _autoBooker.PauseWorking = true;
            _IsAutoWork = false;
            timer2.Stop();
            btnAutoBook.Text = "抢票";
            lblAutoBook.Text = "自动预定设置";
            flpTurnCheckBox.Enabled = true;
            Application.DoEvents();
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
            _autoBooker.from_station_telecode = cboFrom.Text.Split('|')[1];
            _autoBooker.to_station_telecode = cboTo.Text.Split('|')[1];
            _autoBooker.train_no = checiID;
            _autoBooker.trainPassType = rbtnQuanbu.Checked ? "QB" : rbtnShifa.Checked ? "SF" : "GL";
            _autoBooker.trainClass = trainClassType;
            _autoBooker.start_time_str = cboShijian.Text.Replace(":","%3A");
            _autoBooker.PauseWorking = false;
            _autoBooker.Period=Convert.ToInt16(numSelectSpan.Value);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            UpdateRefreshTime();
            lblRefreshTime.Text = _autoBooker.LastSelectTime;
        }
        //更新刷新时间和用时
        private void UpdateRefreshTime()
        {
            TimeSpan span = new TimeSpan();
            span = DateTime.Now - startTime;
            int tmp=Convert.ToInt32(span.TotalSeconds);
            string hh=Convert.ToString(tmp/3600);
            string mm=Convert.ToString(tmp%3600/60);
            string ss=Convert.ToString(tmp%3600%60);
            lblCostTime.Text = hh+":"+mm+":"+ss;
        }
        //获取服务器时间，并与本地时间做对比
        private void timer3_Tick(object sender, EventArgs e)
        {
            selectAction.GetServerTime((ss) =>
            {
                DeterMineCall(() =>
                {
                    ServerTime = Convert.ToDateTime(ss);
                    TimeSpan ts = ServerTime.Subtract(DateTime.Now);
                    if (ts.TotalSeconds > 0)
                    {
                        lblServerTime.Text = ServerTime.ToString("yyyy-MM-dd HH:mm:ss") + " 本地比服务器慢 " + ts.TotalSeconds.ToString("#0.000") + " 秒";
                    }
                    else
                    {
                        lblServerTime.Text = ServerTime.ToString("yyyy-MM-dd HH:mm:ss") + " 本地比服务器快 " + ts.TotalSeconds.ToString("#0.000").Replace("-", "") + " 秒";
                    }
                });
            },  cookieContainer);
        }
        //蹲点功能是否开启
        private void AutoPicker_ValueChanged(object sender, EventArgs e)
        {
            //if (AutoPicker.Checked)
            //    _autoBooker.WatchTime = AutoPicker.Value;
            //else
            //    _autoBooker.WatchTime = Convert.ToDateTime("0001-01-01 00:00:00");
        }
        //刷新间隔设置
        private void numSelectSpan_ValueChanged(object sender, EventArgs e)
        {
            _autoBooker.Period = Convert.ToInt16(numSelectSpan.Value<numSelectSpan.Minimum?numSelectSpan.Minimum:numSelectSpan.Value);
        }

        private void formSelectTicket_FormClosing(object sender, FormClosingEventArgs e)
        {
            notice.Visible = false;

            StopListenning();
            try
            {
                //if (_autoBooker._Thread.ThreadState == System.Threading.ThreadState.Running)
                    _autoBooker._Thread.Abort();
            }
            catch { }
            finally {
                try
                {
                    hostAction.RestoreHosts();
                }
                catch { }
                config.User = user;
                config.From = cboFrom.Text;
                config.To = cboTo.Text;
                config.Date = dtpRiqi.Value;
                config.Time = cboShijian.Text;
                if (chkSelectTurn.Checked)
                {
                    config.Turn = true;
                    config.TurnDates = turnDateTable;
                }
                else
                {
                    config.Turn = false;
                    config.TurnDates = new Hashtable();
                }
                config.Passengers = _QuickPassengers;
                config.SeatTypes = _QuickAddSeatType;
                config.TrainNos = _QuickAddTrainData;
                LocalCookie.WriteConfigToDisk(System.IO.Directory.GetCurrentDirectory() + "\\config.cfg", config);
            }
        }

        private void lkOrderSelect_Click(object sender, EventArgs e)
        {
            formOrderSelect form = new formOrderSelect();
            form.ShowDialog();
        }

        private void lkEditPassenger_Click(object sender, EventArgs e)
        {
            formPassengersEdit form = new formPassengersEdit();
            form.ShowDialog();
        }

        //更新缓存过期时间
        public void UpdateCacheExpires(object expires)
        {
            DeterMineCall(() =>
            {
                if (expires.ToString() != "false")
                {
                    DateTime dt = Convert.ToDateTime(expires);
                    lblHitCache.Text = "这是缓存数据 缓存时间:" + dt.ToString("HH:mm:ss") + " 预计过期时间:" + dt.AddMinutes(1).ToString("HH:mm:ss");
                }
                else
                    lblHitCache.Text = "";
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
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }

        //更改账户
        private void lblDeleteCookies_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("确定要退出本帐号吗？", "更改帐号", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DeleteUserInfo();
                cookieContainer = new CookieContainer();
                formLogin fl = new formLogin();
                fl.Show();
                this.Close();
            }
        }

        private void DeleteUserInfo()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg";
            string path1 = AppDomain.CurrentDomain.BaseDirectory + "config.cfg";
            string path2 = AppDomain.CurrentDomain.BaseDirectory + "usr.cfg";
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                if (System.IO.File.Exists(path1))
                {
                    System.IO.File.Delete(path1);
                } 
                if (System.IO.File.Exists(path2))
                {
                    System.IO.File.Delete(path2);
                }
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
                fplTurnDates.Visible = false;
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

        private void lblHide_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            notice.Visible = true;
            notice.ShowBalloonTip(4000, "提示 "+lblVersion.Text, "如果您开启了抢票，抢到票后会自动弹出窗口.",ToolTipIcon.Info);
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

        private void chkCustomFilter_CheckedChanged(object sender, EventArgs e)
        {
            plCustom.Enabled = chkCustomFilter.Checked;
        }

        private void lnkStartTime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formSelectSaleTime SelectSaleTime = new formSelectSaleTime();
            SelectSaleTime.ShowDialog();
        }

        private void lnkNewContent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formNewContentcs newConetent = new formNewContentcs();
            newConetent.Show();
        }

        private void lblVersion_MouseDown(object sender, MouseEventArgs e)
        {
            formStyle.MoveForm(this.Handle);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            plQuickTrainInfo.Visible = false;
        }

        private void 显示过站信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvQuickTrainInfo.DataSource = null;
            if (dgvTrainView.SelectedRows.Count > 0)
            {
                TrainData data = dgvTrainView.SelectedRows[0].DataBoundItem as TrainData;
                BindQuickTrainInfo(data.From_station_name,data.To_station_name, data.Trainno4, data.From_station_telecode, data.To_station_telecode, dtpRiqi.Value.ToString("yyyy-MM-dd"));
                Point point = new Point(10, Cursor.Position.Y - this.Location.Y - 50);
                plQuickTrainInfo.Location = point;
                lblQuickTrainInfo.Text = data.Station_train_code+" : "+data.From_station_name+" - "+data.To_station_name;
                plQuickTrainInfo.Visible = true;
            }
        }

        //加载过站信息
        private void BindQuickTrainInfo(string from,string to,string train_no, string from_station_telecode, string to_station_telecode, string depart_date)
        {
            selectAction.QueryString = string.Format("&train_no={0}&from_station_telecode={1}&to_station_telecode={2}&depart_date={3}", 
                                                    train_no, from_station_telecode, to_station_telecode, depart_date);
            selectAction.GetArriveStationInfo((str) =>
            {
                if (str == string.Empty || str == "")
                {
                    MessageBox.Show("加载信息失败", "加载过站信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                translation.TranslationHtml(str, (traininfo) => {
                    if (traininfo != null)
                    {
                        DeterMineCall(() =>
                        {
                            quickTrainData = traininfo;
                            dgvQuickTrainInfo.DataSource = quickTrainData;
                            DeterMineCall(() => {
                                foreach(DataGridViewRow row in dgvQuickTrainInfo.Rows)
                                {
                                    if (row.Cells[1].Value.ToString() == from || row.Cells[1].Value.ToString() == to)
                                    { 
                                        row.DefaultCellStyle.ForeColor = Color.Blue;
                                    }
                                }
                            });
                        });
                    }
                }); 
            }, cookieContainer);
        }

        private void lblQuickClose_Click(object sender, EventArgs e)
        {
            plQuickTrainInfo.Visible = false;
        }

        private void lblQuickClose_MouseEnter(object sender, EventArgs e)
        {
            lblQuickClose.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void lblQuickClose_MouseLeave(object sender, EventArgs e)
        {
            lblQuickClose.BackColor = Color.FromArgb(162, 162, 255);
        }

        private void lblQuickTrainInfo_MouseDown(object sender, MouseEventArgs e)
        {
            formStyle.MoveForm(plQuickTrainInfo.Handle);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (plQuickTrainInfo.Visible == true)
                显示过站信息ToolStripMenuItem.Enabled = false;
            else
                显示过站信息ToolStripMenuItem.Enabled = true;
        }

        private void lnkLinkToCommon_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.Common);
        }

        private void lnkLinkToBug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.Bug);
        }

        private void lnkLinkToAdvice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.Advice);
        }

        private void lnkLinkToDeveloper_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.Developer);
        }

        private void lnkLinkToMain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenIE_API.OpenUrl(Properties.Resources.MainPage);
        }

        private void lblAutoSwitch_Click(object sender, EventArgs e)
        {
            //plAutoSwitch.Visible = !plAutoSwitch.Visible;
            if (!switchisalive&&hostEnable&&!formLogin.switchOpen)
            {
                switchisalive = true;
                formSwitchServer fss = new formSwitchServer();
                fss.Show();
            }
        }

        private void btnInitHosts_Click(object sender, EventArgs e)
        {
            try
            {
                hostAction.InitHosts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("由于访问Hosts文件失败，失败原因：{0}\r\n导致无法初始化Hosts文件，请允许程序访问Hosts文件或者去除Hosts文件的保护,然后重新启动本程序", ex.Message), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkAllowSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllowSwitch.Checked)
            {
                //加载缓存服务器列表
                chkAllowSwitch.Text = "禁用自动切换服务器";
                plSourceFrom.Enabled = false;
                switchEnable = true;
                StartGetDnsList();
            }
            else
            {
                chkAllowSwitch.Text = "启用自动切换服务器";
                listenFlag = false;
                switchEnable = false;
                StopListenning();
                plSourceFrom.Enabled = true;
                AddListViewItem("IP自动切换线程已被取消...", Color.Red, "");
            }
        }

        private void StopListenning()
        {
            dnsList.Clear();
            ctsListen.Cancel();
            ctsSwitch.Cancel();
        }

        //蹲点监控
        private void tmWatch_Tick(object sender, EventArgs e)
        {
            TimeSpan ts=new TimeSpan();
            ts=AutoPicker.Value.Subtract(ServerTime);
            lblRefreshTime.Text = "倒计时：" + ts.TotalSeconds + "秒";
            if (ts.TotalSeconds < 60&&ts.TotalSeconds >56)
            {
                tmUpdateServerTime.Interval = 500;
            }
            if (ts.TotalSeconds < -1)
            {
                _autoBooker.ThreadProcStart();
                tmWatch.Stop();
            }
        }

        #region 调整窗体大小
        const int WM_NCHITTEST = 0x0084;
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
            }
        }
        #endregion

        private void notice_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            notice.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formPassengersEdit editPassengers = new formPassengersEdit();
            editPassengers.Show();
        }
    }
}
