using System.Security.Claims;
using ASPCoreMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData.Add("ReturnUrl",ReturnUrl);
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> Login(Userdetails user,string ReturnUrl)
        {
            //validate user
            if (user.userName == "admin" && user.password == "admin123" && user.role=="admin")
            {
                //sign in the user and redirect to the requested page
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.userName),
                    new Claim(ClaimTypes.Role,"admin")
                };
                var  claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl);
            }
            else if(user.userName =="guest" && user.password =="guest")
            {
                var claims = new List<Claim>
                {
                    new Claim (ClaimTypes.Name, user.userName),
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme ,new ClaimsPrincipal(claimsIdentity));
                return Redirect(ReturnUrl);
            }else
            {
                ViewData.Add("Returnurl",ReturnUrl);
                ViewData.Add("msg", "invalid username/password ");
                return View(user);
               
            }
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Employees/Index");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
