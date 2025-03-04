using Microsoft.EntityFrameworkCore;

namespace TicketBookingWEBAPI.Model
{
    public class BookingDBContext : DbContext
    {
        public BookingDBContext(DbContextOptions opts) : base(opts) 
        {
            
        }
        public DbSet<TicketBooking> Ticket { get; set; }


    }
}
