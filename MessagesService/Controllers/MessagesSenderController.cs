using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using System.Timers;
using Newtonsoft.Json;
using System.Text;

namespace Exam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesSenderController : ControllerBase
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static System.Timers.Timer? timer;
        private readonly ILogger<MessagesSenderController> logger;

        public MessagesSenderController(ILogger<MessagesSenderController> logger)
        {
            this.logger = logger; 
            timer = new System.Timers.Timer(5000); //5 секунд
            timer.Elapsed += SendData;
            timer.Start();
        }
        [HttpPost]
     
        private async void SendData(object? sender, ElapsedEventArgs e)
        {
           
            MessageSendModels? messageRequest = new MessageSendModels
            {
                Data = new Data
                {
                    Info = GenerateRandomText() 
                },
                Tags = new Tags
                {
                    Index = GenerateRandomIndex() 
                }
            };

            string json = JsonConvert.SerializeObject(messageRequest);
            StringContent? content = new(json, Encoding.UTF8, "application/json");

            
            await httpClient.PostAsync("http://localhost:5000/api/messages", content);
        }


        private string GenerateRandomText()
        {
            return "Some rndm text" + Guid.NewGuid();
        }

        private string GenerateRandomIndex()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
