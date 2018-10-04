using JCL.Banker.Model;
using JCL.Banker.Model.Interfaces;
using JCL.Banker.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.BLL.WithdrawRules
{
    public class FreeAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Free)
            {
                response.Success = false;
                response.Message = "Error: a non free acount hit the Free Withdrawl Rule";
                return response;
            }

            if (amount > 500)
            {
                response.Success = false;
                response.Message = "Error: Free accounts may not withdrawl more than $500 at a time.";
                return response;
            }

            if (amount <= 0)
            {
                response.Success = false;
                response.Message = "Withdrawl amounts must be greater than 0";
                return response;
            }

            response.OldBalance = account.Balance;
            account.Balance -= amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;

            return response;
        }
    }
}
