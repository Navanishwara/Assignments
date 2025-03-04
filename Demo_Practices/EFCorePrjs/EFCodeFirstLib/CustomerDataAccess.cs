using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstLib
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
       
          private readonly CusomerDBContext dbctx;
          public CustomerDataAccess(CusomerDBContext ctx)
        {
            this.dbctx = ctx;

        }
        public void AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCusotmers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
