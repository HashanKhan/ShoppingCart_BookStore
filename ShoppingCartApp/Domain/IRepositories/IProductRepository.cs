﻿using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Books> GetAllProducts();
    }
}
