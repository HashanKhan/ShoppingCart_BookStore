using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.Models
{
    public class RefreshTokenResource
    {
        public string Token { get; set; }

        public string UserName { get; set; }
    }
}
