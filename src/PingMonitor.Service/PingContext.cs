using Microsoft.EntityFrameworkCore;

namespace PingMonitor.Service
{
    public class PingContext : DbContext
    {
        public DbSet<PingBatch> Batches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PingMonitor;Trusted_Connection=True;");
        }
    }
}
