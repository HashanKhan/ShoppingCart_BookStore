using System;

namespace ShoppingCartApp.Domain.Security.Tokens
{
    public abstract class JsonWebToken
    {
        public string Token { get; protected set; }

        public JsonWebToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Invalid token.");

            Token = token;
        }
    }
}
