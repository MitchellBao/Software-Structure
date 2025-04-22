using System;
using System.Threading;

namespace TimeManagement
{

    // Clock with alarm functionality
    class TimeKeeper
    {

        public event Action<TimeKeeper> OnTick;
        public event Action<TimeKeeper> OnAlarm;

        private bool isRunning;

        public TimeKeeper()
        {
            CurrentTime = new TimePoint();
            OnTick += t => Console.WriteLine("Tick! " + CurrentTime);
            OnAlarm += t => Console.WriteLine("Alarm triggered!");
        }

        public TimePoint CurrentTime { get; set; }
        public TimePoint AlarmTime { get; set; }

        // Starts the clock and continues until stopped
        public void Start()
        {
            Console.WriteLine("Clock has started!");
            isRunning = true;
            while (isRunning)
            {
                DateTime now = DateTime.Now;
                CurrentTime = new TimePoint(now.Hour, now.Minute, now.Second);
                OnTick?.Invoke(this);
                if (AlarmTime.Equals(CurrentTime)) OnAlarm?.Invoke(this);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Clock stopped.");
        }

        // Stops the clock
        public void Stop()
        {
            isRunning = false;
        }
    }
}
