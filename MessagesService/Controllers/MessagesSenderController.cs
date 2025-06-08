using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using Newtonsoft.Json;
using System.Text;
using System.Timers;

namespace MessagesService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageSenderController : ControllerBase
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly ILogger<MessageSenderController> logger;
        private static string currentIndex = Guid.NewGuid().ToString();

        public MessageSenderController(ILogger<MessageSenderController> logger)
        {
            this.logger = logger;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] MessageSendModels messageRequest)
        {
            if (messageRequest == null || messageRequest.Data == null || messageRequest.Tags == null)
            {
                return BadRequest("Invalid message request.");
            }

         
            messageRequest.Tags.Index = currentIndex;

            string json = JsonConvert.SerializeObject(messageRequest);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:32777/api/messagereceiver/receive", content);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError($"Error sending data: {response.StatusCode}");
                return StatusCode((int)response.StatusCode, "Error sending message.");
            }

            return Ok("Message sent successfully.");
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateAndSendMessage()
        {
            var messageRequest = new MessageSendModels
            {
                Data = new Data
                {
                    Info = GenerateRandomText()
                },
                Tags = new Tags
                {
                    Index = currentIndex
                }
            };

            string json = JsonConvert.SerializeObject(messageRequest);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://localhost:32777/api/messagereceiver/receive", content);
            if (!response.IsSuccessStatusCode)
            {
                logger.LogError($"Error sending data: {response.StatusCode}");
                return StatusCode((int)response.StatusCode, "Error sending message.");
            }

            return Ok("Message sent successfully.");
        }

        private string GenerateRandomText()
        {
            return "Some rndm text " + Guid.NewGuid();
        }
    }
}
