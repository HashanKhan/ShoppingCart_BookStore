using ShoppingCartApp.Domain.DTOs;
using ShoppingCartApp.Domain.Models;
using System.Collections.Generic;

namespace ShoppingCartApp.EmailNotification
{
    public class CustomerBill
    {
        public Payments Payment { get; set; }

        public List<ItemDetails> ItemDetailList { get; set; }
    }
}
