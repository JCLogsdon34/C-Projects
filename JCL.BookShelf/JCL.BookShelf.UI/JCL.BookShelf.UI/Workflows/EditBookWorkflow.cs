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
    public class EditBookWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Edit Book Release Date");

            BookRepository repo = new BookRepository();
            List<Book> books = repo.List();

            ConsoleIO.PrintBookListHeader();
            Console.WriteLine();

            int index = ConsoleIO.GetBookIndexFromUser("Which book would you like to edit?");
            index--;

            Console.WriteLine();

            books[index].ReleaseDate = ConsoleIO.GetRequiredDateTimeFromUser(string.Format("Enter new Release Date for {0} {1}: ", books[index].Title,
                books[index].AuthorName));

            repo.Edit(books[index]);
            Console.WriteLine("Release Date updated!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}