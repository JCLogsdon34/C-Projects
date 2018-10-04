using JCL.Banker.Model;
using JCL.Banker.Model.Interfaces;
using JCL.Banker.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.BLL.DepositRules
{
    public class FreeAccountDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            if(account.Type != AccountType.Free)
            {
                response.Success = false;
                response.Message = "Error: a non free acount hit the Free Deposit Rule";
                return response;
            }

            if(amount > 100)
            {
                response.Success = false;
                response.Message = "Error: Free accounts may not deposit more than $100 at a time.";
                return response;
            }

            if(amount <= 0)
            {
                response.Success = false;
                response.Message = "Deposit amounts must be greater than 0";
                return response;
            }

            response.OldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;

            return response;
        }
    }
}
