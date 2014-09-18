﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace aNyoNe.AutoServerSwitch
{
    public class GetIPList
    {
        /// <summary>
        /// 通过URL地址获取IP
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static List<Object_IP> GetSourceList(string url)
        {
            List<Object_IP> list = new List<Object_IP>();
            WebClient wc = new WebClient();
            string strip = wc.DownloadString(url);
            strip = strip.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace("(", "").Replace(")", "").Replace(" ", "").Replace("\r\n", "");
            string[] tmpstr = strip.Split(new string[]{"|",","},StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tmpstr.Length; i++)
            {
                var ip = new Object_IP() { Ip = tmpstr[i] };
                list.Add(ip);
            }
            return list;
        }
        /// <summary>
        /// 通过URL地址获取IP 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static List<Object_Server> GetSourceList1(string url)
        {
            var list = new List<Object_Server>();
            var wc = new WebClient();
            try
            {
                list = JsonConvert.DeserializeObject<List<Object_Server>>(wc.DownloadString(url));
            }
            catch {
                return null;
            }
            list.ForEach((item) =>
            {
                item.ServerSpeed = item.LocalSpeed;
                item.LocalSpeed = 0;
            });
            return list;
        }
    }
}
