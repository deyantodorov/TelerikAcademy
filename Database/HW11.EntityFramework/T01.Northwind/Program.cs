namespace T01.Northwind
{
    using System;
    using System.Linq;

    /// <summary>
    /// 1. Using the Visual Studio Entity Framework designer create a DbContext for the Northwind database
    /// 
    /// 2. Create a DAO class with static methods which provide functionality for inserting, modifying and deleting customers. Write a testing class.
    /// 
    /// 3. Write a method that finds all customers who have orders made in 1997 and shipped to Canada.
    /// 
    /// 4. Implement previous by using native SQL query and executing it through the DbContext.
    /// 
    /// 5. Write a method that finds all the sales by specified region and period (start / end dates).
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            // 1: 
            var db = new NorthwindEntities();

            using (db)
            {
                var employees = db.Employees.ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.City);
                }
            }

            // 2:
            DaoClass.InsertCustomer("123", "Free man", "Nomansland");
            DaoClass.ModifyCustomer("123", "Free man 2", "Nomansland city");
            DaoClass.DeleteCustomer("123");

            // 3:
            PrintOrders(1997, "Canada");

            // 4: 
            PrintOrdersWtihSql(1997, "Canada");

            // 5: 
            FindSales(null, new DateTime(1990, 1, 1), new DateTime(2000, 1, 1));
        }

        private static void PrintOrders(int year, string country)
        {
            var connection = new NorthwindEntities();

            using (connection)
            {
                var orders = connection.Orders.Where(o => o.OrderDate.Value.Year == year && o.ShipCountry == country).GroupBy(o => o.Customer.ContactName);

                foreach (var item in orders)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }

        private static void PrintOrdersWtihSql(int year, string country)
        {
            var connection = new NorthwindEntities();
            using (connection)
            {
                string cmdSql =
                "SELECT c.ContactName " +
                "FROM Customers c " +
                "JOIN Orders o " +
                "ON c.CustomerID = o.CustomerID " +
                "WHERE YEAR(o.OrderDate) = {0} " +
                "AND o.ShipCountry = {1} " +
                "group by c.ContactName";

                object[] parameters = { year, country };
                var customers = connection.Database.SqlQuery<string>(cmdSql, parameters);

                foreach (var item in customers)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void FindSales(string region, DateTime startDate, DateTime endDate)
        {
            var connection = new NorthwindEntities();

            using (connection)
            {
                var sales = connection.Orders.Where(s => s.ShipRegion == region && 
                                                    s.OrderDate > startDate && 
                                                    s.OrderDate < endDate
                                                    );

                foreach (var sale in sales)
                {
                    Console.WriteLine(sale.ShipName);
                }
            }
        }
    }
}
