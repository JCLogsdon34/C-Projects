using JCL.Banker.BLL;
using JCL.Banker.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.UI.Workflows
{
    public class AccountLookupWorkflow
    {
        public void Execute()
        {
            AccountManager manager = AccountManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup an account: ");
            Console.WriteLine("-----------------------------");
            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();
            int AccountID = int.Parse(accountNumber);

            AccountLookupResponse response = manager.LookupAccount(AccountID);

            if (response.Success)
            {
                ConsoleIO.DisplayAccountDetails(response.Account);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }
                Console.WriteLine("Press any key to continue: ");
                Console.ReadKey();

        }
    }
}
