namespace Exam.Models
{
    public class MessageRequest
    {
        public Data? Data { get; set; } // свойство для хранения данных сообщения
        public Tags? Tags { get; set; }   // свойство для хранения тегов
    }

    public class Data
    {
        public string? Info { get; set; } // свойство для хранения информации сообщения
    }

    public class Tags
    {
        public string? Index { get; set; } // свойство для хранения уникального индекса устройства
    }

}
