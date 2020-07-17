using ShoppingCartApp.Domain.Models;

namespace ShoppingCartApp.Domain.Security.Tokens
{
    public interface ITokenHandler
    {
        AccessToken BuildAccessToken(Customers customer);
    }
}
