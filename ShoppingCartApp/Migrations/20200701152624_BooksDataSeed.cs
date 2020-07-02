using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Migrations
{
    public partial class BooksDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Image", "Name", "Price", "Stock", "Type" },
                values: new object[,]
                {
                    { 1, "Martin WickrmaSinghe", "/assets/book_images/MadolDoova.jpg", "Madol Doova", 300m, 100, "Sinhala Novel" },
                    { 2, "Jagath Samarajeewa", "/assets/book_images/Hapana.jpg", "Hapana", 150m, 200, "Kids" },
                    { 3, "Charles Dickens", "/assets/book_images/olivertwist.jpg", "Oliver Twist", 550m, 50, "English Novel" },
                    { 4, "Arthur Conan Doyle", "/assets/book_images/Sherlock Homes.jpg", "Sherlock Holmes", 600m, 300, "English Novel" },
                    { 5, "Arthur Conan Doyle", "/assets/book_images/The Lost World.jpg", "The Lost World", 400m, 180, "English Novel" },
                    { 6, "John Shirley", "/assets/book_images/Constantine.jpg", "Constantine", 1000m, 700, "English Novel" },
                    { 7, "J. K. Rowling", "/assets/book_images/Harry Potter and the Philosopher's Stone.jpg", "Harry Potter and the Philosopher's Stone", 350m, 800, "English Novel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
