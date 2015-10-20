namespace T02.NameDescFromCategories
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// 2. Write a program that retrieves the name and description of all categories in the Northwind DB.
    /// </summary>
    public class NameDesc
    {
        private static void Main()
        {
            var connectDb = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            connectDb.Open();

            using (connectDb)
            {
                Console.WriteLine("All categories from Northwind DB:");
                Console.WriteLine();

                SqlCommand cmdAllCategories = new SqlCommand("SELECT CategoryName, Description FROM Categories ORDER BY CategoryID ASC", connectDb);

                SqlDataReader reader = cmdAllCategories.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var name = (string)reader["CategoryName"];
                        var description = (string)reader["Description"];
                        Console.WriteLine("Name: {0}, Description: {1}", name, description);
                    }
                }
            }
        }
    }
}
