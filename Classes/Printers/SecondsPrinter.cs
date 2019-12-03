using BerlinClock.Classes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Printers
{
    public class SecondsPrinter
    {
        public string Print(TimeEntity time)
        {
            var numberOfSeconds = time.Seconds;

            return numberOfSeconds % 2 > 0 ? Colors.None : Colors.Yellow;
        }
    }
}
