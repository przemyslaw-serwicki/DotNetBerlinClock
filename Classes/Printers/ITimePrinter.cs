using BerlinClock.Classes.Common;

namespace BerlinClock.Classes.Printers
{
    public interface ITimePrinter
    {
        string PrintTime(TimeEntity time);
    }
}
