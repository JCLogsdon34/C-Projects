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
            BookRepository repo = new BookRepository();
            Console.Clear();
            Console.WriteLine("Add Book");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();

            Book newBook = new Book();

            newBook.Title = ConsoleIO.GetRequiredStringFromUser("Title: ");
            newBook.AuthorName = ConsoleIO.GetRequiredStringFromUser("Author: ");
            newBook.Publisher = ConsoleIO.GetRequiredStringFromUser("Publisher: ");
            newBook.ReleaseDate = ConsoleIO.GetRequiredDateTimeFromUser("ReleaseDate: ");
            
            if (ConsoleIO.GetYesNoAnswerFromUser("Add the following information") == "Y")
            {  
                newBook = repo.Add(newBook);
                Console.WriteLine("BookID: " + newBook.BookID);
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