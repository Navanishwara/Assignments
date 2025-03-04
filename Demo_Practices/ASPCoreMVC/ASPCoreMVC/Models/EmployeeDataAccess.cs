
namespace ASPCoreMVC.Models
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly EmpDBContext dbCtx;
        public EmployeeDataAccess(EmpDBContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }
        public void AddEmployee(Employee employee)
        {
            dbCtx.Employees.Add(employee);
            dbCtx.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var record = dbCtx.Employees.Find(id);
            if (record != null)
            {
                dbCtx.Employees.Remove(record);
                dbCtx.SaveChanges();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }

        public List<Employee> GetAllEmp()
        {
            return dbCtx.Employees.ToList();
        }

        public Employee GetEmpById(int id)
        {
            var record = dbCtx.Employees.Find(id);
            if (record != null)
            {
                return record;
            }
            else
            {
                throw new Exception("Record not found");
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            var record = dbCtx.Employees.Find(employee.empid);
            if (record != null)
            {
                record.name = employee.name;
                record.salary = employee.salary;
                record.deptid = employee.deptid;
                dbCtx.SaveChanges();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }
    }
}
