namespace MobilePhone
{
    using System;

    public class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;

        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public int HoursTalk
        {
            get { return this.hoursTalk; }
            set { this.hoursTalk = value; }
        }

        public int HoursIdle
        {
            get { return this.hoursIdle; }
            set { this.hoursIdle = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public BatteryType BatteryType { get; set; }

        public override string ToString()
        {
            return string.Format("model: {0}, hours idle: {1}, hours talk: {2}, battery type: {3}", this.Model, this.HoursIdle, this.HoursTalk, this.BatteryType);
        }
    }
}
