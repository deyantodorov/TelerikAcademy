namespace T04.AddNewProduct
{
    using System;
    using System.Data.SqlClient;
    using System.Configuration;

    /// <summary>
    /// 4. Write a method that adds a new product in the products table in the Northwind database. 
    ///    Use a parameterized SQL command.
    /// </summary>
    public class AddProduct
    {
        private SqlConnection connectDb;

        private void ConnectToDb()
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["SqlServerDb"];
            this.connectDb = new SqlConnection(dbConnectionString.ConnectionString);
            this.connectDb.Open();
        }

        private void DisconnectFromDb()
        {
            if (this.connectDb != null)
            {
                this.connectDb.Close();
            }
        }

        private int InsertProduct(string productName, int supplierId, int categoryId, string quantityPerUnit, decimal unitPrice, int unitsInStock, int unitsOnOrder, int reorderLevel, int discontinued)
        {

            var cmdInsertProduct = new SqlCommand("INSERT INTO Products(ProductName ,SupplierID ,CategoryID ,QuantityPerUnit ,UnitPrice ,UnitsInStock ,UnitsOnOrder,ReorderLevel,Discontinued)" +
                                                         "VALUES(@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", this.connectDb);

            cmdInsertProduct.Parameters.AddWithValue("@productName", productName);
            cmdInsertProduct.Parameters.AddWithValue("@supplierId", supplierId);
            cmdInsertProduct.Parameters.AddWithValue("@categoryId", categoryId);
            cmdInsertProduct.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmdInsertProduct.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmdInsertProduct.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            cmdInsertProduct.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            cmdInsertProduct.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmdInsertProduct.Parameters.AddWithValue("@discontinued", discontinued);

            cmdInsertProduct.ExecuteNonQuery();

            var cmdSelectIdentity = new SqlCommand("SELECT @@Identity", this.connectDb);
            int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }

        private static void Main()
        {
            var add = new AddProduct();

            try
            {
                add.ConnectToDb();

                // Insert new product
                int newProductId = add.InsertProduct("Pesho", 1, 1, "Nishto niama", 123.123m, 123, 123, 123, 0);
                Console.WriteLine("New product id is: " + newProductId);
            }
            finally
            {
                add.DisconnectFromDb();
            }
        }
    }
}
