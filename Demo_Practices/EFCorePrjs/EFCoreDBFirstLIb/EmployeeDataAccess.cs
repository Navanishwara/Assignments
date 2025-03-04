

namespace EFCoreDBFirstLIb
{
    public class EmployeeDataAccess : IEmployeDataAccess
    {
        private readonly EMPDBContext dbCtx;
        public EmployeeDataAccess(EMPDBContext Ctx)
        {
            this.dbCtx = Ctx;
        }
        public void Add(Employee employee)
        {
            dbCtx.employee.Add(employee);
            dbCtx.SaveChanges();
        }

        public void Delete(int id)
        {
          var record=  dbCtx.employee.Where(o => o.empid == id).SingleOrDefault();
            if (record != null)
            {
                //delete the record
                dbCtx.employee.Remove(record);  
                dbCtx.SaveChanges();
            }
            else
            {
                throw new Exception("empid does not exit");
            }
        }

        public List<Employee> GetAllEmps()
        {
            return dbCtx.employee.ToList();
        }

        public Employee GetById(int id)
        {
            var record = dbCtx.employee.Find(id);
            if (record != null)
            {
                return record;
            }
            else
            {
                throw new Exception($"No employee found for {id}");
            }
        }

        public void UpdateEmployee(Employee employee)
        {
           var record = dbCtx.employee.Find(employee.empid);
            if (record != null)
            {
                //dbCtx.employee.Update(record);
                record.name = employee.name;
                record.salary = employee.salary;
                record.depid=employee.depid;
                dbCtx.SaveChanges();
            }
        }
    }
}
