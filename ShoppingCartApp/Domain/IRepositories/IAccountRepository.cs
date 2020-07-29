using ShoppingCartApp.Domain.Models;
using System.Collections.Generic;

namespace ShoppingCartApp.Domain.IRepositories
{
    public interface IAccountRepository
    {
       string RegisterCustomer(Customers customer);

       Customers FindCustomerByUserName(string userName);

       Customers UpdateLoginStatus(Customers customer);

       IEnumerable<Orders> GetOrdersByCustomerId(int customerId);

       IEnumerable<OrderDetails> GetOrderDetailsByOrderId(int orderId);

       IEnumerable<Payments> GetPaymentsByCustomerName(string customerName);
    }
}
