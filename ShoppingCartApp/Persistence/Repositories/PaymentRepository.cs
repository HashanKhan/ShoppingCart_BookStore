using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Models;

namespace ShoppingCartApp.Persistence.Repositories
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        public PaymentRepository(ShoppingCartContext context) : base(context)
        {
        }

        // Inserting Order records to the DB.
        public Orders PlaceOrder(Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order;
        }

        // Inserting OrderDetails records to the DB.
        public OrderDetails PlaceOrderDetails(OrderDetails orderDetails)
        {
            _context.OrderDetails.Add(orderDetails);
            _context.SaveChanges();

            return orderDetails;
        }

        // Inserting Payments records to the DB.
        public Payments ConfirmPayment(Payments payment)
        {
            _context.Payments.Add(payment);
            _context.SaveChanges();

            return payment;
        }
    }
}
