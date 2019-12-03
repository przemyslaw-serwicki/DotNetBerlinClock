using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Validation
{
    public class TimeValidator : ITimeValidator
    {
        private const string TIME_PATTERN = @"^(?:[01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$?";

        private const string SPECIAL_HOUR = "24:00:00";

        private readonly Regex timeRegex;

        public TimeValidator()
        {
            this.timeRegex = new Regex(TIME_PATTERN);
        }

        public bool ValidateEntry(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            return this.timeRegex.IsMatch(input) || input.Equals(SPECIAL_HOUR);
        }
    }
}
