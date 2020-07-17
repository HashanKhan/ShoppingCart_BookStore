using Microsoft.EntityFrameworkCore;
using ShoppingCartApp.Domain.Models;

namespace ShoppingCartApp.Models
{
    public class ShoppingCartContext : DbContext
    {
        //Main context class for the whole shopping cart db.
        //Initial data seed for the book products is also added in below.
        public ShoppingCartContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<Payments> Payments { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>().HasData(new Books
            {
                Id = 1,
                Name = "Madol Doova",
                Type = "Sinhala Novel",
                Author = "Martin WickrmaSinghe",
                Price = 300,
                Stock = 100,
                Image = "/assets/book_images/MadolDoova.jpg"

            }, new Books
            {
                Id = 2,
                Name = "Hapana",
                Type = "Kids",
                Author = "Jagath Samarajeewa",
                Price = 150,
                Stock = 200,
                Image = "/assets/book_images/Hapana.jpg"

            }, new Books
            {
                Id = 3,
                Name = "Oliver Twist",
                Type = "English Novel",
                Author = "Charles Dickens",
                Price = 550,
                Stock = 50,
                Image = "/assets/book_images/olivertwist.jpg"

            }, new Books
            {
                Id = 4,
                Name = "Sherlock Holmes",
                Type = "English Novel",
                Author = "Arthur Conan Doyle",
                Price = 600,
                Stock = 300,
                Image = "/assets/book_images/Sherlock Homes.jpg"

            }, new Books
            {
                Id = 5,
                Name = "The Lost World",
                Type = "English Novel",
                Author = "Arthur Conan Doyle",
                Price = 400,
                Stock = 180,
                Image = "/assets/book_images/The Lost World.jpg"

            }, new Books
            {
                Id = 6,
                Name = "Constantine",
                Type = "English Novel",
                Author = "John Shirley",
                Price = 1000,
                Stock = 700,
                Image = "/assets/book_images/Constantine.jpg"

            }, new Books
            {
                Id = 7,
                Name = "Harry Potter and the Philosopher's Stone",
                Type = "English Novel",
                Author = "J. K. Rowling",
                Price = 350,
                Stock = 800,
                Image = "/assets/book_images/Harry Potter and the Philosopher's Stone.jpg"
            }
            );

            modelBuilder.Entity<OrderDetails>().HasKey(o => new { o.OrderId, o.BookId });
        }
    }
}
