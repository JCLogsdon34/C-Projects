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
        private string _filePath;

        public BookRepository(string filePath)
        {
            _filePath = filePath;
        }

        // CRUD
        public List<Book> List()
        {
            List<Book> books = new List<Book>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Book newBook = new Book();
                    string[] columns = line.Split(',');

                    newBook.Title = columns[0];
                    newBook.Author = columns[1];
                    newBook.Publisher = columns[2];
                    newBook.ReleaseDate = int.Parse(columns[3]);

                    books.Add(newBook);
                }
            }

            return books;
        }

        public void Add(Book book)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                string line = CreateCsvForBook(book);

                sw.WriteLine(line);
            }
        }

        public void Edit(Book book, int index)
        {
            var books = List();

            books[index] = book;

            CreateBookFile(books);
        }

        public void Delete(int index)
        {
            var books = List();
            books.RemoveAt(index);

            CreateBookFile(books);
        }

        private string CreateCsvForBook(Book book)
        {
            return string.Format("{0},{1},{2},{3}", book.Title,
                    book.Author, book.Publisher, book.ReleaseDate);
        }

        private void CreateBookFile(List<Book> books)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("Title,Author,Publisher,ReleaseDate");
                foreach (var book in books)
                {
                    sr.WriteLine(CreateCsvForBook(book));
                }
            }
        }
    }
}