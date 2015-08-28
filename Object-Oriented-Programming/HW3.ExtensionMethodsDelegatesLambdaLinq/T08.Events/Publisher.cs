namespace T08.Events
{
    using System;
    using System.Linq;
    using System.Threading;

    public class Publisher
    {
        private readonly EventArgs e;

        public delegate void TickHandler(Publisher t, EventArgs e);

        public event TickHandler Tick;

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (this.Tick != null)
                {
                    this.Tick(this, this.e);
                }
            }
        }
    }
}
