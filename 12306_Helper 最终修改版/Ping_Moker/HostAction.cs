using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PingMock
{
    public class HostAction
    {
        private object privateLocker = new object();
        /// <summary>
        /// 初始化Hosts
        /// </summary>
        public static string str =  @"# Copyright (c) 1993-2009 Microsoft Corp.
#
# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
#
# This file contains the mappings of IP addresses to host names. Each
# entry should be kept on an individual line. The IP address should
# be placed in the first column followed by the corresponding host name.
# The IP address and the host name should be separated by at least one
# space.
#
# Additionally, comments (such as these) may be inserted on individual
# lines or following the machine name denoted by a '#' symbol.
#
# For example:
#
#      102.54.94.97     rhino.acme.com          # source server
#       38.25.63.10     x.acme.com              # x client host

# localhost name resolution is handled within DNS itself.
#	127.0.0.1       localhost
#	::1             localhost";
        
        /// <summary>
        /// 默认的Hosts文件路径
        /// </summary>
        private string _path = Environment.SystemDirectory + "\\drivers\\etc\\hosts";
        
        /// <summary>
        /// 设置文件路径
        /// </summary>
        /// <param name="path">文件路径</param>
        public void SetPath(string path)
        {
            this._path = path;
        }

        public string Path
        {
            get { return this._path; }
            private set { this._path = value; }
        }

        public HostAction(string path)
        {
            SetPath(path);
            str = ReadFile(path);
            InitDnsResolve();
        }

        /// <summary>
        /// 添加解析IP和域名
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="domain"></param>
        public void InitDnsResolve()
        {
            lock (privateLocker)
            {
                bool flag = false;
                if (ReadFile(this.Path).IndexOf("# aNyoNe Hosts modified mark") > -1)
                    flag = true;
                if (!flag)
                {
                    using (StreamWriter sw = new StreamWriter(this.Path, true, Encoding.Default))
                    {
                        sw.WriteLine(sw.NewLine + "# aNyoNe Hosts modified mark");
                    }
                }
            }
        }

        /// <summary>
        /// 初始化文件
        /// </summary>
        public void InitHosts()
        {
            lock (privateLocker)
            {
                using (StreamWriter sw = new StreamWriter(this.Path, false, Encoding.Default))
                {
                    sw.Write(@"# Copyright (c) 1993-2009 Microsoft Corp.
#
# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
#
# This file contains the mappings of IP addresses to host names. Each
# entry should be kept on an individual line. The IP address should
# be placed in the first column followed by the corresponding host name.
# The IP address and the host name should be separated by at least one
# space.
#
# Additionally, comments (such as these) may be inserted on individual
# lines or following the machine name denoted by a '#' symbol.
#
# For example:
#
#      102.54.94.97     rhino.acme.com          # source server
#       38.25.63.10     x.acme.com              # x client host

# localhost name resolution is handled within DNS itself.
#	127.0.0.1       localhost
#	::1             localhost");
                }
            }
        }

        /// <summary>
        /// 恢复Host文件
        /// </summary>
        public void RestoreHosts()
        {
            lock (privateLocker)
            {
                StringBuilder sb = new StringBuilder();
                string tmp = "";
                using (StreamReader sr = new StreamReader(this.Path, Encoding.Default))
                {
                    while (sr.Peek() > -1)
                    {
                        tmp = sr.ReadLine();
                        if (tmp.IndexOf("# aNyoNe") > -1)
                            break;
                        else
                            sb.AppendLine(tmp);
                    }
                }
                using (StreamWriter sw = new StreamWriter(this.Path, false, Encoding.Default))
                {
                    sw.Write(sb.ToString().Replace("\r\n\r\n\r\n", ""));
                }
            }
        }

        /// <summary>
        /// 添加解析IP和域名
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="domain"></param>
        public void AddDnsResolve(string ip,string domain)
        {
            lock (privateLocker)
            {
                if (!ExistEx(domain))
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(this.Path, true, Encoding.Default))
                        {
                            sw.WriteLine(ip + " " + domain);
                        }
                    }
                    catch { RestoreHosts(); }
                }
                else
                    ModifyDnsResolve(ip, domain);
            }
        }

        /// <summary>
        /// 修改解析IP和域名
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="domain"></param>
        public void ModifyDnsResolve(string ip, string domain)
        {
            lock (privateLocker)
            {
                if (ExistEx(domain))
                {
                    try
                    {
                        string tmpstr = "";
                        using (StreamReader sr = new StreamReader(this.Path, Encoding.Default))
                        {
                            while (sr.Peek() > -1)
                            {
                                tmpstr = sr.ReadLine();
                                if (tmpstr.IndexOf(domain) > -1)
                                {
                                    break;
                                }
                            }
                        }
                        if (tmpstr != "")
                        {
                            string strHost = ReadFile(this.Path);
                            using (StreamWriter sw = new StreamWriter(this.Path, false, Encoding.Default))
                            {
                                sw.Write(strHost.Replace(tmpstr, ip + " " + domain));
                            }
                        }
                    }
                    catch { RestoreHosts(); }
                }
            }
        }

        /// <summary>
        /// 获取本地指定域名的解析服务器
        /// </summary>
        /// <param name="domain">域名</param>
        /// <returns></returns>
        public string GetCacheServerIP(string domain)
        {
            lock (privateLocker)
            {
                if (ExistEx(domain))
                {
                    try
                    {
                        string tmpstr = "";
                        using (StreamReader sr = new StreamReader(this.Path, Encoding.Default))
                        {
                            while (sr.Peek() > -1)
                            {
                                tmpstr = sr.ReadLine();
                                if (tmpstr.IndexOf(domain) > -1)
                                {
                                    return tmpstr;
                                }
                            }
                        }
                    }
                    catch { return ""; }
                }
                return "";
            }
        }

        /// <summary>
        /// 删除解析IP和域名
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="domain"></param>
        public void DeleteDnsResolve(string ip, string domain)
        {
            lock (privateLocker)
            {
                if (ExistEx(domain))
                {
                    try
                    {
                        string str = ReadFile(this.Path);
                        using (StreamWriter sw = new StreamWriter(this.Path, false, Encoding.Default))
                        {
                            sw.Write(str.Replace("\r\n" + ip + " " + domain, ""));
                        }
                    }
                    catch { RestoreHosts(); }
                }
            }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        private string ReadFile(string path)
        {
            lock (privateLocker)
            {
                string str = "";
                using (StreamReader sr = new StreamReader(this.Path, Encoding.Default))
                {
                    str = sr.ReadToEnd();
                }
                return str;
            }
        }

        private bool ExistEx(string domain)
        {
            lock (privateLocker)
            {
                string str = "";
                using (StreamReader sr = new StreamReader(this.Path, Encoding.Default))
                {
                    str = sr.ReadToEnd();
                }

                if (str.IndexOf(domain) > -1)
                    return true;
                return false;
            }
        }
    }
}
