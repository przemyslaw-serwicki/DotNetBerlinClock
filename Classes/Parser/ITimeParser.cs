using BerlinClock.Classes.Common;

namespace BerlinClock.Classes.Parser
{
    public interface ITimeParser
    {
        TimeEntity Parse(string input);
    }
}
