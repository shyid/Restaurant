using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace application.Migrations
{
    /// <inheritdoc />
    public partial class builderseed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc7350c9-91b4-4574-bbba-3c31c1039671", "0d5da095-66c5-4fc2-9da9-da5e4f56b31b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d9f5131c-15a5-43f7-aaf2-1a769e5af443", "6dde66bc-9631-4948-9b67-01693991c709" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc7350c9-91b4-4574-bbba-3c31c1039671");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9f5131c-15a5-43f7-aaf2-1a769e5af443");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d5da095-66c5-4fc2-9da9-da5e4f56b31b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6dde66bc-9631-4948-9b67-01693991c709");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4321b0d2-341b-44db-81c6-4c001c6981cc", null, "Admin", "ADMIN" },
                    { "b30467b6-9fc8-451a-9993-a4b4671aca82", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2448f449-33dd-4c47-9193-635c5915779c", 0, "b791746b-521e-4876-a0e3-f824c8cfacc4", "shadixdey@gmail.com", true, false, null, "SHADIXDEY@GMAIL.COM", "SHADIXDEY@GMAIL.COM", "AQAAAAIAAYagAAAAELDL0QRH5Xn8xDLMPe9pCXypsdZWd+NiCHKI56zlA7oKg1p2SPPLZFyOAp43VgaiKg==", null, false, "51639ef0-9b5c-488d-a2c2-033686a9a950", false, "shadixdey@gmail.com" },
                    { "5b0c4795-9093-464a-b1cb-96b9e358e7cb", 0, "46f28f98-bf72-4de9-bf5c-25749ce503c3", "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEAdDcJ1O+pHQ3KTmxTXv48kwXe8R5nlrBY9LswXAR8Hio51A9xqISUnSJqe1g0o2mg==", null, false, "9c4ca1bb-04a0-48a8-8046-dc13359f6c79", false, "test@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "4321b0d2-341b-44db-81c6-4c001c6981cc", "2448f449-33dd-4c47-9193-635c5915779c" },
                    { "b30467b6-9fc8-451a-9993-a4b4671aca82", "5b0c4795-9093-464a-b1cb-96b9e358e7cb" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4321b0d2-341b-44db-81c6-4c001c6981cc", "2448f449-33dd-4c47-9193-635c5915779c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b30467b6-9fc8-451a-9993-a4b4671aca82", "5b0c4795-9093-464a-b1cb-96b9e358e7cb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4321b0d2-341b-44db-81c6-4c001c6981cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b30467b6-9fc8-451a-9993-a4b4671aca82");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2448f449-33dd-4c47-9193-635c5915779c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5b0c4795-9093-464a-b1cb-96b9e358e7cb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc7350c9-91b4-4574-bbba-3c31c1039671", null, "Admin", "ADMIN" },
                    { "d9f5131c-15a5-43f7-aaf2-1a769e5af443", null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d5da095-66c5-4fc2-9da9-da5e4f56b31b", 0, "26237f70-1f9b-40d2-a88e-279a5bc57fd9", "shadixdey@gmail.com", true, false, null, "SHADIXDEY@GMAIL.COM", "SHADIXDEY@GMAIL.COM", "AQAAAAIAAYagAAAAEFN5mu5CXbwlqlDbpI6UzHBZyw3p/xRn4gs0UiuZlENs9RiA96SLokgTUYk2hocxvQ==", null, false, "daa606d1-3879-4d2a-86a7-16fd9293e2db", false, "shadixdey@gmail.com" },
                    { "6dde66bc-9631-4948-9b67-01693991c709", 0, "2ad0d48a-640d-400a-a1f4-f12f46b30680", "test@gmail.com", true, false, null, "TEST@GMAIL.COM", "TEST@GMAIL.COM", "AQAAAAIAAYagAAAAEGhlQuCsS36yaJe0U3o8Zx79JytsDrhTAldzoUmrnucbLHjvWDS7omokH0gQFZnlEg==", null, false, "be946633-4f3a-4fcf-90fe-0464b478f29e", false, "test@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cc7350c9-91b4-4574-bbba-3c31c1039671", "0d5da095-66c5-4fc2-9da9-da5e4f56b31b" },
                    { "d9f5131c-15a5-43f7-aaf2-1a769e5af443", "6dde66bc-9631-4948-9b67-01693991c709" }
                });
        }
    }
}
