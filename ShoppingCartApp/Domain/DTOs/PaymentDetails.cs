using System;

namespace ShoppingCartApp.Security.Models
{
    public class PaymentDetails
    {
        public CartItem[] Cart { get; set; }

        public decimal Total { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime Date { get; set; }

        public string CustomerUserName { get; set; }
    }
}
