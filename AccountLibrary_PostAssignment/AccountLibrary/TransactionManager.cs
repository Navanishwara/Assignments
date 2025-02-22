using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Npgsql;

namespace AccountLibrary
{



    public class TransactionManager : ITransactionManagement
    {

        NpgsqlConnection con;
        public TransactionManager()
        {
            con = new NpgsqlConnection();
            con.ConnectionString = "Host=localhost;Database=bankdb;Username=postgres;Password=root";
        }




        public void Deposit(decimal amount, int id)
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE Accounts SET Balance = Balance + @am WHERE AccountId = @id", con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@am", amount);
                cmd.Parameters.AddWithValue("@id", id);
                //open the connection
                con.Open();

                var ids = cmd.ExecuteNonQuery();
                if (ids == 0)
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

        public void Withdraw(decimal amount, int id)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE Accounts SET Balance = Balance - @am WHERE AccountId = @id", con);
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@am", amount);
                cmd.Parameters.AddWithValue("@id", id);
                //open the connection
                con.Open();

                var ids = cmd.ExecuteNonQuery();
                if (ids == 0)
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

        public void TransferFunds(int fromAccount, int toAccount, decimal amount)
        {
            con.Open();
            //using (var transaction = con.BeginTransaction())
            //{


                try
                {
                // Withdraw from source account
                NpgsqlCommand withdrawCmd = new NpgsqlCommand("UPDATE Accounts SET Balance = Balance - @amount WHERE AccountId = @fromAccountId ", con);
                withdrawCmd.CommandType = System.Data.CommandType.Text;
                withdrawCmd.Parameters.AddWithValue("@amount", amount);
                withdrawCmd.Parameters.AddWithValue("@fromAccountId", fromAccount);

                int row = withdrawCmd.ExecuteNonQuery();
                if (row == 0)
                {
                    throw new InsufficientFundsException("Inssufient funds");
                }


                NpgsqlCommand depositCmd = new NpgsqlCommand("UPDATE Accounts SET Balance = Balance + @amount WHERE AccountId = @toAccountId", con);
                depositCmd.CommandType = System.Data.CommandType.Text;
                depositCmd.Parameters.AddWithValue("@amount", amount);
                depositCmd.Parameters.AddWithValue("@toAccountId", toAccount);
                row = depositCmd.ExecuteNonQuery();
                if (row == 0)
                {
                    throw new Exception("Destination AccountId does not exist.");
                }

                //Withdraw(amount, fromAccount);
                //Deposit(amount, toAccount);
                //transaction.Commit();

            }
                catch (Exception ex)
                {
                    //transaction.Rollback();

                    throw new Exception("Transaction failed", ex);
                }
                finally
                {
                    con.Close();
                }
            //}
        }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string mag) : base(mag)
        {
        }


    }
}
