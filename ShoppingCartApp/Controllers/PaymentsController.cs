using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Domain.Services;
using ShoppingCartApp.Extensions;
using ShoppingCartApp.Security.Models;

namespace ShoppingCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;

        private readonly IPaymentService _paymentService;

        private readonly IAccountService _accountService;

        private readonly IProductService _productService;

        public PaymentsController(ILogger<PaymentsController> logger, IPaymentService paymentService, 
                                        IAccountService accountService, IProductService productService)
        {
            _logger = logger;
            _paymentService = paymentService;
            _accountService = accountService;
            _productService = productService;
        }

        // Submitting the Payment.
        [HttpPost]
        [Authorize]
        public ActionResult<string> CompletePayment([FromBody] PaymentDetails paymentDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var customer = _accountService.FindCustomerByUserName(paymentDetails.CustomerUserName);

            var order = new Orders()
            {
                Customer = customer,
                DateCreated = paymentDetails.Date,
                SubTotal = paymentDetails.Total
            };

            var orderResult = _paymentService.PlaceOrder(order);

            var itemResult = from cartItem in paymentDetails.Cart
                             group cartItem by cartItem.Id into g
                             let count = g.Count()
                             select new { Value = g.Key, Count = count };

            foreach (var i in itemResult)
            {
                var item = paymentDetails.Cart.FirstOrDefault(c => c.Id == i.Value);

                var orderDetails = new OrderDetails()
                {
                    OrderId = orderResult.Id,
                    BookId = i.Value,
                    Quantity = i.Count,
                    UnitCost = item.Price
                };

                var orderDetailsResult = _paymentService.PlaceOrderDetails(orderDetails);
            }

            var payment = new Payments()
            {
                CustomerName = customer.Name,
                PaymentMethod = paymentDetails.PaymentMethod,
                PaymentAmount = paymentDetails.Total,
                PaymentDate = paymentDetails.Date,
                OrderID = orderResult.Id
            };

            var paymentResult = _paymentService.ConfirmPayment(payment);

            foreach (var i in itemResult)
            {
                var item = _productService.FindBookByID(i.Value);

                var updatedStockResult = _productService.DecreaseBookStock(item, i.Count);
            }

            return "Purchase is Successfull.";
        }
    }
}