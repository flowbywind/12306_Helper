using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12306_Helper
{
    class SelectTicketAction
    {
        private string _orderState = "";
        private string _postdata = "";
        private string _querystring="";
        public SelectTicketAction()
        {
            _postdata = PostData;
            _querystring=QueryString;
        }
        public string OrderState { get { return this._orderState; } set { this._orderState = value; } }
        public string PostData { get { return this._postdata; } set { this._postdata = value; } }
        public string QueryString { get { return this._querystring; } set { this._querystring = value; } }

        //查询余票信息
        public void GetLeftTickets(Action<string> callback,Action<object> callbackExpires, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.querySingleAction_queryLeftTicket + this._querystring, Properties.Resources.querySingleAction_init, "GET", "", cookie);
            webHelper.SendDataToServer((str,expires) =>
            {
                callback(str);
                if (expires != null && expires != "")
                {
                    callbackExpires(expires);
                }
            });
        }

        //获取服务器时间
        public void GetServerTime(Action<object> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.main_jsp, "", "GET", "", cookie);
            webHelper.GetTime((str) =>
            {
                callback(str);
            });
        }

        //获取列车到站信息
        public void GetArriveStationInfo(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.querySingleAction_queryaTrainStopTimeByTrainNo + QueryString, Properties.Resources.querySingleAction_init, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }
    }
}
