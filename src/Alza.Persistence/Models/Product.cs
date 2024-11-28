using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alza.Persistence.Models;

internal sealed class Product : IEntityTypeConfiguration<Product>
{
    [Key]
    [Description("Primary key for the Product entity.")]
    public Guid Id { get; set; }

    [MaxLength(length: 50)]
    [Description("Name of the product.")]
    public string Name { get; set; } = null!;

    [Description("Url of the product image.")]
    public Uri ImageUrl { get; set; } = null!;

    [Range(minimum: 0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
    [Precision(precision: 18, scale: 2)]
    [Description("Price of the product.")]
    public decimal Price { get; set; }

    [MaxLength(length: 200)]
    [Description("Description of the product.")]
    public string? Description { get; set; }

    [Description("Date of creation of the product.")]
    public DateTime CreatedAt { get; set; }

    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("NEWSEQUENTIALID()");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(maxLength: 50);

        builder.Property(p => p.ImageUrl)
            .IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => new Uri(v))
            .HasMaxLength(maxLength: 200);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Description)
            .HasMaxLength(maxLength: 200);

        builder.Property(p => p.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasIndex(p => p.CreatedAt)
            .HasDatabaseName("IX_Product_CreatedAt")
            .IsClustered(clustered: false);

        builder.HasIndex(p => p.Name)
            .HasDatabaseName("IX_Product_Name")
            .IsClustered(clustered: false);
    }
}