namespace VisitorPattern
{
    public abstract class Employee : Element
    {
        protected Employee(string name, double income, int vacationDays)
        {
            this.Name = name;
            this.Income = income;
            this.VacationDays = vacationDays;
        }

        public string Name { get; set; }

        public double Income { get; set; }

        public int VacationDays { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Income: {this.Income}, Vacation Days: {this.VacationDays}";
        }
    }
}
