namespace TicketBookingWEBAPI.Model
{
    public interface ITicketBookingAccess 
    {
        List<TicketBooking> GetAllSeatingSection();
        bool BookTicket(string seatingType, int ticketCount);

    }
}
