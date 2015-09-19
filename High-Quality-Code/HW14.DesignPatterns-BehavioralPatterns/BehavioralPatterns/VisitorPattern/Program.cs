using System;

namespace VisitorPattern
{
    public class Program
    {
        private static void Main()
        {
            var employees = new Employees();
            employees.Attach(new Clerk("Stamat", 1231.123, 21));
            employees.Attach(new Director("Nafarforii", 2231.123, 26));
            employees.Attach(new President("Gazobarov", 3231.123, 30));

            Console.WriteLine("Initial status of employees");
            var print1 = employees.GetEmployees();
            print1.ForEach(Console.WriteLine);

            employees.Accept(new IncomeVisitor());
            employees.Accept(new VacationVisitor());

            Console.WriteLine();
            Console.WriteLine("Change status of employees");
            print1 = employees.GetEmployees();
            print1.ForEach(Console.WriteLine);
        }
    }
}
