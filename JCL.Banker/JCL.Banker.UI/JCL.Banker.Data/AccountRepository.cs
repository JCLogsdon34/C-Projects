using JCL.Banker.Model;
using JCL.Banker.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.Data
{
    public class AccountRepository : IAccountRepository
    {

        private string _filePath;
        private SelectQuery _selectQuery;

        public AccountRepository(SelectQuery selectQuery)
        {
            _selectQuery = selectQuery;
        }

        // CRUD
        public List<Account> List()
        {
            List<Account> accounts = new List<Account>();
            SelectQuery selectQuery = new SelectQuery();
            //    using (_filePath)
            //   {
                accounts = selectQuery.getAllAccounts();
                string line;
                int length = 0;
                
                length = accounts.Count;
                 while ((line = sr.ReadLine()) != null)
                { 
                    Account newAccount = new Account();
                    string[] columns = line.Split(',');

                    newAccount.AccountID = int.Parse(columns[0]);
                    newAccount.AccountName = columns[1];
                    newAccount.BalanceID = int.Parse(columns[2]);
                    newAccount.Balance = decimal.Parse(columns[3]);
                    newAccount.Type = (AccountType)Enum.Parse(typeof(AccountType), columns[4]);

                    accounts.Add(newAccount);
                   }
                
            return accounts;
        }

        public Account View(int index)
        {
            Account account = new Account();
            var accounts = List();

            accounts[index] = account;

            return account;
        }

        public void Add(Account account)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                string line = CreateCsvForAccount(account);

                sw.WriteLine(line);
            }
        }

        public void Edit(Account account, int index)
        {
            var accounts = List();

            accounts[index] = account;

            CreateAccountFile(accounts);
        }

        public void Delete(int index)
        {
            var accounts = List();
            accounts.RemoveAt(index);

            CreateAccountFile(accounts);
        }

        private string CreateCsvForAccount(Account account)
        {
            return string.Format("{0},{1},{2},{3}", account.AccountID,
                    account.AccountName, account.BalanceID, account.Type);
        }

        private void CreateAccountFile(List<Account> accounts)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("Name,Balance,Account Number,Type");
                foreach (var account in accounts)
                {
                    sr.WriteLine(CreateCsvForAccount(account));
                }
            }
        }

        public Account LoadAccount(int AccountID)
        {
            SelectQuery selectQuery = new SelectQuery();
            Account account = new Account();
            account = selectQuery.getAccount(AccountID);
            return account;
        }

        public void SaveAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
