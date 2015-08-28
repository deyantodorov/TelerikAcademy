namespace T07.Timer
{
    using System;
    using System.Linq;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md
    /// </summary>
    public class TestTimer
    {
        public delegate void TimerDelegate(int seconds);

        private static void Main()
        {
            Console.WriteLine("Press any key to stop:\n");
            CustomTimer timer = new CustomTimer();
            TimerDelegate d = new TimerDelegate(timer.StartTimer);
            d(1);
            Console.ReadKey();
        }
    }
}