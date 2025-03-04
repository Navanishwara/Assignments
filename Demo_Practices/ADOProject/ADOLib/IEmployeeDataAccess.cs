using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOLib
{
    public  interface IEmployeeDataAccess

    {
        void AddEmployee(Employee employee);
        void DeleteEmployee(int ecode);
        void UpdateEmployee(Employee employee);

        List<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        void UpdateSalUsingSP(int ecode, int salary);
    }
}
