using GraphQlMaster.Core;
using GraphQlMaster.ServiceFoundation.Interfaces;
using GraphQlMaster.ServiceFoundation.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQlMaster.Business.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly MarketingContext _db;

        public BrandRepository(MarketingContext db)
        {
            _db = db;
        }

        public List<Brand> GetBrands()
        {
            return _db.Brands.ToList();
        }
    }
}
