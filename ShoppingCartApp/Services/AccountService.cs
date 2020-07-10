using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Domain.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Customers FindCustomerByUserName(string userName)
        {
            return _accountRepository.FindCustomerByUserName(userName);
        }

        public Customers LoginCustomer(Customers customer)
        {
            if (customer.LoginStatus == false)
            {
                customer.LoginStatus = true;

                var updated_customer = _accountRepository.UpdateLoginStatus(customer);

                return updated_customer;
            }
            else
            {
                return customer;
            }
        }

        public string LogOutCustomer(Customers customer)
        {
            if (customer.LoginStatus == true)
            {
                customer.LoginStatus = false;

                _accountRepository.UpdateLoginStatus(customer);

                return "You have been Logged Out Successfully.";
            }
            else
            {
                return "You are already Logged Out, Log In first.";
            }
        }
    }
}
