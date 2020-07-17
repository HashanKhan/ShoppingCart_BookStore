using ShoppingCartApp.Models;

namespace ShoppingCartApp.Persistence.Repositories
{
    //Base repository class. All other repositories are derived from this.
    public class BaseRepository
    {
        protected readonly ShoppingCartContext _context;

        public BaseRepository(ShoppingCartContext context)
        {
            _context = context;
        }
    }
}
