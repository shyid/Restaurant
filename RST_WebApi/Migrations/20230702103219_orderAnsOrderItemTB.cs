using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RST_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class orderAnsOrderItemTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Appetizes_appetizeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drinks_drinkId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Foods_foodId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_appetizeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_drinkId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_foodId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdAppetize",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdDrink",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IdFood",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "appetizeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "drinkId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "foodId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    IdFood = table.Column<int>(type: "int", nullable: false),
                    IdDrink = table.Column<int>(type: "int", nullable: false),
                    IdAppetize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Appetizes_IdAppetize",
                        column: x => x.IdAppetize,
                        principalTable: "Appetizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Drinks_IdDrink",
                        column: x => x.IdDrink,
                        principalTable: "Drinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Foods_IdFood",
                        column: x => x.IdFood,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 14, 2, 18, 876, DateTimeKind.Local).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 14, 2, 18, 876, DateTimeKind.Local).AddTicks(7585));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 14, 2, 18, 876, DateTimeKind.Local).AddTicks(7589));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdAppetize",
                table: "OrderItems",
                column: "IdAppetize");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdDrink",
                table: "OrderItems",
                column: "IdDrink");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_IdFood",
                table: "OrderItems",
                column: "IdFood");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "IdAppetize",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDrink",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdFood",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "appetizeId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "drinkId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "foodId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 13, 49, 9, 674, DateTimeKind.Local).AddTicks(276));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 13, 49, 9, 674, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 13, 49, 9, 674, DateTimeKind.Local).AddTicks(299));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_appetizeId",
                table: "Orders",
                column: "appetizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_drinkId",
                table: "Orders",
                column: "drinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_foodId",
                table: "Orders",
                column: "foodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Appetizes_appetizeId",
                table: "Orders",
                column: "appetizeId",
                principalTable: "Appetizes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drinks_drinkId",
                table: "Orders",
                column: "drinkId",
                principalTable: "Drinks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Foods_foodId",
                table: "Orders",
                column: "foodId",
                principalTable: "Foods",
                principalColumn: "Id");
        }
    }
}
