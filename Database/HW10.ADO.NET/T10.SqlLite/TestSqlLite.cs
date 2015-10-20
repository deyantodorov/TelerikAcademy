namespace T10.SqlLite
{
    using System;
    using System.Data.SQLite;

    /// <summary>
    /// 10. Re-implement the previous task with SQLite embedded DB (see http://sqlite.phxsoftware.com).
    /// </summary>
    public class TestSqlLite
    {
        private const string ConnectinString = @"Data Source=..\..\books_catalogue.db;Version=3;";

        private static void Main()
        {
            var connection = new SQLiteConnection(ConnectinString);

            // List all books
            Console.WriteLine("All books: ");
            ListAllBooks(connection);
            Console.WriteLine();

            // Find a book by name
            FindBookByName(connection, "si");

            // Adding a book
            AddBook("Nova kniga", "12123", connection);

            Console.WriteLine("All books: ");
            ListAllBooks(connection);
            Console.WriteLine();
        }

        private static void ListAllBooks(SQLiteConnection connecton)
        {
            connecton.Open();

            string querySelect = "SELECT BookID, Title, Isbn FROM Books";

            SQLiteCommand cmdListBooks = new SQLiteCommand(querySelect, connecton);

            SQLiteDataReader reader = cmdListBooks.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0} | {1} | {2}", reader["BookId"], reader["Title"], reader["ISBN"]);
                }
            }

            connecton.Close();
        }

         private static void FindBookByName(SQLiteConnection findBookCon, string title)
        {
            findBookCon.Open();

            string findBookSql = "SELECT BookID, Title, Isbn FROM Books WHERE Title LIKE @bookName";

            SQLiteCommand cmdFindBook = new SQLiteCommand(findBookSql, findBookCon);
            cmdFindBook.Parameters.AddWithValue("@bookName", "%" + title + "%" as string);

            SQLiteDataReader reader = cmdFindBook.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0} | {1} | {2}", reader["BookId"], reader["Title"], reader["ISBN"]);
                }
            }
            findBookCon.Close();
        }

        private static void AddBook(string title, string isbn, SQLiteConnection addCon)
        {
            addCon.Open();
            string sql = "insert into Books (Title, ISBN) values (@title, @isbn)";
            var command = new SQLiteCommand(sql, addCon);
            command.Parameters.AddWithValue("@title", title as string);
            command.Parameters.AddWithValue("@isbn", isbn as string);
            command.ExecuteNonQuery();
            addCon.Close();
        }
    }
}
