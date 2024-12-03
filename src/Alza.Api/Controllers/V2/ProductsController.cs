using Alza.Api.Dtos;
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
    public Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts()
    {
        throw new NotImplementedException();
    }
}