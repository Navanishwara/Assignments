using InterviewScheduler.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleInterviewController : ControllerBase
    {
        private readonly IInterviewDataAccess dal;
        public ScheduleInterviewController(IInterviewDataAccess dal)
        {
            this.dal = dal;
        }
        [HttpPost]
        public IActionResult ScheduleInterview([FromBody] Recruiter recruiter)
        {
            try
            {
                dal.AddInterview(recruiter);
                return Ok("Interview is Scheduled");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
