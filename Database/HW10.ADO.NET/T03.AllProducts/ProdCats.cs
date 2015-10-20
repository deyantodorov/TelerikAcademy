namespace T03.AllProducts
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// 3. Write a program that retrieves from the Northwind database all product categories and the names of the products in each category. 
    ///    Can you do this with a single SQL query (with table join)?
    /// </summary>
    public class ProdCats
    {
        private static void Main()
        {
            var connectDb = new SqlConnection("Server=.; Database=Northwind; Integrated Security=true");
            connectDb.Open();

            using (connectDb)
            {
                Console.WriteLine("All product categories and the names of the products from Northwind DB:");
                Console.WriteLine();

                SqlCommand cmdAllCategories = new SqlCommand("SELECT p.ProductID ,p.ProductName ,c.CategoryName " +
                                                             "FROM Products p INNER JOIN Categories c ON c.CategoryID = p.CategoryID " +
                                                             "ORDER BY p.ProductID ASC", connectDb);

                SqlDataReader reader = cmdAllCategories.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var productId = (int)reader["ProductID"];
                        var productName = (string)reader["ProductName"];
                        var categoryName = (string)reader["CategoryName"];
                        Console.WriteLine("ID: {0}, Product: {1}, Category: {2}", productId, productName, categoryName);
                    }
                }
            }
        }
    }
}
