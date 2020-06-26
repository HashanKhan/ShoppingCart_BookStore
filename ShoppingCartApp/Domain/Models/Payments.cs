using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.Models
{
    public class Payments
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(15)]
        public string PaymentMethod { get; set; }

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [ForeignKey("Orders")]
        public int OrderID { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
