using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApp.Models
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }

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
                Image = "MadolDoova.jpg"

            }, new Books
            {
                Id = 2,
                Name = "Hapana",
                Type = "Kids",
                Author = "Jagath Samarajeewa",
                Price = 150,
                Stock = 200,
                Image = "Hapana.jpg"

            }, new Books
            {
                Id = 3,
                Name = "Oliver Twist",
                Type = "English Novel",
                Author = "Charles Dickens",
                Price = 550,
                Stock = 50,
                Image = "olivertwist.jpg"

            }, new Books
            {
                Id = 4,
                Name = "Sherlock Holmes",
                Type = "English Novel",
                Author = "Arthur Conan Doyle",
                Price = 600,
                Stock = 300,
                Image = "Sherlock Homes.jpg"

            }, new Books
            {
                Id = 5,
                Name = "The Lost World",
                Type = "English Novel",
                Author = "Arthur Conan Doyle",
                Price = 400,
                Stock = 180,
                Image = "The Lost World.jpg"
            }
            );
        }
    }
}
