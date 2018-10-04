using JCL.Banker.BLL;
using JCL.Banker.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.UI.Workflows
{
    public class WithdrawWorkflow
    {
        public void Execute()
        {
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Please enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Please enter the amount you would like to withdraw: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountWithdrawResponse response = accountManager.Withdraw(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Withdraw Completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber:c}");
                Console.WriteLine($"Old Balance: {response.OldBalance:c}");
                Console.WriteLine($"Withdrawn Amount: {response.Amount:c}");
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