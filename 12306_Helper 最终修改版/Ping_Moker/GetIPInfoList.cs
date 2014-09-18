using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;

namespace PingMock
{
    public class GetIPInfoList
    {

        /// <summary>
        /// 返回前N条数据
        /// </summary>
        /// <param name="n">返回数量</param>
        /// <param name="lst">列表</param>
        /// <returns>返回List<Object_IP></returns>
        public void GetTopN(int n,List<Object_IP> lst,Action< List<Object_IP>> callback)
        {
            List<Object_IP> tmpList = new List<Object_IP>();
            for (int i = 0; i < (lst.Count >= n ? n : lst.Count); i++)
            {
                tmpList.Add(lst[i]);
            }

            Parallel.ForEach(tmpList, (item) =>
            {
                item.HttpSetSpeed();
            });

            callback(tmpList);
        }
        /// <summary>
        /// 返回列表中速度最快的一个IP对象
        /// </summary>
        /// <param name="list">IP列表</param>
        /// <returns>返回Object_IP</returns>
        public Object_IP GetFastestIP(List<Object_IP> list)
        {
            List<Object_IP> lst = new List<Object_IP>();
            lst = list.Where(item => item.Speed != null).Select(x => x).ToList<Object_IP>();
            lst.Sort(CompareSpeedAsc);
            return lst[0] as Object_IP;
        }
        /// <summary>
        /// 获取ip信息列表
        /// </summary>
        /// <param name="url">获取IP的地址</param>
        /// <param name="sort">排序方式</param>
        /// <returns>返回List<Object_IP></returns>
        public void GetSourceList(Action<List<Object_IP>> callback,string url, SortOrder sort = SortOrder.Ascending)
        {
            List<Object_IP> list = GetIPList.GetSourceList(url);
            Parallel.ForEach(list, (item) =>
            {
                item.HttpSetSpeed();

            });
            switch (sort)
            {
                case SortOrder.Ascending:
                    {
                        list.Sort(CompareSpeedAsc);
                        break;
                    }
                case SortOrder.Descending:
                    {
                        list.Sort(CompareSpeedDesc);
                        break;
                    }
                case SortOrder.Unspecified:
                    {
                        break;
                    }
            }
            list = list.Where(item => item.Speed != null && !item.Ip.StartsWith("127")).Select(x => x).ToList<Object_IP>();
            callback(list);
        }
        /// <summary>
        /// 逐条返回信息
        /// </summary>
        /// <param name="callback">返回的Object_IP对象</param>
        /// <param name="url">获取信息的URL</param>
        public void GetSourceItem(Action<Object_IP> callback, string url)
        {
            List<Object_IP> list = GetIPList.GetSourceList(url);
            Parallel.ForEach(list, (item) =>
            {
                item.HttpSetSpeed();
                callback(item);
            });
        }
        /// <summary>
        /// 逐条返回信息
        /// </summary>
        /// <param name="callback">返回的Object_IP对象</param>
        /// <param name="url">获取信息的URL</param>
        public List<Object_Server> GetSourceItem(string url)
        {
            List<Object_Server> list = GetIPList.GetSourceList1(url);
            return list;
        }

        public void GetListItem(List<Object_Server> list,Action<Object_IP> callbackIP)
        {
            List<Object_IP> listIP = new List<Object_IP>();
            list.ForEach(item =>
            {
                Object_IP o = new Object_IP();
                o.Ip = item.Ip;
                listIP.Add(o);
            });

            Parallel.ForEach(listIP, (item) =>
            {
                item.HttpSetSpeed();
                callbackIP(item);
            });
        }

        /// <summary>
        /// 获取ip信息列表
        /// </summary>
        /// <param name="lst">Ip列表</param>
        /// <param name="sort">排序方式</param>
        /// <returns>返回List<Object_IP></returns>
        public void GetSourceList(Action<List<Object_IP>> callback,List<Object_IP> lst, SortOrder sort = SortOrder.Ascending)
        {
            List<Object_IP> list = lst;
            Parallel.ForEach(list, (item) =>
            {
                item.HttpSetSpeed();
            });
            switch (sort)
            {
                case SortOrder.Ascending:
                    {
                        list.Sort(CompareSpeedAsc);
                        break;
                    }
                case SortOrder.Descending:
                    {
                        list.Sort(CompareSpeedDesc);
                        break;
                    }
                case SortOrder.Unspecified:
                    {
                        break;
                    }
            }
            list = list.Where(item => item.Speed != null && !item.Ip.StartsWith("127")).Select(x => x).ToList<Object_IP>();
            callback(list);
        }

        public void SortList(Action<List<Object_IP>> callback, List<Object_IP> lst, SortOrder sort = SortOrder.Ascending)
        {
            List<Object_IP> list = lst;
            switch (sort)
            {
                case SortOrder.Ascending:
                    {
                        list.Sort(CompareSpeedAsc);
                        break;
                    }
                case SortOrder.Descending:
                    {
                        list.Sort(CompareSpeedDesc);
                        break;
                    }
                case SortOrder.Unspecified:
                    {
                        break;
                    }
            }
            list = list.Where(item => item.Speed != null && !item.Ip.StartsWith("127")).Select(x => x).ToList<Object_IP>();
            callback(list);
        }

        /// <summary>
        /// 按降序排序，空值默认为最小
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        private int CompareSpeedDesc(Object_IP o1, Object_IP o2)
        {
            if (o1.Speed == null)
            {
                if (o2.Speed == null)
                {
                    return 0;
                }
                return 1;
            }
            if (o2.Speed == null)
            {
                return -1;
            }
            int retval = o2.Speed.Value.CompareTo(o1.Speed.Value);
            return retval;
        }
        /// <summary>
        /// 按升序排列，空值默认为最大
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        private int CompareSpeedAsc(Object_IP o1, Object_IP o2)
        {
            if (o1.Speed == null)
            {
                if (o2.Speed == null)
                {
                    return 0;
                }
                return 1;
            }
            if (o2.Speed == null)
            {
                return -1;
            }
            int retval = o1.Speed.Value.CompareTo(o2.Speed.Value);
            return retval;
        }

        public enum SortOrder
        { 
            [Description("升序")]
            Ascending,
            [Description("降序")]
            Descending,
            [Description("默认")]
            Unspecified
        }
    }
}
