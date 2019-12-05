using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class TimePrinter : ITimePrinter
    {
        private readonly IPrinter secondsPrinter;

        private readonly IPrinter hoursPrinter;

        private readonly IPrinter minutesPrinter;

        public TimePrinter()
        {
            this.secondsPrinter = new SecondsPrinter();
            this.hoursPrinter = new HoursPrinter();
            this.minutesPrinter = new MinutesPrinter();
        }

        public string PrintTime(TimeEntity time)
        {
            StringBuilder timeBuilder = new StringBuilder();

            this.secondsPrinter.Print(time, timeBuilder);
            timeBuilder.AppendLine();
            this.hoursPrinter.Print(time, timeBuilder);
            timeBuilder.AppendLine();
            this.minutesPrinter.Print(time, timeBuilder);

            return timeBuilder.ToString();
        }
    }
}
