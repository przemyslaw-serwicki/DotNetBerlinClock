using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Tests
{
    public class TimeConverterTests
    {
        private readonly ITimeConverter timeConverter;

        public TimeConverterTests()
        {
            this.timeConverter = new TimeConverter();
        }
    }
}
