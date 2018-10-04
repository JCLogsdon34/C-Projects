using JCL.Banker.Model;
using JCL.Banker.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.Data
{
    public class AccountRepository : IAccountRepository
    {

        private string _filePath;

        public AccountRepository(string filePath)
        {
            _filePath = filePath;
        }

        // CRUD
        public List<Account> List()
        {
            List<Account> accounts = new List<Account>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Account newAccount = new Account();
                    string[] columns = line.Split(',');

                    newAccount.Name = columns[0];
                    newAccount.Balance = decimal.Parse(columns[1]);
                    newAccount.AccountNumber = columns[2];
                    newAccount.Type = Enum.GetName(typeof(AccountType), newAccount.Type.GetTypeCode()); ;

                    accounts.Add(newAccount);
                }
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
            return string.Format("{0},{1},{2},{3}", account.Name,
                    account.Balance, account.AccountNumber, account.Type);
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

        public Account LoadAccount(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
