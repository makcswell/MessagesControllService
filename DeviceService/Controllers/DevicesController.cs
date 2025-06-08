using Microsoft.AspNetCore.Mvc;
using DeviceService.Models;
using System.Collections.Generic;


namespace DeviceService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {
        private static List<Device> knownDevices = new List<Device>();

        [HttpPost("KnownOrNot")]
        public IActionResult MarkAsKnown([FromBody] Device device)
        {
            if (device == null || string.IsNullOrEmpty(device.Id))
            {
                return BadRequest("Invalid device data.");
            }

           
            var existingDevice = knownDevices.Find(d => d.Id == device.Id);// exist check
            if (existingDevice != null)
            {
                existingDevice.IsKnown = true; 
            }
            else
            {
                device.IsKnown = true; // success if known
                knownDevices.Add(device);
            }

            return Ok("Device authorized");
        }

        [HttpGet("known-devices")]
        public IActionResult GetKnownDevices()
        {
            return Ok(knownDevices);
        }
    }
}
