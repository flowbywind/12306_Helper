using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12306_Helper
{
    class GetPassengerAction
    {
        //获取联系人信息
        public void GetPassengersAll(Action<string> callback,System.Net.CookieContainer cookie)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.confirmPassengerAction_getpassengerJson, Properties.Resources.confirmPassengerAction_init, "POST", "", cookie);
            webHelper.SendDataToServer((str) => {
                    callback(str);
            });
        }
    }
}
