namespace T02.StudentsAndWorkers
{
    using System;
    using System.Linq;
    using System.Text;
    using Common;
    using T02.StudentsAndWorkers.Contracts;

    public class Worker : Human, IHuman
    {
        private decimal weekSalary;
        private float workHoursPerDay;

        public Worker(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public float WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                Validation.LessThanZero<float>(value, 0, "WorkHoursPerDay");
                this.workHoursPerDay = value;
            }
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                // In BG accounting I thinkg rounding is two signs after decimal point, so rounding for validation isn't a problem
                Validation.LessThanZero<decimal>(value, 0, "WeekSalary");
                this.weekSalary = value;
            }
        }

        public decimal MoneyPerHour(int workDaysPerWeek = 5)
        {
            decimal result = this.WeekSalary / ((decimal)this.WorkHoursPerDay * workDaysPerWeek);
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("hours per day: " + this.WorkHoursPerDay.ToString());
            sb.AppendLine("week salary: " + this.WeekSalary.ToString());
            sb.AppendLine("money per hour: " + this.MoneyPerHour().ToString("F2"));

            return sb.ToString();
        }
    }
}
