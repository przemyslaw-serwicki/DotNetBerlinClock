using BerlinClock.Classes.Common;
using System.Text;

namespace BerlinClock.Classes.Printers
{
    public interface IPrinter
    {
        StringBuilder Print(TimeEntity timeEntity);
    }
}