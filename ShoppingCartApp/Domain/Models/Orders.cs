using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartApp.Domain.Models
{
    public class Orders
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public decimal SubTotal { get; set; }

        [Required]
        public Customers Customer { get; set; }

        public virtual Payments Payments { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
