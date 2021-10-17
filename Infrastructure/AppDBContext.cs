using Infrustructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MetricConfiguration());
        }
    }
}
