namespace BerlinClock.Classes.Common
{
    public struct TimeEntity
    {
        public int hours;

        public int minutes;

        public int seconds;

        public TimeEntity(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
    }
}
