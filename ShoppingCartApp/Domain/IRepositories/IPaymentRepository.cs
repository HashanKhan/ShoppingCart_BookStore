using ShoppingCartApp.Domain.Models;

namespace ShoppingCartApp.Domain.IRepositories
{
    public interface IPaymentRepository
    {
        Orders PlaceOrder(Orders order);

        OrderDetails PlaceOrderDetails(OrderDetails orderDetails);

        Payments ConfirmPayment(Payments payment);
    }
}
