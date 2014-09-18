using System;
using System.Collections;
using System.Collections.Generic;

namespace _12306_Helper
{
    [Serializable]
    public class ConfigList
    {
        private bool _init = false;
        private string _parentName = "";
        private string _parentText = "";
        private string _user = "";
        private string _cbofrom = "北京|BJP";
        private string _cboto = "上海|SHH";
        private DateTime _dtpriqi = DateTime.Now;
        private bool _watch = false;
        private DateTime _watchTime = DateTime.Now;
        private string _cboshijian = "00:00-24:00";

        private bool _isselectturn = false;
        private Hashtable _turndatetable = new Hashtable();
        private Hashtable _quickpassengers = new Hashtable();
        private List<string> _quickaddseattype = new List<string>();
        private List<string> _quickaddtraindata = new List<string>();
        private Hashtable _customColumn = new Hashtable();

        public ConfigList() { }

        public ConfigList(string usr,string from,string to,DateTime time,string shijian,bool isturn, Hashtable turn,Hashtable pass,List<string> seat,List<string> train,Hashtable columns)
        {
            this.Init = true;
            this._user = usr;
            this._cbofrom = from;
            this._cboto = to;
            this._dtpriqi = time;
            this._cboshijian = shijian;
            this._isselectturn = isturn;
            this._turndatetable = turn;
            this._quickpassengers = pass;
            this._quickaddseattype = seat;
            this._quickaddtraindata = train;
            this._customColumn = columns;
        }


        public bool Init
        {
            get { return _init; }
            set { _init = value; }
        }

        public string ParentName
        {
            get { return _parentName; }
            set { _parentName = value; }
        }

        public string ParentText
        {
            get { return _parentText; }
            set { _parentText = value; }
        }

        public string User
        {
            get { return this._user; }
            set { this._user = value; }
        }

        public string From
        {
            get { return this._cbofrom; }
            set { this._cbofrom = value; }
        }

        public string To
        {
            get { return this._cboto; }
            set { this._cboto = value; }
        }
        public DateTime Date
        {
            get { return this._dtpriqi; }
            set { this._dtpriqi = value; }
        }
        public bool Watched
        {
            get { return _watch; }
        }
        public DateTime WatchTime
        {
            get { return this._watchTime; }
            set { this._watchTime = value; _watch = true; }
        }
        public string Time
        {
            get { return this._cboshijian; }
            set { this._cboshijian = value; }
        }
        public bool Turn
        {
            get { return this._isselectturn; }
            set { this._isselectturn = value; }
        }
        public Hashtable TurnDates
        {
            get { return this._turndatetable; }
            set { this._turndatetable = value; }
        }
        public Hashtable Passengers
        {
            get { return this._quickpassengers; }
            set { this._quickpassengers = value; }
        }
        public Hashtable CustomColumn
        {
            get { return this._customColumn; }
            set { this._customColumn = value; }
        }
        public List<string> SeatTypes
        {
            get { return this._quickaddseattype; }
            set { this._quickaddseattype = value; }
        }
        public List<string> TrainNos
        {
            get { return this._quickaddtraindata; }
            set { this._quickaddtraindata = value; }
        }
    }

    public static class ConfigListExtendMethod
    {
        public static ConfigList CloneConfigList(this ConfigList list)
        {
            var cfg = new ConfigList();
            cfg.Init = list.Init;
            cfg.User = list.User;
            cfg.From = list.From;
            cfg.To= list.To;
            cfg.Date= list.Date;
            cfg.Time= list.Time;
            cfg.Turn = list.Turn;
            cfg.TurnDates = list.TurnDates;
            cfg.Passengers = list.Passengers;
            cfg.SeatTypes = list.SeatTypes;
            cfg.TrainNos = list.TrainNos;
            cfg.CustomColumn = list.CustomColumn;
            return cfg;
        }
    }
}
