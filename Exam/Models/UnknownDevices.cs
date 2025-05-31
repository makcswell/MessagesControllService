namespace Exam.Models
{
    public class UnknownDevices
    {
        public int Id { get; set; } 
        public string? Index { get; set; } 
        public DateTimeOffset MessageReceivedUtc { get; set; } // получение в utc
        public int MessagesNumber { get; set; } = 1; // количество принятых сообщений
    }
}
