using GraphQL;
using GraphQL.Types;

namespace GraphQlMaster.Api.Graphql
{

    public class MarketingSchema : Schema
    {
        public MarketingSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MarketingQuery>();
        }
    }
}