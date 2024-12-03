using Alza.Application.Repositories;
using Alza.Domain.Entities;
using Alza.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Alza.Persistence.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly AlzaDbContext _context;

    public ProductRepository(AlzaDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var productModels = await _context.Products
            .AsNoTracking()
            .ToListAsync();

        if (productModels.Count is 0)
        {
            return Enumerable.Empty<Product>();
        }

        return productModels.Select(p => p.ToDomain());
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