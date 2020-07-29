using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;

namespace ShoppingCartApp.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            this._paymentRepository = paymentRepository;
        }

        //Add Orders.
        public Orders PlaceOrder(Orders order)
        {
            var result = _paymentRepository.PlaceOrder(order);

            return result;
        }

        //Add OrderDetails.
        public OrderDetails PlaceOrderDetails(OrderDetails orderDetails)
        {
            var result = _paymentRepository.PlaceOrderDetails(orderDetails);

            return result;
        }

        //Add Payments.
        public Payments ConfirmPayment(Payments payment)
        {
            var result = _paymentRepository.ConfirmPayment(payment);

            return result;
        }
    }
}
