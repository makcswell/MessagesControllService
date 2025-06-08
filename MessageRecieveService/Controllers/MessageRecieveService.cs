using Microsoft.AspNetCore.Mvc;
using MessageRecieveService.Models;
using System.Collections.Concurrent;

namespace MessageRecieveService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageRecieveService : ControllerBase
    {
        private static readonly ConcurrentDictionary<string, (DateTime messageReceivedUTC, int messagesNumber)> unknownDevices = new();
        private static readonly ConcurrentDictionary<string, string> knownDevices = new();

        [HttpPost("receive")]
        public IActionResult ReceiveMessage([FromBody] RequestedMessages messageRequest)
        {
            if (messageRequest == null || messageRequest.Data == null || messageRequest.Tags == null)
            {
                return BadRequest("Invalid message.");
            }

            string? index = messageRequest.Tags.Index;
            string? info = messageRequest.Data.Info;

            if (!knownDevices.ContainsKey(index))
            {
                // Устройство неизвестно
                var currentTime = DateTime.UtcNow;
                unknownDevices.AddOrUpdate(index, (currentTime, 1), (key, oldValue) => (oldValue.messageReceivedUTC, oldValue.messagesNumber + 1));
                return Ok(new { unknownDevices });
            }
            else
            {
                // Устройство известно
                var receivedData = new Dictionary<string, string>
                {
                    { index, info }
                };
                return Ok(new { receivedData });
            }
        }

        [HttpPost("markKnown")]
        public IActionResult MarkDeviceAsKnown([FromBody] string index)
        {
            if (string.IsNullOrEmpty(index))
            {
                return BadRequest("Invalid index.");
            }

            knownDevices.TryAdd(index, index);
            return Ok("Device marked as known.");
        }
    }
}
