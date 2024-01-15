using Microsoft.EntityFrameworkCore;
using ItemBlazor.Models;

namespace ItemBlazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Items> Item { get; set; }

        public DbSet<Devices> Devices { get; set; }

        public DbSet<TimeSeries> TimeSeries { get; set; }
    }
}
