using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.IServices.Responses;
using ShoppingCartApp.Domain.Security.Hashing;
using ShoppingCartApp.Domain.Security.Tokens;

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

        //Create access token by validating the Username and Password.
        public TokenResponse CreateAccessToken(string userName, string password)
        {
            var customer = _accountService.FindCustomerByUserName(userName);

            if (customer == null || !_passwordHasher.PasswordMatches(password, customer.Password))
            {
                return new TokenResponse(false, "Invalid UserName or Password.", null, null);
            }
            else
            {
                var token = _tokenHandler.BuildAccessToken(customer);

                if (customer.LoginStatus == false)
                {
                    var updated_customer = _accountService.LoginCustomer(customer);

                    return new TokenResponse(true, "Logged in Successfully.", token, updated_customer);
                }
                else
                {
                    return new TokenResponse(true, "Logged in Successfully.", token, customer); ;
                }      
            }
        }
    }
}
