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
    public class ViewBookWorkflow
    {
        public void Execute()
        { 
            Console.Clear();
            Console.WriteLine("View Book");

            BookRepository repo = new BookRepository();
            List<Book> books = repo.List();
            Book book = new Book();
            
            Console.Clear();
            Console.WriteLine("View Book");

            ConsoleIO.PrintBookListHeader();
            books = repo.List();
            int index = 0;
            index = ConsoleIO.GetBookIndexFromUser("Which book would you like to view?");

            //   index--;
            book = repo.GetBook(index);

                string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to view {book.Title} {book.AuthorName}");

           //     foreach (var book in books)
             //   {
                    Console.WriteLine(ConsoleIO.BookLineFormat, book.BookID.ToString(), book.Title + ", " + book.AuthorName + ", " + book.Publisher + ", " + book.ReleaseDate.ToString());
              //  }

            Console.WriteLine();
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}