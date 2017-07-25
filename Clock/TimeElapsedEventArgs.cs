using System;

namespace Clock
{
    /// <summary>
    /// Class containing data for the time elapsing event
    /// </summary>
    public class TimeElapsedEventArgs
    {
        /// <summary>
        /// Message signifying that the time is up
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Date and time of the moment when the time is elapsed
        /// </summary>
        public DateTime CurrentTime { get; }

        /// <summary>
        /// Initializes data for the time elapsing event
        /// </summary>
        /// <param name="timeInterval">Elapsing time interval in seconds</param>
        public TimeElapsedEventArgs(int timeInterval)
        {
            CurrentTime = DateTime.Now;
            Message = $"{timeInterval} seconds is up";
        }
    }
}
