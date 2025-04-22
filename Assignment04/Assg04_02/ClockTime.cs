using System;

namespace TimeManagement
{

    // Time representation class
    public class TimePoint
    {

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public TimePoint(int hours = 0, int minutes = 0, int seconds = 0)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public bool IsValidTime()
        {
            return Hours >= 0 && Minutes >= 0 && Seconds >= 0
                && Hours < 24 && Minutes < 60 && Seconds < 60;
        }

        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            hashCode = hashCode * 31 + Hours.GetHashCode();
            hashCode = hashCode * 31 + Minutes.GetHashCode();
            hashCode = hashCode * 31 + Seconds.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var other = obj as TimePoint;
            return other != null && Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
        }
    }
}
