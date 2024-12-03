using Alza.Domain.Entities;

namespace Alza.MockInfrastructure;

public static class MockProductData
{
    private static readonly List<Product> Products;

    static MockProductData()
    {
        Products = new List<Product>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Gaming Laptop",
                ImageUrl = new Uri("https://example.com/laptop.png"),
                Price = 1499.99m,
                Description = "High-end gaming laptop with RTX 4090."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Wireless Mouse",
                ImageUrl = new Uri("https://example.com/mouse.png"),
                Price = 49.99m,
                Description = "Ergonomic wireless mouse with adjustable DPI."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Mechanical Keyboard",
                ImageUrl = new Uri("https://example.com/keyboard.png"),
                Price = 89.99m,
                Description = "RGB mechanical keyboard with Cherry MX switches."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Ultrawide Monitor",
                ImageUrl = new Uri("https://example.com/monitor.png"),
                Price = 499.99m,
                Description = "34-inch ultrawide QHD monitor."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Gaming Chair",
                ImageUrl = new Uri("https://example.com/chair.png"),
                Price = 199.99m,
                Description = "Ergonomic gaming chair with lumbar support."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Desk Lamp",
                ImageUrl = new Uri("https://example.com/lamp.png"),
                Price = 29.99m,
                Description = "LED desk lamp with adjustable brightness."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "External SSD",
                ImageUrl = new Uri("https://example.com/ssd.png"),
                Price = 119.99m,
                Description = "1TB external SSD for high-speed storage."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Noise Cancelling Headphones",
                ImageUrl = new Uri("https://example.com/headphones.png"),
                Price = 299.99m,
                Description = "Over-ear noise cancelling headphones."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Smartphone",
                ImageUrl = new Uri("https://example.com/phone.png"),
                Price = 999.99m,
                Description = "Latest flagship smartphone."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Tablet",
                ImageUrl = new Uri("https://example.com/tablet.png"),
                Price = 799.99m,
                Description = "Lightweight tablet with pen support."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Portable Speaker",
                ImageUrl = new Uri("https://example.com/speaker.png"),
                Price = 59.99m,
                Description = "Bluetooth portable speaker with 10-hour battery life."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Webcam",
                ImageUrl = new Uri("https://example.com/webcam.png"),
                Price = 79.99m,
                Description = "1080p HD webcam for streaming."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Power Bank",
                ImageUrl = new Uri("https://example.com/powerbank.png"),
                Price = 39.99m,
                Description = "20,000mAh portable power bank."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Docking Station",
                ImageUrl = new Uri("https://example.com/dock.png"),
                Price = 129.99m,
                Description = "USB-C docking station with multiple ports."
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Wireless Earbuds",
                ImageUrl = new Uri("https://example.com/earbuds.png"),
                Price = 149.99m,
                Description = "True wireless earbuds with active noise cancellation."
            }
        };
    }

    public static List<Product> GetProducts()
    {
        return Products;
    }
}