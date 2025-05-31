namespace Exam.Models
{
    public class DeviceMessages
    {
        public int Id { get; set; } 
        public string? Index { get; set; } 
        public string? Info { get; set; } 
        public DateTimeOffset MessageReceivedUtc { get; set; } // messUtc
    }
}
