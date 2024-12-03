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

    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        var productModel = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        return productModel?.ToDomain();
    }

    public async Task UpdateProductDescriptionAsync(Guid id, string description)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        try

        {
            var productModel = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (productModel is null)
            {
                throw new KeyNotFoundException($"Product with ID '{id}' was not found.");
            }

            productModel.Description = description;
            _context.Products.Update(productModel);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}