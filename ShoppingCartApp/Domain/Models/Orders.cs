using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.Models
{
    public class Orders
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(15)]
        public string Status { get; set; }

        [Required]
        public Customers Customer { get; set; }

        public virtual Payments Payments { get; set; }

        public virtual OrderDetails OrderDetails { get; set; }
    }
}
