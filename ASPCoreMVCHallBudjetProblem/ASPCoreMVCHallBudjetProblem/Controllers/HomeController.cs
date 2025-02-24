using ASPCoreMVCHallBudjetProblem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreMVCHallBudjetProblem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHall dal;
        public HomeController(IHall dal)
        {
            this.dal = dal; 
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(int price)
        {
            return View(dal.GetHall(price));
        }

    }
}
