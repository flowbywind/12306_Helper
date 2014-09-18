using System;

namespace aNyoNe.GetInfoFrom12306
{
    public class ModifyPassengerAction
    {
        private string _postdata = "";
        private string _querystring = "";
        public ModifyPassengerAction()
        {
            _postdata = PostData;
            _querystring = QueryString;
        }
        public string PostData { get { return this._postdata; } set { this._postdata = value; } }
        public string QueryString { get { return this._querystring; } set { this._querystring = value; } }



        public void GetPassenger(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.otn_GetPassengerDTOs, Properties.Resources.otn_leftTicket_init, "POST", "", cookie);
            webHelper.SendDataToServer((str) =>
           {
               if(str!="")
                callback(str);
           });
        }

        /**********************************************************更新********************************************************/

        public void InitModifyPassenger(Action<string> callback, System.Net.CookieContainer cookie)
        {
            var webHelper = new WebRequestHelper(Properties.Resources.otn_passengersEdit, Properties.Resources.otn_passengersShow, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        public void InitAddPassenger(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.otn_passengersAdd, Properties.Resources.otn_passengersAddInit, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }
    }
}
