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
    public class RemoveBookWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Remove Book");

            BookRepository repo = new BookRepository(Settings.FilePath);
            List<Book> books = repo.List();

            ConsoleIO.PrintBookListHeader();
            Console.WriteLine();

            int index = ConsoleIO.GetBookIndexFromUser("Which book would you like to delete?", books.Count());
            index--;

            string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to remove {books[index].Title} {books[index].Author}");

            if (answer == "Y")
            {
                repo.Delete(index);
                Console.WriteLine("Book Removed!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Remove cancelled.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}