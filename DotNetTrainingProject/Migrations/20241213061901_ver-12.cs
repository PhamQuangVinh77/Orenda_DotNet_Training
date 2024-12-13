using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetTrainingProject.Migrations
{
    /// <inheritdoc />
    public partial class ver12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1918e8e3-3363-4ceb-a9c5-e4bc0a7c22c9", "2", "Customer", "Customer" },
                    { "1dfb635b-914d-4235-b8fc-d64fc4f8a154", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "DateOfBirth", "Description", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { "8825eafd-648f-4ecf-abd8-ffd346e80090", 0, "Hanoi", "578da75a-f1ae-4c8e-a938-ef0454e45a94", new DateTime(2024, 12, 13, 13, 19, 0, 489, DateTimeKind.Local).AddTicks(5765), new DateTime(2024, 12, 13, 13, 19, 0, 489, DateTimeKind.Local).AddTicks(5754), "It's boss's account", "quangvinh770808@gmail.com", false, "Boss Admin", false, null, "QUANGVINH770808@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEEqkBpWhoVwZ5opWzSir5IljkpZu/ermoobNxRe/Us8mCNm8pPWPl0+Y4/tV5RnsAg==", null, false, "", "5028a53a-096d-43f8-abd8-e46445c87bb2", false, new DateTime(2024, 12, 13, 13, 19, 0, 489, DateTimeKind.Local).AddTicks(5766), "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1dfb635b-914d-4235-b8fc-d64fc4f8a154", "8825eafd-648f-4ecf-abd8-ffd346e80090" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1918e8e3-3363-4ceb-a9c5-e4bc0a7c22c9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1dfb635b-914d-4235-b8fc-d64fc4f8a154", "8825eafd-648f-4ecf-abd8-ffd346e80090" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dfb635b-914d-4235-b8fc-d64fc4f8a154");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8825eafd-648f-4ecf-abd8-ffd346e80090");

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
    }
}
