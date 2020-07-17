using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Migrations
{
    public partial class ChangeTheRelationshipBetweenOrdersAndOrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                unique: true);
        }
    }
}
