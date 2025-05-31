using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Exam.Models;

namespace Exam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController(ILogger<MessagesController> logger) : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceiveMessage([FromBody] MessageRequest request)
        {


            return Ok(new { status = "success", messageId = "12345" });
        }
       



    }


}
