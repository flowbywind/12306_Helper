//#define CHECK
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using aNyoNe.GetInfoFrom12306;

namespace _12306_Helper
{
    public sealed class AutoBooker:IDisposable
    {
        int seed = 0;
        //bool msgFlag = true;
        public List<JsonTrainData> _trainData;
        public List<Nomal_Passengers> PassengerData;
        SelectTicketAction autoSelectAction = new SelectTicketAction();
        HTML_Translation autoTranslation = new HTML_Translation();
        public string LastSelectTime { get; set; }
        public CookieContainer cookieContainer = new CookieContainer();
        public bool SeatTypeFirst { get;set; }
        public List<string> SeatType = new List<string>();
        public List<string> TrainCode = new List<string>();
        //public DateTime WatchTime { get; set; }

        public Dictionary<int, DateTime> TurnDates = new Dictionary<int, DateTime>();
        public DateTime TrainDate { get; set; }
        public string QueryString { get; set; }

        public string from_station_telecode { get; set; }
        public string to_station_telecode{ get; set; }

        public string purpose_codes { get; set; }
        public string train_no{ get; set; }
        public string trainPassType{ get; set; }
        public string trainClass{ get; set; }
        public string start_time_str{ get; set; }

        public string includeStudent = "00";
        public string seatTypeAndNum = "";

        private object locker = new object();
        DateTime dt = DateTime.Now;
        public bool IsPauseWork = false;
        private TimeSpan _Period;
        private bool _IsWorking;
        public AutoResetEvent _NoticeEvent;
        private bool _IsPauseWorking = false;
        public Thread _Thread;
        public int lessCount{get;set;}
        private Control forms = null;

        public void Dispose()
        {
            if (_NoticeEvent != null)
            {
                _NoticeEvent.Dispose();
                //_NoticeEvent = null;
            }
            if (forms != null)
            {
                forms.Dispose();
                //forms = null;
            }
        }

        ~AutoBooker()
        {
           GC.Collect();
           GC.Collect();
        }

        public AutoBooker(Control c=null)
        {
            forms = c;
            _trainData = new List<JsonTrainData>();
            PassengerData = new List<Nomal_Passengers>();
            //WatchTime = Convert.ToDateTime("0001-01-01 00:00:00"); 
            _Period = TimeSpan.FromSeconds(6);
            lessCount = 1;
            _NoticeEvent = new AutoResetEvent(false);
        }

        public void Starts()
        {
            GetLeftTicket();
        }
        public void ThreadProcStart()
        {
            _IsWorking = true;
            _Thread = new Thread(ThreadProc) { IsBackground = true };
            seed = 0;
            _Thread.Start();
        }
        public int Period
        {
            get { return (int)_Period.TotalSeconds; }
            set
            {
                _Period = TimeSpan.FromSeconds(value);
                _NoticeEvent.Set();
            }
        }

        public bool PauseWorking
        {
            get { return _IsPauseWorking; }
            set
            {
                if (_IsPauseWorking != value)
                {
                    _IsPauseWorking = value;
                }
            }
        }

        public void ThreadProc()
        {
            while (_IsWorking)
            {
                if (!_IsPauseWorking)
                {
                    if ((DateTime.Now.Subtract(dt)).TotalSeconds > _Period.Seconds-1)
                    {
#if CHECK
                        Period= new Random().Next(1, 10) + 5;//随机查询间隔
#endif
                        Starts();
                        dt = DateTime.Now;
                    }
                }
                _NoticeEvent.WaitOne(_Period, false);
            }
        }

