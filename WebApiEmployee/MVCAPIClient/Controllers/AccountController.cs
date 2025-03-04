using Microsoft.AspNetCore.Mvc;
using MVCAPIClient.Models;

namespace MVCAPIClient.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            //get the token and store it in the session
            string token = ApiConsumer.GetToken(login);
            if (!string.IsNullOrEmpty(token))
            {
                //save the token in session
                HttpContext.Session.SetString("token", token);
                //redirect ot index
                RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
