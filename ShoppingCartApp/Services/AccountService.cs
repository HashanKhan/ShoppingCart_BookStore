using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Domain.Security.Hashing;
using System.Collections.Generic;

namespace ShoppingCartApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        private readonly IPasswordHasher _passwordHasher;

        public AccountService(IAccountRepository accountRepository, IPasswordHasher passwordHasher)
        {
            this._accountRepository = accountRepository;
            this._passwordHasher = passwordHasher;
        }

        //Register new customers. Returns string notifications for the Web client.
		public string RegisterCustomer(Customers customer)
		{
            customer.Password = _passwordHasher.HashPassword(customer.Password);

            var result = _accountRepository.RegisterCustomer(customer);

            if (result.Equals("Email Already Existed."))
            {
                return "Email Already Existed.";
            }
            else if (result.Equals("UserName Already Existed."))
            {
                return "UserName Already Existed.";
            }
            else
            {
                return "Added Successfully.";
            }
		}

        //Search Customer by the username. Returns the Customer object.
        public Customers FindCustomerByUserName(string userName)
        {
            return _accountRepository.FindCustomerByUserName(userName);
        }

        //Update Login Status when a customer is Login.
        public Customers LoginCustomer(Customers customer)
        {
                customer.LoginStatus = true;

                var updated_customer = _accountRepository.UpdateLoginStatus(customer);

                return updated_customer;
        }

        //Update Login Status when a customer is Logout.
        public string LogOutCustomer(Customers customer)
        {
                customer.LoginStatus = false;

                _accountRepository.UpdateLoginStatus(customer);

                return "You have been Logged Out Successfully.";
        }

        //Get Orders by the Customer Id.
        public IEnumerable<Orders> GetOrdersByCustomerId(int customerId)
        {
            var orders = _accountRepository.GetOrdersByCustomerId(customerId);

            return orders;
        }

        //Gat OrderDetails by Order Id. 
        public IEnumerable<OrderDetails> GetOrderDetailsByOrderId(int orderId)
        {
            var orderDetails = _accountRepository.GetOrderDetailsByOrderId(orderId);

            return orderDetails;
        }

        //Get Payments by the Customer Name.
        public IEnumerable<Payments> GetPaymentsByCustomerName(string customerName)
        {
            var payments = _accountRepository.GetPaymentsByCustomerName(customerName);

            return payments;
        }
    }
}
