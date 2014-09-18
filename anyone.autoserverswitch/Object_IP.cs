using System;
using System.Diagnostics;
using System.Net;

namespace aNyoNe.AutoServerSwitch
{
    [Serializable]
    public class Object_IP
    {
        private string ip;
        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip
        {
            get
            {
                return this.ip;
            }
            set
            {
                this.ip = value;
            }
        }
        /// <summary>
        /// 无效的IP
        /// </summary>
        public bool IsNotValid
        {
            get;
            set;
        }
        /// <summary>
        /// 被禁止
        /// </summary>
        public bool IsForbidden
        {
            get;
            set;
        }
        /// <summary>
        /// IP异常信息
        /// </summary>
        public string Message
        {
            get;
            set;
        }
        /// <summary>
        /// IP延迟
        /// </summary>
        public TimeSpan? Speed
        {
            get;
            set;
        }

        public void HttpSetSpeed()
        {
            this.IsNotValid = false;
            this.IsForbidden = false;
            this.Message = null;
            TimeSpan? nullable = null;
            this.Speed = nullable;
            Stopwatch stopwatch = new Stopwatch();
            HttpWebRequest httpWebRequest = WebRequest.Create(string.Format("https://{0}/otn/", this.Ip)) as HttpWebRequest;
            httpWebRequest.Host = "kyfw.12306.cn";
            httpWebRequest.Timeout = 3500;
            //忽略证书
            ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) =>
            {
                return true;
            };
            stopwatch.Start();
            HttpWebResponse response = null;
            try
            {
                try
                {
                    response = httpWebRequest.GetResponse() as HttpWebResponse;
                }
                catch (WebException webException1)
                {
                    WebException webException = webException1;
                    response = webException.Response as HttpWebResponse;
                    if (response == null || response.StatusCode != HttpStatusCode.Forbidden)
                    {
                        this.IsNotValid = true;
                    }
                    else
                    {
                        this.IsForbidden = true;
                    }
                    this.Message = webException.Message;
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    this.IsNotValid = true;
                    this.Message = exception.Message;
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            stopwatch.Stop();
            if (!this.IsForbidden && !this.IsNotValid)
            {
                this.Speed = new TimeSpan?(stopwatch.Elapsed);
            }
        }
        /// <summary>
        /// 测IP延迟
        /// </summary>
        //public void SetSpeed()
        //{
        //    Stopwatch span = new Stopwatch();
        //    ManagementObjectSearcher mos = null;
        //    ManagementObjectCollection moc = null;

        //    try
        //    {
        //        string searchString = string.Format("select * from win32_PingStatus where Address = '{0}'", this.Ip);

        //        mos = new ManagementObjectSearcher(searchString);
        //        moc = mos.Get();

        //        foreach (ManagementObject mo in moc)
        //        {
        //            object obj = mo.Properties["StatusCode"].Value;
        //            object str = mo.Properties["ResponseTime"].Value;

        //            if (obj == null)
        //            {
        //                lock (thisobject)
        //                {
        //                    this.IsNotValid = true;
        //                    this.Message = "PING 执行失败。可能是主机未知。";
        //                }
        //            }
        //            else
        //            {
        //                if (obj.ToString().Trim() == "0")
        //                {
        //                    this.Message = "可用";
        //                    this.Speed = new TimeSpan?(new TimeSpan(Convert.ToInt64(str)));
        //                    break;
        //                }
        //                lock (thisobject)
        //                {
        //                    this.IsForbidden = true;
        //                    this.Message = "PING 不通!";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.Message = ex.Message;
        //    }
        //    finally
        //    {
        //        if (moc != null) moc.Dispose();
        //        if (mos != null) mos.Dispose();
        //    }
        //}
    }
}