        private void GetLeftTicket()
        {
            lock (locker)
            {
                autoSelectAction.QueryString = GetQueryString();

                autoSelectAction.GetLeftTickets((resultList) =>
                {
                    if (resultList == "-10")
                    {
                        #region 备用解决方案(3)
                        this.IsPauseWork = true;
                        this._Thread.Abort();
                        MessageBox.Show("12306说你登录时间过长,需要重新登录,请手动退出或更换账号查询.", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        #endregion

                        #region 备用解决方案(1)
                        //formSelectTicket.cookieContainer = LocalCookie.ReadCookiesFromDisk(AppDomain.CurrentDomain.BaseDirectory + "usrCookie.cfg");
                        //if (msgFlag)
                        //{
                        //    if (MessageBox.Show("12306说你登录时间过长,需要重新登录\r\n\r\n选择\"是\",终止抢票线程,并手动点击查询页面的\"更换账号\"来重启登录\r\n选择\"否\",忽略此提示,等待恢复会自动重新获取数据(此提示以后不会出现)", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //    {
                        //        this.PauseWorking = true;
                        //        this._Thread.Abort();
                        //    }
                        //    else
                        //        msgFlag = false;
                        //}
                        //return;
                        #endregion
                    }

                    string htmlList = "";
                    if (resultList != null && resultList != string.Empty)
                    {
                        htmlList = resultList;
                        autoTranslation.TranslationJson(htmlList, (listSource) =>
                        {
                            LastSelectTime = DateTime.Now.ToLongTimeString();
                            _trainData = listSource;
                            DeleteFormSelectTicket(() =>
                            {
                                if (forms != null) { ((TicketMain)forms).DgvDataBind(_trainData); }
                                //else
                                //    formSelectTicket.FormThis.DgvDataBind(_trainData);
                            });
                            BeginFilter();
                        });
                    }
                }, (expires) =>
                {
                    DeleteFormSelectTicket(() =>
                    {
                        if (forms != null) { ((TicketMain)forms).UpdateCacheExpires(expires); }
                        //else
                        //    formSelectTicket.FormThis.UpdateCacheExpires(expires);
                    });
                }, cookieContainer);
            }
        }

        private void BeginFilter()
        {
            if (SeatTypeFirst)
                GetTrainInfoBySeatType();
            else
                GetTrainInfoByTrainCode();
        }

        private string GetQueryString()
        {
            if (TurnDates != null && TurnDates.Keys.Count != 0)
            {
                string str = "";
                String.Format("leftTicketDTO.train_date={0}&leftTicketDTO.from_station={1}&leftTicketDTO.to_station={2}&purpose_codes={3}",
                                    TrainDate.ToString("yyyy-MM-dd"), from_station_telecode, to_station_telecode, purpose_codes);
                lock (locker)
                {
                    if (forms != null)
                    { ((TicketMain)forms).UpdateSelectDate(TurnDates[seed]); }
                    //else
                    //    formSelectTicket.FormThis.UpdateSelectDate(TurnDates[seed]);
                    seed++;
                }
                if (seed == TurnDates.Count)
                    seed = 0;
                return str;
            }
            else
            {
                return String.Format("leftTicketDTO.train_date={0}&leftTicketDTO.from_station={1}&leftTicketDTO.to_station={2}&purpose_codes={3}",
                                    TrainDate.ToString("yyyy-MM-dd"), from_station_telecode, to_station_telecode, purpose_codes);
            }   
        }
        private string GetDateTime(string date)
        {
            string newDate = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2);
            DateTime tmpDateTime = Convert.ToDateTime(newDate);
            string fmtDate = "ddd MMM d HH:mm:ss 'UTC'zz'00' yyyy";
            System.Globalization.CultureInfo ciDate = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            //将C#时间转换成JS时间字符串  
            string JSstring = tmpDateTime.ToString(fmtDate, ciDate);
            return JSstring;
        }
        private void GetTrainInfoBySeatType()
        {
            foreach (var obj in SeatType)
            {
                if (!_IsPauseWorking)
                {
                    foreach (JsonTrainData train in _trainData)
                    {
                        if (!_IsPauseWorking)
                        {
                            if (train.QueryLeftNewDto.SeatOwener.ContainsKey(obj))
                            {
                                if (TrainCode.Contains(train.QueryLeftNewDto.Station_train_code) && train.QueryLeftNewDto.CanWebBuy == "Y" && train.QueryLeftNewDto.SeatOwener.Count > 0 && Convert.ToInt32(train.QueryLeftNewDto.SeatOwener[obj]) >= lessCount)
                                {
                                    //formSelectTicket.FormThis._IsAutoWork = false;
                                    _IsPauseWorking = true;
                                    var data = train;
                                    //data.QueryLeftNewDto.Train_date = TrainDate.ToString("yyyy-MM-dd");
                                    DeleteFormSelectTicket(() =>
                                    {
                                        if (forms != null)
                                        {
                                            ((TicketMain)forms).RunBook(data.QueryLeftNewDto, obj);
                                            ((TicketMain)forms).AutoWorkFinished();
                                        }
                                        //else
                                        //{
                                        //    formSelectTicket.FormThis.RunBook(data.QueryLeftNewDto, obj);
                                        //    formSelectTicket.FormThis.AutoWorkFinished();
                                        //}
                                    });
                                    //_IsPauseWorking = false;
                                    //string postData = GetPostDataString(data);
                                    //var form = new formSubmitOrder(postData, data, PassengerData, TrainDate.ToString("yyyy-MM-dd"), cookieContainer, obj.ToString());
                                    //form.ShowDialog();
                                }
                            }
                        }
                    }
                }
            }

        }
        private void GetTrainInfoByTrainCode()
        {
            foreach (JsonTrainData train in _trainData)
            {
                if (!_IsPauseWorking)
                {
                    if (TrainCode.Contains(train.QueryLeftNewDto.Station_train_code) && train.QueryLeftNewDto.CanWebBuy == "Y")
                    {
                        foreach (var obj in SeatType)
                        {
                            if (!_IsPauseWorking)
                            {
                                if (train.QueryLeftNewDto.SeatOwener.ContainsKey(obj) && Convert.ToInt32(train.QueryLeftNewDto.SeatOwener[obj]) >= lessCount)
                                {
                                    //formSelectTicket.FormThis._IsAutoWork = false;
                                    _IsPauseWorking = true;
                                    var data = train;
                                    //data.QueryLeftNewDto.Train_date = TrainDate.ToString("yyyy-MM-dd");
                                    DeleteFormSelectTicket(() =>
                                    {
                                        if (forms != null)
                                        {
                                            ((TicketMain)forms).RunBook(data.QueryLeftNewDto, obj);
                                            ((TicketMain)forms).AutoWorkFinished();
                                        }
                                        //else
                                        //{
                                        //    formSelectTicket.FormThis.RunBook(data.QueryLeftNewDto, obj);
                                        //    formSelectTicket.FormThis.AutoWorkFinished();
                                        //}
                                    });
                                    //_IsPauseWorking = false;
                                    //string postData = GetPostDataString(data);
                                    //var form = new formSubmitOrder(postData, data, PassengerData, TrainDate.ToString("yyyy-MM-dd"), cookieContainer, obj.ToString());
                                    //form.ShowDialog();
                                }
                            }
                        }
                    }
                }
            }

        }

        private void DeleteFormSelectTicket(MethodInvoker method)
        {
            if (forms != null)
            {
                if (((TicketMain)forms).InvokeRequired)
                {
                    ((TicketMain)forms).Invoke(method);
                }
                else
                    method();
            }
            else
                if (formSelectTicket.FormThis.InvokeRequired && formSelectTicket.FormThis != null)
                {
                    formSelectTicket.FormThis.Invoke(method);
                }
                else
                    method();
        }
    }
}
