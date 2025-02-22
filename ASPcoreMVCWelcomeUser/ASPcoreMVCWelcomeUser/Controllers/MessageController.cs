using ASPcoreMVCWelcomeUser.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPcoreMVCWelcomeUser.Controllers
{
    public class MessageController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        

        [HttpPost]
        public IActionResult Display(Welcome wl)
        {
          
            ViewBag.UserName = wl.Title;
            return View();  
        }
    }
}
