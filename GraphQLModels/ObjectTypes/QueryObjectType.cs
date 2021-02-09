using Hotchoco.GraphQL.Jwt.GraphQLCore;
using HotChocolate.Types;

namespace Hotchoco.GraphQL.Jwt.GraphQLModels.ObjectTypes
{
    public class QuerObjectType: ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(_ => _.Welcome()).Name("Welcome").Type<StringType>();
        }
    }
}