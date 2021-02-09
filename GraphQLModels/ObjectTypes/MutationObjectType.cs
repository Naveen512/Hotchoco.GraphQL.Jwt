using Hotchoco.GraphQL.Jwt.GraphQLCore;
using Hotchoco.GraphQL.Jwt.GraphQLModels.InputObjectTypes;
using HotChocolate.Types;

namespace Hotchoco.GraphQL.Jwt.GraphQLModels.ObjectTypes
{
    public class MutationObjectType: ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(_ => _.UserLogin(default,default))
            .Name("UserLogin")
            .Type<StringType>()
            .Argument("login", a => a.Type<LoginInputObjectType>());
        }
    }
}