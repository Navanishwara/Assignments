using ASPCoreMVCRentCalculation.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreMVCRentCalculation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RentCalculation rentCalculation)
        {
            return RedirectToAction("Calculate",rentCalculation);
        }
        [HttpGet]
        public IActionResult Calculate(RentCalculation rentCalculation)
        {
            ViewBag.Name = rentCalculation.Name;
            ViewBag.Owner = rentCalculation.HallOwner;
            ViewBag.cost = rentCalculation.Cost;
            ViewBag.start = rentCalculation.StartDate;
            ViewBag.end = rentCalculation.EndDate;
            var total = ((rentCalculation.EndDate).Day - (rentCalculation.StartDate).Day + 1) * rentCalculation.Cost;
            ViewBag.total = total;
            return View();
        }
    }
}
