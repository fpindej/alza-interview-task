using Alza.Application.Repositories;
using Alza.Domain.Entities;

namespace Alza.MockInfrastructure.Repositories;

public class MockProductRepository : IProductRepository
{
    private static readonly List<Product> Products = MockProductData.GetProducts();

    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return Task.FromResult(Products.AsEnumerable());
    }

    public Task<IEnumerable<Product>> GetAllProductsPaginatedAsync(int pageNumber, int pageSize)
    {
        var paginatedProducts = Products
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        return Task.FromResult(paginatedProducts.AsEnumerable());
    }

    public Task<Product?> GetProductByIdAsync(Guid id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task UpdateProductDescriptionAsync(Guid id, string description)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            throw new KeyNotFoundException($"Product with ID '{id}' was not found.");
        }

        product.Description = description;
        return Task.CompletedTask;
    }
}