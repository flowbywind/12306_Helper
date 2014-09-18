using Newtonsoft.Json.Linq;

namespace aNyoNe.GetInfoFrom12306
{
    public class QuickTrainData
    {
        private string _station_no = "";
        private string _station_name = "";
        private string _arrive_time = "";
        private string _start_time = "";
        private string _stopover_time = "";
        private string _isEnabled = "";

        public QuickTrainData()
        { }

        public QuickTrainData(JObject obj)
        {
            this._station_no = obj["station_no"].ToString();
            this._station_name = obj["station_name"].ToString();
            this._arrive_time = obj["arrive_time"].ToString();
            this._start_time = obj["start_time"].ToString();
            this._stopover_time = obj["stopover_time"].ToString();
            this._isEnabled = obj["isEnabled"].ToString();
        }
        public QuickTrainData(string no,string name,string arrive,string start,string stopover,string enable)
        {
            this._station_no = no;
            this._station_name = name;
            this._arrive_time = arrive;
            this._start_time = start;
            this._stopover_time = stopover;
            this._isEnabled = enable;
        }

        public string Station_no
        {
            get { return this._station_no; }
            set { this._station_no = value; }
        }
        public string Station_name
        {
            get { return this._station_name; }
            set { this._station_name = value; }
        }
        public string Arrive_time
        {
            get { return this._arrive_time; }
            set { this._arrive_time = value; }
        }
        public string Start_time
        {
            get { return this._start_time; }
            set { this._start_time = value; }
        }
        public string Stopover_time
        {
            get { return this._stopover_time; }
            set { this._stopover_time = value; }
        }
        public string IsEnabled
        {
            get { return this._isEnabled; }
            set { this._isEnabled = value; }
        }
    }
}
