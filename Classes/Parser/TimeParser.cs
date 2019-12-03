using Autofac;
using BerlinClock.Classes.Common;
using BerlinClock.Classes.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Parser
{
    public class TimeParser : ITimeParser
    {
        private const char TIME_SEPARATOR = ':';

        private const int HOURS_INDEX = 0;

        private const int MINUTES_INDEX = 1;

        private const int SECONDS_INDEX = 2;

        private readonly ITimeValidator timeValidator;

        public TimeParser()
        {
            IContainer container = AutoFacRegistration.RetrieveAutofacContainer();

            this.timeValidator = container.Resolve<ITimeValidator>();
        }

        public TimeEntity Parse(string input)
        {
            if (!this.timeValidator.ValidateEntry(input))
            {
                return null;
            }

            string[] parts = input.Split(TIME_SEPARATOR);

            var hours = int.Parse(parts[HOURS_INDEX]);

            var minutes = int.Parse(parts[MINUTES_INDEX]);

            var seconds = int.Parse(parts[SECONDS_INDEX]);

            return new TimeEntity(hours, minutes, seconds);
        }
    }
}
