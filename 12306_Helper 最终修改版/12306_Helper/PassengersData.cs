using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.adobe.serialization.json;

namespace _12306_Helper
{
    [Serializable]
    public class PassengersData
    {
        public string Passenger_name { get; set; }
        public string Passenger_id_no { get; set; }
        public string Mobile_no { get; set; }
        public string Passenger_type { get; set; }
        public string Passenger_id_type_name { get; set; }

        public string First_letter { get; set; }
        public string IsUserSelf { get; set; }
        public string Old_passenger_id_no { get; set; }
        public string Old_passenger_id_type_code{ get; set; }
        public string Old_passenger_name{ get; set; }
        public string Passenger_flag{ get; set; }
        public string Passenger_id_type_code{ get; set; }
        public string Passenger_type_name{ get; set; }
        public string RecordCount{ get; set; }
        public bool Checked { get; set; }

        //生成乘客信息列表
        public PassengersData(JavaScriptObject jobj)
        {
            this.Passenger_name = jobj["passenger_name"] as string;
            this.Mobile_no = jobj["mobile_no"] as string;
            this.Passenger_id_no = jobj["passenger_id_no"] as string;
            this.Passenger_type = jobj["passenger_type"] as string;
            this.Passenger_id_type_code = jobj["passenger_id_type_code"] as string;
            this.First_letter = jobj["first_letter"] as string;
            this.IsUserSelf = jobj["isUserUelf"] as string;
            this.Old_passenger_id_no = jobj["old_passenger_id_no"] as string;
            this.Old_passenger_id_type_code = jobj["old_passenger_id_type_code"] as string;
            this.Old_passenger_name = jobj["od_passenger_name"] as string;
            this.Passenger_flag = jobj["passenger_flag"] as string;
            this.Passenger_id_type_code = jobj["passenger_id_type_code"] as string;
            this.Passenger_type_name = jobj["passenger_type_name"] as string;
            this.RecordCount = jobj["recordCount"] as string;
            this.Checked = false;
        }
    }
}
