using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartApp.Domain.DTOs;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Domain.Services;
using ShoppingCartApp.Extensions;
using System.Collections.Generic;

namespace ShoppingCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;

        private readonly IAccountService _accountService;

        private readonly IProductService _productService;

        private readonly IAuthenticationService _authenticationService;

        public AccountsController(ILogger<AccountsController> logger, IAccountService accountService, 
                            IAuthenticationService authenticationService, IProductService productService)
        {
            _logger = logger;
            _accountService = accountService;
            _productService = productService;
            _authenticationService = authenticationService;
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

        //Get all the orders that customer has made.
        [HttpPost("orders")]
        [Authorize]
        public IEnumerable<Orders> GetOrders([FromBody] UserCredentials userCredentials)
        {
            var customer = _accountService.FindCustomerByUserName(userCredentials.UserName);

            var orders = _accountService.GetOrdersByCustomerId(customer.Id);

            return orders;
        }

        //Get all the orderDetails for the Orders has made.
        [HttpPost("orderDetails")]
        [Authorize]
        public IEnumerable<ItemDetails> GetOrderDetails([FromBody] Orders order)
        {
            var orderDetails = _accountService.GetOrderDetailsByOrderId(order.Id);

            List<ItemDetails> itemDetailsList = new List<ItemDetails>();

            foreach (var od in orderDetails)
            {
                var item = _productService.FindBookByID(od.BookId);

                var itemDetail = new ItemDetails()
                {
                    Name = item.Name,
                    Quantity = od.Quantity,
                    UnitCost = od.UnitCost
                };

                itemDetailsList.Add(itemDetail);
            }

            return itemDetailsList;
        }

        //Get all the Payments made by the Customer.
        [HttpPost("payments")]
        [Authorize]
        public IEnumerable<Payments> GetPayments([FromBody] UserCredentials userCredentials)
        {
            var customer = _accountService.FindCustomerByUserName(userCredentials.UserName);

            var payments = _accountService.GetPaymentsByCustomerName(customer.Name);

            return payments;
        }
    }
}