using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Drawing;
using System.IO.Compression;
using System.Windows.Forms;

namespace aNyoNe.GetInfoFrom12306
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
            request.ServicePoint.Expect100Continue = false;
            //是否使用 Nagle 不使用 提高效率 
            request.ServicePoint.UseNagleAlgorithm = false;
            //最大连接数 
            request.ServicePoint.ConnectionLimit = 65500;
            //数据是否缓冲 false 提高效率  
            request.AllowWriteStreamBuffering = false;

            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            request.Method = _method;
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request.CookieContainer = _cookie;
            request.Timeout = 20000;
            request.Proxy = HttpWebRequest.GetSystemWebProxy();
            request.Proxy.Credentials = CredentialCache.DefaultCredentials;
            //request.Proxy = MyWebProxy.Proxy;
            //忽略证书
            ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
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
                catch (Exception e) { callback(null); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                
                    return; }
                finally { request.Abort(); }
            }, null);
        }
        public void GetBitMap(Action<Image> callback, bool refer = false)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
            //request.ServicePoint.Expect100Continue = false; 
            ////是否使用 Nagle 不使用 提高效率 
            request.ServicePoint.UseNagleAlgorithm = false;
            ////最大连接数 
            //request.ServicePoint.ConnectionLimit = 65500;
            //数据是否缓冲 false 提高效率  
            request.AllowWriteStreamBuffering = false;

            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            request.Method = _method;

            if(refer)
                request.Referer = _refer;
            request.CookieContainer = _cookie;
            request.Timeout = 20000;
            request.Proxy = HttpWebRequest.GetSystemWebProxy();
            request.Proxy.Credentials = CredentialCache.DefaultCredentials;
            //request.Proxy = MyWebProxy.Proxy;
            //忽略证书
            ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;
            };
            request.BeginGetResponse((ar) =>
            {
                try
                {
                    using (var webresponse = (HttpWebResponse)request.EndGetResponse(ar))
                    {
                        if (webresponse.ContentEncoding.ToLower().Contains("gzip"))
                        {
                            using (GZipStream stream = new GZipStream(webresponse.GetResponseStream(), CompressionMode.Decompress))
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    Image img = Image.FromStream(stream);
                                    //bitMap = new Bitmap(img);
                                    callback(img);
                                }
                            }
                        }
                        else if (webresponse.ContentEncoding.ToLower().Contains("deflate"))
                        {
                            using (DeflateStream stream = new DeflateStream(webresponse.GetResponseStream(), CompressionMode.Decompress))
                            {
                                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                {
                                    Image img = Image.FromStream(stream);
                                    //bitMap = new Bitmap(img);
                                    callback(img);
                                }
                            }
                        }
                        else
                            using (var stream = webresponse.GetResponseStream())
                            {
                                Image img = Image.FromStream(stream);
                                //bitMap = new Bitmap(img);
                                callback(img);
                            }
                    }
                }
                catch (Exception e) { callback(null); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                 return;
                }
                finally { request.Abort(); }
            }, null);
        }

        public void SendDataToServer(Action<string> callback,bool redirect= true,string redirectRefer="",string accecp="")
        {
            lock (this)
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
                byte[] byteArray = Encoding.ASCII.GetBytes(_postdata);

                //创建对url的请求  
                //基于apache服务器,IIS发布的则不需要  
                httpWebRequest.ServicePoint.Expect100Continue = false;
                //是否使用 Nagle 不使用 提高效率 
                httpWebRequest.ServicePoint.UseNagleAlgorithm = false;
                //最大连接数 
                httpWebRequest.ServicePoint.ConnectionLimit = 65500;
                //数据是否缓冲 false 提高效率  
                httpWebRequest.AllowWriteStreamBuffering = false;

                httpWebRequest.Referer = _refer;
                httpWebRequest.CookieContainer = _cookie;
                //Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)
                //text/html, application/xhtml+xml, */*
                //"image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/QVOD, application/QVOD, application/xaml+xml, application/x-ms-xbap, application/x-ms-application, application/vnd.ms-xpsdocument, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                //"Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; EmbeddedWB 14.52 from: http://www.bsalsa.com/ EmbeddedWB 14.52; .NET CLR 2.0.50727; .NET4.0C; .NET4.0E; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                httpWebRequest.Accept =accecp==""? "text/html, application/xhtml+xml, */*":"*/*";
                httpWebRequest.Headers["Accept-Language"] = "zh-CN";
                httpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
                httpWebRequest.Host = "kyfw.12306.cn";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Headers["Cache-Control"] = "no-cache";
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.Headers["X-Requested-With"] = "XMLHttpRequest";
                //httpWebRequest.ProtocolVersion = HttpVersion.Version11;
                httpWebRequest.Proxy = HttpWebRequest.GetSystemWebProxy();
                httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                //httpWebRequest.Proxy = MyWebProxy.Proxy;
                //协议方式  
                httpWebRequest.Method = _method;
                httpWebRequest.Timeout = 10000;
                httpWebRequest.AllowAutoRedirect = redirect;
                //忽略证书
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
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
                                            using (
                                                var webresponse1 = (HttpWebResponse) httpWebRequest.EndGetResponse(ar))
                                            {
                                                var webresponse = (HttpWebResponse) webresponse1;
                                                if (webresponse.StatusCode == HttpStatusCode.Found)
                                                {
                                                    httpWebRequest = GetNewRequest(webresponse.Headers["Location"],
                                                        redirectRefer == "" ? _refer : redirectRefer, _cookie);
                                                    webresponse = (HttpWebResponse) httpWebRequest.GetResponse();
                                                }

                                                if (webresponse.ContentEncoding.ToLower().Contains("gzip"))
                                                {
                                                    using (
                                                        GZipStream stream =
                                                            new GZipStream(webresponse.GetResponseStream(),
                                                                CompressionMode.Decompress))
                                                    {
                                                        using (
                                                            StreamReader reader = new StreamReader(stream, Encoding.UTF8)
                                                            )
                                                        {
                                                            callback(reader.ReadToEnd());
                                                        }
                                                    }
                                                }
                                                else if (webresponse.ContentEncoding.ToLower().Contains("deflate"))
                                                {
                                                    using (
                                                        DeflateStream stream =
                                                            new DeflateStream(webresponse.GetResponseStream(),
                                                                CompressionMode.Decompress))
                                                    {
                                                        using (
                                                            StreamReader reader = new StreamReader(stream, Encoding.UTF8)
                                                            )
                                                        {
                                                            callback(reader.ReadToEnd());
                                                        }
                                                    }
                                                }
                                                else
                                                    using (var stream = webresponse.GetResponseStream())
                                                    {
                                                        using (var sr = new StreamReader(stream))
                                                        {
                                                            callback(sr.ReadToEnd());
                                                        }
                                                    }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            callback(string.Empty); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                                            
                                        }
                                        finally { httpWebRequest.Abort(); }
                                    }, null);
                                }
                            }
                            catch (Exception e) { callback(string.Empty); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e)); httpWebRequest.Abort();
                             return;
                            }
                        }, null);
                    }
                    catch (Exception e) { callback(string.Empty); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e)); httpWebRequest.Abort();
                     return;
                    }//
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
                                if (webresponse.ContentEncoding.ToLower().Contains("gzip"))
                                {
                                    using (GZipStream stream = new GZipStream(webresponse.GetResponseStream(), CompressionMode.Decompress))
                                    {
                                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                        {
                                            callback(reader.ReadToEnd());
                                        }
                                    }
                                }
                                else if (webresponse.ContentEncoding.ToLower().Contains("deflate"))
                                {
                                    using (DeflateStream stream = new DeflateStream(webresponse.GetResponseStream(), CompressionMode.Decompress))
                                    {
                                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                        {
                                            callback(reader.ReadToEnd());
                                        }
                                    }
                                }
                                else
                                    using (var stream = webresponse.GetResponseStream())
                                    {
                                        using (var sr = new StreamReader(stream))
                                        {
                                            callback(sr.ReadToEnd());
                                        }
                                    }
                            }
                        }
                        catch (Exception e) { callback(string.Empty); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e)); 
                             }
                        finally { httpWebRequest.Abort(); }
                    }, null);
                }
            }
        }
        public void SendDataToServer(Action<string, string> callback)
        {
            lock (this)
            {
                System.Diagnostics.Stopwatch d = new System.Diagnostics.Stopwatch(); d.Start();
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
                byte[] byteArray = Encoding.ASCII.GetBytes(_postdata);

                //创建对url的请求  

                //基于apache服务器,IIS发布的则不需要  
                httpWebRequest.ServicePoint.Expect100Continue = false;
                //是否使用 Nagle 不使用 提高效率 
                httpWebRequest.ServicePoint.UseNagleAlgorithm = false;
                //最大连接数 
                httpWebRequest.ServicePoint.ConnectionLimit = 65500;
                //数据是否缓冲 false 提高效率  
                httpWebRequest.AllowWriteStreamBuffering = false;

                httpWebRequest.Referer = _refer;
                httpWebRequest.CookieContainer = _cookie;
                httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Headers["Accept-Language"] = "zh-CN";
                httpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
                httpWebRequest.Host = "kyfw.12306.cn";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Headers["Cache-Control"] = "no-cache";
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.Headers["X-Requested-With"] = "XMLHttpRequest";
               //httpWebRequest.Headers["Cache-Control"] = "no-cache";
                //httpWebRequest.AllowAutoRedirect = false;
                //协议方式  
                httpWebRequest.Method = _method;
                httpWebRequest.Timeout = 20000;
                httpWebRequest.Proxy = HttpWebRequest.GetSystemWebProxy();
                httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                //httpWebRequest.Proxy = MyWebProxy.Proxy;
                //忽略证书
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
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
                                            using (var webresponse = (HttpWebResponse) httpWebRequest.EndGetResponse(ar)
                                                )
                                            {
                                                if (webresponse.ContentEncoding.ToLower().Contains("gzip"))
                                                {
                                                    using (
                                                        GZipStream st = new GZipStream(webresponse.GetResponseStream(),
                                                            CompressionMode.Decompress))
                                                    {
                                                        using (StreamReader reader = new StreamReader(st, Encoding.UTF8)
                                                            )
                                                        {
                                                            if (webresponse.Headers["Age"] != null)
                                                            {
                                                                callback(reader.ReadToEnd(),
                                                                    (webresponse.Headers["Date"]));
                                                            }
                                                            else
                                                                callback(reader.ReadToEnd(), "false");
                                                        }
                                                    }
                                                }
                                                else if (webresponse.ContentEncoding.ToLower().Contains("deflate"))
                                                {
                                                    using (
                                                        DeflateStream stream =
                                                            new DeflateStream(webresponse.GetResponseStream(),
                                                                CompressionMode.Decompress))
                                                    {
                                                        using (
                                                            StreamReader reader = new StreamReader(stream, Encoding.UTF8)
                                                            )
                                                        {
                                                            if (webresponse.Headers["Age"] != null)
                                                            {
                                                                callback(reader.ReadToEnd(),
                                                                    (webresponse.Headers["Date"]));
                                                            }
                                                            else
                                                                callback(reader.ReadToEnd(), "false");
                                                        }
                                                    }
                                                }
                                                else
                                                    using (var stream = webresponse.GetResponseStream())
                                                    {
                                                        using (var sr = new StreamReader(stream))
                                                        {
                                                            if (webresponse.Headers["Age"] != null)
                                                            {
                                                                callback(sr.ReadToEnd(), (webresponse.Headers["Date"]));
                                                            }
                                                            else
                                                                callback(sr.ReadToEnd(), "false");
                                                        }
                                                    }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            callback(string.Empty, ""); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                                            
                                        }
                                        finally { httpWebRequest.Abort(); }
                                    }, null);
                                }
                            }
                            catch (Exception e) { callback(string.Empty, ""); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                             
                                httpWebRequest.Abort(); return;
                            }
                        }, null);
                    }
                    catch (Exception e) { callback(string.Empty, ""); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                     
                        httpWebRequest.Abort(); return;
                    }// 

                }
                else
                {
                    //异步返回html  
                    httpWebRequest.BeginGetResponse((ar) =>
                    {
                        try
                        {
                            using (var webresponse = (HttpWebResponse) httpWebRequest.EndGetResponse(ar))
                            {
                                if (webresponse.ContentEncoding.ToLower().Contains("gzip"))
                                {
                                    using (
                                        GZipStream st = new GZipStream(webresponse.GetResponseStream(),
                                            CompressionMode.Decompress))
                                    {
                                        using (StreamReader reader = new StreamReader(st, Encoding.UTF8))
                                        {
                                            d.Stop();
                                            if (webresponse.Headers["Age"] != null)
                                            {
                                                callback(reader.ReadToEnd(), (webresponse.Headers["Date"]));
                                            }
                                            else
                                                callback(reader.ReadToEnd(), "false");
                                        }
                                    }
                                }
                                else if (webresponse.ContentEncoding.ToLower().Contains("deflate"))
                                {
                                    using (
                                        DeflateStream stream = new DeflateStream(webresponse.GetResponseStream(),
                                            CompressionMode.Decompress))
                                    {
                                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                        {
                                            if (webresponse.Headers["Age"] != null)
                                            {
                                                callback(reader.ReadToEnd(), (webresponse.Headers["Date"]));
                                            }
                                            else
                                                callback(reader.ReadToEnd(), "false");
                                        }
                                    }
                                }
                                else
                                    using (var stream = webresponse.GetResponseStream())
                                    {
                                        using (var reader = new StreamReader(stream))
                                        {
                                            if (webresponse.Headers["Age"] != null)
                                            {
                                                callback(reader.ReadToEnd(), (webresponse.Headers["Date"]));
                                            }
                                            else
                                                callback(reader.ReadToEnd(), "false");
                                        }
                                    }
                            }
                        }
                        catch (Exception e)
                        {
                            callback(string.Empty, ""); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                            
                        }
                        finally { httpWebRequest.Abort(); }
                    }, null);
                }
            }
        }
        public void SendDataToServer(Action<string, CookieContainer> callback)
        {
            lock (this)
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
                byte[] byteArray = Encoding.ASCII.GetBytes(_postdata);

                //创建对url的请求  
                //基于apache服务器,IIS发布的则不需要  
                httpWebRequest.ServicePoint.Expect100Continue = false;
                //是否使用 Nagle 不使用 提高效率 
                httpWebRequest.ServicePoint.UseNagleAlgorithm = false;
                //最大连接数 
                httpWebRequest.ServicePoint.ConnectionLimit = 65500;
                //数据是否缓冲 false 提高效率  
                httpWebRequest.AllowWriteStreamBuffering = false;

                httpWebRequest.Referer = _refer;
                httpWebRequest.CookieContainer = _cookie;
                httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Headers["Accept-Language"] = "zh-CN";
                httpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
                httpWebRequest.Host = "kyfw.12306.cn";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Headers["Cache-Control"] = "no-cache";
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.Headers["X-Requested-With"] = "XMLHttpRequest";
                //httpWebRequest.Headers["Cache-Control"] = "no-cache";
                //协议方式  
                httpWebRequest.Method = _method;
                httpWebRequest.Timeout = 20000;
                httpWebRequest.Proxy = HttpWebRequest.GetSystemWebProxy();
                httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                //httpWebRequest.Proxy = MyWebProxy.Proxy;
                //忽略证书
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
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
                                            using (var webresponse = (HttpWebResponse) httpWebRequest.EndGetResponse(ar)
                                                )
                                            {
                                                if (webresponse.ContentEncoding.ToLower().Contains("gzip"))
                                                {
                                                    using (
                                                        GZipStream stream =
                                                            new GZipStream(webresponse.GetResponseStream(),
                                                                CompressionMode.Decompress))
                                                    {
                                                        using (
                                                            StreamReader reader = new StreamReader(stream, Encoding.UTF8)
                                                            )
                                                        {
                                                            callback(reader.ReadToEnd(), httpWebRequest.CookieContainer);
                                                        }
                                                    }
                                                }
                                                else if (webresponse.ContentEncoding.ToLower().Contains("deflate"))
                                                {
                                                    using (
                                                        DeflateStream stream =
                                                            new DeflateStream(webresponse.GetResponseStream(),
                                                                CompressionMode.Decompress))
                                                    {
                                                        using (
                                                            StreamReader reader = new StreamReader(stream, Encoding.UTF8)
                                                            )
                                                        {
                                                            callback(reader.ReadToEnd(), httpWebRequest.CookieContainer);
                                                        }
                                                    }
                                                }
                                                else
                                                    using (var stream = webresponse.GetResponseStream())
                                                    {
                                                        using (var sr = new StreamReader(stream))
                                                        {
                                                            callback(sr.ReadToEnd(), httpWebRequest.CookieContainer);
                                                        }
                                                    }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            callback(string.Empty, new CookieContainer());
                                            new LogInfo().WriteLine(
                                                String.Format(
                                                    "WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}",
                                                    e.Message, e.Source, e));
                                            
                                        }
                                        finally
                                        {
                                            httpWebRequest.Abort();
                                        }
                                    }, null);
                                }
                            }
                            catch (Exception e)
                            {
                                callback(string.Empty, new CookieContainer());
                                new LogInfo().WriteLine(
                                    String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message,
                                        e.Source, e));
                                
                                httpWebRequest.Abort();
                                return;
                            }
                        }, null);
                    }
                    catch (Exception e)
                    {
                        callback(string.Empty, new CookieContainer()); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                        
                    }

                }
                else
                {
                    //异步返回html  
                    httpWebRequest.BeginGetResponse((ar) =>
                    {
                        try
                        {
                            using (var webresponse = (HttpWebResponse) httpWebRequest.EndGetResponse(ar))
                            {
                                if (webresponse.ContentEncoding.ToLower().Contains("gzip"))
                                {
                                    using (
                                        GZipStream stream = new GZipStream(webresponse.GetResponseStream(),
                                            CompressionMode.Decompress))
                                    {
                                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                        {
                                            callback(reader.ReadToEnd(), httpWebRequest.CookieContainer);
                                        }
                                    }
                                }
                                else if (webresponse.ContentEncoding.ToLower().Contains("deflate"))
                                {
                                    using (
                                        DeflateStream stream = new DeflateStream(webresponse.GetResponseStream(),
                                            CompressionMode.Decompress))
                                    {
                                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                                        {
                                            callback(reader.ReadToEnd(), httpWebRequest.CookieContainer);
                                        }
                                    }
                                }
                                else
                                    using (var stream = webresponse.GetResponseStream())
                                    {
                                        using (var sr = new StreamReader(stream))
                                        {
                                            callback(sr.ReadToEnd(), httpWebRequest.CookieContainer);
                                        }
                                    }
                            }
                        }
                        catch (Exception e)
                        {
                            callback(string.Empty, new CookieContainer()); new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                            
                        }
                        finally { httpWebRequest.Abort(); }
                    }, null);
                }
            }
        }
        public string SendDataToServer()
        {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
                byte[] byteArray = Encoding.ASCII.GetBytes(_postdata);
                string responseFromServer = "";
                //创建对url的请求  
                //基于apache服务器,IIS发布的则不需要  
                httpWebRequest.ServicePoint.Expect100Continue = false;
                //是否使用 Nagle 不使用 提高效率 
                httpWebRequest.ServicePoint.UseNagleAlgorithm = false;
                //最大连接数 
                httpWebRequest.ServicePoint.ConnectionLimit = 65500;
                //数据是否缓冲 false 提高效率  
                httpWebRequest.AllowWriteStreamBuffering = false;

                httpWebRequest.Referer = _refer;
                httpWebRequest.CookieContainer = _cookie;
                httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Headers["Accept-Language"] = "zh-CN";
                httpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
                httpWebRequest.Host = "kyfw.12306.cn";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.Headers["Cache-Control"] = "no-cache";
                httpWebRequest.AllowAutoRedirect = true;
                httpWebRequest.Headers["X-Requested-With"] = "XMLHttpRequest";
                //httpWebRequest.Headers["Cache-Control"] = "no-cache";
                //协议方式  
                httpWebRequest.Method = _method;
                httpWebRequest.Timeout = 20000;
                httpWebRequest.Proxy = HttpWebRequest.GetSystemWebProxy();
                httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
                httpWebRequest.AllowAutoRedirect = false;
                //忽略证书
                ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
                {
                    return true;
                };
            try
            {
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

                //返回html  
                HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();

                /*
                System.Web.SessionState.HttpSessionState mys=Syste HttpContext.Current.Session; 
                但是有种情况就是用到了AJAX的话在返回的方法中调用就会有问题所以要有小的改动

                [AjaxMethod]
                [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]*/
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    if (httpWebResponse.ContentEncoding.ToLower().Contains("gzip"))
                    {
                        using (
                            GZipStream stream = new GZipStream(httpWebResponse.GetResponseStream(),
                                CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                responseFromServer = reader.ReadToEnd();
                            }
                        }
                    }
                    else if (httpWebResponse.ContentEncoding.ToLower().Contains("deflate"))
                    {
                        using (
                            DeflateStream stream = new DeflateStream(httpWebResponse.GetResponseStream(),
                                CompressionMode.Decompress))
                        {
                            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                            {
                                responseFromServer = reader.ReadToEnd();
                            }
                        }
                    }
                    else
                    {
                        StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.UTF8);
                        //读取响应流  
                        responseFromServer = reader.ReadToEnd(); //读响应流html
                        reader.Close();
                    }
                    httpWebResponse.Close();
                }
            }
            catch (Exception e)
            {
                new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                
            }
            return responseFromServer;
        }
        public Hashtable SendDataToServerHash()
        {
            var hash = new Hashtable();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(_url);
            byte[] byteArray = Encoding.ASCII.GetBytes(_postdata);
            string responseFromServer = "";
            //创建对url的请求  
            //基于apache服务器,IIS发布的则不需要  
            httpWebRequest.ServicePoint.Expect100Continue = false;
            //是否使用 Nagle 不使用 提高效率 
            httpWebRequest.ServicePoint.UseNagleAlgorithm = false;
            //最大连接数 
            httpWebRequest.ServicePoint.ConnectionLimit = 65500;
            //数据是否缓冲 false 提高效率  
            httpWebRequest.AllowWriteStreamBuffering = false;

            httpWebRequest.Referer = _refer;
            httpWebRequest.CookieContainer = _cookie;
            httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Headers["Accept-Language"] = "zh-CN";
            httpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)";
            httpWebRequest.Host = "kyfw.12306.cn";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Headers["Cache-Control"] = "no-cache";
            httpWebRequest.AllowAutoRedirect = true;
            httpWebRequest.Headers["X-Requested-With"] = "XMLHttpRequest";
            //httpWebRequest.Headers["Cache-Control"] = "no-cache";
            //协议方式  
            httpWebRequest.Method = _method;
            httpWebRequest.Timeout = 20000;
            httpWebRequest.Proxy = HttpWebRequest.GetSystemWebProxy();
            httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
            httpWebRequest.AllowAutoRedirect = false;
            //忽略证书
            ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;
            };
            try
            {
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

                //返回html  
                var httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();

                /*
                System.Web.SessionState.HttpSessionState mys=Syste HttpContext.Current.Session; 
                但是有种情况就是用到了AJAX的话在返回的方法中调用就会有问题所以要有小的改动

                [AjaxMethod]
                [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]*/
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream(),
                        Encoding.GetEncoding("utf-8"));
                    //读取响应流  
                    responseFromServer = reader.ReadToEnd(); //读响应流html
                    reader.Close();
                    httpWebResponse.Close();
                }
            }
            catch (Exception e)
            {
                new LogInfo().WriteLine(String.Format("WebRequestHelper Catch:{0}\r\nSource:{1}\r\nException:{2}", e.Message, e.Source, e));
                
            }
            hash.Add(httpWebRequest.CookieContainer, responseFromServer);
            return hash;
        }
        private HttpWebRequest GetNewRequest(string targetUrl, string referer, CookieContainer _cookie)
        {
            var httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(targetUrl);
            httpWebRequest.ServicePoint.Expect100Continue = false;
            //是否使用 Nagle 不使用 提高效率 
            httpWebRequest.ServicePoint.UseNagleAlgorithm = false;
            //最大连接数 
            httpWebRequest.ServicePoint.ConnectionLimit = 65500;
            //数据是否缓冲 false 提高效率  
            httpWebRequest.AllowWriteStreamBuffering = false;

            httpWebRequest.Referer = referer;
            httpWebRequest.CookieContainer = _cookie;
            httpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
            httpWebRequest.Accept = "text/html, application/xhtml+xml, */*";
            httpWebRequest.Headers["Accept-Language"] = "zh-CN";
            httpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.KeepAlive = false;
            //httpWebRequest.Headers["Cache-Control"] = "no-cache";
            //协议方式  
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 20000;
            httpWebRequest.Proxy = HttpWebRequest.GetSystemWebProxy();
            httpWebRequest.Proxy.Credentials = CredentialCache.DefaultCredentials;
            httpWebRequest.AllowAutoRedirect = false;
            return httpWebRequest;
        }
    }
}
