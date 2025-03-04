using ASPCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPCoreMVC.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            ViewData.Add("y", Request.HttpContext.Session.GetInt32("y"));
            var company = Request.Cookies["company"];
            ViewData.Add("company", company);
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            var cutomer = new Customer
            {
                Cities = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Delhi", Value="DLI" },
                    new SelectListItem{Text ="Mysore",Value="MYS"},
                    new SelectListItem{Text="Bangalore",Value="BLR"},
                    new SelectListItem{Text="Hyderabad",Value="hyd"}
                },
                Languages = new List<String>
                {
                    "english","hindi","kandaa"
                }
                };
            return View(cutomer);
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            return View("DisplayDetails",customer);
        }
    }
}
