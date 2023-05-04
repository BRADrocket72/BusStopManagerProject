using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Entry
    {
        public int Id {get; set;}
        public DateTime TimeStamp { get; set;}
        public int Boarded { get; set;}
        public int LeftBehind { get; set; }
        public Bus Bus { get; set; }
        public Loop Loop { get; set; }
        public Stop Stop { get; set; }
    }
}
