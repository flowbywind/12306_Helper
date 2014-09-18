using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _12306_Helper
{
    static class DatasList
    {
        public static string[] SeatTypeNames { get; private set; }
        public static TrainStations[] Stations { get; private set; }
        public static Hashtable SeatType = new Hashtable();
        public static Hashtable TicketType = new Hashtable();
        public static Hashtable CardType = new Hashtable();
        /// <summary>
        /// 省份名称和代码
        /// </summary>
        public static Dictionary<int, string> ProvinceNames = new Dictionary<int, string>();
        /// <summary>
        /// 发车时间列表
        /// </summary>
        public static Dictionary<string, string> TrainStartList = new Dictionary<string, string>();
        public static List<string> StationNames = new List<string>();
        public static void Init()
        {
            var p0Array = CityTelcode.StationNames.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            Stations = new TrainStations[p0Array.Length];
            int i = 0;
            foreach (var p0 in p0Array)
            {
                var p1 = p0.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Stations[i++] = new TrainStations()
                {
                    ShortCut = p1[0],
                    Name = p1[1],
                    Code = p1[2],
                    Pinyin = p1[3],
                    Sipinyin = p1[4],
                    Id = int.Parse(p1[5])
                };
            }
            SeatTypeNames = new string[]{
                "商务座",
                "特等座",
                "一等座",
                "二等座",
                "高级软卧",
                "软卧",
                "硬卧",
                "软座",
                "硬座",
                "无座"
                //"其它"
            }; 

            SeatType.Add("商务座", "9");
            SeatType.Add( "特等座", "P");
            SeatType.Add( "一等座", "M");
            SeatType.Add( "二等座", "O");
            SeatType.Add( "高级软卧", "6");
            SeatType.Add( "软卧", "4");
            SeatType.Add( "硬卧", "3");
            SeatType.Add( "软座", "2");
            SeatType.Add( "硬座", "1");
            SeatType.Add( "无座", "1");
            
            CardType.Add( "二代身份证", "1");
            CardType.Add( "一代身份证", "2");
            CardType.Add( "港澳通行证", "C");
            CardType.Add( "台湾通行证", "G");
            CardType.Add( "护照", "B");
            
            TicketType.Add( "成人票", "1");
            TicketType.Add( "儿童票", "2");
            TicketType.Add( "学生票", "3");
            TicketType.Add("残军票", "4");

            ProvinceNames.Add(11,"北京");
            ProvinceNames.Add(12, "天津");
            ProvinceNames.Add(13, "河北");
            ProvinceNames.Add(15, "内蒙古");
            ProvinceNames.Add(21, "辽宁");
            ProvinceNames.Add(22, "吉林");
            ProvinceNames.Add(23, "黑龙江");
            ProvinceNames.Add(31, "上海");
            ProvinceNames.Add(32, "江苏");
            ProvinceNames.Add(33, "浙江");
            ProvinceNames.Add(34, "安徽");
            ProvinceNames.Add(35, "福建");
            ProvinceNames.Add(36, "江西");
            ProvinceNames.Add(37, "山东");
            ProvinceNames.Add(41, "河南");
            ProvinceNames.Add(42, "湖北");
            ProvinceNames.Add(43, "湖南");
            ProvinceNames.Add(44, "广东");
            ProvinceNames.Add(45, "广西");
            ProvinceNames.Add(46, "海南");
            ProvinceNames.Add(50, "重庆");
            ProvinceNames.Add(51, "四川");
            ProvinceNames.Add(52, "贵州");
            ProvinceNames.Add(53, "云南");
            ProvinceNames.Add(54, "西藏");
            ProvinceNames.Add(61, "陕西");
            ProvinceNames.Add(62, "甘肃");
            ProvinceNames.Add(63, "青海");
            ProvinceNames.Add(64, "宁夏");
            ProvinceNames.Add(65, "新疆");
            ProvinceNames.Add(71, "台湾");
            ProvinceNames.Add(81, "香港");
            ProvinceNames.Add(82, "澳门");

            //加载发车时间列表
            TrainStartList.Clear();
            TrainStartList.Add("8:00", CityTelcode.StartAtEight);
            TrainStartList.Add("9:00", CityTelcode.StartAtNine);
            TrainStartList.Add("10:00", CityTelcode.StartAtTen);
            TrainStartList.Add("11:00", CityTelcode.StartAtEleven);
            TrainStartList.Add("12:00", CityTelcode.StartAtTwelve);
            TrainStartList.Add("13:00", CityTelcode.StartAtThirteen);
            TrainStartList.Add("15:00", CityTelcode.StartAtFivteen);
            TrainStartList.Add("16:00", CityTelcode.StartAtSixteen);
            TrainStartList.Add("17:00", CityTelcode.StartAtSeventeen);
            TrainStartList.Add("18:00", CityTelcode.StartAtEighteen);

            StationNames=StationNames.Concat(CityTelcode.StartAtEight.Split('、')).ToList();
            StationNames = StationNames.Concat(CityTelcode.StartAtNine.Split('、')).ToList();
            StationNames = StationNames.Concat(CityTelcode.StartAtTen.Split('、')).ToList();
            StationNames = StationNames.Concat(CityTelcode.StartAtEleven.Split('、')).ToList();
            StationNames = StationNames.Concat(CityTelcode.StartAtTwelve.Split('、')).ToList();
            StationNames = StationNames.Concat(CityTelcode.StartAtThirteen.Split('、')).ToList();
            StationNames = StationNames.Concat(CityTelcode.StartAtFivteen.Split('、')).ToList();
            StationNames = StationNames.Concat(CityTelcode.StartAtSixteen.Split('、')).ToList();
            StationNames = StationNames.Concat(CityTelcode.StartAtSeventeen.Split('、')).ToList();
            StationNames = StationNames.Concat(CityTelcode.StartAtEighteen.Split('、')).ToList();
        }
    }
}
