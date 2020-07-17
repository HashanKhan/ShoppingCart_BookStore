using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Domain.Security.Tokens;

namespace ShoppingCartApp.Domain.IServices.Responses
{
    public class TokenResponse : BaseResponse
    {
        public AccessToken Token { get; set; }

        public Customers Customer { get; set; }

        public TokenResponse(bool success, string message, AccessToken token, Customers customer) : base(success, message)
        {
            Token = token;
            Customer = customer;
        }
    }
}
