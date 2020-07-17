using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartApp.Domain.Services;
using ShoppingCartApp.Extensions;
using ShoppingCartApp.Models;
using ShoppingCartApp.Security.Models;
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

        //Get All Books.
        [HttpGet]
        public IEnumerable<Books> GetAllProducts()
        {
            _logger.LogInformation("Completed : Getting all Book Products");

            var products = _productService.GetAllProducts();
            return products;
        }

        //Check the stock availability (authorized end-point).
        [HttpPost]
        [Authorize]
        public ActionResult<string> CheckStockAvailability([FromBody] CartItem[] cartItemArray)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var itemResult = from cartItem in cartItemArray
                         group cartItem by cartItem.Name into g
                         let count = g.Count()
                         select new { Value = g.Key, Count = count };

            foreach (var i in itemResult)
            {
                var Item = _productService.FindBookByName(i.Value);

                if (Item.Stock < i.Count)
                {
                    return i.Value + " " + "-" + " " + "Item is Out of stock. Reduce some number of items and try again.";
                }
            }

            return "Order is OK.";
        }
    }
}