using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace JCL.Bookshelf.Data.Data
{
    public class DeleteQuery
    {
        public void RemoveBook(int BookID)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=BookShelfTest;"
               + "User Id=sa;Password=HenryClay1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText =
                    " DELETE FROM Book" +
                     " WHERE BookID = @BookID" +
                     " GO";

                cmd.Parameters.AddWithValue("@BookID", BookID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}