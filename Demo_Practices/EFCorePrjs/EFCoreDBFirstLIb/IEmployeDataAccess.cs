using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDBFirstLIb
{
    public interface IEmployeDataAccess
    {
        void Add(Employee employee);
        void Delete(int id);
        void UpdateEmployee(Employee employee);
        List<Employee> GetAllEmps();
        Employee GetById(int id);
    }
}
