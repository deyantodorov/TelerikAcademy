namespace T01.Northwind
{
    using System;

    public static class DaoClass
    {
        public static void InsertCustomer(string customerId, string companyName, string city)
        {
            NorthwindEntities connection = new NorthwindEntities();

            using (connection)
            {
                var newCustomer = new Customer
                {
                    CustomerID = customerId,
                    CompanyName = companyName,
                    ContactName = null,
                    ContactTitle = null,
                    Address = null,
                    City = city,
                    Region = null,
                    PostalCode = null,
                    Country = null,
                    Phone = null,
                    Fax = null
                };

                connection.Customers.Add(newCustomer);
                connection.SaveChanges();
            }
        }

        public static void DeleteCustomer(string customerId)
        {
            NorthwindEntities connection = new NorthwindEntities();

            using (connection)
            {
                var customerToRemove = connection.Customers.Find(customerId);

                connection.Customers.Remove(customerToRemove);
                connection.SaveChanges();
            }
        }

        public static void ModifyCustomer(string customerId, string companyName, string city)
        {
            NorthwindEntities connection = new NorthwindEntities();

            using (connection)
            {
                var customerToModify = connection.Customers.Find(customerId);
                customerToModify.CompanyName = companyName;
                customerToModify.City = city;
                connection.SaveChanges();
            }
        }
    }
}
