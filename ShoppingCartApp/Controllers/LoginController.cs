using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Extensions;

namespace ShoppingCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        private readonly IAuthenticationService _authenticationService;

        public LoginController(ILogger<LoginController> logger, IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        //Login Customer.
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserCredentials userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var response = _authenticationService.CreateAccessToken(userCredentials.UserName, userCredentials.Password);

            return Ok(response);
        }
    }
}