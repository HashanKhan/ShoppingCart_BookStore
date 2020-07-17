using ShoppingCartApp.Domain.Models;

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
