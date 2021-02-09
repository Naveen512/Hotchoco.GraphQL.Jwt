using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Hotchoco.GraphQL.Jwt.Data.Entities;
using Hotchoco.GraphQL.Jwt.Models;
using HotChocolate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Hotchoco.GraphQL.Jwt.GraphQLCore
{
    public class Mutation
    {
        private List<User> Users = new List<User>
        {
            new User{
                Id = 1,
                FirstName = "Naveen",
                LastName = "Bommidi",
                Email = "naveen@gmail.com",
                Password="1234",
                PhoneNumber="8888899999"
            },
            new User{
                Id = 2,
                FirstName = "Hemanth",
                LastName = "Kumar",
                Email = "hemanth@gmail.com",
                Password = "abcd",
                PhoneNumber = "2222299999"
            }
        };

        public string UserLogin([Service] IOptions<TokenSettings> tokenSettings ,LoginInput login)
        {
            var currentUser = Users.Where(_ => _.Email.ToLower() == login.Email.ToLower() &&
            _.Password == login.Password).FirstOrDefault();

            if (currentUser != null)
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Key));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                var jwtToken = new JwtSecurityToken(
                    issuer: tokenSettings.Value.Issuer,
                    audience: tokenSettings.Value.Audience,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(jwtToken);

            }
            return "";
        }
    }
}