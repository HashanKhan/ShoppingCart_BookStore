using Microsoft.Extensions.Options;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Domain.Security.Hashing;
using ShoppingCartApp.Domain.Security.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ShoppingCartApp.Security.Tokens
{
    public class TokenHandler : ITokenHandler
    {
        private readonly TokenOptions _tokenOptions;

        private readonly SigningConfigurations _signingConfigurations;

        private readonly IPasswordHasher _passwordHasher;

        public TokenHandler(IOptions<TokenOptions> tokenOptionsSnapshot, SigningConfigurations signingConfigurations,
                                                        IPasswordHasher passwordHasher)
        {
            _tokenOptions = tokenOptionsSnapshot.Value;
            _signingConfigurations = signingConfigurations;
            _passwordHasher = passwordHasher;
        }

        //Build access token.
        public AccessToken BuildAccessToken(Customers customer)
        {
            var securityToken = new JwtSecurityToken
            (
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: GetClaims(customer),
                notBefore: DateTime.UtcNow,
                signingCredentials: _signingConfigurations.SigningCredentials
            );

            var handler = new JwtSecurityTokenHandler();
            var accessToken = handler.WriteToken(securityToken);

            return new AccessToken(accessToken);
        }

        //Get Claims for the users.
        private IEnumerable<Claim> GetClaims(Customers customer)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, customer.UserName)
            };

            return claims;
        }
    }
}
