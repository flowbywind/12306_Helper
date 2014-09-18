using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PingMock;

namespace _12306_Helper
{
    [Serializable]
    public class ConfigList
    {
        private string _user = "";
        private string _cbofrom = "北京|BJP";
        private string _cboto = "上海|SHH";
        private DateTime _dtpriqi = DateTime.Now;
        private string _cboshijian = "00:00--24:00";
        private bool _isselectturn = false;
        private Hashtable _turndatetable = new Hashtable();
        private Hashtable _quickpassengers = new Hashtable();
        private List<string> _quickaddseattype = new List<string>();
        private List<string> _quickaddtraindata = new List<string>();

        public ConfigList() { }

        public ConfigList(string usr,string from,string to,DateTime time,string shijian,bool isturn, Hashtable turn,Hashtable pass,List<string> seat,List<string> train)
        {
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
}
