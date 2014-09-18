using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;


namespace _12306_Helper
{
    class HttpWebRequestHelper
    {
        /// <summary>
        /// 获取指定网页的验证码
        /// </summary>
        /// <param name="url">验证码地址</param>
        /// <returns></returns>
        public Bitmap GetBitmap(string url, string method, CookieContainer cookieContainer)
        {
            Bitmap bitMap=null;
            int tryTime = 0;
        Agin:
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0)";
                request.Method = method;
                request.CookieContainer = cookieContainer;
                request.Timeout = 20000;
                //忽略证书
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
                {
                    return true;
                };
                Stream responseStream = ((HttpWebResponse)request.GetResponse()).GetResponseStream();
                Image original = Image.FromStream(responseStream);
                bitMap = new Bitmap(original);
                responseStream.Close();
                
            }
            catch { if (tryTime < 10) { tryTime++; goto Agin; } }
            return bitMap;
        }

        /// <summary>
        /// 向指定地址提交数据
        /// </summary>
        /// <param name="loginUrl">目标地址</param>
        /// <param name="refer">refer</param>
        /// <param name="method">提交方法</param>
        /// <param name="postData">提交数据</param>
        /// <param name="rtrn">是否返回提交后的数据流</param>
        /// <returns></returns>
        public string SendDataToServer(string loginUrl, string refer,string method, string postData, CookieContainer cookieContainer ,bool rtrn)
        {
            string responseFromServer = "";
            HttpWebRequest httpWebRequest;
            HttpWebResponse httpWebResponse=null;
            //byte[] byteArray = Encoding.GetEncoding("UTF-8").GetBytes(postData);
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            int tryTime = 0;
        Agin:
            try
            {
                //基于apache服务器,IIS发布的则不需要  
                ServicePointManager.Expect100Continue = false;

                //创建对url的请求  
                httpWebRequest = (HttpWebRequest)WebRequest.Create(loginUrl);
                httpWebRequest.Referer = refer;
                httpWebRequest.CookieContainer = cookieContainer;
                httpWebRequest.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/QVOD, application/QVOD, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-xpsdocument, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                httpWebRequest.Headers["Accept-Language"] = "zh-cn";
                httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Headers["Cache-Control"] = "no-cache";
                //httpWebRequest.AllowAutoRedirect = false;
                //协议方式  
                httpWebRequest.Method = method;
                httpWebRequest.Timeout = 20000;
                //post开始  
                //请求内容长度
                if (httpWebRequest.Method == "POST" || httpWebRequest.Method == "post")
                {
                    httpWebRequest.ContentLength = byteArray.Length;
                    Stream dataStream = httpWebRequest.GetRequestStream();

                    // 请求数据放入请求流  
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    dataStream.Close();
                }
                //忽略证书
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
                {
                    return true;
                };
                //返回html  
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                
                /*
                System.Web.SessionState.HttpSessionState mys=Syste HttpContext.Current.Session; 
                但是有种情况就是用到了AJAX的话在返回的方法中调用就会有问题所以要有小的改动

                [AjaxMethod]
                [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]*/
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                    //读取响应流  
                    responseFromServer = reader.ReadToEnd();//读响应流html
                    reader.Close();
                    httpWebResponse.Close();
                }
            }
            catch { if (tryTime < 10) { tryTime++; goto Agin; } }
            if (rtrn)
                return responseFromServer;
            return "0";
        }
        /// <summary>
        /// 具有重定向的httpwebrequest向指定地址提交数据
        /// </summary>
        /// <param name="loginUrl">目标地址</param>
        /// <param name="refer">refer</param>
        /// <param name="method">提交方法</param>
        /// <param name="postData">提交数据</param>
        /// <param name="rtrn">是否返回提交后的数据流</param>
        /// <returns></returns>
        public string RedirectSendDataToServer(string loginUrl, string refer, string method, string postData, CookieContainer cookieContainer, bool rtrn)
        {
            string responseFromServer = "";
            HttpWebRequest httpWebRequest;
            HttpWebResponse httpWebResponse;
            //byte[] byteArray = Encoding.GetEncoding("UTF-8").GetBytes(postData);
            byte[] byteArray = Encoding.ASCII.GetBytes(postData);
            int tryTime = 0;
        Agin:
            try
            {
                //基于apache服务器,IIS发布的则不需要  
                ServicePointManager.Expect100Continue = false;

                //创建对url的请求  
                httpWebRequest = GetNewRequest(loginUrl, refer, cookieContainer);

                //协议方式  
                httpWebRequest.Method = method;
                httpWebRequest.Timeout = 20000;

                //post开始  
                //请求内容长度
                if (httpWebRequest.Method == "POST" || httpWebRequest.Method == "post")
                {
                    httpWebRequest.ContentLength = byteArray.Length;
                    Stream dataStream = httpWebRequest.GetRequestStream();

                    // 请求数据放入请求流  
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    dataStream.Close();
                }
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
                {
                    return true;
                };
                //返回html  
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                while (httpWebResponse.StatusCode == HttpStatusCode.Found)//如果提交的方式为POST 那么重定向使用GET
                {
                    //httpWebResponse.Close();
                    httpWebRequest = GetNewRequest(httpWebResponse.Headers["Location"],refer,cookieContainer);
                    httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                }

                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                    //读取响应流  
                    responseFromServer = reader.ReadToEnd();//读响应流html
                    reader.Close();
                    httpWebResponse.Close();
                }
            }
            catch { if (tryTime < 10) { tryTime++; goto Agin; } }
            if (rtrn)
                return responseFromServer;
            return "0";
        }
        private HttpWebRequest GetNewRequest(string targetUrl,string referer, CookieContainer cookieContainer)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUrl);
            request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/QVOD, application/QVOD, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-xpsdocument, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            request.Headers["Accept-Language"] = "zh-cn";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cookieContainer;
            request.Referer = referer;
            request.AllowAutoRedirect = false;
            return request;
        }
    }
}
