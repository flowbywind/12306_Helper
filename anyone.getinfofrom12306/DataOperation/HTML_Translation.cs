using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace aNyoNe.GetInfoFrom12306
{
    public class HTML_Translation
    {
        /****************************************************更新****************************************************/

        public JObject TranslationHtmlEx(string html)
        {
            var data = (JObject)JsonConvert.DeserializeObject(html);
            return data;
        }

        public void TranslationJson(string json, Action<List<JsonTrainData>> callback)
        {
            var trainList = new List<JsonTrainData>();
            try
            {
                if (json != "")
                {      
                    var obj = (JObject) JsonConvert.DeserializeObject(json);
                    if (obj["data"].Any())
                    {
                        for (int i = 0; i < obj["data"].Count(); i++)
                        {
                            var train = obj["data"][i] as JObject;
                            var trainData = new JsonTrainData();
                            trainData.SecretStr = train["secretStr"].ToString();
                            trainData.ButtonTextInfo = train["buttonTextInfo"].ToString();
                            trainData.QueryLeftNewDto = new QueryLeftNewDTO(obj["data"][i]["queryLeftNewDTO"] as JObject);
                            trainList.Add(trainData);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                new LogInfo().WriteLine(String.Format("Entry:HTML_Translation_TranslationJson()\r\nException Catch:{0}\r\nSource:{1}\r\nException:{2}", ee.Message, ee.Source, ee.InnerException));
            }
            callback(trainList);
        }

        public void TranslationJsonEx(string json, Action<List<JsonTrainData>> callback)
        {
            var trainList = new List<JsonTrainData>();
            try
            {
                if (json != "")
                {
                    var obj = (JObject) JsonConvert.DeserializeObject(json);
                    if (obj["data"]["datas"].Any())
                    {
                        for (int i = 0; i < obj["data"]["datas"].Count(); i++)
                        {
                            var train = obj["data"]["datas"][i] as JObject;
                            var trainData = new JsonTrainData();
                            trainData.QueryLeftNewDto = new QueryLeftNewDTO(train);
                            trainList.Add(trainData);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                new LogInfo().WriteLine(String.Format("Entry:HTML_Translation_TranslationJsonEx()\r\nException Catch:{0}\r\nSource:{1}\r\nException:{2}", ee.Message, ee.Source, ee.InnerException));
            }
            callback(trainList);
        }

        public void TranslationPassengerJson(string json, Action<List<Nomal_Passengers>> callback)
        {
            var passengerList = new List<Nomal_Passengers>();
            try
            {
                if (json != "")
                {
                    var obj = (JObject) JsonConvert.DeserializeObject(json);
                    if (obj["data"]["normal_passengers"].Any())
                    {
                        for (int i = 0; i < obj["data"]["normal_passengers"].Count(); i++)
                        {
                            var passengerObj = obj["data"]["normal_passengers"][i] as JObject;
                            var passenger = new Nomal_Passengers(passengerObj);
                            passengerList.Add(passenger);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                new LogInfo().WriteLine(String.Format("Entry:HTML_Translation_TranslationPassengerJson()\r\nException Catch:{0}\r\nSource:{1}\r\nException:{2}", ee.Message, ee.Source, ee.InnerException));
            }
            callback(passengerList);
        }

        public void TranslationHtml(string html, Action<List<QuickTrainData>> callback)
        {
            var stationsList = new List<QuickTrainData>();
            try
            {
                var stations = (JObject) JsonConvert.DeserializeObject(html);
                for (int i = 0; i < stations["data"]["data"].Count(); i++)
                {
                    var jobj = stations["data"]["data"][i] as JObject;
                    var station = new QuickTrainData(jobj);
                    stationsList.Add(station);
                }
            }
            catch (Exception ee)
            {
                new LogInfo().WriteLine(String.Format("Entry:HTML_Translation_TranslationHtml()\r\nException Catch:{0}\r\nSource:{1}\r\nException:{2}", ee.Message, ee.Source, ee.InnerException));
            }
            callback(stationsList);
        }
    }
}
