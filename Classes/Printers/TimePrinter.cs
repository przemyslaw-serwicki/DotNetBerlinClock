using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class TimePrinter : ITimePrinter
    {
        private readonly TimeUnitPrinterBase printerChain;

        public TimePrinter()
        {
            var chain = new SecondsPrinter();
            chain.SetNextPrinter(new HoursPrinter())
                .SetNextPrinter(new MinutesPrinter());

            this.printerChain = chain;
        }

        public string PrintTime(TimeEntity time)
        {
            StringBuilder timeBuilder = this.printerChain.Print(time);

            return timeBuilder.ToString();
        }
    }
}
