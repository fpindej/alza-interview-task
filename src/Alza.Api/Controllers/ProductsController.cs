using Alza.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Alza.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<ProductResponse>> GetAllProducts()
    {
        throw new NotImplementedException();
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