using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using aNyoNe.GetInfoFrom12306;

namespace _12306_Helper
{
    class SortClass
    {
        /// <summary>
        /// 为BindingList排序
        /// </summary>
        /// <param name="data">BindingList数据源</param>
        /// <param name="sortTable">记录排序信息的哈希表</param>
        /// <param name="col">要排序的列编号</param>
        /// <returns></returns>
        public static BindingList<JsonTrainData> SortTrainDataSource(BindingList<JsonTrainData> data, Hashtable sortTable, int col)
        {
            try
            {
                switch (col)
                {
                    case 0:
                        {
                            if ((SortOrder)sortTable["Train_no"] == SortOrder.None || (SortOrder)sortTable["Train_no"] == SortOrder.Descending)
                            {
                                sortTable["Train_no"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Train_no).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Train_no"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Train_no).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 2:
                        {
                            if ((SortOrder)sortTable["Start_time"] == SortOrder.None || (SortOrder)sortTable["Start_time"] == SortOrder.Descending)
                            {
                                sortTable["Start_time"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Start_time).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Start_time"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Start_time).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 4:
                        {
                            if ((SortOrder)sortTable["Arrive_time"] == SortOrder.None || (SortOrder)sortTable["Arrive_time"] == SortOrder.Descending)
                            {
                                sortTable["Arrive_time"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Arrive_time).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Arrive_time"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Arrive_time).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 5:
                        {
                            if ((SortOrder)sortTable["Lishi"] == SortOrder.None || (SortOrder)sortTable["Lishi"] == SortOrder.Descending)
                            {
                                sortTable["Lishi"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Lishi).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Lishi"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Lishi).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 6:
                        {
                            if ((SortOrder)sortTable["Swz_num"] == SortOrder.None || (SortOrder)sortTable["Swz_num"] == SortOrder.Descending)
                            {
                                sortTable["Swz_num"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Swz_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Swz_num"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Swz_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 7:
                        {
                            if ((SortOrder)sortTable["Tz_num"] == SortOrder.None || (SortOrder)sortTable["Tz_num"] == SortOrder.Descending)
                            {
                                sortTable["Tz_num"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Tz_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Tz_num"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Tz_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 8:
                        {
                            if ((SortOrder)sortTable["Zy_num"] == SortOrder.None || (SortOrder)sortTable["Zy_num"] == SortOrder.Descending)
                            {
                                sortTable["Zy_num"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Zy_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Zy_num"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Zy_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 9:
                        {
                            if ((SortOrder)sortTable["Ze_num"] == SortOrder.None || (SortOrder)sortTable["Ze_num"] == SortOrder.Descending)
                            {
                                sortTable["Ze_num"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Ze_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Ze_num"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Ze_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 10:
                        {
                            if ((SortOrder)sortTable["Gr_num"] == SortOrder.None || (SortOrder)sortTable["Gr_num"] == SortOrder.Descending)
                            {
                                sortTable["Gr_num"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Gr_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Gr_num"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Gr_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 11:
                        {
                            if ((SortOrder)sortTable["Rw_num"] == SortOrder.None || (SortOrder)sortTable["Rw_num"] == SortOrder.Descending)
                            {
                                sortTable["Rw_num"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Rw_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Rw_num"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Rw_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 12:
                        {
                            if ((SortOrder)sortTable["Yw_num"] == SortOrder.None || (SortOrder)sortTable["Yw_num"] == SortOrder.Descending)
                            {
                                sortTable["Yw_num"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Yw_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Yw_num"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Yw_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 13:
                        {
                            if ((SortOrder)sortTable["Rz_num"] == SortOrder.None || (SortOrder)sortTable["Rz_num"] == SortOrder.Descending)
                            {
                                sortTable["Rz_num"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Rz_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Rz_num"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Rz_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 14:
                        {
                            if ((SortOrder)sortTable["Yz_num"] == SortOrder.None || (SortOrder)sortTable["Yz_num"] == SortOrder.Descending)
                            {
                                sortTable["Yz_num"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Yz_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Yz_num"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Yz_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            break;
                        }
                    case 15:
                        {
                            if ((SortOrder)sortTable["Wz_num"] == SortOrder.None || (SortOrder)sortTable["Wz_num"] == SortOrder.Descending)
                            {
                                sortTable["Wz_num"] = SortOrder.Ascending;
                                data = new BindingList<JsonTrainData>(data.OrderBy(x => x.QueryLeftNewDto.Wz_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            else
                            {
                                sortTable["Wz_num"] = SortOrder.Descending;
                                data = new BindingList<JsonTrainData>(data.OrderByDescending(x => x.QueryLeftNewDto.Wz_num, new ReverseStringComparer()).ToList<JsonTrainData>());
                            }
                            break;
                        }
                }
            }
            catch
            {
                
            }
            return data;
        }
    }

    public class ReverseStringComparer : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            //默认排序为“--”最大“无”最小，其他数值转成整数比较大小
            if (s1 == "--")
            {
                if (s2 == "--")
                    return 0;
                return 1;
            }
            if (s1 == "无")
            {
                if (s2 == "无")
                    return 0;
                return -1;
            }
            if (s1 == "*")
            {
                if (s2 == "*")
                    return 0;
                return -1;
            }
            if (s2 == "--")
                return -1;
            if (s2 == "无")
                return 1;
            if (s2 == "*")
                return 1;

            int result = 0;
            try
            {
                int i = Convert.ToInt32(s1) - Convert.ToInt32(s2);
                if (i > 0)
                    result = 1;
                else if (i == 0)
                    result = 0;
                else
                    result = -1;
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        
    }
}
