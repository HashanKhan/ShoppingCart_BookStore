using ShoppingCartApp.Domain.Repositories;
using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ShoppingCartContext context) : base(context)
        {
        }

        //Retrieve all book products from the db.
        public IEnumerable<Books> GetAllProducts()
        {
            return _context.Books.ToList();
        }

        //Retrieve a book by name from the db. 
        public Books FindBookByName(string Name)
        {
            return _context.Books.SingleOrDefault(b => b.Name == Name);
        }
    }
}
