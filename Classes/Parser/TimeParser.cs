using BerlinClock.Classes.Common;
using BerlinClock.Classes.Validation;

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
            this.timeValidator = new TimeValidator();
        }

        public TimeEntity Parse(string input)
        {
            if (!this.timeValidator.ValidateEntry(input))
            {
                throw new TimeFormatException("Incorrect time argument");
            }

            string[] parts = input.Split(TIME_SEPARATOR);

            var hours = int.Parse(parts[HOURS_INDEX]);

            var minutes = int.Parse(parts[MINUTES_INDEX]);

            var seconds = int.Parse(parts[SECONDS_INDEX]);

            return new TimeEntity(hours, minutes, seconds);
        }
    }
}
