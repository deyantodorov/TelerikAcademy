namespace T06.NorthwindTwin
{
    using System;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using T01.Northwind;
    

    public class Program
    {
        private static void Main()
        {
            DuplicateDatabase();
            Console.WriteLine("Database created. See Sql Server");
        }

        private static void DuplicateDatabase()
        {
            IObjectContextAdapter context = new NorthwindEntities();
            string cloneNorthwind = context.ObjectContext.CreateDatabaseScript();

            string createNorthwindCloneDB = "CREATE DATABASE NorthwindTwin ON PRIMARY " +
                                            "(NAME = NorthwindTwin, " +
                                            "FILENAME = 'D:\\NorthwindTwin.mdf', " +
                                            "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                                            "LOG ON (NAME = NorthwindTwinLog, " +
                                            "FILENAME = 'D:\\NorthwindTwin.ldf', " +
                                            "SIZE = 1MB, " +
                                            "MAXSIZE = 5MB, " +
                                            "FILEGROWTH = 10%)";

            SqlConnection dbConForCreatingDB = new SqlConnection(
                "Server=.; " +
                "Database=master; " +
                "Integrated Security=true");

            dbConForCreatingDB.Open();

            using (dbConForCreatingDB)
            {
                var createDb = new SqlCommand(createNorthwindCloneDB, dbConForCreatingDB);
                createDb.ExecuteNonQuery();
            }

            var dbConForCloning = new SqlConnection(
                "Server=.; " +
                "Database=NorthwindTwin; " +
                "Integrated Security=true");

            dbConForCloning.Open();

            using (dbConForCloning)
            {
                var cloneDb = new SqlCommand(cloneNorthwind, dbConForCloning);
                cloneDb.ExecuteNonQuery();
            }
        }
    }
}