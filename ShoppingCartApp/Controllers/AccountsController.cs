using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Extensions;

namespace ShoppingCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;

        private readonly IAccountService _accountService;

        public AccountsController(ILogger<AccountsController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        //Resgister Customer.
        [HttpPost("register")]
        public ActionResult<string> RegisterCustomer([FromBody] Customers customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var new_customer = new Customers()
            {
                Id = customer.Id,
                Name = customer.Name,
                Phone = customer.Phone,
                Email = customer.Email,
                Address = customer.Address,
                UserName = customer.UserName,
                Password = customer.Password,
                LoginStatus = customer.LoginStatus,
                RegisterDate = customer.RegisterDate
            };

            var result = _accountService.RegisterCustomer(new_customer);

            return result;
        }

        //Logout Customer from the current session.
        [HttpPost("logout")]
        public ActionResult<string> LogOutCustomer([FromBody] UserCredentials userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var customer = _accountService.FindCustomerByUserName(userCredentials.UserName);

            if (customer == null)
            {
                return "The Customer is not Exist.";
            }
            else
            {
                if (customer.LoginStatus == true)
                {
                    var updated_customer = _accountService.LogOutCustomer(customer);

                    return updated_customer;
                }
                else
                {
                    return "You have been Logged Out Successfully.";
                }
            }
        }
    }
}