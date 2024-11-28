using System.ComponentModel.DataAnnotations;

namespace Alza.Domain.Entities;

public class Product
{
    [Required]
    public Guid Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set;  } = null!;

    public Uri ImageUrl { get; set; } = null!;
    
    public decimal Price { get; set; }
    
    [MaxLength(200)]
    public string? Description { get; set; }
}