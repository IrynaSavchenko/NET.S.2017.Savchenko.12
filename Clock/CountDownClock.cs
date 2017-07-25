using System;
using System.Timers;

namespace Clock
{
    /// <summary>
    /// Class for testing time elapsing events
    /// </summary>
    public class CountDownClock
    {
        private const int MillisecondsInOneSecond = 1000;

        private readonly int timeInterval;
        private readonly Timer timer;

        /// <summary>
        /// Eventhandler for processing time elapsing
        /// </summary>
        public event EventHandler<TimeElapsedEventArgs> TimeElapsed = delegate { };

        /// <summary>
        /// Initializes timer
        /// </summary>
        /// <param name="waitingTime">Time elapsing interval</param>
        public CountDownClock(int waitingTime)
        {
            timeInterval = waitingTime;
            timer = new Timer {Interval = waitingTime * MillisecondsInOneSecond };
            timer.Elapsed += OnTimedEvent;
        }

        /// <summary>
        /// Starts a count-down
        /// </summary>
        public void Start()
        {
            timer.Start();
        }

        private void OnTimeElapsed(TimeElapsedEventArgs e)
        {
            EventHandler<TimeElapsedEventArgs> temp = TimeElapsed;
            temp?.Invoke(this, e);
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            OnTimeElapsed(new TimeElapsedEventArgs(timeInterval));
            ((Timer) source).Stop();
        }
    }
}
