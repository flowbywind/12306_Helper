using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace aNyoNe.GetInfoFrom12306
{
    [Serializable]
    public class QueryLeftNewDTO
    {
        private string train_no = "";//":"24000K118904
        private string station_train_code = "";//":"K1189","+
        private string start_station_telecode = "";//":"BJP","+
        private string start_station_name = "";//":"北京","+
        private string end_station_telecode = "";//":"WWT","+
        private string end_station_name = "";//":"乌兰浩特","+
        private string from_station_telecode = "";//":"BJP","+
        private string from_station_name="";//北京","+
        private string to_station_telecode="";//NMD","+
        private string to_station_name="";//奈曼","+
        private string start_time="";//16:05","+
        private string arrive_time="";//03:24","+
        private string day_difference="";//1","+
        private string train_class_name = "";//"+
        private string lishi="";//11:19","+
        private string canWebBuy="";//Y","+
        private string lishiValue="";//679","+
        private string yp_info="";//1009103218402530000010091001843016400000","+
        private string control_train_day="";//20301231","+
        private string start_train_date="";//20131231","+
        private string seat_feature="";//W3431333","+
        private string yp_ex="";//10401030","+
        private string train_seat_feature="";//3","+
        private string seat_types="";//1413","+
        private string location_code="";//P1","+
        private string from_station_no="";//01","+
        private string to_station_no="";//10","+
        private string control_day = "";//":19"+
        private string sale_time="";//1000","+
        private string is_support_card="";//0","+
        private string gg_num="";//--","+
        private string gr_num="";//--","+
        private string qt_num="";//--","+
        private string rw_num="";//无","+
        private string rz_num="";//--","+
        private string tz_num="";//--","+
        private string wz_num="";//有","+
        private string yb_num="";//--","+
        private string yw_num="";//无","+
        private string yz_num="";//有","+
        private string ze_num="";//--","+
        private string zy_num="";//--","+
        private string swz_num="";//--","+

        private string[] tmpSeat;
        private string secretStr = "";
        private string buttonTextInfo = "";
        public Dictionary<string, string> SpecialSeatType { get; private set; }
        public Dictionary<string, string> seatOwener { get; set; }

        public QueryLeftNewDTO (){}

        
        public QueryLeftNewDTO(JObject jso)
        {
            try
            {
                seatOwener = new Dictionary<string, string>();
                SpecialSeatType = new Dictionary<string, string>();
                train_no = jso["train_no"].ToString();
                station_train_code = jso["station_train_code"].ToString();
                start_station_telecode = jso["start_station_telecode"].ToString();
                start_station_name = jso["start_station_name"].ToString();
                end_station_telecode = jso["end_station_telecode"].ToString();
                end_station_name = jso["end_station_name"].ToString();
                from_station_telecode = jso["from_station_telecode"].ToString();
                from_station_name = jso["from_station_name"].ToString();
                to_station_telecode = jso["to_station_telecode"].ToString();
                to_station_name = jso["to_station_name"].ToString();
                start_time = jso["start_time"].ToString();
                arrive_time = jso["arrive_time"].ToString();
                day_difference = jso["day_difference"].ToString();
                train_class_name = jso["train_class_name"].ToString();
                lishi = jso["lishi"].ToString();
                canWebBuy = jso["canWebBuy"].ToString();
                lishiValue = jso["lishiValue"].ToString();

                yp_info = jso["yp_info"].ToString();

                control_train_day = jso["control_train_day"].ToString();
                start_train_date = jso["start_train_date"].ToString();
                seat_feature = jso["seat_feature"].ToString();
                yp_ex = jso["yp_ex"].ToString();
                train_seat_feature = jso["train_seat_feature"].ToString();
                seat_types = jso["seat_types"].ToString();
                location_code = jso["location_code"].ToString();
                from_station_no = jso["from_station_no"].ToString();
                to_station_no = jso["to_station_no"].ToString();
                control_day = jso["control_day"].ToString();
                sale_time = jso["sale_time"].ToString();
                is_support_card = jso["is_support_card"].ToString();
                gg_num = jso["gg_num"].ToString();
                yb_num = jso["yb_num"].ToString();
                qt_num = jso["qt_num"].ToString();

                swz_num = jso["swz_num"].ToString();
                tz_num = jso["tz_num"].ToString();
                zy_num = jso["zy_num"].ToString();
                ze_num = jso["ze_num"].ToString();
                gr_num = jso["gr_num"].ToString();
                rw_num = jso["rw_num"].ToString();
                yw_num = jso["yw_num"].ToString();
                rz_num = jso["rz_num"].ToString();
                yz_num = jso["yz_num"].ToString();
                wz_num = jso["wz_num"].ToString();

                //if (swz_num == "有" || System.Text.RegularExpressions.Regex.IsMatch(swz_num, "\\d+"))
                //    seatOwener.Add(DatasList.SeatTypeNames[0], swz_num);
                //if (tz_num == "有" || System.Text.RegularExpressions.Regex.IsMatch(tz_num, "\\d+"))
                //    seatOwener.Add(DatasList.SeatTypeNames[1], tz_num);
                //if (zy_num == "有" || System.Text.RegularExpressions.Regex.IsMatch(zy_num, "\\d+"))
                //    seatOwener.Add(DatasList.SeatTypeNames[2], zy_num);
                //if (ze_num == "有" || System.Text.RegularExpressions.Regex.IsMatch(ze_num, "\\d+"))
                //    seatOwener.Add(DatasList.SeatTypeNames[3], ze_num);
                //if (gr_num == "有" || System.Text.RegularExpressions.Regex.IsMatch(gr_num, "\\d+"))
                //    seatOwener.Add(DatasList.SeatTypeNames[4], gr_num);
                //if (rw_num == "有" || System.Text.RegularExpressions.Regex.IsMatch(rw_num, "\\d+"))
                //    seatOwener.Add(DatasList.SeatTypeNames[5], rw_num);
                //if (yw_num == "有" || System.Text.RegularExpressions.Regex.IsMatch(yw_num, "\\d+"))
                //    seatOwener.Add(DatasList.SeatTypeNames[6], yw_num);
                //if (rz_num == "有" || System.Text.RegularExpressions.Regex.IsMatch(rz_num, "\\d+"))
                //    seatOwener.Add(DatasList.SeatTypeNames[7], rz_num);
                //if (yz_num == "有" || System.Text.RegularExpressions.Regex.IsMatch(yz_num, "\\d+"))
                //    seatOwener.Add(DatasList.SeatTypeNames[8], yz_num);
                //if (wz_num == "有" || System.Text.RegularExpressions.Regex.IsMatch(wz_num, "\\d+"))
                //    seatOwener.Add(DatasList.SeatTypeNames[9], wz_num);

                if (yp_info != null && yp_info != string.Empty)
                {
                    string tmpStr = yp_info;
                    tmpSeat = new string[yp_info.Length/10];
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


                swz_num = SetSeatCount(0, jso["swz_num"].ToString());
                tz_num = SetSeatCount(1, jso["tz_num"].ToString());
                zy_num = SetSeatCount(2, jso["zy_num"].ToString());
                ze_num = SetSeatCount(3, jso["ze_num"].ToString());
                gr_num = SetSeatCount(4, jso["gr_num"].ToString());
                rw_num = SetSeatCount(5, jso["rw_num"].ToString());
                yw_num = SetSeatCount(6, jso["yw_num"].ToString());
                rz_num = SetSeatCount(7, jso["rz_num"].ToString());
                yz_num = SetSeatCount(8, jso["yz_num"].ToString());
                wz_num = SetSeatCount(9, jso["wz_num"].ToString());
            }
            catch (Exception ee)
            {
                new LogInfo().WriteLine(String.Format("Entry:QueryLeftNewDTO_QueryLeftNewDTO()\r\nException Catch:{0}\r\nSource:{1}\r\nException:{2}", ee.Message, ee.Source, ee.InnerException));
            }
        }
        private string SetSeatCount(int index,string seat)
        {
            try
            {
                var tmp = "";
                var val = seat;

                if (val.IndexOf("有") > -1)
                {
                    tmp = GetCount(index, val);
                    tmp = tmp.StartsWith("0") ? tmp.Substring(1) : tmp;
                    SeatOwener.Add(DatasList.SeatTypeNames[index], tmp);
                    return tmp;
                }
                else if (val.IndexOf("无") > -1)
                    return val;
                else if (val.IndexOf("*") > -1)
                    return val;
                else if (val.IndexOf("--") > -1)
                    return val;
                else
                {
                    SeatOwener.Add(DatasList.SeatTypeNames[index], val);
                    return val;
                }
            }
            catch (Exception ee)
            {
                new LogInfo().WriteLine(String.Format("Entry:QueryLeftNewDTO_SetSeatCount()\r\nException Catch:{0}\r\nSource:{1}\r\nException:{2}", ee.Message, ee.Source, ee.InnerException));
                return seat;
            }
        }

        private string GetCount(int index,string catchDefault)
        {
            string result = "有";
            try
            {
                string seatCode = DatasList.SeatType[DatasList.SeatTypeNames[index]].ToString();
                if (index == 9)
                {
                    for (int i = 0; i < tmpSeat.Length; i++)
                    {
                        if (tmpSeat[i].Substring(6, 1) == "3")
                        {
                            result = tmpSeat[i];
                            break;
                        }
                    }
                }
                else
                {
                    //if (Convert.ToInt16(tmpSeat[i].Substring(6, 1)) > 3)
                    //{
                    //    tmpSeat[i] = String.Format("{0}3{1}{2}", tmpSeat[i].Substring(0, 6), (Convert.ToInt16(tmpSeat[i].Substring(6, 1)) - 3), tmpSeat[i].Substring(7));
                    //}
                    for (int i = 0; i < tmpSeat.Length; i++)
                    {
                        if (seatCode.IndexOf(tmpSeat[i].Substring(0, 1)) > -1 && tmpSeat[i].Substring(6, 1) != "3")
                        {
                            result = tmpSeat[i];
                            break;
                        }
                        else if (index == 2 && tmpSeat[i].Substring(0, 1) == "7")
                        {
                            SpecialSeatType.Add("一等软座", "7");
                            result = tmpSeat[i];
                            break;
                        }
                        else if (index == 3 && tmpSeat[i].Substring(0, 1) == "8")
                        {
                            SpecialSeatType.Add("二等软座", "8");
                            result = tmpSeat[i];
                            break;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                new LogInfo().WriteLine(String.Format("Entry:QueryLeftNewDTO_GetCount()\r\nException Catch:{0}\r\nSource:{1}\r\nException:{2}", ee.Message, ee.Source, ee.InnerException));
            }
            try
            {
                //if (result.Substring(6, 1) != "0" && result.Substring(6, 1) != "3")
                //    return result.Substring(6);
                //else
                    return result.Substring(7);
            }
            catch { return catchDefault; }
        }

        public string Train_no
        {
            get { return train_no; }
            set { train_no = value; }
        }

        public string Station_train_code
        {
            get { return station_train_code; }
            set { station_train_code = value; }
        }

        public string Start_station_telecode
        {
            get { return start_station_telecode; }
            set { start_station_telecode = value; }
        }

        public string Start_station_name
        {
            get { return start_station_name; }
            set { start_station_name = value; }
        }

        public string End_station_telecode
        {
            get { return end_station_telecode; }
            set { end_station_telecode = value; }
        }

        public string End_station_name
        {
            get { return end_station_name; }
            set { end_station_name = value; }
        }

        public string From_station_telecode
        {
            get { return from_station_telecode; }
            set { from_station_telecode = value; }
        }

        public string From_station_name
        {
            get { return from_station_name; }
            set { from_station_name = value; }
        }

        public string To_station_telecode
        {
            get { return to_station_telecode; }
            set { to_station_telecode = value; }
        }

        public string To_station_name
        {
            get { return to_station_name; }
            set { to_station_name = value; }
        }

        public string Start_time
        {
            get { return start_time; }
            set { start_time = value; }
        }

        public string Arrive_time
        {
            get { return arrive_time; }
            set { arrive_time = value; }
        }

        public string Day_difference
        {
            get { return day_difference; }
            set { day_difference = value; }
        }
        
        public string Train_class_name
        {
            get { return train_class_name; }
            set { train_class_name = value; }
        }

        public string Lishi
        {
            get { return lishi; }
            set { lishi = value; }
        }

        public string CanWebBuy
        {
            get { return canWebBuy; }
            set { canWebBuy = value; }
        }

        public string LishiValue
        {
            get { return lishiValue; }
            set { lishiValue = value; }
        }

        public string Yp_info
        {
            get { return yp_info; }
            set { yp_info = value; }
        }

        public string Control_train_day
        {
            get { return control_train_day; }
            set { control_train_day = value; }
        }

        public string Start_train_date
        {
            get { return start_train_date; }
            set { start_train_date = value; }
        }

        public string Seat_feature
        {
            get { return seat_feature; }
            set { seat_feature = value; }
        }

        public string Yp_ex
        {
            get { return yp_ex; }
            set { yp_ex = value; }
        }

        public string Train_seat_feature
        {
            get { return train_seat_feature; }
            set { train_seat_feature = value; }
        }

        public string Seat_types
        {
            get { return seat_types; }
            set { seat_types = value; }
        }

        public string Location_code
        {
            get { return location_code; }
            set { location_code = value; }
        }

        public string From_station_no
        {
            get { return from_station_no; }
            set { from_station_no = value; }
        }

        public string To_station_no
        {
            get { return to_station_no; }
            set { to_station_no = value; }
        }

        public string Control_day
        {
            get { return control_day; }
            set { control_day = value; }
        }

        public string Sale_time
        {
            get { return sale_time; }
            set { sale_time = value; }
        }

        public string Is_support_card
        {
            get { return is_support_card; }
            set { is_support_card = value; }
        }

        public string Gg_num
        {
            get { return gg_num; }
            set { gg_num = value; }
        }

        public string Gr_num
        {
            get { return gr_num; }
            set { gr_num = value; }
        }

        public string Qt_num
        {
            get { return qt_num; }
            set { qt_num = value; }
        }

        public string Rw_num
        {
            get { return rw_num; }
            set { rw_num = value; }
        }

        public string Rz_num
        {
            get { return rz_num; }
            set { rz_num = value; }
        }

        public string Tz_num
        {
            get { return tz_num; }
            set { tz_num = value; }
        }

        public string Wz_num
        {
            get { return wz_num; }
            set { wz_num = value; }
        }

        public string Yb_num
        {
            get { return yb_num; }
            set { yb_num = value; }
        }

        public string Yw_num
        {
            get { return yw_num; }
            set { yw_num = value; }
        }

        public string Yz_num
        {
            get { return yz_num; }
            set { yz_num = value; }
        }

        public string Ze_num
        {
            get { return ze_num; }
            set { ze_num = value; }
        }

        public string Zy_num
        {
            get { return zy_num; }
            set { zy_num = value; }
        }

        public string Swz_num
        {
            get { return swz_num; }
            set { swz_num = value; }
        }

        public string SecretStr
        {
            get { return secretStr; }
            set { secretStr = value; }
        }

        public string ButtonTextInfo
        {
            get { return buttonTextInfo; }
            set { buttonTextInfo = value; }
        }

        public Dictionary<string, string> SeatOwener
        {
            get { return seatOwener; }
            set { seatOwener = value; }
        }
    }
}