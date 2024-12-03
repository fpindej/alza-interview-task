using Alza.Persistence.Models;
using Microsoft.EntityFrameworkCore;

internal static class DataSeeder
{
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        SeedProducts(modelBuilder);

        return modelBuilder;
    }

    private static void SeedProducts(ModelBuilder modelBuilder)
    {
        // it would be better to use some DateTimeProvider instead, but for the sake of simplicity I keep it like this
        var utcNow = DateTime.UtcNow;

        var products = new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Gaming Laptop",
                ImageUrl = new Uri("https://example.com/laptop.png"),
                Price = 1499.99m,
                Description = "High-end gaming laptop with RTX 4090.",
                CreatedAt = utcNow.AddDays(-3)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Wireless Mouse",
                ImageUrl = new Uri("https://example.com/mouse.png"),
                Price = 49.99m,
                Description = "Ergonomic wireless mouse with adjustable DPI.",
                CreatedAt = utcNow.AddDays(-3)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Mechanical Keyboard",
                ImageUrl = new Uri("https://example.com/keyboard.png"),
                Price = 89.99m,
                Description = "RGB mechanical keyboard with Cherry MX switches.",
                CreatedAt = utcNow.AddDays(-3)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Ultrawide Monitor",
                ImageUrl = new Uri("https://example.com/monitor.png"),
                Price = 499.99m,
                Description = "34-inch ultrawide QHD monitor.",
                CreatedAt = utcNow.AddDays(-2)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Gaming Chair",
                ImageUrl = new Uri("https://example.com/chair.png"),
                Price = 199.99m,
                Description = "Ergonomic gaming chair with lumbar support.",
                CreatedAt = utcNow.AddDays(-2)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Desk Lamp",
                ImageUrl = new Uri("https://example.com/lamp.png"),
                Price = 29.99m,
                Description = "LED desk lamp with adjustable brightness.",
                CreatedAt = utcNow.AddDays(-2)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "External SSD",
                ImageUrl = new Uri("https://example.com/ssd.png"),
                Price = 119.99m,
                Description = "1TB external SSD for high-speed storage.",
                CreatedAt = utcNow.AddDays(-1)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Noise Cancelling Headphones",
                ImageUrl = new Uri("https://example.com/headphones.png"),
                Price = 299.99m,
                Description = "Over-ear noise cancelling headphones.",
                CreatedAt = utcNow.AddDays(-1)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Smartphone",
                ImageUrl = new Uri("https://example.com/phone.png"),
                Price = 999.99m,
                Description = "Latest flagship smartphone.",
                CreatedAt = utcNow.AddDays(-1)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Tablet",
                ImageUrl = new Uri("https://example.com/tablet.png"),
                Price = 799.99m,
                Description = "Lightweight tablet with pen support.",
                CreatedAt = utcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Portable Speaker",
                ImageUrl = new Uri("https://example.com/speaker.png"),
                Price = 59.99m,
                Description = "Bluetooth portable speaker with 10-hour battery life.",
                CreatedAt = utcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Webcam",
                ImageUrl = new Uri("https://example.com/webcam.png"),
                Price = 79.99m,
                Description = "1080p HD webcam for streaming.",
                CreatedAt = utcNow
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Power Bank",
                ImageUrl = new Uri("https://example.com/powerbank.png"),
                Price = 39.99m,
                Description = "20,000mAh portable power bank.",
                CreatedAt = utcNow.AddDays(-3)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Docking Station",
                ImageUrl = new Uri("https://example.com/dock.png"),
                Price = 129.99m,
                Description = "USB-C docking station with multiple ports.",
                CreatedAt = utcNow.AddDays(-2)
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Wireless Earbuds",
                ImageUrl = new Uri("https://example.com/earbuds.png"),
                Price = 149.99m,
                Description = "True wireless earbuds with active noise cancellation.",
                CreatedAt = utcNow.AddDays(-1)
            }
        };

        modelBuilder.Entity<Product>().HasData(products);
    }
}