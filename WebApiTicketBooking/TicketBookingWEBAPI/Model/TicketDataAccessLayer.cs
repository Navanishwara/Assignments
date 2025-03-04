
namespace TicketBookingWEBAPI.Model
{
    public class TicketDataAccessLayer : ITicketBookingAccess
    {
        private readonly BookingDBContext dbctx;
        public TicketDataAccessLayer(BookingDBContext dbctx)
        {
            this.dbctx = dbctx; 
        }

        public bool BookTicket(string seatingType, int ticketCount)
        {
            var record = dbctx.Ticket.FirstOrDefault(s => s.SeatingType == seatingType);
            if (record == null || record.NumberOfTickets < ticketCount)
            {
                return false;
            }
            record.NumberOfTickets -= ticketCount;
            dbctx.SaveChanges();
            return true;
        }

        public List<TicketBooking> GetAllSeatingSection()
        {
            return dbctx.Ticket.ToList();
        }
    }
}
