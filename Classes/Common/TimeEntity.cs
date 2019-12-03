using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Common
{
    public class TimeEntity
    {
        public int Hours { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }

        public TimeEntity(int hours, int minutes, int seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }
    }
}
