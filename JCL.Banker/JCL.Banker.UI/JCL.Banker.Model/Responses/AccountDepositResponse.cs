﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.Model.Responses
{
    public class AccountDepositResponse : Response
    {
       public Account Account { get; set; }
       public decimal Amount { get; set; }
       public decimal OldBalance { get; set; }
       
    }
}