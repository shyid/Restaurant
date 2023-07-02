using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RST_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class orderTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 12, 57, 45, 721, DateTimeKind.Local).AddTicks(8126));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 12, 57, 45, 721, DateTimeKind.Local).AddTicks(8142));

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 12, 57, 45, 721, DateTimeKind.Local).AddTicks(8145));
        }
    }
}
