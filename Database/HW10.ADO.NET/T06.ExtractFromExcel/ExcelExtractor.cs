namespace T06.ExtractFromExcel
{
    using System;
    using System.Data.OleDb;

    /// <summary>
    /// 6. Create an Excel file with 2 columns: name and score:
    ///    Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
    ///    
    ///    README: I used Full Name and Salary from TelerikAcademy DB exported to Excel
    /// </summary>
    public class ExcelExtractor
    {
        private const string File = @"..\..\db_employees.xlsx";

        private static void Main()
        {
            var connectionBuilder = new OleDbConnectionStringBuilder
            {
                Provider = "Microsoft.ACE.OLEDB.12.0;"
            };

            connectionBuilder.Add("Extended Properties", "Excel 12.0 XML");
            connectionBuilder.DataSource = File;

            var connectToExcel = new OleDbConnection(connectionBuilder.ConnectionString);

            var cmdToExcel = new OleDbCommand("SELECT * FROM [Sheet1$]", connectToExcel);

            connectToExcel.Open();
            using (connectToExcel)
            {
                var reader = cmdToExcel.ExecuteReader();

                while (reader != null && reader.Read())
                {
                    var name = (string)reader["FullName"];
                    var salary = (double)reader["Salary"];
                    Console.WriteLine("{0}: {1}", name, salary);
                }
            }
        }
    }
}
