using System;
using System.Collections;
using System.Drawing;
using System.Net;

namespace aNyoNe.GetInfoFrom12306
{
    public class LoginAction
    {
        //提交的数据
        private string _postdata = "";
        public static CookieContainer cookieContainer = new CookieContainer();
        public LoginAction()
        {
            _postdata = PostData;
        }
        public string PostData { get { return this._postdata; } set { this._postdata = value; } }

        //获取登录验证码
        public void GetLoginRandCodeImg(Action<Image> callback)
        {
            //WebRequestHelper webrequest = new WebRequestHelper(Properties.Resources.passCodeNewAction, "", "GET", "", cookieContainer);
            var webrequest = new WebRequestHelper(Properties.Resources.otn_passCodeAction_sjrand, Properties.Resources.otn_loginAction_init, "GET", "", cookieContainer);
            webrequest.GetBitMap((bit) =>
            {
                callback(bit);
            });
        }
        //登录
        public Hashtable BeginLogin()//Action<string,CookieContainer> callback
        {
            //WebRequestHelper webrequest = new WebRequestHelper(Properties.Resources.loginAction_login, Properties.Resources.loginAction_init, "POST", this._postdata, cookieContainer);
            //webrequest.SendDataToServer((str,cookie) => {
            //    if(str!="")
            //        callback(str,cookie);
            //});
            var webrequest = new WebRequestHelper(Properties.Resources.otn_loginAction_login, Properties.Resources.otn_loginAction_init, "POST", this._postdata, cookieContainer);
            return webrequest.SendDataToServerHash();
        }
    }
}
