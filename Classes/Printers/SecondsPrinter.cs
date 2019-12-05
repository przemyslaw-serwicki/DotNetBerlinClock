using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class SecondsPrinter : TimeUnitPrinterBase
    {
        protected override void HandlePrint(TimeEntity time)
        {
            int numberOfSeconds = time.seconds;
            char color = numberOfSeconds % 2 > 0 ? Colors.None : Colors.Yellow;

            this.stringBuilder.Append(color);
        }
    }
}
