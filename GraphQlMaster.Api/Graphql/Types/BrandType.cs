using GraphQL.Types;
using GraphQlMaster.ServiceFoundation.Models;

namespace GraphQlMaster.Api.Graphql.Types
{
    public class BrandType : ObjectGraphType<Brand>
    {
        public BrandType()
        {
            Name = "Brand";
            Field(p => p.Id);
            Field(p => p.Name);
        }
    }
}