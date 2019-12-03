using Autofac;
using BerlinClock.Classes.Common;
using BerlinClock.Classes.Parser;
using BerlinClock.Classes.Printers;
using BerlinClock.Classes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly ITimeParser timeParser;

        private readonly SecondsPrinter secondsPrinter;

        private readonly HoursPrinter hoursPrinter;

        private readonly MinutesPrinter minutesPrinter;

        public TimeConverter()
        {
            IContainer container = AutoFacRegistration.RetrieveAutofacContainer();

            this.timeParser = container.Resolve<ITimeParser>();
            this.secondsPrinter = container.Resolve<SecondsPrinter>();
            this.hoursPrinter = container.Resolve<HoursPrinter>();
            this.minutesPrinter = container.Resolve<MinutesPrinter>();
        }

        public string convertTime(string aTime)
        {
            TimeEntity timeEntity = this.timeParser.Parse(aTime);

            if (timeEntity == null)
            {
                throw new ArgumentException("incorrect time argument");
            }

            string secondsText = this.secondsPrinter.Print(timeEntity);
            string hoursText = this.hoursPrinter.Print(timeEntity);
            string minutesText = this.minutesPrinter.Print(timeEntity);

            var builder = new StringBuilder();
            builder.Append(secondsText).AppendLine();
            builder.Append(hoursText).AppendLine();
            builder.Append(minutesText);

            return builder.ToString();
        }
    }
}
