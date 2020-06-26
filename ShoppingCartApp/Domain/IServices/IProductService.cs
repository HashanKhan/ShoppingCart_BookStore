using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.Services
{
    public interface IProductService
    {
        IEnumerable<Books> GetAllProducts();
    }
}
