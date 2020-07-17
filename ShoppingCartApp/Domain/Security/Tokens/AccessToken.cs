namespace ShoppingCartApp.Domain.Security.Tokens
{
    public class AccessToken : JsonWebToken
    {
        public AccessToken(string token) : base(token)
        {
        }
    }
}
