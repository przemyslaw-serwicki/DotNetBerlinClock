using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class MinutesPrinter : TimeUnitPrinterBase
    {
        private const int LAMPS_IN_FIRST_ROW = 11;

        private const int MINUTES_DIVIDER = 5;

        private const int LAMPS_IN_SECOND_ROW = 4;

        private const int NUMBER_OF_QUARTERS_WITHIN_HOUR = 3;

        protected override void HandlePrint(TimeEntity time)
        {
            int numberOfMinutes = time.minutes;

            this.PopulateFirstRow(numberOfMinutes);
            this.stringBuilder.AppendLine();
            this.PopulateSecondRow(numberOfMinutes);
        }

        private void PopulateFirstRow(int minutes)
        {
            int numberOfActiveLamps = minutes / MINUTES_DIVIDER;

            for (int i = 1; i <= numberOfActiveLamps; i++)
            {
                string color = i % NUMBER_OF_QUARTERS_WITHIN_HOUR == 0 ? Colors.Red : Colors.Yellow;
                this.stringBuilder.Append(color);
            }

            for (int i = numberOfActiveLamps; i < LAMPS_IN_FIRST_ROW; i++)
            {
                this.stringBuilder.Append(Colors.None);
            }
        }

        private void PopulateSecondRow(int minutes)
        {
            int numberOfActiveLamps = minutes % MINUTES_DIVIDER;

            for (int i = 0; i < numberOfActiveLamps; i++)
            {
                this.stringBuilder.Append(Colors.Yellow);
            }

            for (int i = numberOfActiveLamps; i < LAMPS_IN_SECOND_ROW; i++)
            {
                this.stringBuilder.Append(Colors.None);
            }
        }
    }
}
