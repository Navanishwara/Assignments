using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneBookApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactDataAccess dal;
        public ContactsController(IContactDataAccess dal)
        {
            this.dal=dal;
        }

        // GET: api/<ContactsController>
        [HttpGet]
        [Route("GetContacts")]
        public IActionResult Get()
        {
            try
            {
                    return Ok(dal.GetContacts());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ContactsController>/5
        [HttpGet]
        [Route("GetContactById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(dal.GetContactById(id));
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ContactsController>
        [HttpPost]
        [Route("AddContact")]
        public IActionResult Post([FromBody] Contact contact)
        {
            try
            {
                dal.AddContact(contact);
                return Ok("contact record added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ContactsController>/5
        [HttpPut]
        [Route("UpdateContactById/{id}")]
        public IActionResult Put(int id, [FromBody] Contact contact)
        {
            try
            {
                dal.UpdateContact(contact);
                return Ok(new { msg = "Contact record updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete]
        [Route("DeleteContact/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                dal.DeleteContact(id);
                return Ok(new { msg = "Contact record deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
