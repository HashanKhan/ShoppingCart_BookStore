using ShoppingCartApp.Domain.IRepositories;
using ShoppingCartApp.Domain.Models;
using ShoppingCartApp.Models;
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
    }
}
