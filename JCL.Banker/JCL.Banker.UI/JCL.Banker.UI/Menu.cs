﻿using JCL.Banker.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.UI
{
    public static class Menu
    {
        public static void start()
        {
            Boolean keepBoolingAround = true;
            while(keepBoolingAround)
            {
                Console.Clear();
                Console.WriteLine("JCL Bank Application");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1. Lookup an Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("---------------------------");

                Console.WriteLine("\nQ to quit");
                Console.WriteLine("\nEnter selection: ");

                string userinput = Console.ReadLine();

                switch(userinput)
                {
                    case "1":
                        AccountLookupWorkflow lookupWorkflow = new AccountLookupWorkflow();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        DepositWorkflow depositWorkflow = new DepositWorkflow();
                        depositWorkflow.Execute();
                        break;
                    case "3":
                        WithdrawWorkflow withdrawWorkflow = new WithdrawWorkflow();
                        withdrawWorkflow.Execute();
                        break;
                    case "Q":
                        keepBoolingAround = false;
                        break;
                }

            }
        }
    }
}