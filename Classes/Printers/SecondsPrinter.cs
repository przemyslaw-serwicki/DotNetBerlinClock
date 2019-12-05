using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public class SecondsPrinter : IPrinter
    {
        public StringBuilder Print(TimeEntity time)
        {
            var stringBuilder = new StringBuilder();
            int numberOfSeconds = time.seconds;
            char color = numberOfSeconds % 2 > 0 ? Colors.None : Colors.Yellow;

            stringBuilder.Append(color);

            return stringBuilder;
        }
    }
}
