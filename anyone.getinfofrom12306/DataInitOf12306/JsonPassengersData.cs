using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aNyoNe.GetInfoFrom12306.DataInitOf12306
{
    [Serializable]
    public class JsonPassengersData
    {
        private bool isExist = true;
        private string exMsg="";
        private Nomal_Passengers normal_passengers=null;
        private object[] dj_passengers = null;

        public JsonPassengersData() { }

        public bool IsExist
        {
            get { return isExist; }
            set { isExist = value; }
        }

        public string ExMsg
        {
            get { return exMsg; }
            set { exMsg = value; }
        }

        public Nomal_Passengers Normal_passengers
        {
            get { return normal_passengers; }
            set { normal_passengers = value; }
        }

        public object[] Dj_passengers
        {
            get { return dj_passengers; }
            set { dj_passengers = value; }
        }
    }
}
