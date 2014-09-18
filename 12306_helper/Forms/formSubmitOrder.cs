#define DEBUG
#define CHECK
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections;
using System.Threading;
using aNyoNe.GetInfoFrom12306;
using System.Linq;
using Newtonsoft.Json.Linq;
using _12306_Helper.Properties;

namespace _12306_Helper
{
    public partial class formSubmitOrder : Form
    {
        private int flag = 0;
        string _defaultSeat = "";//默认坐席
        decimal _timeSpan = 0;
        decimal _submitSpan = 0;
        string _trainDate = "";
        string _orderNo = "";
        string _postData = "";
        bool IsFirstLoad = false;
        string _user = "";
        System.Media.SoundPlayer sp = null;
        OrderData_Otn orderData;
        Hashtable _tokenAndLeftTicket = new Hashtable();
        CookieContainer _cookieContainer = new CookieContainer();
        SubmitOrderAction submitAction = new SubmitOrderAction();
        HTML_Translation translation = new HTML_Translation();
        SubmitDataOperation getPostData = new SubmitDataOperation();
        QueryLeftNewDTO _trainData = null;
        List<Nomal_Passengers> _passengers = null;
        Thread _Thread;
        System.Windows.Forms.Timer t = null;//时间控制

        Control parent;

        public formSubmitOrder(Control p, string user, string postData, QueryLeftNewDTO trainInfo, List<Nomal_Passengers> passengers, string trainDate, CookieContainer cookie, string title, string defaultseat = "", bool fl = false)
        {
            InitializeComponent();
            parent = p;
            _user = user;
            this.Text += "   " + title;
            this._postData = postData;
            this._trainData = trainInfo;
            this._cookieContainer = cookie;
            this._passengers = passengers;
            this._trainDate = trainDate;
            this._defaultSeat = defaultseat;
            if (!fl && this._defaultSeat != "")
            {
                string path = System.IO.Directory.GetCurrentDirectory() + "\\Sound_GetTicket.wav";
                if (System.IO.File.Exists(path))
                {
                    sp = new System.Media.SoundPlayer(path);
                    sp.Play();
                }
            }
        }
        private void DeterMineCall(MethodInvoker method)
        {
            if (!this.IsDisposed)
                if (InvokeRequired)
                    Invoke(method);
                else
                    method();
        }

        ~formSubmitOrder()
        {
            GC.Collect();
            GC.Collect();
        }

