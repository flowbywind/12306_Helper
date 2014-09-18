using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace _12306_Helper
{
    class SubmitOrderAction
    {
        private string _postdata = "";
        private string _querystring="";
        public SubmitOrderAction()
        {
            _postdata = PostData;
            _querystring=QueryString;
        }
        public string PostData { get { return this._postdata; } set { this._postdata = value; } }
        public string QueryString { get { return this._querystring; } set { this._querystring = value; } }

        //获取Token
        public void GetTokenWithSubmitPage(Action<string> callback,System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.querySingleAction_submutOrderRequest, Properties.Resources.querySingleAction_init, "POST", this._postdata, cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        //获取订单验证码
        public void GetOrderRandCodeImg(Action<Bitmap> callback,System.Net.CookieContainer cookie)
        {
            WebRequestHelper webrequest = new WebRequestHelper(Properties.Resources.passCodeAction_randp, "", "GET", "", cookie);
            webrequest.GetBitMap((bit) =>
            {
                callback(bit);
            });
        }

        //验证订单
        public void ConfirmOrder(Action<string> callback,System.Net.CookieContainer cookie)
        {
            WebRequestHelper webrequest = new WebRequestHelper(Properties.Resources.confirmPassengerAction_checkOrderInfo + this._querystring,
                                                    Properties.Resources.confirmPassengerAction_init, "POST", _postdata, cookie);
            webrequest.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        //提交订单
        public void SubmitOrder(Action<string> callback,System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.confirmPassengerAction_getQueueCount + this._querystring, Properties.Resources.confirmPassengerAction_init, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        //确认队列
        public void ConfirmOrderQueue(Action<string> callback,System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.confirmPassengerAction_confirmSingleForQueue, "", "POST", this._postdata.Replace("&tFlag=dc", ""), cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        //开始占座
        public void BeginGetSeat(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.myOrderAction_queryOrderWaitTime, Properties.Resources.confirmPassengerAction_init, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }
    }
}
