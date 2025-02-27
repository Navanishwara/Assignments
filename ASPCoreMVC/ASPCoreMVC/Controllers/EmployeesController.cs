using ASPCoreMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreMVC.Controllers
{

    //[Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeDataAccess dal;
        public EmployeesController(IEmployeeDataAccess dal)
        {
            this.dal = dal;
        }
        [Authorize]
        public IActionResult Index()
        {
            //ViewData.Add("heading", "EMployeeManagemnt App");
            //ViewBag.Message = "hello";
            ////TempData.Add("x", 100);
            //Request.HttpContext.Session.SetInt32("y", 200);
            Response.Cookies.Append("company", "Tavant");
            return View(dal.GetAllEmp());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (dal.GetEmpById(emp.empid) != null)
            {
                ModelState.AddModelError("Ecode", "duplicate ecode");
            }
                if (ModelState.IsValid)
                {
                   
                
                    //Employee.employees.Add(emp);
                    dal.AddEmployee(emp);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var record = Employee.employees.Find(e => e.empid == id);
            var record = dal.GetEmpById(id);
            if(record != null)
            {
                dal.DeleteEmployee(record.empid);
                return RedirectToAction("Index");
            }
            //Employee.employees.Remove(record);
            //return RedirectToAction("Index");
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            //var record = Employee.employees.Find(e => e.empid == id);
            var record  = dal.GetEmpById(id);
            return View(record);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var record = Employee.employees.Find(e =>e.empid == id);
            var record = dal.GetEmpById(id);
            return View(record);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            //var record = Employee.employees.Find(e => e.empid == emp.empid);
            //record.name = emp.name;
            //record.salary = emp.salary;
            //record.deptid = emp.deptid;
            var record = dal.GetEmpById(emp.empid);
            dal.UpdateEmployee(record);
            return RedirectToAction("Index");
        }
    }
}
