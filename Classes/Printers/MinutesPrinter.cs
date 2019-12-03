using BerlinClock.Classes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Printers
{
    public class MinutesPrinter
    {
        private const int LAMPS_IN_FIRST_ROW = 11;

        private const int MINUTES_DIVIDER = 5;

        private const int LAMPS_IN_SECOND_ROW = 4;

        public string Print(TimeEntity time)
        {
            var numberOfMinutes = time.Minutes;

            string minutesFirstRow = this.PopulateFirstRow(numberOfMinutes);
            string minutesSecondRow = this.PopulateSecondRow(numberOfMinutes);

            var builder = new StringBuilder();
            builder.AppendLine(minutesFirstRow);
            builder.Append(minutesSecondRow);

            return builder.ToString();
        }

        private string PopulateFirstRow(int minutes)
        {
            var builder = new StringBuilder();

            int numberOfActiveLamps = minutes / MINUTES_DIVIDER;

            for (int i = 1; i <= numberOfActiveLamps; i++)
            {
                string color = i % 3 == 0 ? Colors.Red : Colors.Yellow;
                builder.Append(color);
            }

            for (int i = numberOfActiveLamps; i < LAMPS_IN_FIRST_ROW; i++)
            {
                builder.Append(Colors.None);
            }

            return builder.ToString();
        }

        private string PopulateSecondRow(int minutes)
        {
            var builder = new StringBuilder();

            int numberOfActiveLamps = minutes % MINUTES_DIVIDER;

            for (int i = 0; i < numberOfActiveLamps; i++)
            {
                builder.Append(Colors.Yellow);
            }

            for (int i = numberOfActiveLamps; i < LAMPS_IN_SECOND_ROW; i++)
            {
                builder.Append(Colors.None);
            }

            return builder.ToString();
        }
    }
}
