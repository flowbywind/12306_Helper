using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.adobe.serialization.json;
using Newtonsoft.Json;

namespace _12306_Helper
{
    class HTML_Translation
    {
        public string TranslationHtml(string html,string name)
        {
            var data = JSON.decode(html) as JavaScriptObject;
            return data[name] as string;
        }

        public JavaScriptObject TranslationHtml(string html)
        {
            var data = JSON.decode(html) as JavaScriptObject;
            return data;
        }

        public void TranslationHtml(string html, Action<List<TrainData>> callback)
        {
            string tmpHtml = html;
            List<TrainData> trainData = new List<TrainData>(); 
            var rawStatus = tmpHtml.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (rawStatus.Length > 0 && (rawStatus.Length - 1) % 16 == 0)
            {
                int count = (rawStatus.Length - 1) >> 4;
                for (int i = 0; i < count; i++)
                {
                    var status = new string[16];
                    Array.Copy(rawStatus, 1 + (i << 4), status, 0, 16);
                    var trainItem = new TrainData(status);
                    trainData.Add(trainItem);
                }
                callback(trainData);
            }
        }
        public void TranslationHtml(string html, Action<List<QuickTrainData>> callback)
        {
            List<QuickTrainData> stationsList = new List<QuickTrainData>();
            var stations = JSON.decode(html) as object[];
            for (int i = 0; i < stations.Length; i++)
            {
                var jobj = stations[i] as JavaScriptObject;
                var station = new QuickTrainData(jobj);
                stationsList.Add(station);
            }
            if (stationsList != null)
                callback(stationsList);
        }

        public void TranslationHtml(string html, Action<List<PassengersData>> callback)
        {
            List<PassengersData> passengers = new List<PassengersData>();
            var obj = JSON.decode(html) as JavaScriptObject;
            var Rows = obj["passengerJson"] as object[];
            for (int i = 0; i < Rows.Length; i++)
            {
                var jobj = Rows[i] as JavaScriptObject;
                var passenger = new PassengersData(jobj);
                passengers.Add(passenger);
            }
            if (passengers != null)
                callback(passengers);
        }

        public void TranslationHtml(string html, Action<List<PassengersAllData>> callback)
        {
            List<PassengersAllData> passengers = new List<PassengersAllData>();
            if (html != "")
            {
                var obj = JSON.decode(html) as JavaScriptObject;
                int recordCount = Convert.ToInt32(obj["recordCount"]);
                var Rows = obj["rows"] as object[];
                for (int i = 0; i < recordCount; i++)
                {
                    var jobj = Rows[i] as JavaScriptObject;
                    var psData = new PassengersAllData(jobj);
                    passengers.Add(psData);
                }
                if (passengers != null)
                    callback(passengers);
            }
        }

        public string UtfEncode(string str)
        {
            byte[] buffer = Encoding.GetEncoding("UTF-8").GetBytes(str);
            string result = "";
            for (int i = 0; i < buffer.Length; i++)
            {
                result = result + "%" + buffer[i].ToString("x");
            }
            return result;
        }
    }
}
