using JCL.BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Bookshelf.Data.Data
{
    public class UpdateQuery
    {
        public void UpdateBook(Book book)
        {
            try {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Server=localhost;Database=BookShelfTest;"
                   + "User Id=sa;Password=HenryClay1";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = " UPDATE Book" +
                        " SET Title = @Title" +
                        " SET AuthorName = @Author" +
                        " SET Publisher = @Publisher" +
                        " SET ReleaseDate = @ReleaseDate" +
                        " WHERE BookID = @BookID" +
                        " GO";

                    cmd.Parameters.AddWithValue("@Title", book.Title);
                    cmd.Parameters.AddWithValue("@Author", book.AuthorName);
                    cmd.Parameters.AddWithValue("@Publisher", book.Publisher);
                    cmd.Parameters.AddWithValue("@ReleaseDate", book.ReleaseDate);
                    cmd.Parameters.AddWithValue("@BookID", book.BookID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }catch (SqlException exception)
            {
                Console.WriteLine("SQL Exception Thrown");
            }
            
        }
    }
}