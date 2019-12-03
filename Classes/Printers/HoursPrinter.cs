using BerlinClock.Classes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Printers
{
    public class HoursPrinter
    {
        private const int LAMPS_IN_FIRST_ROW = 4;

        private const int HOURS_DIVIDER = 5;

        private const int LAMPS_IN_SECOND_ROW = 4;

        public string Print(TimeEntity time)
        {
            var numberOfHours = time.Hours;

            string hoursFirstRow = this.PopulateFirstRow(numberOfHours);
            string hoursSecondRow = this.PopulateSecondRow(numberOfHours);

            var builder = new StringBuilder();
            builder.AppendLine(hoursFirstRow);
            builder.Append(hoursSecondRow);

            return builder.ToString();
        }

        private string PopulateFirstRow(int hours)
        {
            var builder = new StringBuilder();

            int numberOfActiveLamps = hours / HOURS_DIVIDER;

            for (int i = 0; i < numberOfActiveLamps; i++)
            {
                builder.Append(Colors.Red);
            }

            for (int i = numberOfActiveLamps; i < LAMPS_IN_FIRST_ROW; i++)
            {
                builder.Append(Colors.None);
            }

            return builder.ToString();
        }

        private string PopulateSecondRow(int hours)
        {
            var builder = new StringBuilder();

            int numberOfActiveLamps = hours % HOURS_DIVIDER;

            for (int i = 0; i < numberOfActiveLamps; i++)
            {
                builder.Append(Colors.Red);
            }

            for (int i = numberOfActiveLamps; i < LAMPS_IN_SECOND_ROW; i++)
            {
                builder.Append(Colors.None);
            }

            return builder.ToString();
        }
    }
}
