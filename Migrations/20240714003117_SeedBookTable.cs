using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ef_core.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "ISBN", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "1234567890", 9.99m, "The Great Gatsby" },
                    { 2, "9876543210", 29.99m, "To Kill a Mockingbird" },
                    { 3, "5432109876", 19.99m, "Pride and Prejudice" },
                    { 4, "4567890123", 25.99m, "The Catcher in the Rye" },
                    { 5, "3210987654", 14.99m, "1984" },
                    { 6, "2109876543", 19.99m, "The Lord of the Rings" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
