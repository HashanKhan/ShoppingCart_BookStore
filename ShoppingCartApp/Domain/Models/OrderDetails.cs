using ShoppingCartApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.Models
{
    public class OrderDetails
    {
        [ForeignKey("Orders")]
        public int OrderId { get; set; }

        [ForeignKey("Books")]
        public int BookId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Books Books { get; set; }
    }
}
