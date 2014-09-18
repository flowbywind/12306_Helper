using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;

namespace _12306_Helper
{
    class LoginAction
    {
        //提交的数据
        private string _postdata = "";
        public CookieContainer cookieContainer = new CookieContainer();
        public LoginAction()
        {
            _postdata = PostData;
        }
        public string PostData { get { return this._postdata; } set { this._postdata = value; } }

        //获取随机码
        public void GetLoginRand(Action<string> callback)
        {
            WebRequestHelper webHelper = new WebRequestHelper(Properties.Resources.loginAction_AysnSuggest, Properties.Resources.loginAction_init, "POST", "", cookieContainer);
            webHelper.SendDataToServer((str) =>
            {
                callback(str);
            });
        }
        //获取登录验证码
        public void GetLoginRandCodeImg(Action<Bitmap> callback)
        {
            WebRequestHelper webrequest = new WebRequestHelper(Properties.Resources.passCodeAction_sjrand, "", "GET", "", cookieContainer);
            webrequest.GetBitMap((bit) =>
            {
                callback(bit);
            });
        }
        //登录
        public void BeginLogin(Action<string> callback)
        {
            WebRequestHelper webrequest = new WebRequestHelper(Properties.Resources.loginAction_login, Properties.Resources.loginAction_init, "POST", this._postdata, cookieContainer);
            webrequest.SendDataToServer((str,cookie) => {
                formSelectTicket.cookieContainer = cookie;
                callback(str);
            });
        }
    }
}
