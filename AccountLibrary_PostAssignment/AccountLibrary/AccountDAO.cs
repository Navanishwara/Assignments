using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace AccountLibrary
{
    public class AccountDAO
    {

        NpgsqlConnection con;
        public AccountDAO()
        {
            con = new NpgsqlConnection();
            con.ConnectionString = "Host=localhost;Database=bankdb;Username=postgres;Password=root";
        }


        public void AddAccount(Account account)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into  Accounts values (@ai,@an,@bal,@at)", con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ai", account.AccountId);
                cmd.Parameters.AddWithValue("@an", account.AccountNumber);
                cmd.Parameters.AddWithValue("@bal", account.Balance);
                cmd.Parameters.AddWithValue("@at", account.AccountType);

                //open the connection 
                con.Open();
                //execute the command
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //close the connection
                con.Close();
            }
        }

        public Account GetAccountById(int accountId)
        {

            Account ac = new Account();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Accounts WHERE AccountId = @aid", con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@aid", accountId);

                con.Open();
                var sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    string accountType = (string)sdr["AccountType"];
                    Account account = null;

                    if (accountType == "SavingsAccount")
                    {
                        account = new SavingsAccount
                        {
                            //InterestRate = (decimal)sdr["InterestRate"]
                        };
                    }
                    else if (accountType == "CurrentAccount")
                    {
                        account = new CurrentAccount
                        {
                            //OverdraftLimit = (decimal)sdr["OverdraftLimit"]
                        };
                    }
                    ac = new Account
                    {

                        AccountId = sdr.GetInt32(0),
                        AccountNumber = sdr.GetInt32(1),
                        Balance = sdr.GetDecimal(2),
                        AccountType = sdr.GetString(3),
                    };

                }
                sdr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ac;
            
            
        }

        public void UpdateAccount(Account account)
        {
            
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE Accounts SET Balance = @bal WHERE AccountId = @aid", con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@bal", account.Balance);
                cmd.Parameters.AddWithValue("@aid", account.AccountId);
                //open the connection
                con.Open();
                //execute the command
                var id = cmd.ExecuteNonQuery();
                if (id == 0)
                {
                    throw new Exception("AccountId  does not exists");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //close conection
                con.Close();
            }

        }
    }

    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message) { }

    }
}
