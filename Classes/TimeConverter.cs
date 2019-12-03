using Autofac;
using BerlinClock.Classes.Common;
using BerlinClock.Classes.Parser;
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

        public TimeConverter()
        {
            IContainer container = AutoFacRegistration.RetrieveAutofacContainer();

            this.timeParser = container.Resolve<ITimeParser>();
        }

        public string convertTime(string aTime)
        {
            TimeEntity timeEntity = this.timeParser.Parse(aTime);

            if (timeEntity == null)
            {
                throw new ArgumentException("incorrect time argument");
            }

            var builder = new StringBuilder();
            builder.Append("O").AppendLine();
            builder.Append("RRRR").AppendLine();
            builder.Append("RRRO").AppendLine();
            builder.Append("YYRYYRYYRYY").AppendLine();
            builder.Append("YYYY");

            return builder.ToString();
        }
    }
}
