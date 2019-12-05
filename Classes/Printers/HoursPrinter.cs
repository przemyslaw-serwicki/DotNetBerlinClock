using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class HoursPrinter : IPrinter
    {
        private const int LAMPS_IN_FIRST_ROW = 4;

        private const int HOURS_DIVIDER = 5;

        private const int LAMPS_IN_SECOND_ROW = 4;

        private readonly IPrinter innerPrinter;

        public HoursPrinter(IPrinter innerPrinter)
        {
            this.innerPrinter = innerPrinter;
        }

        public StringBuilder Print(TimeEntity time)
        {
            int numberOfHours = time.hours;

            StringBuilder printedBuilder = this.innerPrinter.Print(time);

            printedBuilder.AppendLine();
            this.PopulateFirstRow(numberOfHours, printedBuilder);
            printedBuilder.AppendLine();
            this.PopulateSecondRow(numberOfHours, printedBuilder);

            return printedBuilder;
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
