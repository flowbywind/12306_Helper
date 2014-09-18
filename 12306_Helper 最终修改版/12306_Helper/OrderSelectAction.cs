using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12306_Helper
{
    class OrderSelectAction
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

        public void GetUnfinishedOrder(Action<string> callback,System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.myOrderAction_queryMyOrderNotComplete, Properties.Resources.editMemberAction_initEdit, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        public void CancelNotCompleteOrder(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.orderAction_cancelMyOrderNotComplete, Properties.Resources.myOrderAction_queryMyOrderNotComplete, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        public void GetOrderSelectToken(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.myOrderAction_showMessage, Properties.Resources.loginAction_login, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        public void SelectOrder(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.myOrderAction_queryMyOrder, Properties.Resources.myOrderAction_showMessage, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }
    }
}
