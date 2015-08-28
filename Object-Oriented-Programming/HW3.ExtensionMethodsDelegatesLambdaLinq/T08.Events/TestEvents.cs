namespace T08.Events
{
    using System;

    /// <summary>
    /// https://github.com/TelerikAcademy/Object-Oriented-Programming/blob/master/03.%20Extension-Methods-Delegates-Lambda-LINQ/README.md#problem-8-events
    /// </summary>
    public class TestEvents
    {
        private static void Main()
        {
            Publisher p = new Publisher();
            Subscriber s = new Subscriber();
            s.Listener(p);
            p.Start();
        }
    }
}