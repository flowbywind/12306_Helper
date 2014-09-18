using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _12306_Helper
{
    class SubmitDataOperation:HTML_Translation
    {
        private PassengersData psInfo = null;
        private OrderData _OData = null;
        //private TrainData _trainData = null;
        private DataGridView _dgvPassenger = null;
        private string _RandCode = "";
        private int _PassengerCount = 0;
        private string _Token = "";
        private string _LeftTicket = "";

        public DataGridView DgvPassenger { get; set; }
        //public TrainData TrainData { get; set; }
        public OrderData OData { get; set; }
        public string RandCode { get; set; }
        public int PassengerCount { get; set; }
        public string Token { get; set; }
        public string LeftTicket { get; set; }

        public SubmitDataOperation()
        {

        }

        public void GetOrderPostData(Action<string> callback)
        {
            _OData = OData;
            _dgvPassenger = DgvPassenger;
            _RandCode = RandCode;
            _Token = Token;
            _LeftTicket = LeftTicket;
            _PassengerCount = PassengerCount;

            string tmpChkName = "";
            string postData = "";
            for (int i = 0; i < _PassengerCount; i++)
            {
                tmpChkName = _dgvPassenger.Rows[i].Cells["zhengjian"].Tag.ToString();
                psInfo = (PassengersData)(_dgvPassenger.Rows[i].Cells["xingming"].Tag);
                postData = postData + tmpChkName + "=" + Regex.Match(tmpChkName, "[0-9]+").ToString() + "&oldPassengers=" + UtfEncode(psInfo.Passenger_name) + "%2C" + psInfo.Passenger_id_type_code + "%2C" + psInfo.Passenger_id_no + "&";
            }
            postData = postData + "checkbox9=Y&checkbox9=Y&checkbox9=Y&checkbox9=Y&checkbox9=Y&";
            postData = postData + "leftTicketStr=" + _LeftTicket + "&";
            for (int i = 0; i < 5 - _PassengerCount; i++)
            {
                postData = postData + "oldPassengers=&";
            }

            int index = 1;
            foreach (DataGridViewRow row in _dgvPassenger.Rows)
            {
                psInfo = (PassengersData)(row.Cells["xingming"].Tag);
                postData = postData + "pasenger_" + index + "_cardno=" + psInfo.Passenger_id_no + "&passenger_" + index + "_cardtype=" + psInfo.Passenger_id_type_code + "&";
                postData = postData + "passenger_" + index + "_mobileno=" + psInfo.Mobile_no + "&";
                postData = postData + "passenger_" + index + "_name=" + UtfEncode(psInfo.Passenger_name) + "&";

                postData = postData + "passenger_" + index + "_seat=" + DatasList.SeatType[row.Cells[1].Value] + "&";
                postData = postData + "passenger_" + index + "_ticket=" + DatasList.TicketType[row.Cells[2].Value] + "&";
                //passengerTickets	3,0,1,TDB的干爹,1,430581199101124034,15901117949,Y	
                postData = postData + "passengerTickets=" + DatasList.SeatType[row.Cells[1].Value] + "%2C0%2C" + DatasList.TicketType[row.Cells[2].Value] + "%2C" + UtfEncode(psInfo.Passenger_name) + "%2C" + psInfo.Passenger_id_type_code + "%2C" + psInfo.Passenger_id_no + "%2C" + psInfo.Mobile_no + "%2CY&";
                index++;
            }

            postData = postData + "randCode=" + _RandCode + "&textfiedld=%E4%B8%AD%E6%96%87%E6%88%96%E6%8B%BC%E9%9F%B3%E9%A6%96%E5%AD%97%E6%AF%8D&tFlag=dc&";

            postData = postData + "orderRequest.bed_level_order_num=" + _OData.Bed_level_order_num + "&";
            postData = postData + "orderRequest.cancel_flag=" + _OData.Cancel_flag + "&";
            postData = postData + "orderRequest.end_time=" + _OData.End_time + "&";
            postData = postData + "orderRequest.from_station_name=" + UtfEncode(_OData.From_station_name) + "&";
            postData = postData + "orderRequest.from_station_telecode=" + _OData.From_station_telecode + "&";
            postData = postData + "orderRequest.id_mode=" + _OData.Id_mode + "&";
            postData = postData + "orderRequest.reserve_flag=" + _OData.Reserve_flag + "&";
            postData = postData + "orderRequest.seat_type_code=" + _OData.Seat_type_code + "&";
            postData = postData + "orderRequest.start_time=" + _OData.Start_time + "&";
            postData = postData + "orderRequest.station_train_code=" + _OData.Station_train_code + "&";
            postData = postData + "orderRequest.ticket_type_order_num=" + _OData.Ticket_type_order_num + "&";
            postData = postData + "orderRequest.to_station_name=" + UtfEncode(_OData.To_station_name) + "&";
            postData = postData + "orderRequest.to_station_telecode=" + _OData.To_station_telecode + "&";
            postData = postData + "orderRequest.train_date=" + _OData.Train_date + "&";
            postData = postData + "orderRequest.train_no=" + _OData.Train_no + "&";
            postData = postData + "org.apache.struts.taglib.html.TOKEN=" + _Token;
            callback(postData);
        }
    }
}
