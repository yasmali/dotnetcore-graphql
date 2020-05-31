using GraphQlMaster.ServiceFoundation.Models;
using GraphQlMaster.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GraphQlMaster.Core
{
    public static class GraphQlMasterSeedData
    {
        public static void EnsureSeedData(this MarketingContext db)
        {
            if (!db.Brands.Any())
            {
                List<Brand> BrandModels = new List<Brand>();

                //TODO: Dummy Brands
                for (int i = 0; i < 15; i++)
                {
                    BrandModels.Add(new Brand
                    {
                        //Id = i,
                        Name = $"Brand-{i}",
                        FoundedDate = DateTime.Now.AddDays(-i * 2).ToPrettyDate(CultureInfo.CreateSpecificCulture("en-US"))
                    });
                }

                db.Brands.AddRange(BrandModels);
                db.SaveChanges();
            }

            if (!db.Materials.Any())
            {
                List<Material> MaterialModels = new List<Material>();

                //TODO: Dummy Materials
                for (int i = 0; i < 50; i++)
                {
                    Random random = new Random();
                    MaterialModels.Add(new Material
                    {
                        //Id = i,
                        Name = $"Material-{i}",
                        Piece = random.Next(5),
                        Brand = db.Brands.FirstOrDefault(p => p.Id == random.Next(1, 15))
                    });
                }

                db.Materials.AddRange(MaterialModels);
                db.SaveChanges();
            }

            if (!db.PurchaseHistories.Any())
            {
                List<PurchaseHistory> PurchaseHistoryModels = new List<PurchaseHistory>();

                //TODO: Dummy Purchase Histories
                for (int i = 0; i < 10; i++)
                {
                    Random random = new Random();
                    PurchaseHistoryModels.Add(new PurchaseHistory
                    {
                        //Id = i,
                        Date = DateTime.Now.AddDays(-i),
                        Amount = random.Next(100, 1000),
                        Material = db.Materials.FirstOrDefault(c => c.Id == random.Next(1, 50))
                    });
                }

                db.PurchaseHistories.AddRange(PurchaseHistoryModels);
                db.SaveChanges();
            }
        }
    }
}
