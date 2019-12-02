using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Validation
{
    interface ITimeValidator
    {
        bool ValidateEntry(string input);
    }
}
