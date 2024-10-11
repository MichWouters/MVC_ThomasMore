using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ThomasMore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adres", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Naam", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8f266ee1-dc62-429d-931b-784c1ee1db33", 0, "Steenweg", "fce21626-4b7e-47eb-b4b6-46f0cc64565d", "michiel@thomasMore.be", false, false, null, "Michiel", null, null, null, null, false, "497ce55f-8853-4ed0-8007-31b51906b25d", false, "Michiel" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumToegevoegd",
                value: new DateTime(2024, 10, 10, 10, 9, 8, 70, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatumToegevoegd",
                value: new DateTime(2024, 10, 10, 10, 9, 8, 70, DateTimeKind.Local).AddTicks(6890));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8f266ee1-dc62-429d-931b-784c1ee1db33");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "DatumToegevoegd",
                value: new DateTime(2024, 10, 10, 9, 41, 21, 57, DateTimeKind.Local).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "DatumToegevoegd",
                value: new DateTime(2024, 10, 10, 9, 41, 21, 57, DateTimeKind.Local).AddTicks(4448));
        }
    }
}
