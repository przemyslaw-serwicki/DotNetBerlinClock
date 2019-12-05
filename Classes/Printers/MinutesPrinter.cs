using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class MinutesPrinter : IPrinter
    {
        private const int LAMPS_IN_FIRST_ROW = 11;

        private const int MINUTES_DIVIDER = 5;

        private const int LAMPS_IN_SECOND_ROW = 4;

        private const int NUMBER_OF_QUARTERS_WITHIN_HOUR = 3;

        private readonly IPrinter innerPrinter;

        public MinutesPrinter(IPrinter innerPrinter)
        {
            this.innerPrinter = innerPrinter;
        }

        public StringBuilder Print(TimeEntity time)
        {
            int numberOfMinutes = time.minutes;

            StringBuilder printedBuilder = this.innerPrinter.Print(time);

            printedBuilder.AppendLine();
            this.PopulateFirstRow(numberOfMinutes, printedBuilder);
            printedBuilder.AppendLine();
            this.PopulateSecondRow(numberOfMinutes, printedBuilder);

            return printedBuilder;
        }

        private void PopulateFirstRow(int minutes, StringBuilder printedBuilder)
        {
            int numberOfActiveLamps = minutes / MINUTES_DIVIDER;

            for (int i = 1; i <= numberOfActiveLamps; i++)
            {
                char color = i % NUMBER_OF_QUARTERS_WITHIN_HOUR == 0 ? Colors.Red : Colors.Yellow;
                printedBuilder.Append(color);
            }

            for (int i = numberOfActiveLamps; i < LAMPS_IN_FIRST_ROW; i++)
            {
                printedBuilder.Append(Colors.None);
            }
        }

        private void PopulateSecondRow(int minutes, StringBuilder printedBuilder)
        {
            int numberOfActiveLamps = minutes % MINUTES_DIVIDER;

            printedBuilder.Append(Colors.Yellow, numberOfActiveLamps);

            for (int i = numberOfActiveLamps; i < LAMPS_IN_SECOND_ROW; i++)
            {
                printedBuilder.Append(Colors.None);
            }
        }
    }
}
