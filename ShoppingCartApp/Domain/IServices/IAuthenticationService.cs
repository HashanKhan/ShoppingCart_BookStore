using ShoppingCartApp.Domain.IServices.Responses;

namespace ShoppingCartApp.Domain.IServices
{
    public interface IAuthenticationService
    {
        TokenResponse CreateAccessToken(string userName, string password);
    }
}
