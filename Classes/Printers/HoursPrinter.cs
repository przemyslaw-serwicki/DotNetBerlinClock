using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class HoursPrinter : IPrinter
    {
        private const int LAMPS_IN_FIRST_ROW = 4;

        private const int HOURS_DIVIDER = 5;

        private const int LAMPS_IN_SECOND_ROW = 4;

        public void Print(TimeEntity timeEntity, StringBuilder printedBuilder)
        {
            int numberOfHours = timeEntity.hours;

            this.PopulateFirstRow(numberOfHours, printedBuilder);
            printedBuilder.AppendLine();
            this.PopulateSecondRow(numberOfHours, printedBuilder);
        }

        private void PopulateFirstRow(int hours, StringBuilder printedBuilder)
        {
            int numberOfActiveLamps = hours / HOURS_DIVIDER;

            printedBuilder.Append(Colors.Red, numberOfActiveLamps);

            for (int i = numberOfActiveLamps; i < LAMPS_IN_FIRST_ROW; i++)
            {
                printedBuilder.Append(Colors.None);
            }
        }

        private void PopulateSecondRow(int hours, StringBuilder printedBuilder)
        {
            int numberOfActiveLamps = hours % HOURS_DIVIDER;

            printedBuilder.Append(Colors.Red, numberOfActiveLamps);

            for (int i = numberOfActiveLamps; i < LAMPS_IN_SECOND_ROW; i++)
            {
                printedBuilder.Append(Colors.None);
            }
        }
    }
}
