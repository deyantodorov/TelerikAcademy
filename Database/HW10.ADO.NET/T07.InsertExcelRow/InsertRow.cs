namespace T07.InsertExcelRow
{
    using System;
    using System.Data.OleDb;

    /// <summary>
    /// 7. Implement appending new rows to the Excel file.
    /// </summary>
    public class InsertRow
    {
        private const string File = @"..\..\db_employees.xlsx";

        private static void Main()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Salary for {0}:", name);
            string salary = Console.ReadLine();

            var connectionBuilder = new OleDbConnectionStringBuilder
            {
                Provider = "Microsoft.ACE.OLEDB.12.0;"
            };
            connectionBuilder.Add("Extended Properties", "Excel 12.0 XML");
            connectionBuilder.DataSource = File;

            var connectToExcel = new OleDbConnection(connectionBuilder.ConnectionString);

            var cmdAppendRow = new OleDbCommand("INSERT INTO [Sheet1$](FullName, Salary) VALUES('" + name + "','" + salary + "')", connectToExcel);

            try
            {
                connectToExcel.Open();

                using (connectToExcel)
                {
                    int rowsAffected = cmdAppendRow.ExecuteNonQuery();
                    Console.WriteLine("{0} rows affected", rowsAffected);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
