using GraphQL.Types;
using GraphQlMaster.Api.Graphql.Types;
using GraphQlMaster.Api.Helpers;
using System;

namespace GraphQlMaster.Api.Graphql
{
    public class MarketingQuery : ObjectGraphType
    {
        public MarketingQuery(ServiceLocator serviceLocator)
        {
            Name = "Marketing_Query";

            //TODO: Graphql endpointlerini belirliyoruz.
            Field<ListGraphType<MaterialType>>("Materials", resolve: ctx => serviceLocator.MaterialRepository.GetMaterials());

            Field<ListGraphType<MaterialType>>("MaterialByBrandId",
                                                arguments: new QueryArguments
                                                {
                                                    //İstek atarken gönderilen parametrenin ismi (Aynı olması lazım.)
                                                    new QueryArgument<IntGraphType>{
                                                        Name="Id",
                                                        Description="Brand Id"
                                                    }
                                                },
                                                resolve: ctx => serviceLocator.MaterialRepository.GetMaterialsByBrandId(ctx.GetArgument<int>("Id")));

            Field<ListGraphType<BrandType>>("Brands", resolve: ctx => serviceLocator.BrandRepository.GetBrands());

            Field<ListGraphType<PurchaseHistoryType>>("PurchaseHistories", resolve: ctx => serviceLocator.PurchaseHistoryRepository.GetPurchaseHistories());

            Field<ListGraphType<PurchaseHistoryType>>("PurchaseHistoriesByMaterialId",
                                                       arguments: new QueryArguments
                                                       {
                                                           new QueryArgument<IntGraphType>
                                                           {
                                                               Name = "Id",
                                                               Description = "Material Id"
                                                           }
                                                       },
                                                       resolve: ctx => serviceLocator.PurchaseHistoryRepository.GetPurchaseHistoriesByMaterialId(ctx.GetArgument<int>("Id")));

            Field<ListGraphType<PurchaseHistoryType>>("PurchaseHistoriesByMaterialIdAndDate",
                                                       arguments: new QueryArguments
                                                       {
                                                           new QueryArgument<IntGraphType>
                                                           {
                                                               Name = "Id",
                                                               Description = "Material Id"
                                                           },
                                                           new QueryArgument<DateTimeGraphType>
                                                           {
                                                               Name = "Date",
                                                               Description = "History Created Date"
                                                           }
                                                       },
                                                       resolve: ctx => serviceLocator.PurchaseHistoryRepository.GetPurchaseHistoriesByMaterialIdAndDate(ctx.GetArgument<int>("Id"),
                                                                                                                                                        ctx.GetArgument<DateTime>("Date")));
        }
    }
}