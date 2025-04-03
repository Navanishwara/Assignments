using Microsoft.AspNetCore.Mvc;
using PhoneBookWebAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContact dal;
        public ContactController(IContact dal)
        {
            this.dal = dal;
        }
        // GET: api/<ContactController>
        [HttpGet]
        [Route("GetContactList")]
        public  IActionResult GetContactList()
        {
            
            try
            {
                return Ok(dal.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<ContactController>/5
        //[HttpGet("{id}")]
        [HttpGet]
        
        [Route("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            try
            {
                return Ok(dal.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/<ContactController>
        [HttpPost]
        [Route("AddContact")]
        public IActionResult Post([FromBody] Contact contact)
        {
            try
            {
                dal.Add(contact);
                return Ok("contact record addedd");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ContactController>/5
        //[HttpPut("{id}")]
        [HttpPut]
        [Route("GetContactById/{id}")]
        public IActionResult Put(int id, [FromBody] Contact contact)
        {
            try
            {
                dal.Update(contact);
                return Ok("record updated");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ContactController>/5
        //[HttpDelete("{id}")]
        [HttpDelete]
        [Route("DeleteById/{id}")]
        public IActionResult Delete(int id)
        {
            try{

                dal.Delete(id);
                return Ok("Record deleted");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
