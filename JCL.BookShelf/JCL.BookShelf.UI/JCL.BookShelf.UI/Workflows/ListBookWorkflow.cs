using JCL.BookShelf.Models;
using JCL.BookShelf.UI.Data;
using JCL.BookShelf.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.BookShelf.UI.Workflows
{
    public class ListBookWorkflow
    {
        public void Execute()
        {
            BookRepository repo = new BookRepository();
            List<Book> books = repo.List();

            Console.Clear();
            Console.WriteLine("Book List");

            ConsoleIO.PrintBookListHeader();

            foreach (var book in books)
            {
                Console.WriteLine(ConsoleIO.BookLineFormat, book.Title + ", " + book.AuthorName + ", " + book.Publisher + ", " + book.ReleaseDate.ToString());
            }

            Console.WriteLine();
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}