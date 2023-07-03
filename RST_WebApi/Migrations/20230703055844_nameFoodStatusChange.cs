using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RST_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class nameFoodStatusChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodStatus",
                table: "Foods",
                newName: "EVStatus");

            migrationBuilder.RenameColumn(
                name: "FoodStatus",
                table: "Drinks",
                newName: "EVStatus");

            migrationBuilder.RenameColumn(
                name: "FoodStatus",
                table: "Appetizes",
                newName: "EVStatus");

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 3, 9, 28, 43, 754, DateTimeKind.Local).AddTicks(2816));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 3, 9, 28, 43, 754, DateTimeKind.Local).AddTicks(2837));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 3, 9, 28, 43, 754, DateTimeKind.Local).AddTicks(2841));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EVStatus",
                table: "Foods",
                newName: "FoodStatus");

            migrationBuilder.RenameColumn(
                name: "EVStatus",
                table: "Drinks",
                newName: "FoodStatus");

            migrationBuilder.RenameColumn(
                name: "EVStatus",
                table: "Appetizes",
                newName: "FoodStatus");

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 14, 9, 29, 498, DateTimeKind.Local).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 14, 9, 29, 498, DateTimeKind.Local).AddTicks(7330));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 14, 9, 29, 498, DateTimeKind.Local).AddTicks(7338));
        }
    }
}
