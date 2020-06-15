using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly ShoppingCartContext _context;

        public BaseRepository(ShoppingCartContext context)
        {
            _context = context;
        }
    }
}
