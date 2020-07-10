using ShoppingCartApp.Domain.IServices.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.IServices
{
    public interface IAuthenticationService
    {
        TokenResponse CreateAccessToken(string userName, string password);
        TokenResponse RefreshToken(string refreshToken, string userName);
        void RevokeRefreshToken(string refreshToken);
    }
}
