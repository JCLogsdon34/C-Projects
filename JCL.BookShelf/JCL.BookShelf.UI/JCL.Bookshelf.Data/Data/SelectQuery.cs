﻿using JCL.BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Bookshelf.Data.Data
{
    public class SelectQuery
    {
        public List<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();
            Book currentBook = new Book();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = "Server=localhost;Database=BookShelfTest;"
                   + "User Id=sa;Password=HenryClay1";

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = " SELECT *" +
                        " FROM Book" +
                        " GO";

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            currentBook.Title = dr["Title"].ToString();
                            currentBook.AuthorName = dr["Author"].ToString();
                            currentBook.Publisher = dr["Publisher"].ToString();
                            currentBook.ReleaseDate = int.Parse(dr["ReleaseDate"].ToString());
                            books.Add(currentBook);
                        }
                    }
                }
            } catch (SqlException exception) {
                Console.WriteLine("SQL Exception thrown");
            }
            return books;
        }
    }
}
