using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCTicketBooking.Models;
using TicketBookingWEBAPI.Model;

namespace MVCTicketBooking.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            List<TicketBooking> book = APIConsumer.GetBookings();

            return View(book);
        }
        public IActionResult BookTicket()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BookTicket(string seatingType, int ticketCount)
        {
            bool booked = APIConsumer.BookTicket(seatingType,ticketCount);
            if (booked)
            {
                TempData["Message"] = "Ticket Booked Sccessfully";
                return View();
            }
            else
            {
                TempData["Message"] = "Ticket Booking Unsuccessfull";
                return View();
            }
        }
       
    }
}
