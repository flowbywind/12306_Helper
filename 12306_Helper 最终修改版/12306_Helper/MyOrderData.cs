using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _12306_Helper
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
        /// 订单日期
        /// </summary>
        public string OrderDate { get; set; }
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

        public MyOrderData(string str)
        {
            OrderID = Regex.Match(str, "E\\d{9}").ToString();
            string tmp = "";
            if (str.IndexOf("alertinfo") > -1)//已付款的订单，未出票
            {
                tmp = str.Replace(StringHelper.FindString(ref str, "<td><inputtype=\"checkbox\"id=\"checkbox_all\"", "/></td>"), "");
                tmp = tmp.Replace(StringHelper.FindString(ref tmp, "<buttontype", "</button>"), "");
                tmp = tmp.Replace("<tdclass=\"blue_bold\">", "#")
                                                .Replace("<br/><!--", "|")
                                                .Replace("-->", "")
                                                .Replace("<!--  ", "")
                                                .Replace("<br/>", "#")
                                                .Replace("<tr>", "")
                                                .Replace("</tr>", "")
                                                .Replace("<td>", "")
                                                .Replace("</td>", "#")
                                                .Replace(",", "#");
            }
            else
            {
                if (str.IndexOf("<inputtype=\"hidden\"id=\"checkbox_pay\"") > -1)//未付款的订单
                {
                    tmp = str.Replace(StringHelper.FindString(ref str, "<inputtype=\"hidden\"id=\"checkbox_pay\"", "/>"), "")
                                                                    .Replace("class=\"blue_bold\"", "")
                                                                    .Replace("<br/>", "#")
                                                                    .Replace("<tr>", "")
                                                                    .Replace("</tr>", "")
                                                                    .Replace("<td>", "")
                                                                    .Replace("</td>", "#")
                                                                    .Replace(",", "#");
                }
                else//已付款的订单，已出票
                {
                    tmp = str.Replace("<trclass=\"gray\">", "#")
                                .Replace("<tdclass=\"blue_bold\">", "#")
                                .Replace("<br/><!--", "|")
                                .Replace("-->", "")
                                .Replace("class=\"blue_bold\"", "")
                                .Replace("<!--  ", "")
                                .Replace("<br/>", "#")
                                .Replace("<tr>", "")
                                .Replace("</tr>", "")
                                .Replace("<td>", "")
                                .Replace("</td>", "#")
                                .Replace(",", "#");
                }
            }

            if (tmp.IndexOf("出票失败") > -1 || tmp.IndexOf("inputtype") > -1)
            {
                if(tmp.IndexOf("tdrowspan")>-1)
                    tmp = tmp.Replace(StringHelper.FindString(ref tmp, "<tdrowspan=", ">"), "");
                tmp = tmp.Replace(StringHelper.FindString(ref tmp, "<inputtype=", "/>"), "");
                string[] tmpp = tmp.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                if (FailedOrderDetail.Flag)
                {
                    TrainDate = FailedOrderDetail._TrainDate;
                    TrainCode = FailedOrderDetail._TrainCode;
                    TrainStationInfo = FailedOrderDetail._TrainStationInfo;
                    TrainNo = "无信息";
                    SeatType = tmpp[0];
                    TicketType = tmpp[1];
                    TicketPrice = "无信息";
                    PassengerName = tmpp[2];
                    CardName = tmpp[3];
                    Status = FailedOrderDetail._Status;
                    StatusInfo = FailedOrderDetail._StatusInfo;
                }
                else
                {
                    TrainDate = tmpp[0] + " " + tmpp[3];
                    TrainCode = tmpp[1];
                    TrainStationInfo = tmpp[2];
                    TrainNo = "无信息";
                    SeatType = tmpp[4];
                    TicketType = tmpp[5];
                    TicketPrice = "无信息";
                    PassengerName = tmpp[6];
                    CardName = tmpp[7];
                    Status = tmpp[8];
                    StatusInfo = tmpp[9];
                }
            }
            else
            {
                string[] tmpp = tmp.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                TrainDate = tmpp[0] + " " + tmpp[3];
                TrainCode = tmpp[1];
                TrainStationInfo = tmpp[2];
                TrainNo = tmpp[4] + " " + tmpp[5];
                SeatType = tmpp[6];
                TicketType = tmpp[7];
                if (tmpp.Length == 12)
                {
                    TicketPrice = tmpp[8];
                    PassengerName = tmpp[9];
                    CardName = tmpp[10];
                    Status = tmpp[11];
                    StatusInfo = "订票成功";
                }
                if (tmpp.Length == 13)
                {
                    TicketCount = tmpp[8];
                    TicketPrice = tmpp[9];
                    PassengerName = tmpp[10];
                    CardName = tmpp[11];
                    Status = tmpp[12];
                    StatusInfo = "订票成功";
                }
                
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
