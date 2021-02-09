using Hotchoco.GraphQL.Jwt.Models;
using HotChocolate.Types;

namespace Hotchoco.GraphQL.Jwt.GraphQLModels.InputObjectTypes
{
    public class LoginInputObjectType:InputObjectType<LoginInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<LoginInput> descriptor)
        {
            descriptor.Field(_ => _.Email).Name("Email").Type<StringType>();
            descriptor.Field(_ => _.Password).Name("Password").Type<StringType>();
        }
    }
}