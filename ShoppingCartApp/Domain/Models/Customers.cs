using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Domain.Models
{
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string LoginStatus { get; set; }

        public DateTime RegisterDate { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
