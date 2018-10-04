using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.Model
{
    public class Account
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountType Type { get; set; }

        public void SetAccountTypeDescription()
        {
            switch (Type)
            {
                case AccountType.Free:
                    Type = AccountType.Free;
                    break;
                case AccountType.Basic:
                    Type = AccountType.Basic;
                    break;
                case AccountType.Premium:
                    Type = AccountType.Premium;
                    break;
            }
        }
    }
}