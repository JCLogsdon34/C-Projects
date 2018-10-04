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
    public class AddBookWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add Book");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();

            Book newBook = new Book();

            newBook.Title = ConsoleIO.GetRequiredStringFromUser("Title: ");
            newBook.Author = ConsoleIO.GetRequiredStringFromUser("Author: ");
            newBook.Publisher = ConsoleIO.GetRequiredStringFromUser("Publisher: ");
            newBook.ReleaseDate = ConsoleIO.GetRequiredDateTimeFromUser("ReleaseDate: ");

            Console.WriteLine();
            ConsoleIO.PrintBookListHeader();
            Console.WriteLine(ConsoleIO.BookLineFormat, newBook.Title + ", " + newBook.Author + ", " + newBook.Publisher + ", " + newBook.ReleaseDate);

            Console.WriteLine();
            if (ConsoleIO.GetYesNoAnswerFromUser("Add the following information") == "Y")
            {
                BookRepository repo = new BookRepository(Settings.FilePath);
                repo.Add(newBook);
                Console.WriteLine("Book Added!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Add Cancelled");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}