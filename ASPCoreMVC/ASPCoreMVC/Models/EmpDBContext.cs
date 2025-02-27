using Microsoft.EntityFrameworkCore;

namespace ASPCoreMVC.Models
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext(DbContextOptions opts) : base(opts)
        { 
        }
       
        public DbSet<Employee> Employees { get; set;    } 
       // public DbSet<Course> Courses { get; set; }
       // public DbSet<Student> Students { get; set; }
    }
}
