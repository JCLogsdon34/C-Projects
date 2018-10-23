using JCL.Bookshelf.Data.Data;
using JCL.BookShelf.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.BookShelf.UI.Data
{
    public class BookRepository
    {
        //        private string _filePath;

        public BookRepository()
        {
            //     _filePath = filePath;

        }

        // CRUD
        public List<Book> List()
        {
            List<Book> books = new List<Book>();
            SelectQuery select = new SelectQuery();
            books = select.getAllBooks();
//            using (StreamReader sr = new StreamReader(_filePath))
//            {
//                sr.ReadLine();
//                string line;

//                while ((line = sr.ReadLine()) != null)
//                {
//                    Book newBook = new Book();
//                    string[] columns = line.Split(',');

//                    newBook.Title = columns[0];
//                    newBook.AuthorName = columns[1];
//                    newBook.Publisher = columns[2];
//                    newBook.ReleaseDate = int.Parse(columns[3]);

//                    books.Add(newBook);
//                }
//            }

            return books;
        }

        public Book GetBook(int BookID)
        {
            SelectQueryWithParameters para = new SelectQueryWithParameters();
            return para.GetBook(BookID);
        }

        public Book Add(Book book)
        {
            //            using (StreamWriter sw = new StreamWriter(_filePath, true))
            //            {
            //                string line = CreateCsvForBook(book);

            //               sw.WriteLine(line);
            //            }
            InsertQuery insertQuery = new InsertQuery();
            return insertQuery.InsertBook(book);
        }

        public void Edit(Book book)
        {
            //            var books = List();

            //            books[index] = book;

            //            CreateBookFile(books);
            UpdateQuery update = new UpdateQuery();
            update.UpdateBook(book);
        }

        public void Delete(int BookID)
        {
            //    var books = List();
            //   books.RemoveAt(index);

            //  CreateBookFile(books);
            DeleteQuery delete = new DeleteQuery();
            delete.RemoveBook(BookID);
        }

        private string CreateCsvForBook(Book book)
        {
            return string.Format("{0},{1},{2},{3}", book.Title,
                    book.AuthorName, book.Publisher, book.ReleaseDate);
        }

  //      private void CreateBookFile(List<Book> books)
  //      {
    //        if (File.Exists(_filePath))
      //          File.Delete(_filePath);

//            using (StreamWriter sr = new StreamWriter(_filePath))
  //          {
    //            sr.WriteLine("Title,Author,Publisher,ReleaseDate");
      //          foreach (var book in books)
        //        {
          //          sr.WriteLine(CreateCsvForBook(book));
            //    }
         //   }
       // }
    }
}