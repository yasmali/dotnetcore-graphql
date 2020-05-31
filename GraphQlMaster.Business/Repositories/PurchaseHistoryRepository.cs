using GraphQlMaster.Core;
using GraphQlMaster.ServiceFoundation.Interfaces;
using GraphQlMaster.ServiceFoundation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphQlMaster.Business.Repositories
{
    public class PurchaseHistoryRepository : IPurchaseHistoryRepository
    {
        private readonly MarketingContext _db;

        public PurchaseHistoryRepository(MarketingContext db)
        {
            _db = db;
        }

        public List<PurchaseHistory> GetPurchaseHistories()
        {
            return _db.PurchaseHistories.Include(c => c.Material).ToList();
        }

        public List<PurchaseHistory> GetPurchaseHistoriesByMaterialId(int materialId)
        {
            return _db.PurchaseHistories.Include(c => c.Material).Where(c => c.Material.Id == materialId).ToList();
        }

        public List<PurchaseHistory> GetPurchaseHistoriesByMaterialIdAndDate(int materialId, DateTime date)
        {
            return _db.PurchaseHistories.Include(c => c.Material).Where(c => c.Material.Id == materialId && c.Date.Date == date.Date).ToList();
        }
    }
}
