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

            BookRepository repo = new BookRepository(Settings.FilePath);
            List<Book> books = repo.List();

            
            Console.Clear();
            Console.WriteLine("View Book");

            ConsoleIO.PrintBookListHeader();
            int index = ConsoleIO.GetBookIndexFromUser("Which book would you like to view?", books.Count());
            index--;

            string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to remove {books[index].Title} {books[index].Author}");

            //foreach (var book in books)
           // {
                Console.WriteLine(ConsoleIO.BookLineFormat, books[index].Title + ", " + books[index].Author + ", " + books[index].Publisher + ", " + books[index].ReleaseDate.ToString());
           // }

            Console.WriteLine();
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}