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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Status { get; set; }

        public Customers Customer { get; set; }

        public virtual Payments Payments { get; set; }

        public virtual OrderDetails OrderDetails { get; set; }
    }
}
