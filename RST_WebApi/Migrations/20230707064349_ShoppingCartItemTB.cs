using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RST_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartItemTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foodId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Foods_foodId",
                        column: x => x.foodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_foodId",
                table: "ShoppingCartItems",
                column: "foodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");
        }
    }
}
