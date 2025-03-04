using EFCoreDBFirstLIb;

namespace BusinessLayerHRMLIB
{
    public class BusinessLayer
    {
        private readonly IEmployeDataAccess dal;
        public BusinessLayer(IEmployeDataAccess dal)
        {
            this.dal = dal; 
        }
            public List<Employee> GetAllEmps()
        {
            return dal.GetAllEmps();
        }
        public Employee GetEmployee(int id)
        {
            return dal.GetById(id);
        }
        public void Add(Employee employee)
        { 
            dal.Add(employee);
        }
        public void Delete(int id) 
        {
            dal.Delete(id);
        }
        public void UpdateEmployee(Employee employee)
        {
            dal.UpdateEmployee(employee);
        }
    }
}
