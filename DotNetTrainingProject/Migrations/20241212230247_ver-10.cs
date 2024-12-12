using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetTrainingProject.Migrations
{
    /// <inheritdoc />
    public partial class ver10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "a6f11ed8-0d95-4fe4-8b61-469770367910", "2", "Customer", "Customer" },
                    { "cc209e08-770e-4c19-8a6f-214d0b628025", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Description", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "c17582a7-8792-4893-b259-ab32f2051238", 0, "Hanoi", "7c3bc4a4-9ae3-4834-a174-129e1afd544e", new DateTime(2024, 12, 13, 6, 2, 45, 170, DateTimeKind.Local).AddTicks(3486), new DateTime(2024, 12, 13, 6, 2, 45, 170, DateTimeKind.Local).AddTicks(3472), "It's boss's account", "admin@gmail.com", false, "Boss Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEEU0ZNnb4BBbM2eFuHEMEtTMKwiMte6wx4XywwwLD7X1c09aMMak9vh/KGbpy1rfVg==", null, false, "", "363ac65a-ca8b-4545-8eec-6247fb97d9e3", false, new DateTime(2024, 12, 13, 6, 2, 45, 170, DateTimeKind.Local).AddTicks(3487), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cc209e08-770e-4c19-8a6f-214d0b628025", "c17582a7-8792-4893-b259-ab32f2051238" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6f11ed8-0d95-4fe4-8b61-469770367910");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc209e08-770e-4c19-8a6f-214d0b628025", "c17582a7-8792-4893-b259-ab32f2051238" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc209e08-770e-4c19-8a6f-214d0b628025");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c17582a7-8792-4893-b259-ab32f2051238");

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
    }
}
