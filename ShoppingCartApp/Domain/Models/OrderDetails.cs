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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Orders")]
        public int OrderID { get; set; }

        [ForeignKey("Books")]
        public int BookID { get; set; }

        public int Quantity { get; set; }

        public decimal SubTotal { get; set; }

        public virtual Orders Orders { get; set; }

        public virtual Books Books { get; set; }
    }
}
