using ShoppingCartApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Models
{
    public class Books
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(15)]
        public string Type { get; set; }

        [Required]
        [StringLength(20)]
        public string Author { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
