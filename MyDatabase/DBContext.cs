namespace Mydbcontext

{
    using Microsoft.EntityFrameworkCore;
    using MyLibrary;

    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UnknownDevice> UnknownDevices { get; set; }
        public DbSet<KnownDevice> KnownDevices { get; set; }
        public DbSet<MessageRequest> MessageRequest { get; set; }
        public DbSet<DeviceMessages> DeviceMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Exam;Username=postgres;Password=popvolvol4567");
        }
    }
}

