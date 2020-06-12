using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Migrations
{
    public partial class ShoppingCartAppModelsShoppingCartContextSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Image", "Name", "Price", "Stock", "Type" },
                values: new object[,]
                {
                    { 1, "Martin WickrmaSinghe", "MadolDoova.jpg", "Madol Doova", 300f, 100, "Sinhala Novel" },
                    { 2, "Jagath Samarajeewa", "Hapana.jpg", "Hapana", 150f, 200, "Kids" },
                    { 3, "Charles Dickens", "olivertwist.jpg", "Oliver Twist", 550f, 50, "English Novel" },
                    { 4, "Arthur Conan Doyle", "Sherlock Homes.jpg", "Sherlock Holmes", 600f, 300, "English Novel" },
                    { 5, "Arthur Conan Doyle", "The Lost World.jpg", "The Lost World", 400f, 180, "English Novel" }
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
        }
    }
}
