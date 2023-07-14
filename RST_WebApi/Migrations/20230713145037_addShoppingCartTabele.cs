using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RST_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addShoppingCartTabele : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemUsers_Appetizes_IdAppetize",
                table: "OrderItemUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemUsers_Drinks_IdDrink",
                table: "OrderItemUsers");

            migrationBuilder.DropIndex(
                name: "IX_OrderItemUsers_IdAppetize",
                table: "OrderItemUsers");

            migrationBuilder.DropIndex(
                name: "IX_OrderItemUsers_IdDrink",
                table: "OrderItemUsers");

            migrationBuilder.DropColumn(
                name: "IdAppetize",
                table: "OrderItemUsers");

            migrationBuilder.DropColumn(
                name: "IdDrink",
                table: "OrderItemUsers");

            migrationBuilder.CreateTable(
                name: "shoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_shoppingCarts_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_ApplicationUserId",
                table: "shoppingCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_FoodId",
                table: "shoppingCarts",
                column: "FoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "IdAppetize",
                table: "OrderItemUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDrink",
                table: "OrderItemUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemUsers_IdAppetize",
                table: "OrderItemUsers",
                column: "IdAppetize");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemUsers_IdDrink",
                table: "OrderItemUsers",
                column: "IdDrink");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemUsers_Appetizes_IdAppetize",
                table: "OrderItemUsers",
                column: "IdAppetize",
                principalTable: "Appetizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemUsers_Drinks_IdDrink",
                table: "OrderItemUsers",
                column: "IdDrink",
                principalTable: "Drinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
