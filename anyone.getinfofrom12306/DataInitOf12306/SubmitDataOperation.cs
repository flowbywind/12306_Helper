using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace aNyoNe.GetInfoFrom12306
{
    public class SubmitDataOperation:HTML_Translation
    {
        public DataGridView DgvPassenger { get; set; }
        public OrderData_Otn OData { get; set; }
        public string RandCode { get; set; }
        public int PassengerCount { get; set; }
        public string Token { get; set; }
        public string LeftTicket { get; set; }

        /*******************************************************更新********************************************************/

        //验证订单的postdata
        public string GetCheckOrderPostData(OrderData_Otn orderInfo)
        {
            return System.Web.HttpUtility.UrlEncode(string.Format("cancel_flag={0}&bed_level_order_num={1}&passengerTicketStr={2}&oldPassengerStr={3}&tour_flag={4}&randCode={5}&_json_att={6}&REPEAT_SUBMIT_TOKEN={7}",
                               orderInfo.Cancel_flag, orderInfo.Bed_level_order_num, orderInfo.PassengerTicketStr, orderInfo.OldPassengerStr, orderInfo.Tour_flag, orderInfo.RandCode, orderInfo.Json_att, orderInfo.REPEAT_SUBMIT_TOKEN)).Replace("%3d", "=").Replace("%26", "&");
        }

        public string GetSubmitOrderPostData(QueryLeftNewDTO train,System.Collections.Hashtable Token)
        {
            return System.Web.HttpUtility.UrlEncode(string.Format("train_date={0}&train_no={1}&stationTrainCode={2}&seatType={3}&fromStationTelecode={4}&toStationTelecode={5}&leftTicket={6}&purpose_codes={7}&_json_att={8}&REPEAT_SUBMIT_TOKEN={9}",
                               GetDateTime(train.Start_train_date), train.Train_no, train.Station_train_code, "1", train.From_station_telecode, train.To_station_telecode, Token["leftTicket"].ToString(), Token["purposeCodes"].ToString(), "", Token["Token"].ToString())).Replace("%3d", "=").Replace("%26", "&");
        }

        private string GetDateTime(string date)
        {
            string newDate = date.Substring(0, 4) + "-" + date.Substring(4, 2) + "-" + date.Substring(6,2);
            DateTime tmpDateTime = Convert.ToDateTime(newDate);
            string fmtDate = "ddd MMM d HH:mm:ss 'UTC'zz'00' yyyy";
            System.Globalization.CultureInfo ciDate = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            //将C#时间转换成JS时间字符串  
            string JSstring = tmpDateTime.ToString(fmtDate, ciDate);
            return JSstring;
        }

        public string GetSingleForQueuePostData(OrderData_Otn orderData,System.Collections.Hashtable token)
        {
            return System.Web.HttpUtility.UrlEncode(string.Format("passengerTicketStr={0}&oldPassengerStr={1}&randCode={2}&purpose_codes={3}&key_check_isChange={4}&leftTicketStr={5}&train_location={6}&_json_att={7}&REPEAT_SUBMIT_TOKEN={8}",
                               orderData.PassengerTicketStr, orderData.OldPassengerStr, orderData.RandCode, token["purposeCodes"].ToString(), token["keyCheck"].ToString(), token["leftTicket"].ToString(), token["trainLocation"].ToString(), "", token["Token"].ToString())).Replace("%3d", "=").Replace("%26", "&");
        }

        public string GetQueryOrderWaitTimeQueryString(System.Collections.Hashtable token)
        { 
            return System.Web.HttpUtility.UrlEncode(string.Format("random={0}&tourFlag={1}&_json_att={2}&REPEAT_SUBMIT_TOKEN={3}",
                        DateTime.Now.Subtract(Convert.ToDateTime("1970-01-01")).Ticks.ToString().Substring(0,13), "dc", "", token["Token"].ToString())).Replace("%3d", "=").Replace("%26", "&");
        }

        /********************************************************自动提交***************************************************************/
        public string GetAsyncSubmitOrderPostData(QueryLeftNewDTO train, System.Collections.Hashtable Token)
        {
            return System.Web.HttpUtility.UrlEncode(string.Format("train_date={0}&train_no={1}&stationTrainCode={2}&seatType={3}&fromStationTelecode={4}&toStationTelecode={5}&leftTicket={6}&purpose_codes={7}&_json_att=",
                               GetDateTime(train.Start_train_date), train.Train_no, train.Station_train_code, Token["leftTicket"].ToString().Substring(10,1), train.From_station_telecode, train.To_station_telecode, Token["leftTicket"].ToString(), Token["purposeCodes"].ToString(), "")).Replace("%3d", "=").Replace("%26", "&");
        }

        public string GetSingleForQueueAsyncPostData(OrderData_Otn orderData, System.Collections.Hashtable token)
        {
            return string.Format("passengerTicketStr={0}&oldPassengerStr={1}&randCode={2}&purpose_codes={3}&key_check_isChange={4}&leftTicketStr={5}&train_location={6}&_json_att=",
                               orderData.PassengerTicketStr, orderData.OldPassengerStr, orderData.RandCode, orderData.Purpose_codes, token["keyCheck"].ToString(), token["leftTicket"].ToString(), token["trainLocation"].ToString()).Replace(",","%2c");
        }

        public string GetQueryOrderWaitTimeQueryString()
        {
            return System.Web.HttpUtility.UrlEncode(string.Format("random={0}&tourFlag={1}&_json_att={2}",
                        DateTime.Now.Subtract(Convert.ToDateTime("1970-01-01")).Ticks.ToString().Substring(0, 13), "dc", "")).Replace("%3d", "=").Replace("%26", "&");
        }
    }
}
