using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12306_Helper
{
    class OrderData
    {
        public string Bed_level_order_num{get;set;}
        public string Cancel_flag{get;set;}
        public string End_time{get;set;}
        public string From_station_name{get;set;}
        public string From_station_telecode{get;set;}
        public string Id_mode{get;set;}
        public string Reserve_flag{get;set;}
        public string Seat_type_code{get;set;}
        public string Start_time{get;set;}
        public string Station_train_code{get;set;}
        public string Ticket_type_order_num{get;set;}
        public string To_station_name{get;set;}
        public string To_station_telecode{get;set;}
        public string Train_date{get;set;}
        public string Train_no { get; set; }

        public OrderData(TrainData trainInfo)
        {
            End_time = trainInfo.Arrive_time;
            From_station_name = trainInfo.From_station_name;
            From_station_telecode = trainInfo.From_station_telecode;
            Start_time = trainInfo.Start_time;
            Station_train_code = trainInfo.Station_train_code;          
            To_station_name = trainInfo.To_station_name;
            To_station_telecode = trainInfo.To_station_telecode;
            Train_date = trainInfo.Train_date;
            Train_no = trainInfo.Trainno4;

            Bed_level_order_num = "000000000000000000000000000000";
            Cancel_flag = "1";
            Id_mode = "Y";
            Reserve_flag = "A";
            Seat_type_code = "";
            Ticket_type_order_num = "";
        }
    }
}
