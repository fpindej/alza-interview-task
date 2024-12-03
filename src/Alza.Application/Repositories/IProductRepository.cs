using Alza.Domain.Entities;

namespace Alza.Application.Repositories;

public interface IProductRepository
{
    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>A list of all products.</returns>
    Task<IEnumerable<Product>> GetAllProductsAsync();

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <returns>The product if found, or null if not.</returns>
    Task<Product?> GetProductByIdAsync(Guid id);

    /// <summary>
    /// Updates the description of a product.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <param name="description">The new description for the product.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateProductDescriptionAsync(Guid id, string description);
}