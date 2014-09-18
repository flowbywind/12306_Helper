using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12306_Helper
{
    class ModifyPassengerAction
    {       
        private string _postdata = "";
        private string _querystring="";
        public ModifyPassengerAction()
        {
            _postdata = PostData;
            _querystring=QueryString;
        }
        public string PostData { get { return this._postdata; } set { this._postdata = value; } }
        public string QueryString { get { return this._querystring; } set { this._querystring = value; } }

        public void GetUnfinishedOrder(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.editMemberAction_initEdit, Properties.Resources.ostweb, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        public void InitUsualPassenger12306(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.passengerAction_initUsualPassenger12306All, Properties.Resources.loginAction_login, "GET", "", cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        public void GetPagePassengerAll(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.passengerAction_getPagePassengerAll, Properties.Resources.passengerAction_initUsualPassenger12306, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                if(str!="")
                callback(str);
            });
        }

        public void InitModifyPassenger(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.passengerAction_initModifyPassenger, Properties.Resources.passengerAction_initUsualPassenger12306, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        public void ModifyPassenger(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.passengerAction_modifyPassenger, Properties.Resources.passengerAction_initModifyPassenger, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        public void InitAddPassenger(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.initAddPassenger, Properties.Resources.passengerAction_initUsualPassenger12306, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }

        public void SavePassenger(Action<string> callback, System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.savePassenger, Properties.Resources.initAddPassenger, "POST", PostData, cookie);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }  
    }
}
