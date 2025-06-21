using Microsoft.EntityFrameworkCore;

namespace Price_Comparison.Data
{
    public class PriceDBContext : DbContext
    {
        public PriceDBContext(DbContextOptions<PriceDBContext> options) : base(options)
        {
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Vendor> Vendors { get; set; }
        public DbSet<Models.SearchHistory> SearchHistories { get; set; }
        public DbSet<Models.PriceAlert> PriceAlerts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
