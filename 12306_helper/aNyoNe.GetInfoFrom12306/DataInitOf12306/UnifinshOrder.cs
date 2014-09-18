using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace aNyoNe.GetInfoFrom12306.DataInitOf12306
{
   public class UnifinshOrder
    {
       public string trainData { get; set; }  //发车日期
       public string trainNo { get; set; } //车次
       public string fromStation { get; set; } //发站

       public string toStation{get;set;}  //到站
       public string seatType{get;set;} //坐席
       public string ticketType{get;set;} //票种
       public string ticketPrice { get; set; } //票价 
       public string passenger { get; set; } //乘车人
       public string ticketSatus { get; set; } //订单状态
       public string otherInfo { get; set; } //详细信息
       public string fromstationandEND { get; set; } //发站--到站
       public UnifinshOrder()
       { }

      

       public List<UnifinshOrder> tranSoloHtmlJSON(string HtmlJSON)
       {
           var Morder = new UnifinshOrder();
           var list = new List<UnifinshOrder>();
           var OBJ = (JObject)JsonConvert.DeserializeObject(HtmlJSON);
           int count = int.Parse(OBJ["data"]["ticket_totalnum"].ToString()); //订单数量
           for (int i = 0; i < count; i++)
           {
               Morder.trainData = OBJ[i]["orderDBList"]["tickets"]["start_train_date_page"].ToString();//发车日期
               Morder.trainNo = OBJ[i]["orderDBList"]["tickets"]["stationTrainDTO"]["station_train_code"].ToString();//发车车次
               Morder.fromstationandEND = OBJ[i]["orderDBList"]["tickets"]["stationTrainDTO"]["from_station_name"].ToString() + "-->" + OBJ[i]["orderDBList"]["tickets"]["stationTrainDTO"]["to_station_name"].ToString();
               Morder.seatType = OBJ[i]["orderDBList"]["tickets"]["coach_no"].ToString() + "车厢" + "\r\n" + OBJ[i]["orderDBList"]["tickets"]["seat_name"].ToString() + "\r\n" + OBJ[i]["orderDBList"]["tickets"]["seat_type_name"].ToString();
               list.Add(Morder);
           }
           return list;
       }
    }
}
