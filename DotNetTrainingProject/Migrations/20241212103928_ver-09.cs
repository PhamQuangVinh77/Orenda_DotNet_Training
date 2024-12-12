using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetTrainingProject.Migrations
{
    /// <inheritdoc />
    public partial class ver09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "5f92a7f1-777f-4362-bf6f-660c950745fa", "1", "Admin", "Admin" },
                    { "a2a38735-5da3-44b1-9c5c-103fcad4d912", "2", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Description", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "3b39402a-e8ab-4838-8386-a90fb05dcfab", 0, "Hanoi", "b99e5b3f-ae54-4701-b64c-b0c3fcbde494", new DateTime(2024, 12, 12, 17, 39, 27, 912, DateTimeKind.Local).AddTicks(906), new DateTime(2024, 12, 12, 17, 39, 27, 912, DateTimeKind.Local).AddTicks(893), "It's boss's account", "admin@gmail.com", false, "Boss Admin", false, null, null, null, "AQAAAAIAAYagAAAAEDxDxHjYAJ3lS921Ja/nsJcgMVaf+1gKlDjU0QsfEySHVvDhyR72AigqLIbDA3kCdg==", null, false, "", "ebb17f50-c430-4d8b-93a2-653888d58216", false, new DateTime(2024, 12, 12, 17, 39, 27, 912, DateTimeKind.Local).AddTicks(907), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5f92a7f1-777f-4362-bf6f-660c950745fa", "3b39402a-e8ab-4838-8386-a90fb05dcfab" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2a38735-5da3-44b1-9c5c-103fcad4d912");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5f92a7f1-777f-4362-bf6f-660c950745fa", "3b39402a-e8ab-4838-8386-a90fb05dcfab" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f92a7f1-777f-4362-bf6f-660c950745fa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b39402a-e8ab-4838-8386-a90fb05dcfab");

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
    }
}