        private void formSubmitOrder_Load(object sender, EventArgs e)
        {

            DeterMineCall(() =>
            {
                lblTrainNoInfo.Text = String.Format("{0} ——→ {1}   车次：{2}   发车时间：{3} {4}   历时：{5}",
                    _trainData.From_station_name, _trainData.To_station_name,
                    _trainData.Station_train_code, _trainDate, _trainData.Start_time, _trainData.Lishi);

                _Thread = new Thread(new ThreadStart(() =>
                {
                    DeterMineCall(() =>
                    {
                        GetSeatTypes();

                        lblState1.Text = "正在获取Token(由于官方服务里返回结果时快时慢,等待时间可能很长很长很长)...";
                        Application.DoEvents();
                        GetToken();
                        flplPassengers.AutoScroll = true;
                        flplPassengers.VerticalScroll.Enabled = true;
                        flplPassengers.VerticalScroll.Visible = true;
                        flplPassengers.VerticalScroll.Minimum = 0;
                        flplPassengers.VerticalScroll.Maximum = 100;
                    });
                }));
                _Thread.IsBackground = true;
                _Thread.Start();
            });
        }
        //加载票价
        //private void GetTicketPrice()
        //{
        //    alreadyGetPrice = true;
        //    DetermineCall(() =>
        //    {
        //        ticketsPrice.Clear();
        //        if (ticketPriceStr != null)
        //        {
        //            ticketPriceStr = ticketPriceStr.Split(new string[] { "<tr" }, StringSplitOptions.RemoveEmptyEntries)[2].Replace("<td>", "").Replace("</tr>", "").Replace("\r\n", "").Replace(">", "").Replace("\t", "");
        //            string[] tmp = ticketPriceStr.Split(new string[] { "</td" }, StringSplitOptions.RemoveEmptyEntries);
        //            for (int i = 0; i < tmp.Length; i++)
        //            {
        //                ticketsPrice.Add(tmp[i].Split(')')[0]);
        //            }
        //        }
        //        GetLeftTicketCount();
        //    });
        //}
        //加载余票信息
        private void GetLeftTicketCount()
        {
            //DeterMineCall(() =>
            //{
            fpPrice.Controls.Clear();

            var tmpTable = new Hashtable();
            string price = "";
            string count = "";
            var details = _tokenAndLeftTicket["queryLeftNewDetailDTO"] as JObject;
            if (_trainData.SeatOwener.Keys.Count > 1 && _trainData.SeatOwener.Keys.Contains("无座"))
                try
                { ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Remove("无座"); }
                catch { }
            foreach (var seat in _trainData.SeatOwener.Keys)
            {
                switch (seat)
                {
                    case "商务座": { price = details["SWZ_price"].ToString(); count = details["SWZ_num"].ToString(); break; }
                    case "特等座": { price = details["TZ_price"].ToString(); count = details["TZ_num"].ToString(); break; }
                    case "一等座": { price = details["ZY_price"].ToString(); count = details["ZY_num"].ToString(); break; }
                    //case "一等软座": { break; }
                    case "二等座": { price = details["ZE_price"].ToString(); count = details["ZE_num"].ToString(); break; }
                    //case "二等软座": { break; }
                    case "高级软卧": { price = details["GR_price"].ToString(); count = details["GR_num"].ToString(); break; }
                    case "软卧": { price = details["RW_price"].ToString(); count = details["RW_num"].ToString(); break; }
                    case "硬卧": { price = details["YW_price"].ToString(); count = details["YW_num"].ToString(); break; }
                    case "软座": { price = details["RZ_price"].ToString(); count = details["RZ_num"].ToString(); break; }
                    case "硬座": { price = details["YZ_price"].ToString(); count = details["YZ_num"].ToString(); break; }
                    case "无座": { price = details["WZ_price"].ToString(); count = details["WZ_num"].ToString(); break; }
                }

                Label lbl = new Label();

                for (int i = 0; i < price.Length; i++)
                {
                    if (price.Substring(0, 1) == "0")
                        price = price.Substring(1);
                }
                price = price.Substring(0, price.Length - 1) + "." + price.Substring(price.Length - 1, 1);
                lbl.ForeColor = Color.Blue;
                lbl.Text = String.Format("{0}({1}元):{2}张", seat, price, count);
                lbl.Visible = true;
                lbl.AutoSize = true;
                fpPrice.Controls.Add(lbl);
            }
            //});
        }

