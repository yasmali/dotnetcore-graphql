using GraphQL.Types;
using GraphQlMaster.ServiceFoundation.Models;

namespace GraphQlMaster.Api.Graphql.Types
{
    public class MaterialType : ObjectGraphType<Material>
    {
        public MaterialType()
        {
            Name = "Material";
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.Piece);
            Field<BrandType>("Brand", resolve: _ => _.Source.Brand);
        }
    }

}