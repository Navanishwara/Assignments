using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBookingWEBAPI.Model
{
    [Table("ticket")]
    public class TicketBooking
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("seattype")]
        public string SeatingType { get; set; }
        [Column("ticketcost")]
        public double TicketCost { get; set; }
        [Column("noofticket")]
        public int NumberOfTickets { get; set; }
    }
}
