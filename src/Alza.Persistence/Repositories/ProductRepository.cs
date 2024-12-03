using Alza.Application.Repositories;
using Alza.Domain.Entities;

namespace Alza.Persistence.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetProductByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProductDescriptionAsync(Guid id, string description)
    {
        throw new NotImplementedException();
    }
}