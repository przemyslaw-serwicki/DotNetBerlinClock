using BerlinClock.Classes.Common;
using BerlinClock.Classes.Parser;
using BerlinClock.Classes.Printers;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeParser timeParser;

        private readonly ITimePrinter timePrinter;

        public TimeConverter()
        {
            this.timeParser = new TimeParser();
            this.timePrinter = new TimePrinter();
        }

        public string convertTime(string aTime)
        {
            TimeEntity timeEntity = this.timeParser.Parse(aTime);

            return this.timePrinter.PrintTime(timeEntity);
        }
    }
}
