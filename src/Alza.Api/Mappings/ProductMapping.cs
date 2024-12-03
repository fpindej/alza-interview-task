using Alza.Api.Dtos;
using Alza.Domain.Entities;

namespace Alza.Api.Mappings;

internal static class ProductMapping
{
    public static ProductResponse ToResponse(this Product product)
    {
        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        };
    }
}