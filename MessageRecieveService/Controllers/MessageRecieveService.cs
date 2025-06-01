
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MessageRecieveService.Models;
using System.Timers;
using Newtonsoft.Json;
using System.Text;

namespace MessageRecieveService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageRecieveService : ControllerBase
    {
         
        [HttpPost]
        public IActionResult ReceiveMessage([FromBody] RequestedMessages messageRequest)
        {
            if (messageRequest == null || messageRequest.Data == null || messageRequest.Tags == null)
            {
                return BadRequest("Unvalid message");
            }        
            Console.WriteLine($"Received message: {messageRequest.Data.Info}");
            Console.WriteLine($"Received index: {messageRequest.Tags.Index}");

            return Ok("Message received successfully.");
        }
    }
   
}
