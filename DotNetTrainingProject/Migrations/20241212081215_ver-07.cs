using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetTrainingProject.Migrations
{
    /// <inheritdoc />
    public partial class ver07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34c56b1c-4826-49f6-955c-7413a5dc75e6", "1", "Admin", "Admin" },
                    { "b8595401-9bd7-4a46-8c0c-9a9c22f7601d", "2", "Customer", "Customer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34c56b1c-4826-49f6-955c-7413a5dc75e6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8595401-9bd7-4a46-8c0c-9a9c22f7601d");
        }
    }
}
