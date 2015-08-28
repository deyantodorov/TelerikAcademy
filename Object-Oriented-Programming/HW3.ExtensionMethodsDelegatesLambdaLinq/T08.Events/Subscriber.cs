namespace T08.Events
{
    using System;

    public class Subscriber
    {
        public void Listener(Publisher t)
        {
            t.Tick += new Publisher.TickHandler(this.TimeIs);
        }

        public void TimeIs(Publisher t, EventArgs e)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
