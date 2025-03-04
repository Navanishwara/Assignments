using System.Data.Common;
using System.Linq.Expressions;
using EmployeesWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class EmployeeController : ControllerBase

    {
        private readonly IEmployeeDataAccess dal;
        public EmployeeController(IEmployeeDataAccess dal)
        {
            this.dal = dal;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("GetAllEmps")]

        public IEnumerable<Employee> GetAllEmps()
        {
            //int a = 10;
            //int b = 0;
            //int c = a / b;
                return dal.GetAll();
                     
        }

        // GET api/<EmployeeController>/5
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("GetEmpById/{id}")]
        public IActionResult GetEmpById(int id)
        {
            return Ok( dal.Get(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("AddEmp")]
        public IActionResult AddEmp([FromBody] Employee employee)
        {
            try
            {
                if (employee.Name.IsNullOrEmpty())
                {
                    ModelState.AddModelError("ename", "ename must be entered");
                    if (ModelState.IsValid)
                    {
                        dal.Add(employee);

                    }
                    return Ok("record inserted");
                }
                else
                {
                    throw new Exception("ename must be not same");
                }
              
            
            }
            catch(Exception ex){
            return BadRequest(ex.Message);
            }
        }

        // PUT api/<EmployeeController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("UpdateEmp/{id}")]
        public void UpdateEmp(int id, [FromBody] Employee emp)
        {
            dal.Update(emp);
        }

        // DELETE api/<EmployeeController>/5
        //[HttpDelete("{id}")]
        [HttpDelete]
        [Route("DeleteByID/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                dal.Delete(id);
                return Ok("Record deleted");
            }catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
