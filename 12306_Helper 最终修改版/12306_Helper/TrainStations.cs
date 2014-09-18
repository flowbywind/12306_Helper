using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12306_Helper
{
    class TrainStations : IComparable<TrainStations>
    {
        public string ShortCut { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Id { get; set; }
        public string Pinyin { get; set; }
        public string Sipinyin { get; set; }


        public int CompareTo(TrainStations other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
