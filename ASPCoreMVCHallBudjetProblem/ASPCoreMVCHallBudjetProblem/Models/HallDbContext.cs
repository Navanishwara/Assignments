using Microsoft.EntityFrameworkCore;

namespace ASPCoreMVCHallBudjetProblem.Models
{
    public class HallDbContext : DbContext

    {
        public HallDbContext(DbContextOptions opts) : base(opts)
        {
            
        }
        public DbSet<Hall> Hall { get; set; }
    }

 
}
