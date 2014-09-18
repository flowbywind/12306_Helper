using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

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
        
        //int queueFlag = 0;
        string ticketPriceStr = "";
        IList<string> ticketsPrice = new List<string>();
        System.Media.SoundPlayer sp=null;
        Hashtable _ticketPrice = new Hashtable();
        Hashtable _tokenAndLeftTicket = new Hashtable();
        FormShowStyle formStyle = new FormShowStyle();
        CookieContainer _cookieContainer = new CookieContainer();
        SubmitOrderAction submitAction = new SubmitOrderAction();
        HTML_Translation translation = new HTML_Translation();
        SubmitDataOperation getPostData = new SubmitDataOperation();
        TrainData _trainData = null;
        List<PassengersData> _passengers = null;
        Thread _Thread;
        public formSubmitOrder(string postData,TrainData trainInfo, List<PassengersData> passengers, string trainDate, CookieContainer cookie,string defaultseat="")
        {
            InitializeComponent();
            formStyle.MakeShadow(this.Handle);
            this._postData = postData;
            this._trainData = trainInfo;
            this._cookieContainer = cookie;
            this._passengers = passengers;
            this._trainDate = trainDate;
            this._defaultSeat = defaultseat;
            if (this._defaultSeat != "")
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
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }
        private void formSubmitOrder_Load(object sender, EventArgs e)
        {
            DeterMineCall(() =>
            {
                lblTrainNoInfo.Text = _trainData.From_station_name
                                    + " ——→ " + _trainData.To_station_name
                                    + "   车次：" + _trainData.Station_train_code
                                    + "   发车日期：" + _trainDate + " " + _trainData.Start_time
                                    + "   历时：" + _trainData.Cost_time;

                _Thread = new System.Threading.Thread(new System.Threading.ThreadStart(() =>
                {
                    DeterMineCall(() =>
                    {
                        GetSeatTypes();

                        lblState1.Text = "正在加载联系人...";
                        Application.DoEvents();

                        fpPrice.Controls.Clear();
                        for (int i = 1; i < flplPassengers.Controls.Count; i++)
                        {
                            flplPassengers.Controls.RemoveAt(i);
                        }
                        //加载坐席
                        lblState1.Text = "正在加载坐席...";
                        Application.DoEvents();
                        LoadPassengers();
                        lblState1.Text = "正在加载验证码...";
                        Application.DoEvents();
                        GetRandCodeImg();
                        lblState1.Text = "正在获取Token...";
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
        private void GetTicketPrice()
        {
            DetermineCall(() =>
            {
                ticketsPrice.Clear();
                if (ticketPriceStr != null)
                {
                    ticketPriceStr = ticketPriceStr.Split(new string[] { "<tr" }, StringSplitOptions.RemoveEmptyEntries)[2].Replace("<td>", "").Replace("</tr>", "").Replace("\r\n", "").Replace(">", "").Replace("\t", "");
                    string[] tmp = ticketPriceStr.Split(new string[] { "</td" }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        ticketsPrice.Add(tmp[i].Split(')')[0]);
                    }
                }
                GetLeftTicketCount();
            });
        }
        //加载余票信息
        private void GetLeftTicketCount()
        {
            DeterMineCall(() =>
            {
                Hashtable tmpTable = new Hashtable();
                string tmpStr="";
                string strSeat = "";
                foreach (var seat in _trainData.SeatOwener.Keys)
                {
                    strSeat = seat.ToString();
                    try
                    {
                        foreach (var v in ticketsPrice)
                        {
                            if (!tmpTable.ContainsValue(v.Split('(')[1]))
                                tmpTable.Add(v.Split('(')[0], v.Split('(')[1]);

                            if (v.StartsWith(seat.ToString().Substring(0, 2)))
                            {
                                strSeat = strSeat + "(" + v.Split('(')[1] + ")";
                                break;
                            }
                        }
                    }
                    catch { }
                    Label lbl = new Label();
                    try
                    {
                        if (tmpStr.IndexOf(strSeat.Split('(')[1]) > -1)
                        {
                        
                                ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Remove("无座");

                        }
                    }
                    catch { }
                    tmpStr += strSeat;
                    lbl.ForeColor = Color.Blue;
                    lbl.Text = strSeat + ":" + _trainData.SeatOwener[seat] + "张";
                    lbl.Visible = true;
                    lbl.AutoSize = true;
                    fpPrice.Controls.Add(lbl);
                }
            });
        }

        //获取Token
        private void GetToken()
        {
            submitAction.PostData = _postData;
            submitAction.GetTokenWithSubmitPage((str) =>
            {
                if (str == "获取信息失败" || str == string.Empty)
                { MessageBox.Show("信息获取失败，请重试", "获取Token", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (str.IndexOf("维护时间") > -1)
                {
                    MessageBox.Show(this, "系统维护，不能订票了", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    return;
                }
                if (str.IndexOf("未完成订单")>-1)
                {
                    DetermineCall(()=>
                    {
                        MessageBox.Show(this, "您还有未完成订单，请到订单查询中取消或到网页进行支付。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    });
                    return;
                }
                ticketPriceStr = StringHelper.FindString(ref str,"<table width=\"100%\" border=\"0\" cellspacing=\"1\" cellpadding=\"0\"","</table>");
                DeterMineCall(()=>{
                    //获取余票信息
                    DeterMineCall(()=>
                    GetTicketPrice());
                
                    _tokenAndLeftTicket["Token"] = System.Text.RegularExpressions.Regex.Match(str, "(?<=org.apache.struts.taglib.html.TOKEN\" value=\")[0-9abcdefABCDEF]{32}").ToString();
                    _tokenAndLeftTicket["LeftTicket"] = System.Text.RegularExpressions.Regex.Match(str, "(?<=leftTicketStr\" id=\"left_ticket\"\r\n\tvalue=\")[0-9A-Z]{10,}(?=\" />)").ToString();
                    
                    //开启安全期倒数
                    this.numSafeTime.Value = formSelectTicket.FormThis.SafeTime;
                    _timeSpan = this.numSafeTime.Value < 4 ? 4 : this.numSafeTime.Value;
                    _submitSpan = numSubmitSpan.Value * 1000;
                    lblState1.Text = "距离安全期还有 " + _timeSpan.ToString() + " 秒";
                    timer1.Start(); 
                });
            }, _cookieContainer);
        }

        //获取坐席类别
        private void GetSeatTypes()
        {
            ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Clear();
            foreach (var seat in _trainData.SeatOwener.Keys)
            {
                ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Add(seat.ToString());
            }
        }

        //获取并添加联系人信息
        private void LoadPassengers()
        {
            int j = 0;
            foreach (PassengersData passenger in _passengers)
            {
                CheckBox chk = new CheckBox();
                chk.AutoSize = true;
                chk.Tag = passenger;
                chk.Name = "checkbox" + j.ToString();
                chk.TabIndex = _passengers.IndexOf(passenger);
                chk.Text = passenger.Passenger_name;
                chk.Checked = false;
                chk.FlatStyle = FlatStyle.Flat;
                flplPassengers.Controls.Add(chk);
                if (passenger.Checked)
                {
                    chk.Checked = true;
                    int index = dgvPassenger.Rows.Add();
                    dgvPassenger.Rows[index].Cells["xingming"].Value = chk.Text;
                    dgvPassenger.Rows[index].Cells["xingming"].Tag = chk.Tag;//存储乘车人信息
                    dgvPassenger.Rows[index].Cells["zhengjianhao"].Value = ((PassengersData)chk.Tag).Passenger_id_no;
                    dgvPassenger.Rows[index].Cells["shoujihao"].Value = ((PassengersData)chk.Tag).Mobile_no;
                    if (_defaultSeat != "")
                    {
                        dgvPassenger.Rows[index].Cells["xibie"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items[((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.IndexOf(_defaultSeat)].ToString();
                    }
                    else
                        dgvPassenger.Rows[index].Cells["xibie"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items[((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Count - 1].ToString();
                    //有其它座位可以选择的时候不选择无座为默认坐席
                    if (dgvPassenger.Rows[index].Cells["xibie"].Value.ToString() == "无座" && ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Count>1)
                    {
                        dgvPassenger.Rows[index].Cells["xibie"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items[((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Count-2].ToString();
                    }
                    dgvPassenger.Rows[index].Cells["zhengjian"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[3]).Items[0].ToString();
                    dgvPassenger.Rows[index].Cells["zhengjian"].Tag = chk.Name;
                    dgvPassenger.Rows[index].Cells["piaozhong"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[2]).Items[0].ToString();
                    dgvPassenger.Refresh();
                }
                chk.CheckedChanged += (ss, ee) =>
                {
                    if (chk.Checked == true)
                    {
                        if (dgvPassenger.Rows.Count == 5) { MessageBox.Show("已经是订票的最大人数", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information); chk.Checked = false; return; }
                        int index = dgvPassenger.Rows.Add();
                        dgvPassenger.Rows[index].Cells["xingming"].Value = chk.Text;
                        dgvPassenger.Rows[index].Cells["xingming"].Tag = chk.Tag;//存储乘车人信息
                        dgvPassenger.Rows[index].Cells["zhengjianhao"].Value = ((PassengersData)chk.Tag).Passenger_id_no;
                        dgvPassenger.Rows[index].Cells["shoujihao"].Value = ((PassengersData)chk.Tag).Mobile_no;
                        dgvPassenger.Rows[index].Cells["xibie"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items[((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Count - 1].ToString();
                        //有其它座位可以选择的时候不选择无座为默认坐席
                        if (dgvPassenger.Rows[index].Cells["xibie"].Value.ToString() == "无座" && ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Count > 1)
                        {
                            dgvPassenger.Rows[index].Cells["xibie"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items[((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Count - 2].ToString();
                        }
                        dgvPassenger.Rows[index].Cells["zhengjian"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[3]).Items[0].ToString();
                        dgvPassenger.Rows[index].Cells["zhengjian"].Tag = chk.Name;
                        dgvPassenger.Rows[index].Cells["piaozhong"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[2]).Items[0].ToString();
                        dgvPassenger.Refresh();
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dgvPassenger.Rows)
                        {
                            if (((PassengersData)chk.Tag).Passenger_id_no == row.Cells["zhengjianhao"].Value.ToString())
                            {
                                dgvPassenger.Rows.Remove(row);
                            }
                        }
                    }
                };
                j++;
            }
        }

        //获取验证码
        private void GetRandCodeImg()
        {
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
            },_cookieContainer);
        }
        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(192, 192, 255);
        }

        private void lblTop_MouseDown(object sender, MouseEventArgs e)
        {
            formStyle.ShowForm(this.Handle, 500);
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

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(128, 128, 255);
        }

        private void lblMini_MouseLeave(object sender, EventArgs e)
        {
            lblMini.BackColor = Color.FromArgb(128, 128, 255);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            formStyle.HideForm(this.Handle, 500);
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            DetermineCall(() =>
            {
                //if (_timeSpan == 1) { txtRandCode1.Text = "test"; btnSubmit_Click(sender, e); }
                _timeSpan--;
                if (_timeSpan == 0)
                {
                    btnSubmit.Enabled = true;
                    timer1.Stop();
                    lblState1.Text = "安全期已过，可以提交订单了。";
                    return;
                }
                else
                    lblState1.Text = "距离安全期还有 " + _timeSpan.ToString() + " 秒";
            });
        }

        private void randCode1_Click(object sender, EventArgs e)
        {
            GetRandCodeImg();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //queueFlag = 0;
            int itemCount = dgvPassenger.Rows.Count;
            if (itemCount > 0)
            {
                if (txtRandCode1.Text.Length != 4) 
                { 
                    lblState1.Text = "请输入正确的验证码!"; 
                    return;
                }
                btnSubmit.Enabled = false; 
                getPostData.OData = new OrderData(_trainData);
                getPostData.PassengerCount = itemCount;
                getPostData.RandCode = txtRandCode1.Text;
                getPostData.DgvPassenger = this.dgvPassenger;
                getPostData.LeftTicket = _tokenAndLeftTicket["LeftTicket"].ToString();
                getPostData.Token = _tokenAndLeftTicket["Token"].ToString();
                ConfirmOrder();
            }
            else
            {
                lblState1.Text = "请选择联系人！"; 
            }
        }
        private void DetermineCall(MethodInvoker method)
        {
            if (InvokeRequired)
                Invoke(method);
            else
                method();
        }

        private void StopSubmit(string info="")
        {
            DetermineCall(() => {
                timer2.Enabled = false;
                btnSubmit.Enabled = true;
                btnStopSubmit.Enabled = false;
                GetRandCodeImg();
                txtRandCode1.Text = "";
                lblState1.Text = info;
            });
        }
        private void ConfirmOrder()
        {
            getPostData.GetOrderPostData((data) =>
            {
                if (_trainData.SpecialSeatType != null && _trainData.SpecialSeatType.Count != 0)
                {   //适应一等软座和二等软座的代码
                    data = data.Replace("passengerTickets=M", "passengerTickets=7").Replace("passengerTickets=O", "passengerTickets=8");
                }
                submitAction.PostData = data;
                submitAction.QueryString = "&rand=" + txtRandCode1.Text;
                submitAction.ConfirmOrder((str) =>
                {
                    if (str == "获取信息失败" || str == string.Empty)
                    { MessageBox.Show("信息获取失败，请重试", "订单确认", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                    var result = translation.TranslationHtml(str);
                    if (result["checkHuimd"] as string == "N")
                    {
                        DetermineCall(() =>
                        {
                            MessageBox.Show(this, result["msg"] as string, "确认订单 Huimd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            StopSubmit();
                            return;
                        });
                    }
                    else if (result["check608"] as string == "N")
                    {
                        DetermineCall(() =>
                        {
                            MessageBox.Show(this, "本车为实名制列车，实行一日一车一证一票制！", "确认订单 608", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            StopSubmit();
                            return;
                        });
                    }
                    else if (result["errMsg"] as string != "Y")
                    {
                        if ((result["errMsg"] as string).Contains("验证码输入错误"))
                        {
                            decimal i = _submitSpan;
                            while (i-- > 0)
                            {
                                DetermineCall(() =>
                                {
                                    lblState1.Text = string.Format("检测订单失败,请勿关闭窗口,{0}秒后将重新提交，请稍候.........", i);
                                    //btnStopSubmit.Enabled = true;
                                });
                                Thread.Sleep(1000);
                            }
                            ConfirmOrder();
                        }
                        else if ((result["errMsg"] as string).Contains("输入的验证码不正确"))
                        {
                            DetermineCall(() =>
                            {
                                StopSubmit("输入的验证码不正确,请重试.........");
                                return;
                            });
                        }
                        else
                        {
                            DetermineCall(() =>
                            {
                                if (!string.IsNullOrEmpty(result["errMsg"] as string))
                                {
                                    MessageBox.Show(this, result["errMsg"] as string, "确认订单 msg!=Y", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    StopSubmit();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show(this, "铁道部在做怪，让你必需重新登陆了。", "提示 TD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    StopSubmit();
                                    return;
                                }
                            });
                        }
                    }
                    else
                    {
                        DetermineCall(() =>
                        {
                            lblState1.Text = "正在查询订单余票信息，请稍候.........";
                        });
                        Thread.Sleep(100);
                        ConfirmSubmit();
                    }
                }, _cookieContainer);
            });
        }

        private void ConfirmSubmit()
        {
            if (_trainData.SpecialSeatType!=null&&_trainData.SpecialSeatType.Keys.Count != 0)
            {
                foreach (var key in _trainData.SpecialSeatType.Keys)
                {
                    if (key.IndexOf(dgvPassenger.Rows[dgvPassenger.Rows.Count - 1].Cells[1].Value.ToString().Substring(0, 2)) > -1)
                    {
                        submitAction.QueryString = "&train_date=" + _trainData.Train_date + "&train_no=" + _trainData.Trainno4 + "&station=" + _trainData.Station_train_code + "&seat=" + _trainData.SpecialSeatType[key] + "&from=" + _trainData.From_station_telecode + "&to=" + _trainData.To_station_telecode + "&ticket=" + _tokenAndLeftTicket["LeftTicket"].ToString();
                        break;
                    }
                }
            }
            else
            {
                submitAction.QueryString = "&train_date=" + _trainData.Train_date + "&train_no=" + _trainData.Trainno4 + "&station=" + _trainData.Station_train_code + "&seat=" + DatasList.SeatType[dgvPassenger.Rows[dgvPassenger.Rows.Count - 1].Cells[1].Value.ToString()] + "&from=" + _trainData.From_station_telecode + "&to=" + _trainData.To_station_telecode + "&ticket=" + _tokenAndLeftTicket["LeftTicket"].ToString();
            }
            submitAction.SubmitOrder((callback) =>
            {
                if (callback == "获取信息失败" || callback == string.Empty)
                { MessageBox.Show("信息获取失败，请重试", "提交订单确认", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                var passengers = translation.TranslationHtml(callback) ;
                DetermineCall(() =>
                {
                    lblState1.Text = string.Format("当前排队人数:{0},正在下单，请稍候.........", passengers["countT"] as string);
                });
                Thread.Sleep(800);
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
            submitAction.ConfirmOrderQueue((str)=>{
                if (str == "获取信息失败" || str == string.Empty)
                { MessageBox.Show("信息获取失败，请重试", "提交订单", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (str != "")
                {
                    var data = translation.TranslationHtml(str);
                    string tmpstr = data["errMsg"] as string;
                    if (tmpstr != "Y")
                    {
                        if (tmpstr.IndexOf("排队") > -1)
                        {
                            DetermineCall(() =>
                            {
                                lblState1.Text = "当前排队的人数大于余票的人数，正在尝试重新进入队列。";
                                Application.DoEvents();
                                btnStopSubmit.Enabled = true;
                                Thread.Sleep(1000);
                                ConfirmOrder();
                            });
                        }
                        else
                        {
                            DetermineCall(() =>
                            {
                                MessageBox.Show(this, tmpstr + "\n\r\n\r提示猜测：\n\r1.呐~如果出现的是“重复提交”的提示，可能是你之前的订单没有足够的票，系统还在提交的过程中哦,请骚等一会儿再提交试试~~\n\r2.如果是网络问题，那可能是12306现在真的很忙~~", "提交订单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                StopSubmit();
                            });
                        }
                    }
                    else
                    {
                        DetermineCall(() =>
                        {
                            lblState1.Text = "提交订单成功,正在占座……";
                            GetSeat();
                            timer2.Interval = Convert.ToInt32(_submitSpan);
                            timer2.Start();
                        });
                    }
                }
                else
                {
                    DetermineCall(() =>
                    {
                        MessageBox.Show(this, "提交失败，请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        StopSubmit();
                    });
                }
            },_cookieContainer);
        }
        //获取坐席信息
        private void GetSeat()
        {
            submitAction.BeginGetSeat((str) =>
            {
                if (str == "获取信息失败" || str == string.Empty)
                { MessageBox.Show("信息获取失败，请重试", "获取坐席信息", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
                if (str!=""&&str.IndexOf("没有足够的票") > -1)
                {
                    DetermineCall(() =>
                    {
                        StopSubmit("订票失败,这事不赖我~~因为已经没有足够的票了");
                    });
                    return;
                }

                string result = str;
                string waitCount = "";

                if (Regex.Match(result, "(?<=\"waitCount\":)[\\-]?\\d{1,}(?=,\")").ToString() == "0")
                {
                    DetermineCall(() =>
                    {
                        _orderNo = Regex.Match(result, "(?<=\"orderId\":\")[A-Z]\\d{9}(?=\",\")").ToString();
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
                        waitCount = Regex.Match(result, "(?<=\"waitCount\":)[\\-]?\\d{1,}(?=,\")").ToString();
                        lblState1.Text = "据说前面还有 " + waitCount + " 个人，估计还需要等上 " + Regex.Match(result, "(?<=\"waitTime\":)[\\-]?\\d{1,}(?=,\")").ToString() + " 秒";
                        Application.DoEvents();
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
            formSelectTicket.FormThis.SafeTime = Convert.ToInt16(numSafeTime.Value);
        }

        private void formSubmitOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(sp!=null)
                sp.Stop();
            Action ac=(()=>{
            formSelectTicket.FormThis.AutoWorkFinished();});
            if (InvokeRequired)
                Invoke(ac);
            _Thread.Abort();
        }

        private void txtRandCode1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter&&btnSubmit.Enabled)
            {
                if (txtRandCode1.Text.Length == 4)
                    btnSubmit_Click(sender, e);
            }
        }
    }
}
