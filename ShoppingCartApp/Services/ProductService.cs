using ShoppingCartApp.Domain.Repositories;
using ShoppingCartApp.Domain.Services;
using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IEnumerable<Books> GetAll()
        {
            return _productRepository.GetAll();
        }
    }
}
