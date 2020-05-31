using GraphQlMaster.ServiceFoundation.Models;
using System;
using System.Collections.Generic;

namespace GraphQlMaster.ServiceFoundation.Interfaces
{
    public interface IPurchaseHistoryRepository
    {
        List<PurchaseHistory> GetPurchaseHistories();

        List<PurchaseHistory> GetPurchaseHistoriesByMaterialId(int materialId);

        List<PurchaseHistory> GetPurchaseHistoriesByMaterialIdAndDate(int materialId, DateTime date);
    }
}
