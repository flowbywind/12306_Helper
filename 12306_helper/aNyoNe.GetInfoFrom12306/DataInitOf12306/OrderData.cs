
using System;
using System.Collections.Generic;
namespace aNyoNe.GetInfoFrom12306
{
    public class OrderData_Otn
    {
        private string cancel_flag;
        private string bed_level_order_num;
        private string passengerTicketStr;
        private string oldPassengerStr;
        private string tour_flag;
        private string randCode;
        private string _json_att;
        private string _REPEAT_SUBMIT_TOKEN;

        public string Cancel_flag { get { return cancel_flag; } set { cancel_flag = value; } }
        public string Bed_level_order_num { get { return bed_level_order_num; } set { bed_level_order_num = value; } }
        public string PassengerTicketStr { get { return passengerTicketStr; } set { passengerTicketStr = value; } }
        public string OldPassengerStr { get { return oldPassengerStr; } set { oldPassengerStr = value; } }
        public string Tour_flag { get { return tour_flag; } set { tour_flag = value; } }
        public string RandCode { get { return randCode; } set { randCode = value; } }
        public string Json_att { get { return _json_att; } set { _json_att = value; } }
        public string REPEAT_SUBMIT_TOKEN { get { return _REPEAT_SUBMIT_TOKEN; } set { _REPEAT_SUBMIT_TOKEN = value; } }

        private string train_date;
        private string train_no;
        private string stationTrainCode;
        private string seatType;
        private string fromStationTelecode;
        private string toStationTelecode;
        private string leftTicket;
        private string purpose_codes;

        public string Train_date { get { return train_date; } set { train_date = value; } }
        public string Train_no { get { return train_no; } set { train_no = value; } }
        public string StationTrainCode { get { return stationTrainCode; } set { stationTrainCode = value; } }
        public string SeatType { get { return seatType; } set { seatType = value; } }
        public string FromStationTelecode { get { return fromStationTelecode; } set { fromStationTelecode = value; } }
        public string ToStationTelecode { get { return toStationTelecode; } set { toStationTelecode = value; } }
        public string LeftTicket { get { return leftTicket; } set { leftTicket = value; } }
        public string Purpose_codes { get { return purpose_codes; } set { purpose_codes = value; } }

        public OrderData_Otn() { }

        public OrderData_Otn(QueryLeftNewDTO trainInfo,List<Nomal_Passengers> passengers,bool auto=false,string token="",string code="",string purpose="ADULT")
        {
            train_date = GetDateTime(trainInfo.Start_train_date);
            train_no = trainInfo.Train_no;
            stationTrainCode = trainInfo.Station_train_code;
            seatType = trainInfo.Seat_types;
            fromStationTelecode = trainInfo.From_station_telecode;
            toStationTelecode = trainInfo.To_station_telecode;
            leftTicket = trainInfo.Yp_info;
            purpose_codes = purpose;

            cancel_flag="2";
            bed_level_order_num = "000000000000000000000000000000";

            int i = 0;
            foreach(Nomal_Passengers passenger in passengers)
            {
                //如果是自动提交,需要把这里的Passenger_name进行url编码  System.Web.HttpUtility.UrlEncode
                //1,0,1,阿飞,1,152326196602010090,13522222222,N_1,0,1,啊啊,1,610104196212028315,,N
                passengerTicketStr += passenger.SeatCode + "," + passenger.Passenger_flag + "," + passenger.TicketCode + "," + passenger.Passenger_name
                    + "," + passenger.Passenger_id_type_code + "," + passenger.Passenger_id_no + "," + passenger.Mobile_no + "," + "N" + ((i + 1) < passengers.Count ? "_" : "");
                //阿飞,1,152326198802010090,1_啊啊,1,610104196212028315,1_
                oldPassengerStr += passenger.Passenger_name + "," + passenger.Passenger_id_type_code + "," + passenger.Passenger_id_no
                    + "," + passenger.TicketCode + "_";

                if (auto)
                {
                    passengerTicketStr = passengerTicketStr.Replace(passenger.Passenger_name, System.Web.HttpUtility.UrlEncode(passenger.Passenger_name));
                    oldPassengerStr = oldPassengerStr.Replace(passenger.Passenger_name, System.Web.HttpUtility.UrlEncode(passenger.Passenger_name));
                }

                i++;
            }
            tour_flag = "dc";
            _json_att = "";
            randCode = code;
            _REPEAT_SUBMIT_TOKEN = token;

        }
        //2014-01-10#00#C2003#00:33#06:35#24000C200307#VNP#TJP#07:08#北京南#天津#01#02#O005450419M006550037P009350008#P2#1389160024454#C9EB3A940AA419C3DA2C8B195DFFD417520941BA11F8DA97BCDB9E6B
        private string GetDateTime(string date)
        {
            string newDate = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6, 2);
            DateTime tmpDateTime = Convert.ToDateTime(newDate);
            string fmtDate = "ddd MMM d HH:mm:ss 'UTC'zz'00' yyyy";
            System.Globalization.CultureInfo ciDate = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            //将C#时间转换成JS时间字符串  
            string JSstring = tmpDateTime.ToString(fmtDate, ciDate);
            return JSstring;
        }
    }
}
