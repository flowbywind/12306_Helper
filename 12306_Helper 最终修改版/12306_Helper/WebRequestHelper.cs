using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace _12306_Helper
{
    class WebRequestHelper
    {
        private string _url = "";
        private string _refer = "";
        private string _method = "";
        private string _postdata = "";
        private CookieContainer _cookie = null;

        public  WebRequestHelper(string loginUrl, string refer, string method, string postData, CookieContainer cookieContainer)
        {
            _url = loginUrl;
            _refer = refer;
            _method = method;
            _postdata = postData;
            _cookie = cookieContainer;
        }
        public WebRequestHelper() { }
        public string Url { get { return this._url; } set { this._url = value; } }
        public string Refer { get { return this._refer; } set { this._refer = value; } }
        public string Method { get { return this._method; } set { this._method = value; } }
        public string PostData { get { return this._postdata; } set { this._postdata = value; } }
        public CookieContainer Cookie { get; set; }
        public void GetTime(Action<object> callback)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0)";
            request.Method = _method;
            request.CookieContainer = _cookie;
            request.Timeout = 20000;

            //忽略证书
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;
            };
            request.BeginGetResponse((ar) =>
            {
                try
                {
                    using (var webresponse = (HttpWebResponse)request.EndGetResponse(ar))
                    {
                        callback(webresponse.Headers["Date"]);
                    }
                }
                catch (Exception e) { callback(null); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); return; }
                finally { request.Abort(); }
            }, null);
        }
        public void GetBitMap(Action<Bitmap> callback)
        {
            Bitmap bitMap = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0)";
            request.Method = _method;
            request.CookieContainer = _cookie;
            request.Timeout = 20000;

            //忽略证书
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;
            };
            request.BeginGetResponse((ar) => {
                try
                {
                    using (var webresponse = (HttpWebResponse)request.EndGetResponse(ar))
                    {
                        using (var stream = webresponse.GetResponseStream())
                        {
                            Image img = Image.FromStream(stream);
                            bitMap = new Bitmap(img);
                            callback(bitMap);
                        }
                    }
                }
                catch (Exception e) { callback(null); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); return; }
                finally { request.Abort(); }
            },null);
        }

        public void SendDataToServer(Action<string> callback)
        {
            lock (this)
            {
                HttpWebRequest httpWebRequest;
                byte[] byteArray = Encoding.ASCII.GetBytes(_postdata);

                //基于apache服务器,IIS发布的则不需要  
                ServicePointManager.Expect100Continue = false;

                //创建对url的请求  
                httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
                httpWebRequest.Referer = _refer;
                httpWebRequest.CookieContainer = _cookie;
                httpWebRequest.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/QVOD, application/QVOD, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-xpsdocument, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                httpWebRequest.Headers["Accept-Language"] = "zh-cn";
                httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Headers["Cache-Control"] = "no-cache";
                httpWebRequest.AllowAutoRedirect = true;
                //httpWebRequest.ProtocolVersion = HttpVersion.Version11;

                //协议方式  
                httpWebRequest.Method = _method;
                httpWebRequest.Timeout = 20000;
                //忽略证书
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
                {
                    return true;
                };
                //post开始  
                //请求内容长度
                if (httpWebRequest.Method == "POST" || httpWebRequest.Method == "post")
                {
                    try
                    {
                        httpWebRequest.ContentLength = byteArray.Length;
                        //httpWebRequest.GetRequestStream().Dispose();
                        //Stream dataStream = httpWebRequest.GetRequestStream();
                        //// 请求数据放入请求流  
                        //dataStream.Write(byteArray, 0, byteArray.Length);
                        //dataStream.Dispose();
                        //dataStream.Close();
                        httpWebRequest.BeginGetRequestStream((a) =>
                        {
                            try
                            {
                                using (Stream datasStream = httpWebRequest.EndGetRequestStream(a))
                                {
                                    datasStream.Write(byteArray, 0, byteArray.Length);
                                    //异步返回html  
                                    httpWebRequest.BeginGetResponse((ar) =>
                                    {
                                        try
                                        {
                                            using (var webresponse = (HttpWebResponse)httpWebRequest.EndGetResponse(ar))
                                            {
                                                using (var stream = webresponse.GetResponseStream())
                                                {
                                                    using (var sr = new StreamReader(stream))
                                                    {
                                                        callback(sr.ReadToEnd());
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception e) { callback(string.Empty); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); }
                                        finally { httpWebRequest.Abort(); }
                                    }, null);
                                }
                            }
                            catch (Exception e) { callback(string.Empty); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); httpWebRequest.Abort(); return; }
                        }, null);
                    }
                    catch (Exception e) { callback(string.Empty); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); httpWebRequest.Abort(); return; }//
                }
                else
                {
                    //异步返回html  
                    httpWebRequest.BeginGetResponse((ar) =>
                    {
                        try
                        {
                            using (var webresponse = (HttpWebResponse)httpWebRequest.EndGetResponse(ar))
                            {
                                using (var stream = webresponse.GetResponseStream())
                                {
                                    using (var sr = new StreamReader(stream))
                                    {
                                        callback(sr.ReadToEnd());
                                    }
                                }
                            }
                        }
                        catch (Exception e) { callback(string.Empty); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); }
                        finally { httpWebRequest.Abort(); }
                    }, null);
                }
            }   
        }
        public void SendDataToServer(Action<string,string> callback )//Action<object> callbackExpires
        {
            lock (this)
            {
                HttpWebRequest httpWebRequest;
                byte[] byteArray = Encoding.ASCII.GetBytes(_postdata);

                //基于apache服务器,IIS发布的则不需要  
                ServicePointManager.Expect100Continue = false;

                //创建对url的请求  
                httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
                httpWebRequest.Referer = _refer;
                httpWebRequest.CookieContainer = _cookie;
                httpWebRequest.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/QVOD, application/QVOD, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-xpsdocument, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                httpWebRequest.Headers["Accept-Language"] = "zh-cn";
                httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Headers["Cache-Control"] = "no-cache";
                //httpWebRequest.AllowAutoRedirect = false;
                //协议方式  
                httpWebRequest.Method = _method;
                httpWebRequest.Timeout = 20000;
                //忽略证书
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
                {
                    return true;
                };
                //post开始  
                //请求内容长度
                if (httpWebRequest.Method == "POST" || httpWebRequest.Method == "post")
                {
                    try
                    {
                        httpWebRequest.ContentLength = byteArray.Length;
                        //Stream dataStream = httpWebRequest.GetRequestStream();
                        //// 请求数据放入请求流  
                        //dataStream.Write(byteArray, 0, byteArray.Length);
                        //dataStream.Dispose();
                        //dataStream.Close();
                        httpWebRequest.BeginGetRequestStream((a) =>
                        {
                            try
                            {
                                using (Stream datasStream = httpWebRequest.EndGetRequestStream(a))
                                {
                                    datasStream.Write(byteArray, 0, byteArray.Length);
                                    //异步返回html  
                                    httpWebRequest.BeginGetResponse((ar) =>
                                    {
                                        try
                                        {
                                            using (var webresponse = (HttpWebResponse)httpWebRequest.EndGetResponse(ar))
                                            {
                                                using (var stream = webresponse.GetResponseStream())
                                                {
                                                    using (var sr = new StreamReader(stream))
                                                    {
                                                        if (webresponse.Headers["X-Cache"].ToString().IndexOf("HIT") > -1)
                                                        {
                                                            callback(sr.ReadToEnd(),(webresponse.Headers["Expires"]));
                                                        }
                                                        else
                                                            callback(sr.ReadToEnd(), "false");

                                                        //callback(sr.ReadToEnd());
                                                        //if (webresponse.Headers["X-Cache"].ToString().IndexOf("HIT") > -1)
                                                        //{
                                                        //    callbackExpires(webresponse.Headers["Expires"]);
                                                        //}
                                                        //else
                                                        //    callbackExpires("false");
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception e) { callback(string.Empty,""); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); }
                                        finally { httpWebRequest.Abort(); }
                                    }, null);
                                }
                            }
                            catch (Exception e) { callback(string.Empty, ""); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); httpWebRequest.Abort(); return; }
                        }, null);
                    }
                    catch (Exception e) { callback(string.Empty, ""); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); httpWebRequest.Abort(); return; }// 

                }
                else
                {
                    //异步返回html  
                    httpWebRequest.BeginGetResponse((ar) =>
                    {
                        try
                        {
                            using (var webresponse = (HttpWebResponse)httpWebRequest.EndGetResponse(ar))
                            {
                                using (var stream = webresponse.GetResponseStream())
                                {
                                    using (var sr = new StreamReader(stream))
                                    {
                                        if (webresponse.Headers["X-Cache"].ToString().IndexOf("HIT") > -1)
                                        {
                                            callback(sr.ReadToEnd(), (webresponse.Headers["Expires"]));
                                        }
                                        else
                                            callback(sr.ReadToEnd(), "false");
                                        //callback(sr.ReadToEnd());
                                        //if (webresponse.Headers["X-Cache"].ToString().IndexOf("HIT") > -1)
                                        //{
                                        //    callbackExpires(webresponse.Headers["Expires"]);
                                        //}
                                        //else
                                        //    callbackExpires("false");
                                    }
                                }
                            }
                        }
                        catch (Exception e) { callback(string.Empty, ""); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); }
                        finally { httpWebRequest.Abort(); }
                    }, null);
                }
            }
        }
        public void SendDataToServer(Action<string,CookieContainer> callback)
        {
            lock(this)
            {
                HttpWebRequest httpWebRequest;
                byte[] byteArray = Encoding.ASCII.GetBytes(_postdata);

                //基于apache服务器,IIS发布的则不需要  
                ServicePointManager.Expect100Continue = false;

                //创建对url的请求  
                httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
                httpWebRequest.Referer = _refer;
                httpWebRequest.CookieContainer = _cookie;
                httpWebRequest.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/QVOD, application/QVOD, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-xpsdocument, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                httpWebRequest.Headers["Accept-Language"] = "zh-cn";
                httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Headers["Cache-Control"] = "no-cache";
                //协议方式  
                httpWebRequest.Method = _method;
                httpWebRequest.Timeout = 20000;
                //忽略证书
                System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
                {
                    return true;
                };
                //post开始  
                //请求内容长度
                if (httpWebRequest.Method == "POST" || httpWebRequest.Method == "post")
                {
                    try
                    {
                        httpWebRequest.ContentLength = byteArray.Length;
                        //Stream dataStream = httpWebRequest.GetRequestStream();
                        //// 请求数据放入请求流  
                        //dataStream.Write(byteArray, 0, byteArray.Length);
                        //dataStream.Dispose();
                        //dataStream.Close();
                        httpWebRequest.BeginGetRequestStream((a) =>
                        {
                            try
                            {
                                using (Stream datasStream = httpWebRequest.EndGetRequestStream(a))
                                {
                                    datasStream.Write(byteArray, 0, byteArray.Length);
                                    //异步返回html  
                                    httpWebRequest.BeginGetResponse((ar) =>
                                    {
                                        try
                                        {
                                            using (var webresponse = (HttpWebResponse)httpWebRequest.EndGetResponse(ar))
                                            {
                                                using (var stream = webresponse.GetResponseStream())
                                                {
                                                    using (var sr = new StreamReader(stream))
                                                    {
                                                        callback(sr.ReadToEnd(), httpWebRequest.CookieContainer);
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception e) { callback(string.Empty,new CookieContainer()); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); }
                                        finally { httpWebRequest.Abort(); }
                                    }, null);
                                }
                            }
                            catch (Exception e) { callback(string.Empty,new CookieContainer()); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); httpWebRequest.Abort(); return; }
                        }, null);
                    }
                    catch (Exception e) { callback(string.Empty, new CookieContainer()); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); }

                }
                else
                {
                    //异步返回html  
                    httpWebRequest.BeginGetResponse((ar) =>
                    {
                        try
                        {
                            using (var webresponse = (HttpWebResponse)httpWebRequest.EndGetResponse(ar))
                            {
                                using (var stream = webresponse.GetResponseStream())
                                {
                                    using (var sr = new StreamReader(stream))
                                    {
                                        callback(sr.ReadToEnd(), httpWebRequest.CookieContainer);
                                    }
                                }
                            }
                        }
                        catch (Exception e) { callback(string.Empty, new CookieContainer()); LogClass.WriteLogFile("WebRequestHelper Catch:" + e.Message + "\r\nSource:" + e.Source + "\r\nException:" + e.ToString()); }
                        finally { httpWebRequest.Abort(); }
                    }, null);
                }
            }
        }
        
    }
}
