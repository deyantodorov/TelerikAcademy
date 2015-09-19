using System.Collections.Generic;

namespace VisitorPattern
{
    public class Employees
    {
        private readonly List<Employee> employees;

        public Employees()
        {
            this.employees = new List<Employee>();
        }

        public List<Employee> GetEmployees()
        {
            return new List<Employee>(this.employees);
        }

        public void Attach(Employee employee)
        {
            this.employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            this.employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var employee in this.employees)
            {
                employee.Accept(visitor);
            }
        }
    }
}
