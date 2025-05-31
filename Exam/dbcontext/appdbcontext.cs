namespace Exam.dbcontext

{
    using Microsoft.EntityFrameworkCore;
    using Exam.Models;
    public class appdbcontext : DbContext
    {
    public DbSet<DeviceMessages> DeviceMessages { get; set; }  
    public DbSet<KnownDevices> KnownDevices { get; set; }  
    public DbSet<UnknownDevices> UnknownDevices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=postgres;Database=db;Username=postgres;Password=popvolvol4567");
        }
    }
}

