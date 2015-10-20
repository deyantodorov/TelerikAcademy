namespace T01.CountCategoriesInNorthwind
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// 1. Write a program that retrieves from the Northwind sample database in MS SQL Server the number of  
    /// rows in the Categories table.
    /// </summary>
    public class CountCategories
    {
        private static void Main()
        {
            var connectDb = new SqlConnection(@"Server=.; Database=Northwind; Integrated Security=true");
            connectDb.Open();

            using (connectDb)
            {
                var commandCount = new SqlCommand("SELECT COUNT(*) FROM Categories", connectDb);
                var numberOfRows = (int)commandCount.ExecuteScalar();
                Console.WriteLine("Number of rows in the Categories: {0}", numberOfRows);
            }
        }
    }
}
