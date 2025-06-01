namespace MessageRecieveService.Models
{
    public class RequestedMessages
    {
        public Data? Data { get; set; } 
        public Tags? Tags { get; set; }   
    }

    public class Data
    {
        public string? Info { get; set; } 
    }

    public class Tags
    {
        public string? Index { get; set; } 
    }
}





