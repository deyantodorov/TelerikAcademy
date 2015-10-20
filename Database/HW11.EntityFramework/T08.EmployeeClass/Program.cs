namespace T08.EmployeeClass
{
    using System;
    using T01.Northwind;

    /// <summary>
    /// 8. By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            Employee extended = new Employee();

            NorthwindEntities context = new NorthwindEntities();

            extended = context.Employees.Find(2);

            foreach (var item in extended.EntityTerritories)
            {
                Console.WriteLine("Teritory description - {0}", item.TerritoryDescription);
            }
        }
    }
}
