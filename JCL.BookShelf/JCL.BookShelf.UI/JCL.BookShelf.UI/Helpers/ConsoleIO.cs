using JCL.BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.BookShelf.UI.Helpers
{
    public class ConsoleIO
    {
        public const string SeparatorBar = "===================================================";
        public const string BookLineFormat = "{0,-20} {1,-15} {2, 5}";
        public const string PickBookLineFormat = "{0,2} {1,-20} {2,-15} {3, 5}";

        public static void PrintBookListHeader()
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine(BookLineFormat, "BookID", "Title", "Author", "Publisher", "Release Date");
            Console.WriteLine(SeparatorBar);
        }

        public static string GetRequiredStringFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }

        public static void PrintPickListOfBooks(List<Book> books)
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine(PickBookLineFormat, "BookID", "Title", "Author", "Publisher", "Release Date");
            Console.WriteLine(SeparatorBar);

            for (int i = 0; i < books.Count(); i++)
            {
                Console.WriteLine(PickBookLineFormat, i + 1, books[i].BookID + " ," + books[i].Title + ", " + books[i].AuthorName + ", " + books[i].Publisher + ", " +
                 books[i].ReleaseDate);
            }

         //   Console.WriteLine();
            Console.WriteLine(SeparatorBar);
        }

        public static string GetYesNoAnswerFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    return input;
                }
            }
        }

        public static int GetRequiredDateTimeFromUser(string prompt)
        {
            DateTime output = new DateTime();
            int finaloutput = 0;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!DateTime.TryParse(input, out output))
                {
                    Console.WriteLine("Date must be a of the pattern: MM/DD/YYYY.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    output = DateTime.Parse(input);
                    finaloutput = output.Year;
                }   
                    return finaloutput;
                }
            }

        public static int GetBookIndexFromUser(string prompt, int count)
        {
            int output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid integer.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (output < 1 || output > count)
                    {
                        Console.WriteLine("Please choose a student by number between {0} and {1}", 1, count);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    return output;
                }
            }
        }
    }
}
