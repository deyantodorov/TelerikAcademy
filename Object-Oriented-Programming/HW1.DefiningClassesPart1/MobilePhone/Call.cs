namespace MobilePhone
{
    using System;

    public class Call
    {
        private DateTime date;
        private string phone;
        private int duration;

        public Call(DateTime date, string phone, int duration)
        {
            this.Date = date;
            this.Phone = phone;
            this.Duration = duration;
        }

        public int Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }

        public string Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public override string ToString()
        {
            return string.Format("date: {0}, phone: {1}, duration: {2} sec.", this.Date, this.Phone, this.Duration);
        }
    }
}