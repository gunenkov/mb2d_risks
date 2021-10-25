using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options) {
            Database.EnsureCreated();
        }
        public DbSet<BusinessService>BusinessServices { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventsLog> EventsLogs { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Risk> Risks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlite("DataSource=DB.db");
        }
    }
}
