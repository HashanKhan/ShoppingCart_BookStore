using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.IServices;
using ShoppingCartApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

		public string RegisterCustomer(Customers customer)
		{
			var result = _accountRepository.RegisterCustomer(customer);

            if (result.Equals("Email Already Existed."))
            {
                return "Email Already Existed.";
            }
            else if (result.Equals("Phone Already Existed."))
            {
                return "Phone Already Existed.";
            }
            else if (result.Equals("UserName Already Existed."))
            {
                return "UserName Already Existed.";
            }
            else if (result.Equals("Password Already Existed."))
            {
                return "Password Already Existed.";
            }
            else
            {
                return "Added Successfully.";
            }
		}
	}
}
