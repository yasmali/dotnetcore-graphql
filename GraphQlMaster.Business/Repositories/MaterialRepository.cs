using GraphQlMaster.Core;
using GraphQlMaster.ServiceFoundation.Interfaces;
using GraphQlMaster.ServiceFoundation.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GraphQlMaster.Business.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly MarketingContext _db;

        public MaterialRepository(MarketingContext db)
        {
            _db = db;
        }

        public List<Material> GetMaterials()
        {
            return _db.Materials.ToList();
        }

        public List<Material> GetMaterialsByBrandId(int brandId)
        {
            return _db.Materials.Include(c => c.Brand).Where(p => p.Brand.Id == brandId).ToList();
        }
    }
}
