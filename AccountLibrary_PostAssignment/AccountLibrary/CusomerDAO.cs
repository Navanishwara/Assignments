using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace AccountLibrary
{
    public class CusomerDAO 
    {


        NpgsqlConnection con;
        public CusomerDAO()
        {
            con = new NpgsqlConnection();
            con.ConnectionString = "Host=localhost;Database=bankdb;Username=postgres;Password=root";
        }
        

        public void AddCustomer(Customers customers)
        {

            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into customers values(@ci,@fn,@mb,@em)", con);
                cmd.CommandType = System.Data.CommandType.Text;
              
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ci", customers.CustomerId);
                cmd.Parameters.AddWithValue("@fn", customers.Name);
                cmd.Parameters.AddWithValue("@mb", customers.Mobile);
                cmd.Parameters.AddWithValue("@em",customers.Email);

                //open the connection 
                con.Open();
                //execute the command
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {
                //close the connection
                con.Close();
            }

        }

        public Customers GetCustomerById(int customerId)
        {
            Customers customers = null;

            try
            {

                NpgsqlCommand cmd = new NpgsqlCommand("select * from Customers where CustomerId= @ci ", con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ci", customerId);
                con.Open();

                var sdr = cmd.ExecuteReader();
                if (sdr.Read()) {
               //get the record one by one and add int
                    customers = new Customers
                    {

                        CustomerId = sdr.GetInt32(0),
                        Name = sdr.GetString(1),
                        Mobile = sdr.GetString(2),
                        Email = sdr.GetString(3),
                    };
                }
                else
                {
                    throw new CustomerNotFoundException("Customer not found.");
                }
                sdr.Close();
            }
            catch (Exception ex) { throw ex; }
            finally { con.Close(); }
            return customers;
        }

        public void UpdateCustomer(Customers customer)
        {
            try
            {  
                NpgsqlCommand cmd = new NpgsqlCommand("update Customers set  MobileNumber=@mb where CustomerId=@ci", con);
                cmd.CommandType = System.Data.CommandType.Text;
               
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mb", customer.Mobile);
                cmd.Parameters.AddWithValue("@ci", customer.CustomerId);
                //open the connection
                con.Open();
                //execute the command
                var id = cmd.ExecuteNonQuery();
                if (id == 0)
                {
                    throw new Exception("CustomerId  does not exists");
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
    public class CustomerNotFoundException : Exception
        {
         public CustomerNotFoundException(string message) : base(message) { }   
    }
}
