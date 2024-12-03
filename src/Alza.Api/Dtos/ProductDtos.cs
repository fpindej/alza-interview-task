using System.ComponentModel.DataAnnotations;

namespace Alza.Api.Dtos;

public class ProductResponse
{
    [Required]
    public Guid Id { get; init; }

    [Required] 
    public string Name { get; init; } = null!;
    
    [Required]
    public decimal Price { get; init; }
    
    public string? Description { get; init; }
}

public class UpdateProductDescriptionRequest
{
    [Required]
    public string Description { get; init; } = null!;
}