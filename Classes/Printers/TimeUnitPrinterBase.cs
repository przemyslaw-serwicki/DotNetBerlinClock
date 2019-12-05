using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public abstract class TimeUnitPrinterBase
    {
        private TimeUnitPrinterBase nextPrinter;

        protected StringBuilder stringBuilder;

        protected TimeUnitPrinterBase()
        {
            this.stringBuilder = new StringBuilder();
        }

        public TimeUnitPrinterBase SetNextPrinter(TimeUnitPrinterBase printer)
        {
            this.nextPrinter = printer;
            return this.nextPrinter;
        }

        public StringBuilder Print(TimeEntity time)
        {
            this.HandlePrint(time);
            if (this.nextPrinter != null)
            {
                this.stringBuilder.AppendLine();
                this.nextPrinter.stringBuilder = this.stringBuilder;
                return this.nextPrinter.Print(time);
            }

            return this.stringBuilder;
        }

        protected abstract void HandlePrint(TimeEntity time);
    }
}
