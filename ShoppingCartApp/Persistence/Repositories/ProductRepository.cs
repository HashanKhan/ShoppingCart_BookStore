using ShoppingCartApp.Domain.Repositories;
using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(ShoppingCartContext context) : base(context)
        {
        }

        public IEnumerable<Books> GetAll()
        {
            return _context.Books.ToList();
        }
    }
}
