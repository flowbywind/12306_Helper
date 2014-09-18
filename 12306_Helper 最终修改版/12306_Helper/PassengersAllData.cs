using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.adobe.serialization.json;

namespace _12306_Helper
{
    class PassengersAllData
    {
        public string passenger_name { get; set; }
        public string old_name { get; set; }
        public string gender { get; set; }
        public string sex_code { get; set; }
        public string born_date { get; set; }
        public string country_code { get; set; }
        public string card_type { get; set; }
        public string passenger_id_type_name { get; set; }
        public string old_card_type { get; set; }
        public string card_no { get; set; }
        public string old_card_no { get; set; }
        public string psgTypeCode { get; set; }
        public string passenger_type { get; set; }
        public string passenger_type_name { get; set; }
        public string mobile_no { get; set; }
        public string phone_no { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string postalcode { get; set; }
        public string studentInfo_province_code { get; set; }
        public string studentInfo_school_code { get; set; }
        public string studentInfo_school_name { get; set; }
        public string studentInfo_department { get; set; }
        public string studentInfo_school_class { get; set; }
        public string studentInfo_student_no { get; set; }
        public string schoolSystemDefault { get; set; }
        public string studentInfo_school_system { get; set; }
        public string enterYearCode { get; set; }
        public string studentInfo_enter_year { get; set; }
        public string studentInfo_preference_card_no { get; set; }
        public string studentInfo_preference_from_station_name { get; set; }
        public string studentInfo_preference_from_station_code { get; set; }
        public string studentInfo_preference_to_station_name { get; set; }
        public string studentInfo_preference_to_station_code { get; set; }

        public PassengersAllData(string name,string idname, string idcode,string tickettype, string mono="", string phone = "", string email = "", string address = "", string psgcode = "")
        {
            this.passenger_name = name;
            this.card_type = DatasList.CardType[idname].ToString();
            this.passenger_id_type_name = idname;
            this.passenger_type = DatasList.TicketType[string.Format("{0}票", tickettype)].ToString();
            this.passenger_type_name = tickettype;
            this.mobile_no = mono;
            this.born_date = idcode.Length > 14 ? string.Format("{0}-{1}-{2}", idcode.Substring(6, 4), idcode.Substring(10, 2), idcode.Substring(12, 2)) : "";
            this.sex_code = Convert.ToInt16(idcode.Substring(idcode.Length - 2, 1)) % 2 == 0 ? "F" : "M";
            this.card_no = idcode;

            this.old_name = this.passenger_name;
            this.gender = this.sex_code;
            this.country_code = "CN";
            this.old_card_type = this.card_type;
            this.old_card_no = this.card_no;
            this.psgTypeCode = "1";
            this.phone_no = phone;
            this.email = email;
            this.address = address;
            this.postalcode = psgcode;

            this.studentInfo_province_code = "11";
            this.studentInfo_school_code = "";
            this.studentInfo_school_name = "%E7%AE%80%E7%A0%81%2F%E6%B1%89%E5%AD%97";
            this.studentInfo_department = "";
            this.studentInfo_school_class = "";
            this.studentInfo_student_no = "";
            this.schoolSystemDefault = "";
            this.studentInfo_school_system = "4";
            this.enterYearCode = "";
            this.studentInfo_enter_year = "2002";
            this.studentInfo_preference_card_no = "";
            this.studentInfo_preference_from_station_name = "%E7%AE%80%E7%A0%81%2F%E6%B1%89%E5%AD%97";
            this.studentInfo_preference_from_station_code = "";
            this.studentInfo_preference_to_station_name = "%E7%AE%80%E7%A0%81%2F%E6%B1%89%E5%AD%97";
            this.studentInfo_preference_to_station_code = "";
        }
        public PassengersAllData(JavaScriptObject jobj)
        {
            this.passenger_id_type_name = jobj["passenger_id_type_name"] as string;
            this.passenger_name=jobj["passenger_name"] as string;
            this.old_name =jobj["old_passenger_name"] as string;
            this.gender = jobj["sex_code"] as string;
            this.sex_code =jobj["sex_code"] as string;
            this.country_code=jobj["country_code"] as string;
            this.card_type =jobj["passenger_id_type_code"] as string;
            this.old_card_type =jobj["old_passenger_id_type_code"] as string;
            this.card_no =jobj["passenger_id_no"] as string;
            this.old_card_no =jobj["old_passenger_id_no"] as string;
            this.born_date = card_no.Substring(6, 4) + "-" + card_no.Substring(10, 2) + "-" + card_no.Substring(12,2);
            this.psgTypeCode ="1";
            this.passenger_type =jobj["passenger_type"] as string;
            this.passenger_type_name = jobj["passenger_type_name"] as string;
            this.mobile_no =jobj["mobile_no"] as string;
            this.phone_no=jobj["phone_no"] as string;
            this.email =jobj["email"] as string;
            this.address=jobj["address"] as string;
            this.postalcode =jobj["postalcode"] as string;
            this.studentInfo_province_code ="11";
            this.studentInfo_school_code ="";
            this.studentInfo_school_name ="%E7%AE%80%E7%A0%81%2F%E6%B1%89%E5%AD%97";
            this.studentInfo_department ="";
            this.studentInfo_school_class="";
            this.studentInfo_student_no ="";
            this.schoolSystemDefault ="";
            this.studentInfo_school_system ="4";
            this.enterYearCode ="";
            this.studentInfo_enter_year="2002";
            this.studentInfo_preference_card_no ="";
            this.studentInfo_preference_from_station_name="%E7%AE%80%E7%A0%81%2F%E6%B1%89%E5%AD%97";
            this.studentInfo_preference_from_station_code="";
            this.studentInfo_preference_to_station_name ="%E7%AE%80%E7%A0%81%2F%E6%B1%89%E5%AD%97";
            this.studentInfo_preference_to_station_code = "";
        }
    }
}
