using Microsoft.EntityFrameworkCore;

namespace GraphQlMaster.Core
{
    public class TemporaryDbContextFactory : DesignTimeDbContextFactoryBase<MarketingContext>
    {
        protected override MarketingContext CreateNewInstance(DbContextOptions<MarketingContext> options)
        {
            return new MarketingContext(options);
        }
    }
}
