using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCAPIClient.Models;

namespace MVCAPIClient.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("token");
            if(token == null)
            {
                //send user to login page to get token
                return  RedirectToAction("Login","Account");
            }
            else
            {
                try
                {
                    List<Employee> lstEmps = ApiConsumer.GetEmps(token);//get from API 
                    return View(lstEmps);
                }
                catch (Exception ex)
                {
                    
                    return View("Error");
                }
            }
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            string token = HttpContext.Session.GetString("token");
            if (token != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            string token = HttpContext.Session.GetString("token");
            if (token != null)
            {
                //call the api add emp
                ApiConsumer.AddEmp(emp);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = ApiConsumer.GetEmpId(id);
            return View(emp);

        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            //call tha api to update employee
            var status = ApiConsumer.Update(emp);
            if (status)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Details()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var emp = ApiConsumer.GetEmpId(id);
            return View(emp);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = ApiConsumer.Delete(id);
            if (emp)
            {
                return RedirectToAction("Index");
            }

            return View(emp);
        }
    
    }
}
