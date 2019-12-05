using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class TimePrinter : ITimePrinter
    {
        private readonly IPrinter decoratedPrinter;

        public TimePrinter()
        {
            var secondsPrinter = new SecondsPrinter();
            var decoratedHoursPrinter = new HoursPrinter(secondsPrinter);

            this.decoratedPrinter = new MinutesPrinter(decoratedHoursPrinter);
        }

        public string PrintTime(TimeEntity time)
        {
            StringBuilder timeBuilder = this.decoratedPrinter.Print(time);

            return timeBuilder.ToString();
        }
    }
}
