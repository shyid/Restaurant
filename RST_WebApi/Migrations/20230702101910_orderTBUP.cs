using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RST_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class orderTBUP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFood = table.Column<int>(type: "int", nullable: false),
                    foodId = table.Column<int>(type: "int", nullable: true),
                    IdDrink = table.Column<int>(type: "int", nullable: false),
                    drinkId = table.Column<int>(type: "int", nullable: true),
                    IdAppetize = table.Column<int>(type: "int", nullable: false),
                    appetizeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Appetizes_appetizeId",
                        column: x => x.appetizeId,
                        principalTable: "Appetizes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Drinks_drinkId",
                        column: x => x.drinkId,
                        principalTable: "Drinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Foods_foodId",
                        column: x => x.foodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 13, 47, 34, 323, DateTimeKind.Local).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 13, 47, 34, 323, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 13, 47, 34, 323, DateTimeKind.Local).AddTicks(81));
        }
    }
}
