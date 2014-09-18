using System;
using Newtonsoft.Json.Linq;

namespace aNyoNe.GetInfoFrom12306
{
    [Serializable]
    public class Nomal_Passengers
    {
        private string code ="";
        private string passenger_name ="";
        private string sex_code ="";
        private string sex_name ="";
        private string born_date ="";
        private string country_code ="";
        private string passenger_id_type_code ="";
        private string passenger_id_type_name ="";
        private string passenger_id_no ="";
        private string passenger_type ="";
        private string passenger_flag ="";
        private string passenger_type_name ="";
        private string mobile_no ="";
        private string phone_no ="";
        private string email ="";
        private string address ="";
        private string postalcode ="";
        private string first_letter ="";
        private string recordCount ="";
        private string total_times = "";

        private bool isCheck = false;
        private string seatCode = "";
        private string seatCodeName = "";
        private string ticketCode = "1";
        private string ticketCodeName = "成人票";
        private string status = "";
        private string information = "";

        public Nomal_Passengers(){}

        public Nomal_Passengers(JObject jso)
        {
            code = jso["code"] == null ? "" : jso["code"].ToString();
            passenger_name = jso["passenger_name"] == null ? "" : jso["passenger_name"].ToString();
            sex_code = jso["sex_code"] == null ? "" : jso["sex_code"].ToString();
            sex_name = jso["sex_name"] == null ? "" : jso["sex_name"].ToString();
            born_date = jso["born_date"] == null ? "" : jso["born_date"].ToString();
            country_code = jso["country_code"] == null ? "" : jso["country_code"].ToString();
            passenger_id_type_code = jso["passenger_id_type_code"] == null ? "" : jso["passenger_id_type_code"].ToString();
            passenger_id_type_name = jso["passenger_id_type_name"] == null ? "" : jso["passenger_id_type_name"].ToString();
            passenger_id_no = jso["passenger_id_no"] == null ? "" : jso["passenger_id_no"].ToString();
            passenger_type = jso["passenger_type"] == null ? "" : jso["passenger_type"].ToString();
            passenger_flag = jso["passenger_flag"] == null ? "" : jso["passenger_flag"].ToString();
            passenger_type_name = jso["passenger_type_name"] == null ? "" : jso["passenger_type_name"].ToString();
            mobile_no = jso["mobile_no"] == null ? "" : jso["mobile_no"].ToString();
            phone_no = jso["phone_no"] == null ? "" : jso["phone_no"].ToString();
            email = jso["email"] == null ? "" : jso["email"].ToString();
            address = jso["address"] == null ? "" : jso["address"].ToString();
            postalcode = jso["postalcode"] == null ? "" : jso["postalcode"].ToString();
            first_letter = jso["first_letter"] == null ? "" : jso["first_letter"].ToString();
            recordCount = jso["recordCount"] == null ? "" : jso["recordCount"].ToString();
            total_times = jso["total_times"] == null ? "" : jso["total_times"].ToString();
            status= CheckPassengerStatus(this);
            if (passenger_name == "" && passenger_id_no == "")
            {
                new LogInfo().WriteStringToTxt("passengerLogs","passengersLogs",jso.ToString()); 
            }
        }

        /// <summary>
        /// 检查联系人的身份核实状态
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns></returns>
        private string CheckPassengerStatus(Nomal_Passengers passenger)
        {
            if (passenger.Passenger_id_type_code == "2")
            {
                this.Information = "12306不再支持一代居民身份证，请更改为二代居民身份证";
                return "未通过"; 
            }
            else
            {
                if (passenger.TotalTimes == "95" || passenger.TotalTimes == "97")
                { 
                    return "已通过"; 
                }
                else if (passenger.TotalTimes == "93" || passenger.TotalTimes == "99")
                {
                    if (passenger.Passenger_id_type_code == "1")
                    {
                        return "已通过";    
                    }
                    else
                    { 
                        return "预通过";
                    }
                } 
                else if (passenger.TotalTimes == "94" || passenger.TotalTimes == "96")
                {
                    if (passenger.Passenger_id_type_code == "1") 
                    {
                        this.Information = "身份信息经过核验但未通过，需修改在12306中所填写的身份信息内容与二代居民身份证原件完全一致，\r\n保存后状态仍显示“待核验”时，需持二代居民身份证原件到车站售票窗口或铁路客票代售点办理核验，\r\n详见《铁路互联网购票身份核验须知》";
                        return "未通过";   
                    }
                    else    
                    {
                        this.Information = "身份信息核验未通过，详见《铁路互联网购票身份核验须知》";
                        return "未通过";   
                    }
                }
                else if(passenger.TotalTimes == "92" || passenger.TotalTimes == "98")
                {
                    if (passenger.Passenger_id_type_code == "B" || passenger.Passenger_id_type_code == "C" || passenger.Passenger_id_type_code == "G")
                    {
                        this.Information = "身份信息未经核验，需持在12306中填写的有效身份证件原件到车站售票窗口办理预核验，\r\n详见《铁路互联网购票身份核验须知》";
                        return "请报验";
                    }
                    else
                    {
                        this.Information = "身份信息未经核验，需持二代居民身份证原件到车站售票窗口或铁路客票代售点办理核验，\r\n详见《铁路互联网购票身份核验须知》";
                        return "待核验";
                    }
                }
                else if (passenger.TotalTimes == "91")
                {
                    if (passenger.Passenger_id_type_code == "B" || passenger.Passenger_id_type_code == "C" || passenger.Passenger_id_type_code == "G")
                    {
                        this.Information = "身份信息未经核验，需持在12306中填写的有效身份证件原件到车站售票窗口办理预核验，\r\n详见《铁路互联网购票身份核验须知》";
                        return "请报验";
                    }
                }
            }
            this.Information = "身份信息未经核验，需持在12306中填写的有效身份证件原件到车站售票窗口办理预核验，\r\n详见《铁路互联网购票身份核验须知》";
            return "请报验";
        }

