using GraphQlMaster.ServiceFoundation.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQlMaster.Core
{
    public sealed class MarketingContext : DbContext
    {
        public MarketingContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
    }
}
