namespace T09.MySQL
{
    using System;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// 9. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool. 
    /// Create a MySQL database to store Books (title, author, publish date and ISBN). Write methods for listing all books, finding a book by name and adding a book.
    /// </summary>
    public class TestMySql
    {
        private const string ConnectinString = "Server=localhost;Database=books_catalogue;Uid=root;Pwd=toor;";

        private static void Main()
        {
            MySqlConnection connection = new MySqlConnection(ConnectinString);
            
            // List all books
            Console.WriteLine("All books: ");
            ListAllBooks(connection);
            Console.WriteLine();

            // Find a book by name
            FindBookByName(connection, "si");

            // Adding a book
            AddBook("Nova kniga", DateTime.Now, "12123", 1, connection);

            Console.WriteLine("All books: ");
            ListAllBooks(connection);
            Console.WriteLine();
        }

        private static void ListAllBooks(MySqlConnection connection)
        {
            MySqlCommand cmdListBooks = new MySqlCommand("select book_id, title, publish_date, isbn from books", connection);
            connection.Open();

            MySqlDataReader reader = cmdListBooks.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0} | {1} | {2} | {3}", reader["book_id"], reader["title"], reader["publish_date"], reader["isbn"]);
                }
            }
            connection.Close();
        }

        private static void FindBookByName(MySqlConnection connection, string title)
        {
            string insertSql = "select book_id, title, publish_date, isbn from books where title like @searchForTitle";

            MySqlCommand insertBook = new MySqlCommand(insertSql, connection);

            insertBook.Parameters.AddWithValue("@searchForTitle", "%" + title + "%");

            connection.Open();

            using (MySqlDataReader reader = insertBook.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0} | {1} | {2} | {3}", reader["book_id"], reader["title"], reader["publish_date"], reader["isbn"]);
                }
            }

            connection.Close();
        }

        private static void AddBook(string title, DateTime publishDate, string isbn, int authorId, MySqlConnection connection)
        {
            MySqlCommand cmdInsertBook = new MySqlCommand("insert into books (title, publish_date, isbn, author_id) values (@title, @publish_date, @isbn, @author_id)", connection);
            connection.Open();
            cmdInsertBook.Parameters.AddWithValue("@title", title);
            cmdInsertBook.Parameters.AddWithValue("@publish_date", publishDate);
            cmdInsertBook.Parameters.AddWithValue("@isbn", isbn);
            cmdInsertBook.Parameters.AddWithValue("@author_id", authorId);
            cmdInsertBook.ExecuteNonQuery();
            connection.Close();
        }
    }
}