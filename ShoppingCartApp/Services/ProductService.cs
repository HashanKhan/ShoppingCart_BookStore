using ShoppingCartApp.Domain.Repositories;
using ShoppingCartApp.Domain.Services;
using ShoppingCartApp.Models;
using System.Collections.Generic;

namespace ShoppingCartApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        //Get all book products service.
        public IEnumerable<Books> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        //Get a book by the name.
        public Books FindBookByName(string Name)
        {
            return _productRepository.FindBookByName(Name);
        }
    }
}
