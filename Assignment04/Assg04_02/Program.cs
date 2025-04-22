using System;
using System.Threading;

namespace TimeManagement
{

    // Main entry point for the program
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                TimeKeeper clock = new TimeKeeper();
                clock.AlarmTime = new TimePoint(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second + 5);
                clock.OnAlarm += TriggerSound;
                int tickCounter = 0;
                clock.OnTick += (t) => tickCounter++;

                // Run the clock in a separate thread
                new Thread(clock.Start).Start();

                Console.WriteLine("Press any key to stop the clock.");
                Console.ReadKey();
                clock.Stop();
                Console.WriteLine($"Ticks counted: {tickCounter}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        // Event handler for alarm trigger
        public static void TriggerSound(TimeKeeper clock)
        {
            TimePoint time = clock.CurrentTime;
            Console.WriteLine($"Alarm triggered at {time.Hours}:{time.Minutes}:{time.Seconds}");
            Console.WriteLine("Playing sound...");
        }
    }
}
