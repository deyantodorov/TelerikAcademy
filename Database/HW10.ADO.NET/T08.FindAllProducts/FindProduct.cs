namespace T08.FindAllProducts
{
    using System;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    public class FindProduct
    {
        private const string MyConnectionString = "Server=.; Database=Northwind; Integrated Security=true";

        static void Main(string[] args)
        {
            Console.Write("Type phrase: ");
            var readLine = Console.ReadLine();

            if (readLine == null)
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            string inputString = readLine.ToLower();

            if (Regex.IsMatch(inputString, "[^0-9a-zA-Z]", RegexOptions.CultureInvariant))
            {
                inputString = "[" + inputString + "]";
            }

            var connectDb = new SqlConnection(MyConnectionString);
            var inputParam = new SqlParameter();

            inputParam.ParameterName = "@inputParam";
            inputParam.Value = string.Format("%{0}%", inputString);

            var cmdGetProductByString = new SqlCommand("SELECT ProductName FROM Products WHERE ProductName LIKE @inputParam", connectDb);

            cmdGetProductByString.Parameters.Add(inputParam);
            connectDb.Open();

            using (connectDb)
            {
                var reader = cmdGetProductByString.ExecuteReader();

                Console.WriteLine("Result: ");
                while (reader.Read())
                {
                    Console.WriteLine((string)reader["ProductName"]);
                }
            }
        }
    }
}
