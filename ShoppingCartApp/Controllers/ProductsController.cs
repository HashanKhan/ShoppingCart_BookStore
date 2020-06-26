using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartApp.Domain.Services;
using ShoppingCartApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Books> GetAllProducts()
        {
            _logger.LogInformation("Completed : Getting all Book Products");

            var products = _productService.GetAllProducts();
            return products;
        }
    }
}