using BerlinClock.Classes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Parser
{
    public interface ITimeParser
    {
        TimeEntity Parse(string input);
    }
}
