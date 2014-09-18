using System;
using Newtonsoft.Json.Linq;

namespace aNyoNe.GetInfoFrom12306
{
    public class MyOrderData
    {
        /// <summary>
        /// 发车日期
        /// </summary>
        public string TrainDate { get; private set; }
        /// <summary>
        /// 车次
        /// </summary>
        public string TrainCode { get; private set; }
        /// <summary>
        /// 发到站信息
        /// </summary>
        public string TrainStationInfo { get; private set; }
        /// <summary>
        /// 车次编号
        /// </summary>
        public string TrainNo { get; private set; }
        /// <summary>
        /// 席别
        /// </summary>
        public string SeatType { get; private set; }
        /// <summary>
        /// 车票类型
        /// </summary>
        public string TicketType { get; private set; }
        /// <summary>
        /// 票价
        /// </summary>
        public string TicketPrice { get; private set; }
        /// <summary>
        /// 乘车人姓名
        /// </summary>
        public string PassengerName { get; private set; }
        /// <summary>
        /// 证件名称
        /// </summary>
        public string CardName { get; private set; }
        /// <summary>
        /// 订票状态
        /// </summary>
        public string Status { get; private set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public string OrderDate { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public string OrderLoseTime { get; set; }
        /// <summary>
        /// 订单总价钱
        /// </summary>
        public string OrderTotalPrice { get; set; }
        /// <summary>
        /// 订票张数
        /// </summary>
        public string TicketCount { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string StatusInfo { get; set; }

        public MyOrderData(JObject ticket, int index,int lstIndex=0,bool isComplete=false)
        {
            try
            {
                if (!isComplete)
                {
                    TrainDate = ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["start_train_date_page"].ToString();
                    TrainCode =
                        ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["stationTrainDTO"]["station_train_code"]
                            .ToString
                            ();
                    TrainStationInfo =
                        ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["stationTrainDTO"]["from_station_name"]
                            .ToString() +
                        " - " +
                        ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["stationTrainDTO"]["to_station_name"]
                            .ToString();
                    TrainNo = "无信息";
                    SeatType = ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["seat_type_name"].ToString() + ","
                               + ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["coach_name"].ToString() + "车," +
                               ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["seat_name"].ToString();
                    TicketType = ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["ticket_type_name"].ToString();
                    TicketPrice = ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["str_ticket_price_page"].ToString();
                    PassengerName =
                        ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["passengerDTO"]["passenger_name"].ToString();
                    CardName =
                        ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["passengerDTO"]["passenger_id_type_name"]
                            .ToString();
                    Status = ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["ticket_status_name"].ToString();
                    OrderID = ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["sequence_no"].ToString();
                    OrderDate = ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["limit_time"].ToString();
                    OrderLoseTime = ticket["data"]["orderDBList"][lstIndex]["tickets"][index]["lose_time"].ToString();
                    OrderTotalPrice = ticket["data"]["orderDBList"][lstIndex]["ticket_total_price_page"].ToString();
                    TicketCount = ticket["data"]["orderDBList"][lstIndex]["ticket_totalnum"].ToString();
                    StatusInfo = "正常";
                }
                else
                {
                    TrainDate =
                        ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["start_train_date_page"].ToString();
                    TrainCode =
                        ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["stationTrainDTO"]["station_train_code"]
                            .ToString
                            ();
                    TrainStationInfo =
                        ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["stationTrainDTO"]["from_station_name"]
                            .ToString() +
                        " - " +
                        ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["stationTrainDTO"]["to_station_name"]
                            .ToString();
                    TrainNo = "无信息";
                    SeatType = ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["seat_type_name"].ToString() +
                               ","
                               + ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["coach_name"].ToString() + "车," +
                               ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["seat_name"].ToString();
                    TicketType = ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["ticket_type_name"].ToString();
                    TicketPrice =
                        ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["str_ticket_price_page"].ToString();
                    PassengerName =
                        ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["passengerDTO"]["passenger_name"]
                            .ToString();
                    CardName =
                        ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["passengerDTO"]["passenger_id_type_name"
                            ]
                            .ToString();
                    Status = ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["ticket_status_name"].ToString();
                    OrderID = ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["sequence_no"].ToString();
                    OrderDate = ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["limit_time"].ToString();
                    OrderLoseTime = ticket["data"]["OrderDTODataList"][lstIndex]["tickets"][index]["lose_time"].ToString();
                    OrderTotalPrice = ticket["data"]["OrderDTODataList"][lstIndex]["ticket_total_price_page"].ToString();
                    TicketCount = ticket["data"]["OrderDTODataList"][lstIndex]["ticket_totalnum"].ToString();
                    StatusInfo = "正常";
                }
            }
            catch(Exception ee)
            {
                new LogInfo().WriteLine(String.Format("Entry:QMyOrderData_MyOrderData()\r\nException Catch:{0}\r\nSource:{1}\r\nException:{2}", ee.Message, ee.Source, ee.InnerException));
            }
        }
    }
    public static class FailedOrderDetail
    {
        public static bool Flag = false;
        public static string _TrainDate ="";
        public static string _TrainCode = "";
        public static string _TrainStationInfo = "";
        public static string _TrainNo = "";
        public static string _Status = "";
        public static string _StatusInfo = "";        
    }
}