        //获取Token
        private void GetToken()
        {
            DetermineCall(() =>
            {
                lblState1.Text = "正在获取Token(由于官方服务里返回结果时快时慢,等待时间可能很长很长很长)...";
                Application.DoEvents();
            });
            submitAction.PostData = _postData;

            submitAction.EnterSubmitPage((str) =>
            {
                DetermineCall(() =>
                {
                    var returnString = translation.TranslationHtmlEx(str);
                    if (returnString["messages"].Any())
                    {
                        //if (str.Contains("未完成订单"))
                        //{
                            MessageBox.Show(returnString["messages"][0].ToString(), "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lblState1.Text = returnString["messages"][0].ToString();
                            Application.DoEvents();
                            return;
                        //}

                    }
                    //else
                    //{
                    //    MessageBox.Show("获取Token失败!");
                    //    return;
                    //}
               

                submitAction.GetTokenFromSubmitPageSync((tokenHtml) =>
                {
                    if (!string.IsNullOrEmpty(tokenHtml))
                    {
                        DetermineCall(() =>
                        {
                            _tokenAndLeftTicket["Token"] = System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<=var globalRepeatSubmitToken = ')[0-9abcdefABCDEF]{32}").ToString();
                            _tokenAndLeftTicket["leftTicket"] = System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<='leftTicketStr':')[0-9A-Za-z]{30,50}").ToString();
                            _tokenAndLeftTicket["keyCheck"] = System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<='key_check_isChange':')[0-9A-Za-z]*").ToString();
                            _tokenAndLeftTicket["trainLocation"] = System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<='train_location':')[^']*").ToString();
                            _tokenAndLeftTicket["purposeCodes"] = System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<='purpose_codes':')[^']*").ToString();
                            _tokenAndLeftTicket["ticketInfoForPassengerForm"] = System.Text.RegularExpressions.Regex.Match(tokenHtml, "(?<=ticketInfoForPassengerForm=)[^;]*").ToString().Replace("'", "\"");

                            if (_tokenAndLeftTicket["Token"] == null || _tokenAndLeftTicket["Token"].ToString() == "" || _tokenAndLeftTicket["ticketInfoForPassengerForm"] == null || _tokenAndLeftTicket["ticketInfoForPassengerForm"].ToString() == "")
                            {
                                MessageBox.Show("获取Token失败!");
                                lblState1.Text = "获取Token失败";
                                Application.DoEvents();
                                return;
                            }
                        });

                        var javaObj = translation.TranslationHtmlEx(_tokenAndLeftTicket["ticketInfoForPassengerForm"].ToString());
                        _tokenAndLeftTicket["queryLeftNewDetailDTO"] = javaObj["queryLeftNewDetailDTO"] as JObject;
                        GetRandCodeImg();
                        DetermineCall(() =>
                        {

                            fpPrice.Controls.Clear();
                            lblState1.Text = "正在加载余票信息...";
                            Application.DoEvents();
                            GetLeftTicketCount(); //加载余票信息
                            if (flplPassengers.Controls.Count <= 1)
                                LoadPassengers();  //加载联系人
                            lblState1.Text = "";
                            Application.DoEvents();
                            BeginSafeCount();

                        });
                    }
                    else
                    {
                        DetermineCall(() => {

                            MessageBox.Show("获取该车次信息出现异常，请重新提交订单");
                            return;
                        });
                    }
                }, _cookieContainer);

                });
                //获取联系人
                //DetermineCall(() => { lblPassenger.Text = "乘客：正在加载联系人,请稍等..."; Application.DoEvents(); });
                //var passengerAction = new GetPassengerAction();
                //passengerAction.PostData = string.Format("_json_att=&REPEAT_SUBMIT_TOKEN={0}", _tokenAndLeftTicket["Token"].ToString());
                //passengerAction.GetPassengersAllJson((strPassenger) =>
                //{

                //    var htmlTrans = new HTML_Translation();
                //    var returnStrings = htmlTrans.TranslationHtmlEx(strPassenger);
                //    if (returnStrings["data"]["normal_passengers"].Count() > 0)
                //        htmlTrans.TranslationPassengerJson(strPassenger, (passengerList) =>
                //        {
                //            //new LogInfo().WriteStringToTxt(_user, "JsonPassengers", strPassenger);
                //            //_passengersNew = passengerList;
                //            //加载验证码

                //            //LoadPassengers();
                //        });
                //    else
                //    {
                //        DetermineCall(() => { lblPassenger.Text = "乘客：联系人加载失败!"; Application.DoEvents(); });
                //    }
                //}, _cookieContainer);

            }, _cookieContainer);
        }

        private void BeginSafeCount()
        {
            if (!IsFirstLoad)
            {
                //开启安全期倒数
                IsFirstLoad = true;
                this.numSafeTime.Value = ((TicketFrame)(parent.Parent.Parent.Parent)).SafeTime;
                _timeSpan = this.numSafeTime.Value;//< 4 ? 4 : this.numSafeTime.Value;
                _submitSpan = numSubmitSpan.Value * 1000;
                lblState1.Text = String.Format("距离安全期还有 {0} 秒", _timeSpan);
                timer1.Start();
            }
        }

        //获取坐席类别
        private void GetSeatTypes()
        {
            ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Clear();
            foreach (var seat in _trainData.SeatOwener.Keys)
            {
                ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Add(seat);
            }
        }

