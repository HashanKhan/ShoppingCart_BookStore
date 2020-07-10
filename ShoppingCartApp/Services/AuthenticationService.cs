using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.IServices.Responses;
using ShoppingCartApp.Domain.Security.Hashing;
using ShoppingCartApp.Domain.Security.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;

        private readonly ITokenHandler _tokenHandler;

        private readonly IPasswordHasher _passwordHasher;

        public AuthenticationService(IAccountService accountService, ITokenHandler tokenHandler, IPasswordHasher passwordHasher)
        {
            _tokenHandler = tokenHandler;
            _accountService = accountService;
            _passwordHasher = passwordHasher;
        }

        public TokenResponse CreateAccessToken(string userName, string password)
        {
            var customer = _accountService.FindCustomerByUserName(userName);

            if (customer == null || !_passwordHasher.PasswordMatches(password, customer.Password))
            {
                return new TokenResponse(false, "Invalid UserName or Password.", null, null);
            }

            var token = _tokenHandler.CreateAccessToken(customer);

            var updated_customer = _accountService.LoginCustomer(customer);

            return new TokenResponse(true, "Logged in Successfully.", token, updated_customer);
        }

        public TokenResponse RefreshToken(string refreshToken, string userName)
        {
            var token = _tokenHandler.TakeRefreshToken(refreshToken);

            if (token == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null, null);
            }

            if (token.IsExpired())
            {
                return new TokenResponse(false, "Expired refresh token.", null, null);
            }

            var customer = _accountService.FindCustomerByUserName(userName);

            if (customer == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null, null);
            }

            var accessToken = _tokenHandler.CreateAccessToken(customer);

            return new TokenResponse(true, null, accessToken, customer);
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            _tokenHandler.RevokeRefreshToken(refreshToken);
        }
    }
}
