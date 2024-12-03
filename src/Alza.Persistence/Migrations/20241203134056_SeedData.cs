using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alza.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2f829254-630c-46bb-b1e6-886072f8e7e8"), new DateTime(2024, 12, 2, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "Over-ear noise cancelling headphones.", "https://example.com/headphones.png", "Noise Cancelling Headphones", 299.99m },
                    { new Guid("35f26883-9b3f-4c59-9bbd-4d09848a5fbc"), new DateTime(2024, 12, 2, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "1TB external SSD for high-speed storage.", "https://example.com/ssd.png", "External SSD", 119.99m },
                    { new Guid("571f36a2-4a0f-400d-9595-7ebcf66d0a86"), new DateTime(2024, 12, 1, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "34-inch ultrawide QHD monitor.", "https://example.com/monitor.png", "Ultrawide Monitor", 499.99m },
                    { new Guid("77e00846-e138-499f-952a-35cfd206c88d"), new DateTime(2024, 12, 1, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "USB-C docking station with multiple ports.", "https://example.com/dock.png", "Docking Station", 129.99m },
                    { new Guid("7b248367-556e-4fc2-baa3-2d4c69da7281"), new DateTime(2024, 12, 3, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "1080p HD webcam for streaming.", "https://example.com/webcam.png", "Webcam", 79.99m },
                    { new Guid("89770280-7299-4066-8b19-c999d1b02ebb"), new DateTime(2024, 12, 3, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "Bluetooth portable speaker with 10-hour battery life.", "https://example.com/speaker.png", "Portable Speaker", 59.99m },
                    { new Guid("9751d27e-0ec9-46fc-ab25-2cbdac46a45b"), new DateTime(2024, 12, 1, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "Ergonomic gaming chair with lumbar support.", "https://example.com/chair.png", "Gaming Chair", 199.99m },
                    { new Guid("9f88a461-1678-4773-a059-0c517e311c68"), new DateTime(2024, 12, 1, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "LED desk lamp with adjustable brightness.", "https://example.com/lamp.png", "Desk Lamp", 29.99m },
                    { new Guid("aeae8fb4-bc85-4046-a7f0-3e4452f8737c"), new DateTime(2024, 11, 30, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "High-end gaming laptop with RTX 4090.", "https://example.com/laptop.png", "Gaming Laptop", 1499.99m },
                    { new Guid("b1818275-0beb-4911-9aeb-2f09b7923525"), new DateTime(2024, 11, 30, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "RGB mechanical keyboard with Cherry MX switches.", "https://example.com/keyboard.png", "Mechanical Keyboard", 89.99m },
                    { new Guid("c254dd20-882c-488e-b2f1-1ebb06ec9b68"), new DateTime(2024, 12, 2, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "Latest flagship smartphone.", "https://example.com/phone.png", "Smartphone", 999.99m },
                    { new Guid("d48f9cd5-0db7-47e7-beae-5c3741ead07e"), new DateTime(2024, 12, 2, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "True wireless earbuds with active noise cancellation.", "https://example.com/earbuds.png", "Wireless Earbuds", 149.99m },
                    { new Guid("dd7ee6a1-403e-4d14-9f7b-7efc77b0cb7f"), new DateTime(2024, 11, 30, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "Ergonomic wireless mouse with adjustable DPI.", "https://example.com/mouse.png", "Wireless Mouse", 49.99m },
                    { new Guid("e9a62381-af0f-495c-9534-aa2ae008a4b4"), new DateTime(2024, 12, 3, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "Lightweight tablet with pen support.", "https://example.com/tablet.png", "Tablet", 799.99m },
                    { new Guid("f80fad30-ea08-4d96-8357-d9c81bbe1d0f"), new DateTime(2024, 11, 30, 13, 40, 56, 672, DateTimeKind.Utc).AddTicks(7994), "20,000mAh portable power bank.", "https://example.com/powerbank.png", "Power Bank", 39.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2f829254-630c-46bb-b1e6-886072f8e7e8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("35f26883-9b3f-4c59-9bbd-4d09848a5fbc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("571f36a2-4a0f-400d-9595-7ebcf66d0a86"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77e00846-e138-499f-952a-35cfd206c88d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b248367-556e-4fc2-baa3-2d4c69da7281"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("89770280-7299-4066-8b19-c999d1b02ebb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9751d27e-0ec9-46fc-ab25-2cbdac46a45b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9f88a461-1678-4773-a059-0c517e311c68"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aeae8fb4-bc85-4046-a7f0-3e4452f8737c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b1818275-0beb-4911-9aeb-2f09b7923525"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c254dd20-882c-488e-b2f1-1ebb06ec9b68"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d48f9cd5-0db7-47e7-beae-5c3741ead07e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd7ee6a1-403e-4d14-9f7b-7efc77b0cb7f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e9a62381-af0f-495c-9534-aa2ae008a4b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f80fad30-ea08-4d96-8357-d9c81bbe1d0f"));
        }
    }
}
