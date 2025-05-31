using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyLibrary
{
    public class MyDbContext : DbContext
    {
        public DbSet<UnknownDevice> UnknownDevices { get; set; }
        public DbSet<KnownDevice> KnownDevices { get; set; }
        public DbSet<MessageRequest> MessageRequest { get; set; }
        public DbSet<DeviceMessages> DeviceMessages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=mydb;Username=myuser;Password=mypassword");
        }
    }
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
    public class DeviceMessages
    {
        public int Id { get; set; }
        public string? Index { get; set; }
        public string? Info { get; set; }
        public DateTimeOffset MessageReceivedUtc { get; set; } // messUtc
    }
    public class UnknownDevice
    {
        public string? Index { get; set; }
        public DateTimeOffset MessageReceivedUTC { get; set; }
        public int MessagesNumber { get; set; }
    }

    public class KnownDevice
    {
        public string? Index { get; set; }
        public string? Info { get; set; }
    }
}
