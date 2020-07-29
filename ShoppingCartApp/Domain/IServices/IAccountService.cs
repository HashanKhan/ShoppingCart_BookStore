using ShoppingCartApp.Domain.Models;
using System.Collections.Generic;

namespace ShoppingCartApp.Domain.IServices
{
    public interface IAccountService
    {
        string RegisterCustomer(Customers customer);

        Customers FindCustomerByUserName(string userName);

        Customers LoginCustomer(Customers customer);

        string LogOutCustomer(Customers customer);

        IEnumerable<Orders> GetOrdersByCustomerId(int customerId);

        IEnumerable<OrderDetails> GetOrderDetailsByOrderId(int orderId);

        IEnumerable<Payments> GetPaymentsByCustomerName(string customerName);
    }
}
