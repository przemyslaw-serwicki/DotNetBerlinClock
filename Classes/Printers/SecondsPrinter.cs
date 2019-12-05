using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class SecondsPrinter : IPrinter
    {
        public void Print(TimeEntity timeEntity, StringBuilder printedBuilder)
        {
            int numberOfSeconds = timeEntity.seconds;
            char color = numberOfSeconds % 2 > 0 ? Colors.None : Colors.Yellow;

            printedBuilder.Append(color);
        }
    }
}
