using ShoppingCartApp.Models;
using System.Collections.Generic;

namespace ShoppingCartApp.Domain.Services
{
    public interface IProductService
    {
        IEnumerable<Books> GetAllProducts();

        Books FindBookByName(string Name);

        Books FindBookByID(int Id);

        Books DecreaseBookStock(Books book, int count);
    }
}
