using _12306_Helper.Properties;
using aNyoNe.GetInfoFrom12306;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace _12306_Helper.Forms
{
    public partial class formAutoSubmitOrder : Form
    {
        private int flag = 0;
        string _defaultSeat = "";//默认坐席
        string _trainDate = "";
        string _orderNo = "";
        string _postData = "";
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

        private void DeterMineCall(MethodInvoker method)
        {
            if (!this.IsDisposed)
                if (InvokeRequired)
                    Invoke(method);
                else
                    method();
        }

        ~formAutoSubmitOrder()
        {
            GC.Collect();
            GC.Collect();
        }

        public formAutoSubmitOrder(OrderData_Otn  order, string user, string postData, QueryLeftNewDTO trainInfo, List<Nomal_Passengers> passengers, string trainDate, CookieContainer cookie, string title, string defaultseat = "", bool fl = false)
        {
            InitializeComponent();
            orderData = order;
            _user = user;
            this.Text += "   " + title;
            this._postData = postData;
            this._trainData = trainInfo;
            this._cookieContainer = cookie;
            this._passengers = passengers;
            this._trainDate = trainDate;
            this._defaultSeat = defaultseat;

            string path = System.IO.Directory.GetCurrentDirectory() + "\\Sound_GetTicket.wav";
            if (System.IO.File.Exists(path))
            {
                sp = new System.Media.SoundPlayer(path);
                sp.Play();
            }
            
        }

        private void formAutoSubmitOrder_Load(object sender, EventArgs e)
        {
            DeterMineCall(() =>
            {
                lblTrainNoInfo.Text = String.Format("{0} ——→ {1}   车次：{2}   发车日期：{3}   历时：{4}",
                    _trainData.From_station_name, _trainData.To_station_name,
                    _trainData.Station_train_code, _trainDate, _trainData.Lishi);

                _Thread = new Thread(new ThreadStart(() =>
                {
                    DeterMineCall(() =>
                    {
                        GetSeatTypes();
                        LoadPassengers();
                        AutoSubmitPage();
                    });
                }));
                _Thread.IsBackground = true;
                _Thread.Start();
            });
        }

        //获取Token
        private void AutoSubmitPage()
        {
            submitAction.PostData = _postData;
            submitAction.SubmitOrderRequestAsync((str) =>
            {
                var returnString = translation.TranslationHtmlEx(str);
                if (returnString["messages"].Any())
                {
                    if (str.Contains("未完成订单"))
                    {
                        MessageBox.Show("您有未处理订单！", "提醒", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(returnString["messages"].ToString(),"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        return;
                    }
                }
                if (returnString["data"]["submitStatus"].ToString() != "True")
                {
                    MessageBox.Show("订单验证失败~请重新提交", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var datas = returnString["data"]["result"].ToString().Split('#');

                _tokenAndLeftTicket["leftTicket"] = datas[2];
                _tokenAndLeftTicket["keyCheck"] = datas[1];
                _tokenAndLeftTicket["trainLocation"] = datas[0];
                _tokenAndLeftTicket["purposeCodes"] = orderData.Purpose_codes;

                ConfirGetQueueCountAsync();

            }, _cookieContainer);
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
            foreach (Nomal_Passengers passenger in _passengers.Where(x=>x.IsCheck).Select(x=>x).ToList<Nomal_Passengers>())
            {
                int index = dgvPassenger.Rows.Add();
                AddPassengerToGrid(passenger.Passenger_name,passenger,index,passenger.SeatCodeName);
            }
        }

        private void AddPassengerToGrid(string text,  Nomal_Passengers passenger, int index, string def)
        {
            dgvPassenger.Rows[index].Cells["xingming"].Value = text;
            dgvPassenger.Rows[index].Cells["xingming"].Tag = passenger;//存储乘车人信息
            dgvPassenger.Rows[index].Cells["zhengjianhao"].Value = passenger.Passenger_id_no;
            dgvPassenger.Rows[index].Cells["shoujihao"].Value = passenger.Mobile_no;
            if (def != "")
            {
                try
                {
                    dgvPassenger.Rows[index].Cells["xibie"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items[((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.IndexOf(def)].ToString();
                }
                catch {
                    dgvPassenger.Rows[index].Cells["xibie"].Value = ((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items[((DataGridViewComboBoxColumn)dgvPassenger.Columns[1]).Items.Count - 1].ToString();
                }
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

            dgvPassenger.Rows[index].Cells["piaozhong"].Value = passenger.TicketCodeName;

            dgvPassenger.Refresh();
        }

        //获取验证码
        private void GetRandCodeImg()
        {
            DeterMineCall(() =>
            {
                randCode1.Image = Resources.loading;
            });
            submitAction.QueryString = "module=login&rand=sjrand&" + new Random().NextDouble();
            submitAction.GetAsyncOrderRandCodeImg((bit) =>
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

        private void randCode1_Click(object sender, EventArgs e)
        {
            GetRandCodeImg();
        }

        private void DetermineCall(MethodInvoker method)
        {
            if (InvokeRequired && !this.IsDisposed)
                Invoke(method);
            else
                method();
        }

        private void ConfirGetQueueCountAsync()
        {
            submitAction.PostData = getPostData.GetAsyncSubmitOrderPostData(_trainData, _tokenAndLeftTicket);
            submitAction.GetQueueCountAsync((callback) =>
            {
                var returnString = translation.TranslationHtmlEx(callback);
                if (returnString["messages"].Any())
                {
                    DeterMineCall(() =>
                    {
                        lblState1.Text = returnString["messages"][0].ToString();
                        Application.DoEvents();
                        txtRandCode1.Text = "";
                        txtRandCode1.Focus();
                    });
                    return;
                }
                DetermineCall(() =>
                {
                    lblState1.Text = string.Format("当前排队人数:{0},正在下单，请稍候.........", returnString["data"]["countT"] == null ? "" : returnString["data"]["countT"].ToString());
                });

                Thread.Sleep(100);

                DeterMineCall(() =>
                {
                    randCode1.Image = Resources.loading;
                });
                submitAction.QueryString = "module=login&rand=sjrand&" + new Random().NextDouble() ;
                submitAction.GetAsyncOrderRandCodeImg((bit) =>
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

                
            }, _cookieContainer);
        }

        private void CheckRandCodeAsync()
        {
            submitAction.CheckRandCodeAsync((str) => {
                var returnString = translation.TranslationHtmlEx(str);
                if (returnString["data"]!= null && returnString["data"].ToString() == "Y")
                {
                    orderData.RandCode = txtRandCode1.Text;
                    ConfirmSingleForQueueAsync();
                }
                else if (str.IndexOf("isRelogin")>-1&&returnString["data"]["isRelogin"].ToString() == "Y")
                {
                    MessageBox.Show("系统提示,需要重新登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "data\\" + _user + "\\usrCookie.cfg"))
                        System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + "data\\" + _user + "\\usrCookie.cfg");
                    //System.Diagnostics.Process.GetCurrentProcess().Kill();
                    return;
                }
                else   
                {
                    DetermineCall(() => {
                        lblState1.Text = returnString["messages"].ToString()=="[]"?"验证码错误":returnString["messages"][0].ToString();
                        Application.DoEvents();
                    });
                }
            }, _cookieContainer);
        }

        private void ConfirmSingleForQueueAsync()
        {
            DetermineCall(() =>
            {
                lblState1.Text = "正在提交订单……";
            });
            //这里可以重试

            submitAction.PostData = getPostData.GetSingleForQueueAsyncPostData(orderData, _tokenAndLeftTicket);
            submitAction.ConfirmSingleForQueueAsync((str) =>
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
                        txtRandCode1.Focus();
                        AutoSubmitPage();
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
                        txtRandCode1.Focus();
                        AutoSubmitPage();
                    });
                    return;

                }

                if (returnString["data"]["submitStatus"] != null && returnString["data"]["submitStatus"].ToString() == "True")
                {
                    DetermineCall(() =>
                    {
                        lblState1.Text = "提交订单成功,正在占座……";
                        Thread.Sleep(500);
                        GetSeat();
                    });
                }
                else
                {
                    MessageBox.Show("订票失败~", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }, _cookieContainer);
        }
        //获取坐席信息
        private void GetSeat()
        {
            submitAction.QueryString = getPostData.GetQueryOrderWaitTimeQueryString();
            submitAction.GetSeatAsync((str) =>
            {
                var returnString = translation.TranslationHtmlEx(str);
                if (returnString["messages"].Any())
                {
                    GetRandCodeImg();
                    DeterMineCall(() =>
                    {
                        lblState1.Text = returnString["messages"][0].ToString();
                        Application.DoEvents();
                        txtRandCode1.Text = "";
                        txtRandCode1.Focus();
                        timer2.Stop();
                        AutoSubmitPage();
                    });
                    return;
                }

                if (returnString["data"]["msg"] != null && returnString["data"]["msg"].ToString() != "")
                {
                    GetRandCodeImg();
                    DeterMineCall(() =>
                    {
                        MessageBox.Show(returnString["data"]["msg"].ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblState1.Text = returnString["data"]["msg"].ToString();
                        txtRandCode1.Text = "";
                        txtRandCode1.Focus();
                        timer2.Stop();
                        AutoSubmitPage();
                    });
                    return;
                }

                string waitCount = "";
                if (returnString["data"]["orderId"] != null && returnString["data"]["orderId"].ToString() != "" && returnString["data"]["orderId"].ToString()!="null")
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
                            if (MessageBox.Show(string.Format("订票成功，赶紧到网站上支付吧~~订单号{0}", _orderNo), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                OpenIE_API.OpenIE(_cookieContainer);
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
                if (_orderNo == "" || _orderNo != "null")
                {
                    GetSeat();
                    timer2.Start();
                }
                else
                {
                    if (MessageBox.Show(string.Format("订票成功，赶紧到网站上支付吧~~订单号{0}",_orderNo), "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        OpenIE_API.OpenIE(_cookieContainer);
                        this.Close();
                    }
                }
            });
        }

        private void txtRandCode1_TextChanged_1(object sender, EventArgs e)
        {
            if (this.txtRandCode1.Text.Length == 4)
            {
                submitAction.PostData = string.Format("randCode={0}&rand=sjrand&_json_att=",txtRandCode1.Text);
                CheckRandCodeAsync();
            }
        }

        private void txtRandCode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                CheckRandCodeAsync();
        }
    }
}