        //获取并添加联系人信息
        private void LoadPassengers()
        {
            for (int i = 1; i < flplPassengers.Controls.Count; i++)
            {
                flplPassengers.Controls.RemoveAt(i);
            }
            dgvPassenger.Rows.Clear();
            //if (_passengers != null && _passengers.Count > 0)
            //{
            //    var tmpList = _passengers.Where(x => x.IsCheck == true).Select(x => x).ToList<Nomal_Passengers>();
            //    if (tmpList != null && tmpList.Count > 0)
            //        foreach (Nomal_Passengers pas in tmpList)
            //        {
            //            for (int i = 0; i < _passengersNew.Count; i++)
            //            {
            //                if (_passengersNew[i].Passenger_id_no == pas.Passenger_id_no)
            //                {
            //                    _passengersNew[i].IsCheck = true;
            //                }
            //            }
            //        }
            //}
            int j = 0;
            foreach (Nomal_Passengers passenger in _passengers)
            {
                var chk = new CheckBox()
                {
                    AutoSize = true,
                    Tag = passenger,
                    Name = "checkbox" + j,
                    TabIndex = _passengers.IndexOf(passenger),
                    Text = passenger.Passenger_name,
                    Checked = false,
                    ForeColor = Color.FromArgb(64, 64, 64),
                    FlatStyle = FlatStyle.Flat
                };
                DetermineCall(() =>
                {
                    flplPassengers.Controls.Add(chk);

                    if (passenger.IsCheck)
                    {
                        chk.Checked = true;
                        int index = dgvPassenger.Rows.Add();
                        AddPassengerToGrid(chk.Text, chk.Name, (Nomal_Passengers)(chk.Tag), index, _defaultSeat);
                    }
                });
                chk.CheckedChanged += (ss, ee) =>
                {
                    if (chk.Checked == true)
                    {
                        if (dgvPassenger.Rows.Count == 5)
                        {
                            chk.Checked = false;
                            MessageBox.Show("已经是订票的最大人数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return;
                        }
                        int index = dgvPassenger.Rows.Add();
                        AddPassengerToGrid(chk.Text, chk.Name, (Nomal_Passengers)(chk.Tag), index, "");
                        foreach (Nomal_Passengers pas in _passengers)
                        {
                            if (pas.Passenger_id_no == ((Nomal_Passengers)(chk.Tag)).Passenger_id_no)
                                pas.IsCheck = true;
                        }

                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgvPassenger.Rows)
                        {
                            if (((Nomal_Passengers)chk.Tag).Passenger_id_no == row.Cells["zhengjianhao"].Value.ToString() && ((Nomal_Passengers)chk.Tag).Passenger_name == row.Cells["xingming"].Value.ToString())
                            {
                                dgvPassenger.Rows.Remove(row);
                            }
                        }
                        foreach (Nomal_Passengers pas in _passengers)
                        {
                            if (pas.Passenger_id_no == ((Nomal_Passengers)(chk.Tag)).Passenger_id_no)
                                pas.IsCheck = false;
                        }
                    }
                };
                j++;
            }
            DetermineCall(() => { lblPassenger.Text = "乘客："; Application.DoEvents(); });
        }

