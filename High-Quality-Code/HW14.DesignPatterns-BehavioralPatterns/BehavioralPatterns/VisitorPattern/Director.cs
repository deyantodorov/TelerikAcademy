namespace VisitorPattern
{
    public class Director : Employee
    {
        public Director(string name, double income, int vacationDays)
            : base(name, income, vacationDays)
        {
        }
    }
}
