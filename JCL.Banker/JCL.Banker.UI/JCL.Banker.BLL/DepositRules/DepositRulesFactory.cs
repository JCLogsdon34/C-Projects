using JCL.Banker.Model;
using JCL.Banker.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.BLL.DepositRules
{
    public class DepositRulesFactory
    {
        public static IDeposit Create(AccountType type)
        {
            switch(type)
            {
                case AccountType.Free:
                    return new FreeAccountDepositRule();
            }

            throw new Exception("Account type is not supported!");

        }
    }
}
