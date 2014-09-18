using System;
using System.Drawing;

namespace aNyoNe.GetInfoFrom12306
{
    public class SubmitOrderAction
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

        /****************************************************更新******************************************************/
        //进入预定页
        public void EnterSubmitPage(Action<string> callback, System.Net.CookieContainer cookie, string referer = "")
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_submitOrderRequest, Properties.Resources.otn_leftTicket_init, 
                    "POST", this._postdata, cookie);
            webHelper.SendDataToServer((str) =>
            {
                if(str!="")
                    callback(str);
            }, false, referer);
        }

        //获取Token
        public string GetTokenFromSubmitPage(System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_initDc, Properties.Resources.otn_leftTicket_init, "POST", "_json_att=", cookie);
            return webHelper.SendDataToServer();
        }

        //获取Token
        public void GetTokenFromSubmitPageSync(Action<string> callback,System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_initDc, Properties.Resources.otn_leftTicket_init, "POST", "_json_att=", cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        //获取订单验证码
        public void GetOrderRandCodeImg(Action<Image> callback, System.Net.CookieContainer cookie)
        {
            var webrequest = new WebRequestHelper(Properties.Resources.otn_getPassCodeNew, Properties.Resources.otn_initDc, "GET", "", cookie);
            webrequest.GetBitMap((bit) =>
            {
                callback(bit);
            });
        }

        //验证订单
        public void CheckOrderInfo(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webrequest = new WebRequestHelper(Properties.Resources.otn_checkOrderInfo,
                                                    Properties.Resources.otn_initDc, "POST", _postdata, cookie);
            webrequest.SendDataToServer((str) =>
            {
                if(str!="")
                    callback(str);
            });
        }

        //验证订单
        public string CheckOrderInfoEx(System.Net.CookieContainer cookie)
        {
            var webrequest = new WebRequestHelper(Properties.Resources.otn_checkOrderInfo,
                                                    Properties.Resources.otn_initDc, "POST", _postdata, cookie);

            return webrequest.SendDataToServer();

        }

        //提交订单
        public void GetQueueCount(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_getQueueCount, Properties.Resources.otn_initDc, "POST", this._postdata, cookie);
            webHelper.SendDataToServer((str) =>
            {
                if (str != "")
                    callback(str);
            });
        }

        //确认队列
        public void ConfirmSingleForQueue(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_confirmSingleForQueue, Properties.Resources.otn_initDc, 
                    "POST", this._postdata, cookie);
            webHelper.SendDataToServer((str) =>
            {
                if (str != "")
                    callback(str);
            });
        }

        //开始占座
        public void BeginGetSeat(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_queryOrderWaitTime + this._querystring, Properties.Resources.otn_initDc, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                if(str!="")
                    callback(str);
            });
        }

        /*****************************************************自动提交**********************************************************/
        //提交订单
        public void SubmitOrderRequestAsync(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_SubmitOrderRequestAsync, Properties.Resources.otn_leftTicket_init, "POST", this._postdata, cookie);
            webHelper.SendDataToServer((str) =>
            {
                if (str != "")
                    callback(str);
            });
        }
        public void GetQueueCountAsync(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_getQueueCountAsync, Properties.Resources.otn_leftTicket_init, "POST", this._postdata, cookie);
            webHelper.SendDataToServer((str) =>
            {
                if (str != "")
                    callback(str);
            });
        }
        public void CheckRandCodeAsync(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_checkRandCodeAsync, Properties.Resources.otn_leftTicket_init, "POST", this._postdata, cookie);
            webHelper.SendDataToServer((str) =>
            {
                if (str != "")
                    callback(str);
            });
        }
        public void ConfirmSingleForQueueAsync(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_confirmSingleForQueueAsync, Properties.Resources.otn_leftTicket_init, "POST", this._postdata, cookie);
            webHelper.SendDataToServer((str) =>
            {
                if (str != "")
                    callback(str);
            });
        }
        //开始占座
        public void GetSeatAsync(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_queryOrderWaitTime + this._querystring, Properties.Resources.otn_leftTicket_init, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                if (str != "")
                    callback(str);
            });
        }

        //获取订单验证码
        public void GetAsyncOrderRandCodeImg(Action<Image> callback, System.Net.CookieContainer cookie)
        {
            var webrequest = new WebRequestHelper(Properties.Resources.otn_getPassCodeNewAsync+this.QueryString, Properties.Resources.otn_leftTicket_init, "GET", "", cookie);
            webrequest.GetBitMap((bit) =>
            {
                callback(bit);
            },true);
        }
    }
}
