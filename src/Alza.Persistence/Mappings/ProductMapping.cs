using Alza.Domain.Entities;

namespace Alza.Persistence.Mappings;

internal static class ProductMapping
{
    public static Product ToDomain(this Models.Product model)
    {
        return new Product
        {
            Id = model.Id,
            Name = model.Name,
            ImageUrl = model.ImageUrl,
            Price = model.Price,
            Description = model.Description
        };
    }
}