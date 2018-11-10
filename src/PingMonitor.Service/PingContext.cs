using Microsoft.EntityFrameworkCore;

namespace PingMonitor.Service
{
    public class PingContext : DbContext
    {
        public DbSet<PingBatch> Batches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\pingmonitor.db");
        }
    }
}
