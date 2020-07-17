using ShoppingCartApp.Domain.Models;

namespace ShoppingCartApp.Domain.IRepositories
{
    public interface IAccountRepository
    {
       string RegisterCustomer(Customers customer);

       Customers FindCustomerByUserName(string userName);

       Customers UpdateLoginStatus(Customers customer);
    }
}
