using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Persistence.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(ShoppingCartContext context) : base(context)
        {
        }

        //Add new user records to the db.
        public string RegisterCustomer(Customers customer)
        {
            var isEmailExisted = _context.Customers.Any(c => c.Email == customer.Email);
            var isUserNameExisted = _context.Customers.Any(c => c.UserName == customer.UserName);

            if (isEmailExisted)
            {
                return "Email Already Existed.";
            }
            else if (isUserNameExisted)
            {
                return "UserName Already Existed.";
            }
            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return "The Customer Registered Successfully.";
            }
        }

        //Search and retrieve Customer details by the username.
        public Customers FindCustomerByUserName(string userName)
        {
            return _context.Customers.SingleOrDefault(c => c.UserName == userName);
        }

        //Update Login Status field in the Customer table as per the rquirement.
        public Customers UpdateLoginStatus(Customers customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();

            return customer;
        }

        //Retrieve Orders by the Customer Id from the db.
        public IEnumerable<Orders> GetOrdersByCustomerId(int customerId)
        {
            var orders = _context.Orders.Where(o => o.Customer.Id == customerId).ToList();

            return orders;
        }

        //Retrieve Orderdetails by the Order Id from the db.
        public IEnumerable<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails = _context.OrderDetails.Where(od => od.OrderId == orderId).ToList();

            return orderDetails;
        }

        //Retrieve Payments by the Customer Name from the db.
        public IEnumerable<Payments> GetPaymentsByCustomerName(string customerName)
        {
            var payments = _context.Payments.Where(p => p.CustomerName == customerName).ToList();

            return payments;
        }
    }
}
