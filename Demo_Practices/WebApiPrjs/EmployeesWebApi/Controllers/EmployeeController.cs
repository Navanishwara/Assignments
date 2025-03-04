using EmployeesWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            return dal.GetAll();
        }

        // GET api/<EmployeeController>/5
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("GetEmpById/{id}")]
        public Employee GetEmpById(int id)
        {
            return dal.Get(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("AddEmp")]
        public void Post([FromBody] Employee employee)
        {
            dal.Add(employee);
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
        public void Delete(int id)
        {
            dal.Delete(id);
        }
    }
}
