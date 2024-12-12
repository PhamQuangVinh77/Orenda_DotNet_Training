using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetTrainingProject.Migrations
{
    /// <inheritdoc />
    public partial class ver08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34c56b1c-4826-49f6-955c-7413a5dc75e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8595401-9bd7-4a46-8c0c-9a9c22f7601d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17ecc1e0-ecc7-49a7-8827-2e6ae36041f0", "1", "Admin", "Admin" },
                    { "27a6f3e7-9c22-42a5-bd5f-458ebf71bd7f", "2", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Description", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "ab4f93a6-5f63-4595-bf9e-46e8d91b4c22", 0, "Hanoi", "0dbfcabf-03b4-43a8-97c5-0a653bd70d4b", new DateTime(2024, 12, 12, 17, 24, 1, 421, DateTimeKind.Local).AddTicks(889), new DateTime(2024, 12, 12, 17, 24, 1, 421, DateTimeKind.Local).AddTicks(877), "It's boss's account", "admin@gmail.com", false, "Boss Admin", false, null, null, null, null, null, false, "", "cfdb3e73-e093-4cd0-ba58-e894a1b75da8", false, new DateTime(2024, 12, 12, 17, 24, 1, 421, DateTimeKind.Local).AddTicks(890), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "17ecc1e0-ecc7-49a7-8827-2e6ae36041f0", "ab4f93a6-5f63-4595-bf9e-46e8d91b4c22" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27a6f3e7-9c22-42a5-bd5f-458ebf71bd7f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "17ecc1e0-ecc7-49a7-8827-2e6ae36041f0", "ab4f93a6-5f63-4595-bf9e-46e8d91b4c22" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17ecc1e0-ecc7-49a7-8827-2e6ae36041f0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab4f93a6-5f63-4595-bf9e-46e8d91b4c22");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34c56b1c-4826-49f6-955c-7413a5dc75e6", "1", "Admin", "Admin" },
                    { "b8595401-9bd7-4a46-8c0c-9a9c22f7601d", "2", "Customer", "Customer" }
                });
        }
    }
}
