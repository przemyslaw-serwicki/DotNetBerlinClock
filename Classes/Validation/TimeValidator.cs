using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Validation
{
    public class TimeValidator : ITimeValidator
    {
        public bool ValidateEntry(string input)
        {
            return true;
        }
    }
}
