using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.ComponentModel;
using System.Collections;
using System.Threading;
using System.Diagnostics;

namespace _12306_Helper
{
    public class AutoBooker
    {
        int seed = 0;
        public List<TrainData> _trainData;
        public List<PassengersData> PassengerData;
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

        public AutoBooker()
        {
            _trainData=new List<TrainData>();
            PassengerData = new List<PassengersData>();
            //WatchTime = Convert.ToDateTime("0001-01-01 00:00:00"); 
            _Period = TimeSpan.FromSeconds(6);
            _NoticeEvent = new AutoResetEvent(false);
        }

        public void Starts()
        {
            GetLeftTicket();
        }
        public void ThreadProcStart()
        {
            _IsWorking = true;
            _Thread = new Thread(ThreadProc);
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
                    string htmlList = "";
                    if (resultList != null && resultList != string.Empty)
                    {
                        htmlList = resultList;
                        autoTranslation.TranslationHtml(htmlList, (listSource) =>
                        {
                            LastSelectTime = DateTime.Now.ToLongTimeString();
                            _trainData = listSource;
                            DeleteFormSelectTicket(() =>
                            {
                                formSelectTicket.FormThis.DgvDataBind(_trainData);
                            });
                            BeginFilter();
                        });
                    }
                }, (expires) =>
                {
                    DeleteFormSelectTicket(() =>
                    {
                        formSelectTicket.FormThis.UpdateCacheExpires(expires);
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
                str = string.Format("&orderRequest.train_date={0}&orderRequest.from_station_telecode={1}&orderRequest.to_station_telecode={2}&orderRequest.train_no={3}&trainPassType={4}&trainClass={5}&includeStudent=00&seatTypeAndNum=&orderRequest.start_time_str={6}",
                                    TurnDates[seed].ToString("yyyy-MM-dd"), from_station_telecode, to_station_telecode, train_no, trainPassType, trainClass, start_time_str);
                lock (locker)
                {
                    formSelectTicket.FormThis.UpdateSelectDate(TurnDates[seed]);
                    seed++;
                }
                if (seed == TurnDates.Count)
                    seed = 0;
                return str;
            }
            else
            {
                return string.Format("&orderRequest.train_date={0}&orderRequest.from_station_telecode={1}&orderRequest.to_station_telecode={2}&orderRequest.train_no={3}&trainPassType={4}&trainClass={5}&includeStudent=00&seatTypeAndNum=&orderRequest.start_time_str={6}",
                                    TrainDate.ToString("yyyy-MM-dd"), from_station_telecode, to_station_telecode, train_no, trainPassType, trainClass, start_time_str);
            }   
        }

        private void GetTrainInfoBySeatType()
        {
            foreach (var obj in SeatType)
            {
                if (!_IsPauseWorking)
                {
                    foreach (TrainData train in _trainData)
                    {
                        if (!_IsPauseWorking)
                        {
                            if (train.SeatOwener.ContainsKey(obj))
                            {
                                if (TrainCode.Contains(train.Station_train_code) && train.Bookable && train.SeatOwener.Count > 0)
                                {
                                    //formSelectTicket.FormThis._IsAutoWork = false;
                                    _IsPauseWorking = true;
                                    var data = train;
                                    data.Train_date = TrainDate.ToString("yyyy-MM-dd");
                                    DeleteFormSelectTicket(() =>
                                    {
                                        formSelectTicket.FormThis.RunBook(data,obj.ToString());
                                        formSelectTicket.FormThis.AutoWorkFinished();
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
            foreach (TrainData train in _trainData)
            {
                if (!_IsPauseWorking)
                {
                    if (TrainCode.Contains(train.Station_train_code) && train.Bookable && train.SeatOwener.Count > 0)
                    {
                        foreach (var obj in SeatType)
                        {
                            if (!_IsPauseWorking)
                            {
                                if (train.SeatOwener.ContainsKey(obj))
                                {
                                    //formSelectTicket.FormThis._IsAutoWork = false;
                                    _IsPauseWorking = true;
                                    if (formSelectTicket.FormThis.InvokeRequired) { }
                                    var data = train;
                                    data.Train_date = TrainDate.ToString("yyyy-MM-dd");
                                    DeleteFormSelectTicket(() =>
                                    {
                                        formSelectTicket.FormThis.RunBook(data,obj.ToString());
                                        formSelectTicket.FormThis.AutoWorkFinished();
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

        public void Stop()
        {
            
        }

        private void DeleteFormSelectTicket(MethodInvoker method)
        {
            if (formSelectTicket.FormThis.InvokeRequired && formSelectTicket.FormThis != null)
            {
                formSelectTicket.FormThis.Invoke(method);
            }
            else
                method();
        }
    }
}
