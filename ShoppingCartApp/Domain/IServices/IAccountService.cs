using ShoppingCartApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.IServices
{
    public interface IAccountService
    {
        string RegisterCustomer(Customers customer);

        Customers FindCustomerByUserName(string userName);

        Customers LoginCustomer(Customers customer);

        string LogOutCustomer(Customers customer);
    }
}
