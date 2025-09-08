using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryAspireSample.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "IsActive", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Electronics", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "15-inch business laptop", true, "Laptop", 1200.00m, 15 },
                    { 2, "Electronics", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latest Android smartphone", true, "Smartphone", 800.00m, 30 },
                    { 3, "Furniture", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ergonomic office chair", true, "Office Chair", 250.00m, 20 },
                    { 4, "Home", new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "LED desk lamp", true, "Desk Lamp", 40.00m, 50 },
                    { 5, "Accessories", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waterproof travel backpack", true, "Backpack", 60.00m, 25 },
                    { 6, "Electronics", new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noise-cancelling headphones", true, "Headphones", 150.00m, 40 },
                    { 7, "Sportswear", new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lightweight running shoes", true, "Running Shoes", 100.00m, 35 },
                    { 8, "Appliances", new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automatic drip coffee maker", true, "Coffee Maker", 90.00m, 10 },
                    { 9, "Electronics", new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portable Bluetooth speaker", true, "Bluetooth Speaker", 70.00m, 45 },
                    { 10, "Stationery", new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hardcover ruled notebook", true, "Notebook", 12.50m, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
