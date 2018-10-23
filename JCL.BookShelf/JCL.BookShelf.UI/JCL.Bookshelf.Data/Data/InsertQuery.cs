using JCL.BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Bookshelf.Data.Data
{
    public class InsertQuery
    {
        public Book InsertBook(Book book)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Server=localhost;Database=BookShelfTest;"
                   + "User Id=sa;Password=HenryClay1";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = " INSERT INTO Book (Title, Author, Publisher, ReleaseDate)" +
                        " VALUES (@Title, @Author, @Publisher, @ReleaseDate)" +
                        " GO";

                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.AuthorName);
                    cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                    cmd.Parameters.AddWithValue("@ReleaseDate", book.ReleaseDate);

                    conn.Open();
                    book.BookID = cmd.ExecuteNonQuery();
                }
            }catch (SqlException exception)
            {
                Console.WriteLine("Sql Exception Caught");
            }
            return book;         
        }
    }
}