using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDBFirstLIb
{
    public  class EMPDBContext : DbContext
    {
        public EMPDBContext(DbContextOptions<EMPDBContext> options) : base(options) 
        {
        }
        public DbSet<Employee> employee { get; set; }
    }
}
