namespace ShoppingCartApp.Security.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }

        public string UUID { get; set; }

        public bool? Remove { get; set; }
    }
}
