using GraphQL.Types;
using GraphQlMaster.ServiceFoundation.Models;

namespace GraphQlMaster.Api.Graphql.Types
{
    public class PurchaseHistoryType : ObjectGraphType<PurchaseHistory>
    {
        public PurchaseHistoryType()
        {
            Name = "PurchaseHistory";
            Field(p => p.Id);
            Field(p => p.Date);
            Field(p => p.Amount);
            Field<MaterialType>("Material", resolve: _ => _.Source.Material);
        }
    }
}
