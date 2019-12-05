using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class HoursPrinter : TimeUnitPrinterBase
    {
        private const int LAMPS_IN_FIRST_ROW = 4;

        private const int HOURS_DIVIDER = 5;

        private const int LAMPS_IN_SECOND_ROW = 4;

        protected override void HandlePrint(TimeEntity time)
        {
            int numberOfHours = time.hours;

            this.PopulateFirstRow(numberOfHours);
            this.stringBuilder.AppendLine();
            this.PopulateSecondRow(numberOfHours);
        }

        private void PopulateFirstRow(int hours)
        {
            int numberOfActiveLamps = hours / HOURS_DIVIDER;

            this.stringBuilder.Append(Colors.Red, numberOfActiveLamps);

            for (int i = numberOfActiveLamps; i < LAMPS_IN_FIRST_ROW; i++)
            {
                this.stringBuilder.Append(Colors.None);
            }
        }

        private void PopulateSecondRow(int hours)
        {
            int numberOfActiveLamps = hours % HOURS_DIVIDER;

            this.stringBuilder.Append(Colors.Red, numberOfActiveLamps);

            for (int i = numberOfActiveLamps; i < LAMPS_IN_SECOND_ROW; i++)
            {
                this.stringBuilder.Append(Colors.None);
            }
        }
    }
}
