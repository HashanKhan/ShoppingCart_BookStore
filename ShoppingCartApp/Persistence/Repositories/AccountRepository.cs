using Microsoft.AspNetCore.Mvc;
using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Persistence.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(ShoppingCartContext context) : base(context)
        {
        }

        public string RegisterCustomer(Customers customer)
        {
            var isEmailExisted = _context.Customers.Any(c => c.Email == customer.Email);
            var isPhoneExisted = _context.Customers.Any(c => c.Phone == customer.Phone);
            var isUserNameExisted = _context.Customers.Any(c => c.UserName == customer.UserName);
            var isPasswordExisted = _context.Customers.Any(c => c.Password == customer.Password);

            if (isEmailExisted)
            {
                return "Email Already Existed.";
            }
            else if (isPhoneExisted)
            {
                return "Phone Already Existed.";
            }
            else if (isUserNameExisted)
            {
                return "UserName Already Existed.";
            }
            else if (isPasswordExisted)
            {
                return "Password Already Existed.";
            }
            else
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return "The Customer Registered Successfully.";
            }
        }
    }
}
