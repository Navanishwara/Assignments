using Microsoft.EntityFrameworkCore;

namespace PhoneBookWebAPI.Model
{
    public class ContactDBContext : DbContext
    {
        public ContactDBContext(DbContextOptions<ContactDBContext>opts): base(opts) { }
        
        public DbSet<Contact> contact { get; set; }
    }
}
