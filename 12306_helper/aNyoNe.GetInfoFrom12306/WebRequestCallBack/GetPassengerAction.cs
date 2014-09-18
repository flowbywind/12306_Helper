using System;

namespace aNyoNe.GetInfoFrom12306
{
    public class GetPassengerAction
    {    
        private string _orderState = "";
        private string _postdata = "";
        private string _querystring="";
        public GetPassengerAction()
        {
            _postdata = PostData;
            _querystring=QueryString;
        }
        public string OrderState { get { return this._orderState; } set { this._orderState = value; } }
        public string PostData { get { return this._postdata; } set { this._postdata = value; } }
        public string QueryString { get { return this._querystring; } set { this._querystring = value; } }
        //获取联系人信息
        public void GetPassengersAllJson(Action<string> callback,System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_GetPassengerDTOs, Properties.Resources.otn_initDc, "POST", this._postdata, cookie);
            //var webHelper = new WebRequestHelper(Properties.Resources.otn_GetPassengerDTOs, Properties.Resources.otn_leftTicket_init, "POST", "", cookie);
            webHelper.SendDataToServer((str) => {
                if(str!="")
                    callback(str);
            });
        }  

    }
}
