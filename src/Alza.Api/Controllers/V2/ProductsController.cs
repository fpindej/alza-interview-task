using Alza.Api.Dtos;
using Alza.Api.Mappings;
using Alza.Application.Repositories;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Alza.Api.Controllers.V2;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("2.0")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts([FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be non-negative.");
        }

        var products = (await _productRepository.GetAllProductsPaginatedAsync(pageNumber, pageSize)).ToList();

        if (products.Count is 0)
        {
            return NotFound("No products were found.");
        }

        var response = products.Select(p => p.ToResponse());

        return Ok(response);
    }
}