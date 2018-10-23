using JCL.Banker.BLL;
using JCL.Banker.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Please enter an account number: ");
            string accountNumber = Console.ReadLine();
            int AccountID = int.Parse(accountNumber);

            Console.Write("Please enter a deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountDepositResponse response = accountManager.Deposit(AccountID, amount);

            if(response.Success)
            {
                Console.WriteLine("Deposit Completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountID:c}");
                Console.WriteLine($"Old Balance: {response.OldBalance:c}");
                Console.WriteLine($"Deposited Amount: {response.Amount:c}");
                Console.WriteLine($"New Balance: {response.Account.Balance:c}");
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue . . . ");
            Console.ReadKey();

        }
    }
}