        public Nomal_Passengers CloneNomalPassengers()
        {
            var passenger = new Nomal_Passengers();
            passenger.Code = code;
            passenger.Passenger_name = passenger_name;
            passenger.Sex_code = sex_code;
            passenger.Sex_name = sex_name;
            passenger.Born_date = born_date;
            passenger.Country_code = country_code;
            passenger.Passenger_id_type_code = passenger_id_type_code;
            passenger.Passenger_id_type_name = passenger_id_type_name;
            passenger.Passenger_id_no = passenger_id_no;
            passenger.Passenger_type = passenger_type;
            passenger.Passenger_flag = passenger_flag;
            passenger.Passenger_type_name = passenger_type_name;
            passenger.Mobile_no = mobile_no;
            passenger.Phone_no = phone_no;
            passenger.Email = email;
            passenger.Address = address;
            passenger.Postalcode = postalcode;
            passenger.First_letter = first_letter;
            passenger.RecordCount = recordCount;
            passenger.TotalTimes = total_times;
            passenger.Status = status;
            passenger.Information = information;
            return passenger;
        }

        public string Code { get { return code; } set { code = value; } }
        public string Passenger_name { get { return passenger_name; } set { passenger_name = value; } }
        public string Sex_code { get { return sex_code; } set { sex_code = value; } }
        public string Sex_name { get { return sex_name; } set { sex_name = value; } }
        public string Born_date { get { return born_date; } set { born_date = value; } }
        public string Country_code { get { return country_code; } set { country_code = value; } }
        public string Passenger_id_type_code { get { return passenger_id_type_code; } set { passenger_id_type_code = value; } }
        public string Passenger_id_type_name { get { return passenger_id_type_name; } set { code = passenger_id_type_name; } }
        public string Passenger_id_no { get { return passenger_id_no; } set { passenger_id_no = value; } }
        public string Passenger_type { get { return passenger_type; } set { passenger_type = value; } }
        public string Passenger_flag { get { return passenger_flag; } set { passenger_flag = value; } }
        public string Passenger_type_name { get { return passenger_type_name; } set { passenger_type_name = value; } }
        public string Mobile_no { get { return mobile_no; } set { mobile_no = value; } }
        public string Phone_no { get { return phone_no; } set { phone_no = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Postalcode { get { return postalcode; } set { postalcode = value; } }
        public string First_letter { get { return first_letter; } set { first_letter = value; } }
        public string RecordCount { get { return recordCount; } set { recordCount = value; } }
        public string TotalTimes { get { return total_times; } set { total_times = value; } }
        public bool IsCheck { get { return isCheck; } set { isCheck = value; } }
        public string SeatCode { get { return seatCode; } set { seatCode = value; } }
        public string TicketCode { get { return ticketCode; } set { ticketCode = value; } }
        public string SeatCodeName { get { return seatCodeName; } set { seatCodeName = value; if(value!=null&&value!="") seatCode = DatasList.SeatType[value].ToString(); } }
        public string TicketCodeName { get { return ticketCodeName; } set { ticketCodeName = value; if (value != null && value != "")  ticketCode = DatasList.TicketType[value].ToString(); } }
        public string Status { get { return status; } private set { status = value; } }
        public string Information { get { return information; } private set { information = value; } }
    }
}
