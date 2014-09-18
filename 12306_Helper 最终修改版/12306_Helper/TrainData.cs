using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _12306_Helper
{
    [Serializable]
    public class TrainData
    {
        /// <summary>
        /// 发站名
        /// </summary>
        public string From_station_name { get; private set; }
        /// <summary>
        /// 发车时间
        /// </summary>
        public string Start_time { get; private set; }
        /// <summary>
        /// 到站名
        /// </summary>
        public string To_station_name { get; private set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public string Arrive_time { get; private set; }
        /// <summary>
        /// 历时
        /// </summary>
        public string Cost_time { get; private set; }
        /// <summary>
        /// 坐席表
        /// </summary>
        public Dictionary<string, string> SeatCounters { get; private set; }
        /// <summary>
        /// 坐席名称描述
        /// </summary>
        public string Seat_Description{ get; private set; }
        /// <summary>
        /// 发站编号
        /// </summary>
        public string From_station_no{ get; private set; }
        /// <summary>
        /// 发站名的电报码
        /// </summary>
        public string From_station_telecode{ get; private set; }
        /// <summary>
        /// 发站名
        /// </summary>
        public string From_station_telecode_name{ get; private set; }
        /// <summary>
        /// 到站编号
        /// </summary>
        public string To_station_no{ get; private set; }
        /// <summary>
        /// 到站名
        /// </summary>
        public string To_station_telecode_name{ get; private set; }
        /// <summary>
        /// 火车车次号
        /// </summary>
        public string Station_train_code{ get; private set; }
        /// <summary>
        /// 到站名的电报码
        /// </summary>
        public string To_station_telecode{ get; private set; }
        /// <summary>
        /// 发车日期
        /// </summary>
        public string Train_date { get;set; }
        /// <summary>
        /// 本地编码
        /// </summary>
        public string LocationCode{ get; private set; }
        /// <summary>
        /// 防重复提交验证码
        /// </summary>
        public string mmStr{ get; private set; }
        /// <summary>
        /// 车次编号
        /// </summary>
        public string Trainno4 { get; private set; }
        /// <summary>
        /// 余票信息字符串
        /// </summary>
        public string ypInfoDetail { get; private set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string UpdateTime { get; private set; }
        /// <summary>
        /// 对象集合
        /// </summary>
        public string[] Tag { get; private set; }
        /// <summary>
        /// 是否可以预定
        /// </summary>
        public bool Bookable { get; private set; }
        /// <summary>
        /// 是否为默认列表不存在的坐席
        /// </summary>
        public Dictionary<string, string> SpecialSeatType { get; private set; }
        /// <summary>
        /// 无座
        /// </summary>
        public string _0seat{ get; private set; }
        /// <summary>
        /// 硬座
        /// </summary>
        public string _1seat{ get; private set; }
        /// <summary>
        /// 软座
        /// </summary>
        public string _2seat{ get; private set; }
        /// <summary>
        /// 硬卧
        /// </summary>
        public string _3seat{ get; private set; }
        /// <summary>
        /// 软卧
        /// </summary>
        public string _4seat{ get; private set; }
        /// <summary>
        /// 高级软卧
        /// </summary>
        public string _6seat{ get; private set; }
        /// <summary>
        /// 二等座
        /// </summary>
        public string _Oseat{ get; private set; }
        /// <summary>
        /// 一等座
        /// </summary>
        public string _Mseat{ get; private set; }
        /// <summary>
        /// 特等座
        /// </summary>
        public string _Pseat{ get; private set; }
        /// <summary>
        /// 商务座
        /// </summary>
        public string _9seat{ get; private set; }
        private Hashtable tmpHash = new Hashtable();
        private string[] tmpSeat;//传递余票信息的中间量

        //public Hashtable SeatOwener = new Hashtable();
        /// <summary>
        /// 有余票的做席列表
        /// </summary>
        public Dictionary<string, string> SeatOwener { get; set; }
        /// <summary>
        /// 票种
        /// </summary>
        public string seattype_num="";
        public string single_round_type="1";//不知道是啥
        public string Include_student = "00";//0X00,1F

        public TrainData() { }
        public TrainData(string[] items)
        {
            lock (this)
            {
                SpecialSeatType = new Dictionary<string, string>();
                SeatOwener = new Dictionary<string, string>();
                string[] item = items;
                Tag = item;
                UpdateTime = DateTime.Now.ToString();
                this.Station_train_code = System.Text.RegularExpressions.Regex.Match(item[0], ">(?<no>[^<]+)</span>").Groups["no"].Value;
                this.Trainno4 = item[0].Split('#')[0].Split('(')[1].Replace("'", "");
                this.From_station_telecode = item[0].Split('#')[1];
                this.To_station_telecode = item[0].Split('#')[2].Substring(0, item[0].Split('#')[2].IndexOf("'"));

                var parts = item[1].Split(new string[] { "&nbsp;" }, StringSplitOptions.RemoveEmptyEntries);
                int offset = 0;
                if (parts[0].StartsWith("<img")) offset++;
                //Start_time = parts[offset + 2];
                Start_time = parts[parts.Length-1];
                this.From_station_name = parts[offset].Replace("<br>", "");
                parts = item[2].Split(new string[] { "&nbsp;" }, StringSplitOptions.RemoveEmptyEntries);
                offset = 0;
                if (parts[0].StartsWith("<img")) offset++;
                //Arrive_time = parts[offset + 2];
                Arrive_time = parts[parts.Length-1];
                this.To_station_name = parts[offset];
                Cost_time = item[3];

                parts = item[15].Split(new char[] { '#' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 10)
                {
                    this.From_station_telecode_name = parts[7];
                    this.To_station_telecode_name = parts[8];
                    this.From_station_no = parts[9];
                    this.To_station_no = parts[10];
                    this.ypInfoDetail = parts[11];
                    this.mmStr = parts[12];
                    this.LocationCode = parts[13].Split(')')[0].Replace("'", "");
                    Bookable = true;
                }
                else
                    Bookable = false;

                if ( ypInfoDetail!=null&&ypInfoDetail != string.Empty)
                {
                    string tmpStr = ypInfoDetail;
                    tmpSeat = new string[ypInfoDetail.Length / 10];
                    for (int i = 0; i < tmpSeat.Length; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            tmpSeat[i] += tmpStr.Substring(j, 1);
                        }
                        if (tmpStr.Length >= 10)
                            tmpStr = tmpStr.Substring(10);
                    }
                }
                string tmp = "";
                var counters = new Dictionary<string, string>();
                for (int j = 0; j < DatasList.SeatTypeNames.Length; j++)
                {
                    var val = item[4 + j];

                    if (val.IndexOf("有") > -1)
                    {
                        tmp = GetCount(DatasList.SeatTypeNames[j]);
                        tmp = tmp.StartsWith("0") ? tmp.Substring(1) : tmp;
                        counters[DatasList.SeatTypeNames[j]] = tmp;
                        SeatOwener.Add(DatasList.SeatTypeNames[j], tmp);
                    }
                    else if (val.IndexOf("无") > -1)
                        counters[DatasList.SeatTypeNames[j]] = "无";
                    else if (val.IndexOf("*") > -1)
                        counters[DatasList.SeatTypeNames[j]] = "*";
                    else if (val.IndexOf("--") > -1)
                        counters[DatasList.SeatTypeNames[j]] = "--";
                    else
                    {
                        counters[DatasList.SeatTypeNames[j]] = val;
                        SeatOwener.Add(DatasList.SeatTypeNames[j], val);
                    }
                }
                SeatCounters = counters;
                if (counters.Count == 0)
                {
                    Bookable = false;
                }
                else
                {
                    this._0seat = counters[DatasList.SeatTypeNames[9]];
                    this._1seat = counters[DatasList.SeatTypeNames[8]];
                    this._2seat = counters[DatasList.SeatTypeNames[7]];
                    this._3seat = counters[DatasList.SeatTypeNames[6]];
                    this._4seat = counters[DatasList.SeatTypeNames[5]];
                    this._6seat = counters[DatasList.SeatTypeNames[4]];
                    this._Oseat = counters[DatasList.SeatTypeNames[3]];
                    this._Mseat = counters[DatasList.SeatTypeNames[2]];
                    this._Pseat = counters[DatasList.SeatTypeNames[1]];
                    this._9seat = counters[DatasList.SeatTypeNames[0]];
                }
            }
        }
        //余票信息处理，显示具体余票
        private string GetCount(string str)
        {
            string seatCode = DatasList.SeatType[str].ToString();
            string result = "有";
            if (str == "无座")
            {
                for (int i = 0; i < tmpSeat.Length; i++)
                {
                    if (Convert.ToInt16(tmpSeat[i].Substring(6, 1))>3)
                    {
                        tmpSeat[i] = tmpSeat[i].Substring(0, 6) + "3" + (Convert.ToInt16(tmpSeat[i].Substring(6, 1))-3).ToString() + tmpSeat[i].Substring(7);
                    }
                    if (tmpSeat[i].Substring(6, 1) == "3" )
                    {
                        result = tmpSeat[i];
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < tmpSeat.Length; i++)
                {
                    if (seatCode.IndexOf(tmpSeat[i].Substring(0, 1)) > -1 && tmpSeat[i].Substring(6, 1) != "3")
                    {
                        result = tmpSeat[i];
                        break;
                    }
                    else if (str == "一等座" && tmpSeat[i].Substring(0, 1)=="7")
                    {
                        SpecialSeatType.Add("一等软座","7");
                        result = tmpSeat[i];
                        break;
                    }
                    else if (str == "二等座" && tmpSeat[i].Substring(0, 1) == "8")
                    {
                        SpecialSeatType.Add("二等软座", "8");
                        result = tmpSeat[i];
                        break;
                    }
                }
            }
            try
            {
                if (result.Substring(6, 1) != "0" && result.Substring(6, 1) != "3")
                    return result.Substring(6);
                else
                    return result.Substring(7);
            }
            catch { return str; }
        }
    }
}
