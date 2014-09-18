using System;
using Newtonsoft.Json;

namespace aNyoNe.AutoServerSwitch
{
    [Serializable]
    public class Object_Server : IComparable<Object_Server>
    {
        //{"ip":"101.23.128.17","addTime":"2013-05-12T20:20:12.277","validCount":9,"failedCount":0,"speedCount":9,"averageSpeed":513,"brokenCount":0}
        public DateTime AddTime
        {
            get;
            set;
        }

        public int BrokenCount
        {
            get;
            set;
        }

        public int FailedCount
        {
            get;
            set;
        }

        public string Ip
        {
            get;
            set;
        }
        [JsonProperty("AverageSpeed")]
        public int LocalSpeed
        {
            get;
            set;
        }
        [JsonProperty("host")]
        public string Host
        {
            get;
            set;
        }
        //public int AverageSpeed
        //{
        //    get;
        //    set;
        //}

        [JsonIgnore]
        public int ServerSpeed
        {
            get;
            set;
        }

        public int SpeedCount
        {
            get;
            set;
        }

        public int ValidCount
        {
            get;
            set;
        }

        public Object_Server() { }
        public int CompareTo(Object_Server other)
        {
            int num;
            bool localSpeed = this.LocalSpeed >= 0;
            if (localSpeed)
            {
                localSpeed = this.LocalSpeed != 0;
                if (!localSpeed)
                {
                    localSpeed = other.LocalSpeed != 0;
                    if (localSpeed)
                    {
                        localSpeed = other.LocalSpeed >= 0;
                        if (!localSpeed)
                        {
                            num = -1;
                            return num;
                        }
                    }
                    else
                    {
                        num = 0;
                        return num;
                    }
                }
                localSpeed = other.LocalSpeed > 0;
                num = (localSpeed ? other.LocalSpeed - this.LocalSpeed : -1);
            }
            else
            {
                localSpeed = other.LocalSpeed >= 0;
                num = (localSpeed ? 1 : other.LocalSpeed - this.LocalSpeed);
            }
            return num;
        }
        public event EventHandler StateChanged;
        internal virtual void OnStateChanged()
        {
            EventHandler eventHandler = this.StateChanged;
            bool flag = eventHandler == null;
            if (!flag)
            {
                eventHandler(this, EventArgs.Empty);
            }
        }
        public override string ToString()
        {
            return Ip;
        }
    }
}
