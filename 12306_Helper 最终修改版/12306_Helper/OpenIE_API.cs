using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace _12306_Helper
{
    class OpenIE_API
    {
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetCookie(string A_0, string A_1, string A_2);
        public static void OpenIE(CookieContainer _cookieContainer)
        {
            foreach (Cookie cookie in _cookieContainer.GetCookies(new Uri(Properties.Resources.loginAction_login)))
            {
                InternetSetCookie("https://" + cookie.Domain.ToString(), cookie.Name.ToString(), cookie.Value.ToString() + ";expires=Sun,22-Feb-2099 00:00:00 GMT");
            }
            System.Diagnostics.Process.Start("iexplore.exe", Properties.Resources.ostweb);
        }

        public static void OpenUrl(string URL)
        {
            System.Diagnostics.Process.Start("iexplore.exe", URL);
        }
    }
}
