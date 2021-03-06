﻿using JCL.Banker.BLL.DepositRules;
using JCL.Banker.BLL.WithdrawRules;
using JCL.Banker.Model.Interfaces;
using JCL.Banker.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.BLL
{
    public class AccountManager
    {
        private IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountLookupResponse LookupAccount(int AccountID)
        {
            AccountLookupResponse response = new AccountLookupResponse();

            response.Account = _accountRepository.LoadAccount(AccountID);

            if(response.Account == null)
            {
                response.Success = false;
                response.Message = $"{AccountID} is not a valid account";
            } 
            else
            {
                response.Success = true;
            }

            return response;
        }

        public AccountDepositResponse Deposit(int AccountID, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            response.Account = _accountRepository.LoadAccount(AccountID);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{AccountID} is not a valid account";
            }
            else
            {
                response.Success = true;
            }

            IDeposit depositRule = DepositRulesFactory.Create(response.Account.Type);
            response = depositRule.Deposit(response.Account, amount);

            if(response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }
            return response;
        }

        public AccountWithdrawResponse Withdraw(int AccountID, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            response.Account = _accountRepository.LoadAccount(AccountID);

            if (response.Account == null)
            {
                response.Success = false;
                response.Message = $"{AccountID} is not a valid account";
            }
            else
            {
                response.Success = true;
            }

            IWithdraw withdrawRule = WithdrawRulesFactory.Create(response.Account.Type);
            response = withdrawRule.Withdraw(response.Account, amount);

            if (response.Success)
            {
                _accountRepository.SaveAccount(response.Account);
            }

            return response;

        }

    }
}
