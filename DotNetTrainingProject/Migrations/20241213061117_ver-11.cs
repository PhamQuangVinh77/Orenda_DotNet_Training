using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetTrainingProject.Migrations
{
    /// <inheritdoc />
    public partial class ver11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "58409c93-680d-4e3e-80a4-8915b014c318", "1", "Admin", "Admin" },
                    { "ab1cade3-ad61-4a5e-af01-31086d2a2ea6", "2", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Description", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "7ab8ac44-6f8f-493c-ab64-50f7024e5020", 0, "Hanoi", "3d2db5a3-f8cb-41a4-afc8-08ea8b059a0b", new DateTime(2024, 12, 13, 13, 11, 16, 132, DateTimeKind.Local).AddTicks(4184), new DateTime(2024, 12, 13, 13, 11, 16, 132, DateTimeKind.Local).AddTicks(4171), "It's boss's account", "quangvinh770808@gmail.com", false, "Boss Admin", false, null, "QUANGVINH770808@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAENcqT3lOq0g0AyMHtEW1YIVz4A5GrdMnUauq1TWEmsaLGKzcw3f6F2Xa+k9CgGSkCw==", null, false, "", "182f9c19-f4e2-48f1-afcc-d27ecb6fbea0", false, new DateTime(2024, 12, 13, 13, 11, 16, 132, DateTimeKind.Local).AddTicks(4186), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "58409c93-680d-4e3e-80a4-8915b014c318", "7ab8ac44-6f8f-493c-ab64-50f7024e5020" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab1cade3-ad61-4a5e-af01-31086d2a2ea6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "58409c93-680d-4e3e-80a4-8915b014c318", "7ab8ac44-6f8f-493c-ab64-50f7024e5020" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58409c93-680d-4e3e-80a4-8915b014c318");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7ab8ac44-6f8f-493c-ab64-50f7024e5020");

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
    }
}
