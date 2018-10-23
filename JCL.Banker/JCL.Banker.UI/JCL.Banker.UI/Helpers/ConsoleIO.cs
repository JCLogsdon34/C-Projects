using JCL.Banker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.UI
{
    public class ConsoleIO
    {
        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine($"Account Number: {account.AccountID}");
            Console.WriteLine($"Name: {account.AccountName}");
            Console.WriteLine($"Balance: {account.Balance:c}");
        }
    }
}
