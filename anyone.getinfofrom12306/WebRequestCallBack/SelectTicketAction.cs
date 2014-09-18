using System;

namespace aNyoNe.GetInfoFrom12306
{
    public class SelectTicketAction
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

        /***********************************************************更新******************************************************/

        public void RedirectMy12306(Action<object> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_initMy12306, Properties.Resources.otn_loginAction_init, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                if (str.ToString() != "")
                    callback(str);
            });
        }

        //获取服务器时间
        public void GetServerTime(Action<object> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_indexInit, "", "GET", "", cookie);
            webHelper.GetTime((str) =>
            {
                if(str.ToString()!="")
                    callback(str);
            });
        }

        //查询余票信息
        public void GetLeftTickets(Action<string> callback, Action<object> callbackExpires, System.Net.CookieContainer cookie)
        {//+" "+DateTime.Now.Subtract(Convert.ToDateTime("1970-01-01")).Ticks.ToString().Substring(0,13)
            var webHelper = new WebRequestHelper(Properties.Resources.otn_leftTicket_Query + this._querystring, Properties.Resources.otn_leftTicket_init, "GET", "", cookie);
            webHelper.SendDataToServer((str, expires) =>
            {
                if(str!="")
                    callback(str);
                if (expires != null && expires != "")
                {
                    callbackExpires(expires);
                }
            });
        }

        public void GetLeftTicketsEx( System.Net.CookieContainer cookie)
        {//+" "+DateTime.Now.Subtract(Convert.ToDateTime("1970-01-01")).Ticks.ToString().Substring(0,13)
            var webHelper = new WebRequestHelper("http://kyfw.12306.cn/otn/dynamicJs/queryJs", Properties.Resources.otn_leftTicket_init, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                //if (str != "")
                //    callback(str);
            });
        }



        //查询余票信息(不可预订)
        public void GetLeftTicketsEx(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_lcxxcxQuery + this._querystring, Properties.Resources.otn_lcxxcxInit, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                if (str != "")
                    callback(str);
            });
        }

        //获取列车到站信息
        public void GetArriveStationInfo(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_czxxQueryByTrainNo + QueryString, Properties.Resources.otn_leftTicket_init, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }
    }
}
