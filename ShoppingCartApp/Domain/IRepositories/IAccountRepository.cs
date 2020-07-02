using ShoppingCartApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.IRepositories
{
    public interface IAccountRepository
    {
       string RegisterCustomer(Customers customer);
    }
}
