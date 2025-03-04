using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstLib
{
    public interface ICustomerDataAccess
    {
        List<Customer> GetCusotmers();
        Customer  GetCustomer(int id);
        void AddCustomer(Customer customer);
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer customer);


    }
}
