using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartApp.Domain.DTOs;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Domain.Services;
using ShoppingCartApp.EmailNotification;
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

        private readonly IEmailService _emailService;

        public PaymentsController(ILogger<PaymentsController> logger, IPaymentService paymentService, 
                                  IAccountService accountService, IProductService productService,
                                  IEmailService emailService)
        {
            _logger = logger;
            _paymentService = paymentService;
            _accountService = accountService;
            _productService = productService;
            _emailService = emailService;
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
                TotalAmount = paymentDetails.Total
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

            List<ItemDetails> itemDetailsList = new List<ItemDetails>();

            foreach (var i in itemResult)
            {
                var item = paymentDetails.Cart.FirstOrDefault(c => c.Id == i.Value);

                var itemDetail = new ItemDetails()
                {
                    Name = item.Name,
                    Quantity = i.Count,
                    UnitCost = item.Price
                };

                itemDetailsList.Add(itemDetail);
            }

            var customerBill = new CustomerBill()
            {
                Payment = payment,
                ItemDetailList = itemDetailsList
            };

            var mailRequest = new MailRequest()
            {
                ToEmail = customer.Email,
                Subject = "Your Payment Confirmation",
                Bill = customerBill
            };

            // Passing to the Email service.
            _emailService.SendEmailAsync(mailRequest);

            return "Purchase is Successfull.";
        }
    }
}