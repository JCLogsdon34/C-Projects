using JCL.Banker.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.Data
{
    public class SelectQuery
    {

        public List<Account> getAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            Account currentAccount = new Account();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=BankAccountTest;"
               + "User Id=sa;Password=HenryClay1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT a.AccountID, a.AccountName, a.BalanceID, a.AccountTypeID " +
                    "b.BalanceID, b.Balance, " +
                    "t.AccountTypeID, t.AccountType" +
                    "FROM Account a, Balance b, Account Type t " +
                    "INNER JOIN Account a ON b.BalanceID = a.BalanceID" +
                    "INNER JOIN Account a ON t.AccountTypeID = a.AccountTypeID";

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        currentAccount.AccountName = dr["AccountName"].ToString();
                        if (dr["BalanceID"] != DBNull.Value)
                            currentAccount.BalanceID = (int)dr["BalanceID"];
                        currentAccount.Balance = decimal.Parse(dr["Balance"].ToString());
                        if (dr["AccountTypeID"] != DBNull.Value)
                            currentAccount.Type = (AccountType)Enum.Parse(typeof(AccountType), (dr["AccountTypeID"].ToString()));
                        if (dr["AccountID"] != DBNull.Value)
                            currentAccount.AccountID = (int)dr["AccountID"];
                    }
                }
            }
            return accounts;
        }

        public Account getAccount(int AccountID)
        {
            Account currentAccount = new Account();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=SBankAccountTest;"
               + "User Id=sa;Password=HenryClay1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT a.AccountID, a.AccountName, a.BalanceID, a.AccountTypeID " +
                    "b.BalanceID, b.Balance, " +
                    "t.AccountTypeID, t.AccountType" +
                    "FROM Account a, Balance b, Account Type t " +
                    "INNER JOIN Account a ON b.BalanceID = a.BalanceID" +
                    "INNER JOIN Account a ON t.AccountTypeID = a.AccountTypeID" +
                    "WHERE AccountID = @Account";
                cmd.Parameters.AddWithValue("@Account", AccountID);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        currentAccount.AccountName = dr["AccountName"].ToString();
                        if (dr["BalanceID"] != DBNull.Value)
                            currentAccount.BalanceID = (int)dr["BalanceID"];
                        currentAccount.Balance = decimal.Parse(dr["Balance"].ToString());
                        if (dr["AccountTypeID"] != DBNull.Value)
                            currentAccount.Type = (AccountType)Enum.Parse(typeof(AccountType), (dr["AccountTypeID"].ToString()));
                        if (dr["AccountID"] != DBNull.Value)
                            currentAccount.AccountID = (int)dr["AccountID"];
                    }
                }
            }
            return currentAccount;
        }

        public void InsertAccount(string AccountName, decimal Balance, AccountType Type)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString =
                        ConfigurationManager.ConnectionStrings["BankAccount"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Account (AccoutName, Balance, Type) " +
                    "VALUES (@AccountName, @Balance, @Type)";

                cmd.Parameters.AddWithValue("@AccountName", AccountName);
                cmd.Parameters.AddWithValue("@Balance", Balance);
                cmd.Parameters.AddWithValue("@Type", Type);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public class UpdateQuery
        {
            public void UpdateAccount(int AccountID, string AccountName, int BalanceID, decimal Balance, AccountType Type)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["BankAccount"].ConnectionString;

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Account " +
                        " SET AccountName = @AccountName, " +
                        "UPDATE Balance" +
                        " WHERE BalanceID = @BalanceID " +
                            " SET BALANCE = @Balance";

                    cmd.Parameters.AddWithValue("@AccountName", AccountName);
                    cmd.Parameters.AddWithValue("@BalanceID", BalanceID);
                    cmd.Parameters.AddWithValue("@Balance", Balance);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }


            public void DeleteAccount(int AccountID, int BalanceID)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["BankAccount"].ConnectionString;

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = 
                        " DELETE FROM Balance" +
                         " WHERE BalanceID = @BalanceID" +
                        " DELETE FROM Account " +
                           " WHERE AccountID = @AccountID";

                    cmd.Parameters.AddWithValue("@BalanceID", BalanceID);
                    cmd.Parameters.AddWithValue("@AccountID", AccountID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public AccountType getAccountType(AccountType type)
        {
            AccountType currentAccount = new AccountType();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=SBankAccountTest;"
               + "User Id=sa;Password=HenryClay1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT" +
                    " AccountTypeID, AccountType" +
                    " FROM  AccountType" +
                    " WHERE AcccountTypeID = @AccountType";
                cmd.Parameters.AddWithValue("@AccountType", type);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["AccountTypeID"] != DBNull.Value)
                            currentAccount = (AccountType)Enum.Parse(typeof(AccountType), (dr["AccountTypeID"].ToString()));
                    }
                }
            }
            return currentAccount;
        }


        public decimal getAccountBalance(int BalanceID)
        {
            decimal Balance = 0;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=localhost;Database=SBankAccountTest;"
               + "User Id=sa;Password=HenryClay1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT" +
                    " Balance" +
                    " FROM  Balance" +
                    " WHERE BalanceID = @Balance";

                cmd.Parameters.AddWithValue("@Balance", BalanceID);

                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr["BalanceID"] != DBNull.Value)
                            Balance = decimal.Parse((dr["AccountTypeID"]).ToString());
                    }
                }
            }
            return Balance;
        }
    }
}