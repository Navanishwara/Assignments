using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstLib
{
    public class CusomerDBContext : DbContext
    {
        public CusomerDBContext(DbContextOptions<CusomerDBContext> options) : base(options)
        { }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Database=empdb;Username=postgres;Password=root");
        }
        public CusomerDBContext()
        {
            
        }

        public DbSet<Customer> Customer { get; set; }

    }
}