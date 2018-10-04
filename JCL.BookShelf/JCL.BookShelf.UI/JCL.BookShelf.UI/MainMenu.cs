using JCL.BookShelf.UI.Helpers;
using JCL.BookShelf.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.BookShelf.UI
{
    public class MainMenu
    {
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Book Management System");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("1. List Books");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. Remove Book");
            Console.WriteLine("4. Edit Book Release Date");
            Console.WriteLine("5. View Book");
            Console.WriteLine("");
            Console.WriteLine("Q - Quit");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("");
            Console.Write("Enter choice: ");
        }

        private static bool ProcessChoice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListBookWorkflow listWorkflow = new ListBookWorkflow();
                    listWorkflow.Execute();
                    break;
                case "2":
                    AddBookWorkflow addWorkflow = new AddBookWorkflow();
                    addWorkflow.Execute();
                    break;
                case "3":
                    RemoveBookWorkflow removeWorkflow = new RemoveBookWorkflow();
                    removeWorkflow.Execute();
                    break;
                case "4":
                    EditBookWorkflow editWorkflow = new EditBookWorkflow();
                    editWorkflow.Execute();
                    break;
                case "5":
                    ViewBookWorkflow viewBookWorkflow = new ViewBookWorkflow();
                    viewBookWorkflow.Execute();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("That is not a valid choice.  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            return true;
        }

        public static void Show()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                DisplayMenu();
                continueRunning = ProcessChoice();
            }
        }
    }
}