using System;
using Clock;

namespace ClockConsole.Listeners
{
    /// <summary>
    /// Class used for handling time elapsing events
    /// </summary>
    internal abstract class BasicListener
    {
        protected abstract string ListenerSpecificMsg { get; }

        /// <summary>
        /// Hooks up the event handling method to the listener event
        /// </summary>
        /// <param name="clock">Object that fires time elapsing events</param>
        public void Register(CountDownClock clock)
        {
            clock.TimeElapsed += TimeElapsedMsg;
        }

        private void TimeElapsedMsg(object sender, TimeElapsedEventArgs eventArgs)
        {
            Console.WriteLine($"{ListenerSpecificMsg} : ");
            Console.WriteLine($"{eventArgs.Message} at {eventArgs.CurrentTime}");
            Console.WriteLine();
        }
    }
}
