using System;

namespace aNyoNe.GetInfoFrom12306
{
    public class OrderSelectAction
    {
        private string _postdata = "";
        private string _querystring="";
        public OrderSelectAction()
        {
            _postdata = PostData;
            _querystring=QueryString;
        }
        public string PostData { get { return this._postdata; } set { this._postdata = value; } }
        public string QueryString { get { return this._querystring; } set { this._querystring = value; } }



        /**************************************************************更新******************************************************************/

        //加载未完成订单
        public void QueryMyOrderNoComplete(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_queryMyOrderNoComplete, Properties.Resources.otn_initNoComplete, "POST", "_json_att=", cookie);
            webHelper.SendDataToServer((str) =>
            {
                if (str != "")
                    callback(str);
            });
        }

        //取消订单
        public void CancelNotCompleteOrder(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.otn_orderAction_cancelMyOrderNotComplete, Properties.Resources.otn_orderAction_cancelMyOrderNotCompleteREF, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        //已完成订单查询
        public void SelectOrder(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_queryMyOrder, Properties.Resources.otn_queryOrderInit, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                if(str!="")
                    callback(str);
            });
        }

    }
}
