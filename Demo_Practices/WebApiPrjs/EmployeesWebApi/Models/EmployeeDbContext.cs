using Microsoft.EntityFrameworkCore;

namespace EmployeesWebApi.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext>options) : base(options)
        { 
        } 
        public DbSet<Employee> employee { get; set; }
    }
}
