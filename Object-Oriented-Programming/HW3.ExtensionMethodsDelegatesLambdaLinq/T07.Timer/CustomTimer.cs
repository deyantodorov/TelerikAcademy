namespace T07.Timer
{
    using System;
    using System.Timers;

    public class CustomTimer
    {
        public void StartTimer(int seconds)
        {
            Timer timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(this.EventPrintCurrentDateTime);
            timer.Interval = seconds * 1000;
            timer.Start();
        }

        private void EventPrintCurrentDateTime(object sender, EventArgs e)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
