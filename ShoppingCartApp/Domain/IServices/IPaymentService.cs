using ShoppingCartApp.Domain.Models;

namespace ShoppingCartApp.Domain.IServices
{
    public interface IPaymentService
    {
        Orders PlaceOrder(Orders order);

        OrderDetails PlaceOrderDetails(OrderDetails orderDetails);

        Payments ConfirmPayment(Payments payment);
    }
}
