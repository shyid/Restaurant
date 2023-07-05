using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RST_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UPTBFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "CreatedDate", "Details", "EVStatus", "ImageUrl", "Name", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 5, 14, 16, 57, 771, DateTimeKind.Local).AddTicks(5075), "It has pepperoni and pizza cheese", 0, "https://dotnetmastery.com/bluevillaimages/villa3.jpg", "Pepperoni pizza", 150.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 7, 5, 14, 16, 57, 771, DateTimeKind.Local).AddTicks(5091), "It has meat, mushroom and pizza cheese", 0, "https://dotnetmastery.com/bluevillaimages/villa3.jpg", "Meat pizza", 150.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 7, 5, 14, 16, 57, 771, DateTimeKind.Local).AddTicks(5094), "It has chicken, mushroom and cheese pizza", 0, "https://dotnetmastery.com/bluevillaimages/villa3.jpg", "Chicken pizza", 150.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
