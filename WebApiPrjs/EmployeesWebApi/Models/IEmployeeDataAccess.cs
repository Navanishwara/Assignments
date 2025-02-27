namespace EmployeesWebApi.Models
{
    public interface IEmployeeDataAccess
    {
        void Add(Employee employee);
        void Delete(int id);
        void Update(Employee employee);
        Employee Get(int id);
        List<Employee> GetAll();    
    }
}
