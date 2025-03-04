using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBookingWEBAPI.Model;

namespace TicketBookingWEBAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketBookingAccess dal;
        public TicketController(ITicketBookingAccess dal)
        {
            this.dal = dal;   
        }

        [HttpGet]
        [Route("GetSeatingSections")]
        public IActionResult GetSeatingSection()
        {
            return Ok(dal.GetAllSeatingSection());
        }

        [HttpPost]
        [Route("bookTicket")]
        public IActionResult BookTicket(string seatingType, int ticketCount)
        {
            bool success = dal.BookTicket(seatingType, ticketCount);
            if (success)
            {
                return Ok("Ticket Booked successfully");
            }
            else
            {
                return BadRequest("Request Number of tickets not available");
            }
        }
        // GET: TicketController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: TicketController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: TicketController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: TicketController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: TicketController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: TicketController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TicketController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: TicketController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
