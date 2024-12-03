using Alza.Api.Dtos;
using Alza.Api.Mappings;
using Alza.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Alza.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts()
    {
        var products = (await _productRepository.GetAllProductsAsync()).ToList();

        if (products.Count is 0)
        {
            return NotFound("No products were found.");
        }

        var response = products.Select(p => p.ToResponse());

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public ActionResult<ProductResponse> GetProductById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateProductDescription(Guid id, [FromBody] UpdateProductDescriptionRequest request)
    {
        throw new NotImplementedException();
    }
}