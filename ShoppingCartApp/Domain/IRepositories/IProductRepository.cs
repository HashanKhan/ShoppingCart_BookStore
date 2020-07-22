using ShoppingCartApp.Models;
using System.Collections.Generic;

namespace ShoppingCartApp.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Books> GetAllProducts();

        Books FindBookByName(string Name);

        Books FindBookByID(int Id);

        Books UpdateBookStock(Books book);
    }
}
