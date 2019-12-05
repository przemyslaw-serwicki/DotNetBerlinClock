using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public interface IPrinter
    {
        void Print(TimeEntity timeEntity, StringBuilder printedBuilder);
    }
}
