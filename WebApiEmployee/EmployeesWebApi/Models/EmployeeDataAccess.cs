
namespace EmployeesWebApi.Models
{
    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly EmployeeDbContext dbCtx;
        public EmployeeDataAccess(EmployeeDbContext dbCtx) 
        {
            this.dbCtx = dbCtx;
        }

        public void Add(Employee employee)
        {
           
            dbCtx.employee.Add(employee);
            dbCtx.SaveChanges();
        }

        public void Delete(int id)
        {
            //throw new NotImplementedException();
            var record = dbCtx.employee.Find(id);
            if (record != null)
            {
                dbCtx.employee.Remove(record);
                dbCtx.SaveChanges();
            }
            else
            {
                throw new Exception("record not found");
            }

        }

        public Employee Get(int id)
        {
            //throw new NotImplementedException();
            var record = dbCtx.employee.Find(id);
            if (record != null)
            {
                return record;
            }
            else
            {
                throw new Exception($"Could not find {id}");
            }

        }

       

        public List<Employee> GetAll()
        {
            //throw new NotImplementedException();
            return dbCtx.employee.ToList();
        }

        public void Update(Employee employee)
        {
            //throw new NotImplementedException();
            var record = dbCtx.employee.Find(employee.Empid);
            if (record != null)
            {
                record.Name = employee.Name;
                record.Salary = employee.Salary;
                record.Deptid = employee.Deptid;
                dbCtx.SaveChanges();
            }
            else
            {
                throw new Exception("record not found");
            }
        }
    }
}
