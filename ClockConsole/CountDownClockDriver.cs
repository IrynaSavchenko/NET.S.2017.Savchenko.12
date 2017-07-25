using System;
using Clock;
using ClockConsole.Listeners;

namespace ClockConsole
{
    /// <summary>
    /// The driver class that hooks up the event handling method of CountDownClock
    /// to listener events using a delegate
    /// </summary>
    internal class CountDownClockDriver
    {
        private static void Main(string[] args)
        {
            var fiveSecondsTimer = new CountDownClock(5);
            var tenSecondsTimer = new CountDownClock(10);

            var firstListener = new FirstListener();
            var secondListener = new SecondListener();
            var thirdListener = new ThirdListener();

            RegisterListener(firstListener, fiveSecondsTimer, tenSecondsTimer);
            RegisterListener(secondListener, fiveSecondsTimer, tenSecondsTimer);
            RegisterListener(thirdListener, fiveSecondsTimer, tenSecondsTimer);

            fiveSecondsTimer.Start();
            tenSecondsTimer.Start();

            Console.ReadLine();
        }

        private static void RegisterListener(BasicListener listener, params CountDownClock [] handlers)
        {
            foreach (CountDownClock handler in handlers)
            {
                listener.Register(handler);
            }
        }
    }
}
