namespace T05.ExtractImages
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    /// <summary>
    /// 5. Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
    /// </summary>
    public class ExtractImage
    {
        private const string DbConnectionString = "Server=.; Database=Northwind; Integrated Security=true";
        private const int StupidMagicNumberForHeaderProblem = 78;

        private static void ExtractImageFromDb()
        {
            SqlConnection connectDb = new SqlConnection(DbConnectionString);

            connectDb.Open();

            using (connectDb)
            {
                SqlCommand cmd = new SqlCommand("SELECT Picture FROM Categories", connectDb);

                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    byte[] image;
                    var index = 1;

                    while (reader.Read())
                    {
                        image = (byte[])reader["Picture"];
                        WriteBinaryFile(image, @"..\..\images\Picture_" + index + ".jpg");
                        index++;
                    }
                }
            }
        }

        static void WriteBinaryFile(byte[] fileContents, string fileLocation)
        {
            var stream = new FileStream(fileLocation, FileMode.Create);
            using (stream)
            {
                stream.Write(fileContents, StupidMagicNumberForHeaderProblem, fileContents.Length - StupidMagicNumberForHeaderProblem);
            }
        }

        private static void Main()
        {
            ExtractImageFromDb();
            Console.WriteLine("Images extracted in folder images...");
        }
    }
}
