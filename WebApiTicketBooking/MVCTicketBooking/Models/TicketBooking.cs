using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBookingWEBAPI.Model
{
 
    public class TicketBooking
    {
       
        public int id { get; set; }
    
        public string seatingType { get; set; }
 
        public double ticketCost { get; set; }
     
        public int numberOfTickets { get; set; }
        
    }
}
