using BerlinClock.Classes.Common;
using System.Text.RegularExpressions;

namespace BerlinClock.Classes.Parser
{
    public class TimeParser : ITimeParser
    {
        private const char TIME_SEPARATOR = ':';

        private const int HOURS_INDEX = 0;

        private const int MINUTES_INDEX = 1;

        private const int SECONDS_INDEX = 2;


        public TimeEntity Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new TimeFormatException("Empty time argument");
            }

            string[] timePartials = input.Split(TIME_SEPARATOR);

            if (timePartials.Length != 3)
            {
                throw new TimeFormatException("Incorrect format of time argument");
            }

            int seconds = this.provideSeconds(timePartials);
            int minutes = this.provideMinutes(timePartials);
            int hours = this.provideHours(timePartials, minutes, seconds);

            return new TimeEntity(hours, minutes, seconds);
        }

        private int provideHours(string[] timePartials, int minutes, int seconds)
        {
            int hours;

            if (!int.TryParse(timePartials[HOURS_INDEX], out hours))
            {
                throw new TimeFormatException("Incorrect hours value");
            }

            if (hours < 0 || hours > 24)
            {
                throw new TimeFormatException("Hour exceeds allowed range");
            }

            int specialHour = 24;

            if (hours == specialHour && (minutes != 0 || seconds != 0))
            {
                throw new TimeFormatException("Incorrect time for hour: 24");
            }

            return hours;
        }

        private int provideMinutes(string[] timePartials)
        {
            int minutes;

            if (!int.TryParse(timePartials[MINUTES_INDEX], out minutes))
            {
                throw new TimeFormatException("Incorrect minutes value");
            }

            if (minutes < 0 || minutes > 59)
            {
                throw new TimeFormatException("Minutes exceeds allowed range");
            }

            return minutes;
        }

        private int provideSeconds(string[] timePartials)
        {
            int seconds;

            if (!int.TryParse(timePartials[SECONDS_INDEX], out seconds))
            {
                throw new TimeFormatException("Incorrect seconds value");
            }

            if (seconds < 0 || seconds > 59)
            {
                throw new TimeFormatException("Seconds exceeds allowed range");
            }

            return seconds;
        }
    }
}