        private void AddPassengerToGrid(string text, string name, Nomal_Passengers passenger, int index, string def)
        {
            dgvPassenger.Rows[index].Cells["xingming"].Value = text;
            dgvPassenger.Rows[index].Cells["xingming"].Tag = passenger;//存储乘车人信息
            dgvPassenger.Rows[index].Cells["zhengjianhao"].Value = passenger.Passenger_id_no;
            dgvPassenger.Rows[index].Cells["shoujihao"].Value = passenger.Mobile_no;
            if (def != "")
            {
                dgvPassenger.Rows[index].Cells["xibie"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items[((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.IndexOf(def)].ToString();
            }
            else
                dgvPassenger.Rows[index].Cells["xibie"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items[((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Count - 1].ToString();
            //有其它座位可以选择的时候不选择无座为默认坐席
            if (dgvPassenger.Rows[index].Cells["xibie"].Value.ToString() == "无座" && ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Count > 1)
            {
                dgvPassenger.Rows[index].Cells["xibie"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items[((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Count - 2].ToString();
            }
            string typeCode = passenger.Passenger_id_type_code;
            foreach (var v in DatasList.CardType.Keys)
            {
                if (DatasList.CardType[v].ToString() == typeCode)
                {
                    typeCode = v.ToString();
                    break;
                }
            }
            dgvPassenger.Rows[index].Cells["zhengjian"].Value = typeCode.Length >= 2 ? typeCode : ((DataGridViewComboBoxColumn)dgvPassenger.Columns[3]).Items[0].ToString();
            dgvPassenger.Rows[index].Cells["zhengjian"].Tag = name;

            string ticketCode = passenger.Passenger_type;
            foreach (var v in DatasList.TicketType.Keys)
            {
                if (DatasList.TicketType[v].ToString() == ticketCode)
                {
                    ticketCode = v.ToString();
                    break;
                }
            }
            dgvPassenger.Rows[index].Cells["piaozhong"].Value = ticketCode.Length >= 2 ? ticketCode : ((DataGridViewComboBoxColumn)dgvPassenger.Columns[2]).Items[0].ToString();

            dgvPassenger.Refresh();
        }

        //获取验证码
        private void GetRandCodeImg()
        {
            DeterMineCall(() =>
            {
                randCode1.Image = Resources.loading;
            });
            submitAction.GetOrderRandCodeImg((bit) =>
            {
                Action ac = () =>
                {
                    randCode1.Image = bit;
                    txtRandCode1.Text = "";
                    txtRandCode1.Focus();
                };
                if (InvokeRequired)
                    Invoke(ac);
            }, _cookieContainer);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DetermineCall(() =>
            {
                _timeSpan--;
                if (_timeSpan == 0)
                {
                    btnSubmit.Enabled = true;
                    timer1.Stop();
                    lblState1.Text = "安全期已过，可以提交订单了。";

                    t = new System.Windows.Forms.Timer();
                    t.Interval = 1000 * 60 * 3;
                    t.Start();
                    t.Tick += (o, arg) =>
                    {
                        t.Stop();
                        DeterMineCall(() =>
                        {
                            MessageBox.Show("您长时间处于预定等待状态,可能会造成无法正常提交的情况,因此,为了保证您订票的成功率,请关闭本窗体重新预定.", "等待超时", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                    };
                    return;
                }
                else
                    lblState1.Text = String.Format("距离安全期还有 {0} 秒", _timeSpan);
            });
        }

        private void randCode1_Click(object sender, EventArgs e)
        {
            GetRandCodeImg();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //queueFlag = 0;
            if (_tokenAndLeftTicket["Token"].ToString() == "")
            {
                MessageBox.Show("获取Token失败,该票已停售或已卖完.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //new MessageBoxEx("获取Token失败,该票已停售或已卖完！", MessageboxExIcon.ERROR) { NewPrivateInterval = 1000 }.Show();
                return;
            }
            int itemCount = dgvPassenger.Rows.Count;
            if (itemCount <= 0)
            {
                lblState1.Text = "请选择联系人！";
            }
            else
            {
                if (txtRandCode1.Text.Length != 4)
                {
                    lblState1.Text = "请输入正确的验证码!";
                    return;
                }
                btnSubmit.Enabled = false;

                var passengers = new List<Nomal_Passengers>();
                for (int i = 0; i < dgvPassenger.Rows.Count; i++)
                {
                    var pas = ((Nomal_Passengers)(dgvPassenger.Rows[i].Cells["xingming"].Tag));
                    pas.SeatCode = DatasList.SeatType[dgvPassenger.Rows[i].Cells[1].Value].ToString();
                    pas.TicketCode = DatasList.TicketType[dgvPassenger.Rows[i].Cells[2].Value].ToString();
                    pas.IsCheck = true;
                    passengers.Add(pas);
                }

                orderData = new OrderData_Otn(_trainData, passengers);
                orderData.RandCode = txtRandCode1.Text;
                orderData.REPEAT_SUBMIT_TOKEN = _tokenAndLeftTicket["Token"].ToString();

                getPostData.OData = orderData;
                DetermineCall(() =>
                {
                    lblState1.Text = "开始确认订单...";
                    Application.DoEvents();
                });
                ConfirmOrder();
            }
        }

        private void DetermineCall(MethodInvoker method)
        {
            if (InvokeRequired && !this.IsDisposed)
                Invoke(method);
            else
                method();
        }

        private void StopSubmit(string info = "")
        {
            DetermineCall(() =>
            {
                timer2.Enabled = false;
                btnSubmit.Enabled = true;
                btnStopSubmit.Enabled = false;
                //GetRandCodeImg();
                txtRandCode1.Text = "";
                lblState1.Text = info;
            });
        }
        private void ConfirmOrder()
        {
            //getPostData.GetOrderPostData((data) =>
            //{
            //    if (_trainData.SpecialSeatType != null && _trainData.SpecialSeatType.Count != 0)
            //    {   //适应一等软座和二等软座的代码
            //        data = data.Replace("passengerTickets=M", "passengerTickets=7").Replace("passengerTickets=O", "passengerTickets=8");
            //    }
            //    foreach (DataGridViewRow v in dgvPassenger.Rows)
            //    {
            //        string queryString = string.Format("method=logClickPassenger&passenger_name={0}&passenger_id_no={1}&action=checked", translation.UtfEncode(v.Cells[0].Value.ToString()), v.Cells[4].Value.ToString());
            //        submitAction.QueryString = queryString;
            //        submitAction.ConfirmOrder_traceAction((str) => { }, _cookieContainer);
            //    }
            string data = getPostData.GetCheckOrderPostData(getPostData.OData);
            submitAction.PostData = data;
            //submitAction.QueryString = "&rand=" + txtRandCode1.Text;

            submitAction.CheckOrderInfo((str) =>
            {
                //{"validateMessagesShowId":"_validatorMessage","status":true,"httpstatus":200,"data":{"submitStatus":true},"messages":[],"validateMessages":{}}
                var returnString = translation.TranslationHtmlEx(str);
                if (returnString["messages"].Any())
                {
                    GetRandCodeImg();
                    DeterMineCall(() =>
                    {
                        lblState1.Text = returnString["messages"][0].ToString();
                        txtRandCode1.Text = "";
                        btnSubmit.Enabled = true;
                        txtRandCode1.Focus();

                        StopSubmit();
                        Application.DoEvents();

                    });
                    return;
                }
                if (returnString["data"]["errMsg"] != null && returnString["data"]["errMsg"].ToString() != "")
                {
                    GetRandCodeImg();
                    DetermineCall(() =>
                    {
                        MessageBox.Show(returnString["data"]["errMsg"].ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRandCode1.Text = "";
                        btnSubmit.Enabled = true;
                        txtRandCode1.Focus();

                        StopSubmit();
                        Application.DoEvents();
                    });
                    return;
                }
                if (str.Contains("取消次数过多"))
                {
                    GetRandCodeImg();
                    DetermineCall(() =>
                    {
                        MessageBox.Show("由于您取消次数过多，今日将不能继续受理您的订票请求！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRandCode1.Text = "";
                        btnSubmit.Enabled = true;
                        txtRandCode1.Focus();

                        StopSubmit();
                        Application.DoEvents();
                    });
                    return;
                }
                if (returnString["data"]["get608Msg"] != null)
                {
                    if (MessageBox.Show(returnString["data"]["get608Msg"].ToString(), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        GetRandCodeImg();
                        DeterMineCall(() =>
                        {
                            lblState1.Text = returnString["data"]["get608Msg"].ToString();
                            txtRandCode1.Text = "";
                            btnSubmit.Enabled = true;
                            txtRandCode1.Focus();

                            StopSubmit();
                            Application.DoEvents();
                        });
                    }
                    return;
                }

                DetermineCall(() =>
                    {
                        lblState1.Text = "正在查询订单余票信息，请稍候.........";
                    });
                Thread.Sleep(1000);
                ConfirmSubmit();
            }, _cookieContainer);
            //});
        }

        private void ConfirmSubmit()
        {
            //if (_trainData.SpecialSeatType!=null&&_trainData.SpecialSeatType.Keys.Count != 0)
            //{
            //    foreach (var key in _trainData.SpecialSeatType.Keys)
            //    {
            //        if (key.IndexOf(dgvPassenger.Rows[dgvPassenger.Rows.Count - 1].Cells[1].Value.ToString().Substring(0, 2)) > -1)
            //        {
            //            submitAction.QueryString = String.Format("&train_date={0}&train_no={1}&station={2}&seat={3}&from={4}&to={5}&ticket={6}", _trainData.Start_train_date, _trainData.Train_no, _trainData.Station_train_code, _trainData.SpecialSeatType[key], _trainData.From_station_telecode, _trainData.To_station_telecode, _tokenAndLeftTicket["LeftTicket"]);
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    submitAction.QueryString = String.Format("&train_date={0}&train_no={1}&station={2}&seat={3}&from={4}&to={5}&ticket={6}", _trainData.Start_train_date, _trainData.Train_no, _trainData.Station_train_code, DatasList.SeatType[dgvPassenger.Rows[dgvPassenger.Rows.Count - 1].Cells[1].Value.ToString()], _trainData.From_station_telecode, _trainData.To_station_telecode, _tokenAndLeftTicket["LeftTicket"]);
            //}

            submitAction.PostData = getPostData.GetSubmitOrderPostData(_trainData, _tokenAndLeftTicket);
            submitAction.GetQueueCount((callback) =>
            {
                var returnString = translation.TranslationHtmlEx(callback);
                //var obj = returnString["data"] as JavaScriptObject;
                _tokenAndLeftTicket["leftTicket"] = returnString["data"]["ticket"] ?? _tokenAndLeftTicket["leftTicket"];
                if (returnString["data"]["isRelogin"] != null && returnString["data"]["isRelogin"].ToString() == "Y")
                {
                    MessageBox.Show("系统提示,需要重新登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "data\\" + _user + "\\usrCookie.cfg"))
                        System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "data\\" + _user + "\\usrCookie.cfg");
                    //System.Diagnostics.Process.GetCurrentProcess().Kill();
                    return;
                }
                if (returnString["messages"].Any())
                {
                    GetRandCodeImg();
                    DeterMineCall(() =>
                    {
                        lblState1.Text = returnString["messages"][0].ToString();
                        Application.DoEvents();
                        txtRandCode1.Text = "";
                        btnSubmit.Enabled = true;
                        txtRandCode1.Focus();
                    });
                    return;
                }
                DetermineCall(() =>
                {
                    lblState1.Text = string.Format("当前排队人数:{0},正在下单，请稍候.........", returnString["data"]["countT"] == null ? "" : returnString["data"]["countT"].ToString());
                });
                Thread.Sleep(500);
                Submit();
            }, _cookieContainer);
        }

        private void Submit()
        {
            DetermineCall(() =>
            {
                lblState1.Text = "正在提交订单……";
            });
            //这里可以重试

            submitAction.PostData = getPostData.GetSingleForQueuePostData(orderData, _tokenAndLeftTicket);
            submitAction.ConfirmSingleForQueue((str) =>
            {
                //status=false?????
                var returnString = translation.TranslationHtmlEx(str);
                if (returnString["messages"].Any())
                {
                    GetRandCodeImg();
                    DeterMineCall(() =>
                    {
                        lblState1.Text = returnString["messages"][0].ToString();
                        Application.DoEvents();
                        txtRandCode1.Text = "";
                        btnSubmit.Enabled = true;
                        txtRandCode1.Focus();
                    });
                    return;
                }
                if (returnString["data"]["errMsg"] != null && returnString["data"]["errMsg"].ToString() != "")
                {
                    GetRandCodeImg();
                    DeterMineCall(() =>
                    {
                        lblState1.Text = returnString["data"]["errMsg"].ToString();
                        MessageBox.Show(returnString["data"]["errMsg"].ToString(), "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.DoEvents();
                        txtRandCode1.Text = "";
                        btnSubmit.Enabled = true;
                        txtRandCode1.Focus();
                    });
                    return;

                }
                DetermineCall(() =>
                {
                    lblState1.Text = "提交订单成功,正在占座……";
                    Thread.Sleep(500);
                    GetSeat();
                });
            }, _cookieContainer);
        }
        //获取坐席信息
        private void GetSeat()
        {
            submitAction.QueryString = getPostData.GetQueryOrderWaitTimeQueryString(_tokenAndLeftTicket);
            submitAction.BeginGetSeat((str) =>
            {
                var returnString = translation.TranslationHtmlEx(str);
                if (returnString["messages"].Any())
                {
                    //GetRandCodeImg();
                    DeterMineCall(() =>
                    {
                        lblState1.Text = returnString["messages"][0].ToString();
                        Application.DoEvents();
                        txtRandCode1.Text = "";
                        btnSubmit.Enabled = true;
                        txtRandCode1.Focus();

                        StopSubmit();
                        GetToken();
                    });
                    return;
                }

                if (returnString["data"]["msg"] != null && returnString["data"]["msg"].ToString() != "")
                {
                    //GetRandCodeImg();
                    DeterMineCall(() =>
                    {
                        MessageBox.Show(returnString["data"]["msg"].ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtRandCode1.Text = "";
                        btnSubmit.Enabled = true;
                        txtRandCode1.Focus();

                        StopSubmit();
                        GetToken();
                    });
                    return;
                }

                string waitCount = "";
                if (returnString["data"]["orderId"] != null && returnString["data"]["orderId"].ToString() != "")
                {
                    DetermineCall(() =>
                    {
                        _orderNo = returnString["data"]["orderId"].ToString();
                        if (_orderNo != "" && flag == 0)
                        {
                            flag++;
                            timer2.Enabled = false;
                            lblState1.Text = "订票成功~~！订单号为：" + _orderNo;
                            string path = System.IO.Directory.GetCurrentDirectory() + "\\Sound_Sucessed.wav";
                            if (System.IO.File.Exists(path))
                            {
                                sp = new System.Media.SoundPlayer(path);
                                sp.Play();
                            }
                            if (MessageBox.Show("订票成功，赶紧到网站上支付吧~~", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                if (chkOpenIE.Checked)
                                {
                                    OpenIE_API.OpenIE(_cookieContainer);
                                }
                                this.Close();
                            }
                        }
                    });
                }
                else
                {
                    DetermineCall(() =>
                    {
                        //waitCount = Regex.Match(result, "(?<=\"waitCount\":)[\\-]?\\d{1,}(?=,\")").ToString();
                        waitCount = returnString["data"]["waitCount"].ToString();
                        lblState1.Text = "据说前面还有 " + waitCount + " 个人，估计还需要等上 " + returnString["data"]["waitTime"] as string + " 秒";// Regex.Match(result, "(?<=\"waitTime\":)[\\-]?\\d{1,}(?=,\")").ToString() + " 秒";
                        Application.DoEvents();
                        timer2.Interval = 1000;//Convert.ToInt32(_submitSpan)
                        timer2.Start();
                    });
                }

            }, _cookieContainer);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            DetermineCall(() =>
            {
                btnStopSubmit.Enabled = true;
                if (_orderNo == "")
                {
                    GetSeat();
                    timer2.Start();
                }
                else
                {
                    btnStopSubmit.Enabled = false;
                    btnSubmit.Enabled = true;
                }
            });
        }

        private void btnStopSubmit_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            btnSubmit.Enabled = true;
            btnStopSubmit.Enabled = false;
        }

        private void numSafeTime_ValueChanged(object sender, EventArgs e)
        {
            ((TicketFrame)(parent.Parent.Parent.Parent)).SafeTime = Convert.ToInt16(numSafeTime.Value);
        }

        private void formSubmitOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sp != null)
                sp.Stop();
            if (t != null)
            {
                t.Stop();
                t.Dispose();
            }

            ((TicketMain)parent).AutoWorkFinished();
            //Action ac=(()=>{
            //formSelectTicket.FormThis.AutoWorkFinished();});
            //if (InvokeRequired)
            //    Invoke(ac);
            _Thread.Abort();
        }

        private void txtRandCode1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && btnSubmit.Enabled)
            {
                if (txtRandCode1.Text.Length == 4)
                    btnSubmit_Click(sender, e);
            }
        }

        private void txtRandCode1_TextChanged(object sender, EventArgs e)
        {
            //if (this.txtRandCode1.Text.Length == 4)
            //btnSubmit.PerformClick();
        }

        private void txtRandCode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
                btnSubmit.PerformClick();
        }
    }
}
