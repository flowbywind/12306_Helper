using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aNyoNe.AutoServerSwitch
{
    public class CDNSwitcher
    {
        public static List<Object_IP> CDN_List = new List<Object_IP>();
        public static int _index = -1;
        private const string _domain = "kyfw.12306.cn";
        private HostAction hostAction;

        public CDNSwitcher()
        {
            if(hostAction==null)
                hostAction = new HostAction(Environment.SystemDirectory + "\\drivers\\etc\\hosts");
            if (CDN_List.Count > 0)
                _index = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objp">手动切换的IP对象，自动切换请置空</param>
        /// <param name="callback"></param>
        /// <param name="flag">手否是手动切换</param>
        public void AutoSwitchCDN(Object_IP objp, Action<string> callback, bool flag = false)
        {
            if (_index == -1)
                _index = 0;
            if (flag)
            {
                objp.HttpSetSpeed();
                //if (objp.Speed != null)
                //{
                    hostAction.AddDnsResolve(objp.Ip, _domain);
                    callback(string.Format("自动切换完成 [{0}]", objp.Ip));
                //}
            }
            else
            {
                if (CDN_List.Count <= 0)
                {
                    callback("没有可以切换的服务器...");
                    return;
                }
                for (int i = _index; i < CDN_List.Count; i++)
                {
                    var obj = new Object_IP();
                    obj.Ip = CDN_List[i].Ip;
                    //obj.HttpSetSpeed();
                    _index++;

                    //if (obj.Speed != null)
                    //{
                        hostAction.AddDnsResolve(obj.Ip, _domain);
                        callback(string.Format("自动切换完成 [{0}] ", obj.Ip));
                        break;
                    //}
                }
                if (_index >= CDN_List.Count/2)
                    _index = 0;
            }
        }

        public void SwitchCDN(string ip,string domain,Action<string> callback )
        {
            var _ip = new Object_IP() { Ip = ip};
            ServerSwitch( _ip,domain, (objip) =>
            {
                callback(string.Format("自动切换完成 [{0}] ,响应速度={1}秒",  objip.Ip, objip.Speed.Value.TotalSeconds.ToString("#0.00") ));
            },true);
        }

        /// <summary>
        /// 切换服务器
        /// </summary>
        /// <param name="objp">切换前的服务器</param>
        /// <param name="callback">切换后的服务器</param>
        private void ServerSwitch( Object_IP objp,string domain, Action<Object_IP> callback, bool flag = false)
        {
            hostAction.AddDnsResolve(objp.Ip, domain);
        }
    }
}
