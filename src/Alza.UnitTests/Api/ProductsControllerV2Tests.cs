using Alza.Api.Controllers.V2;
using Alza.Api.Dtos;
using Alza.MockInfrastructure;
using Alza.MockInfrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Alza.UnitTests.Api;

public class ProductsControllerV2Tests
{
    private readonly ProductsController _controller;
    private readonly MockProductRepository _mockRepo;

    public ProductsControllerV2Tests()
    {
        _mockRepo = new MockProductRepository();
        _controller = new ProductsController(_mockRepo);
    }

    [Fact]
    public async Task GetAllProducts_ReturnsOkWithPaginatedProducts_WhenProductsExist()
    {
        // Arrange
        const int pageNumber = 1;
        const int pageSize = 5;

        // Act
        var result = await _controller.GetAllProducts(pageNumber, pageSize);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var responseProducts = Assert.IsAssignableFrom<IEnumerable<ProductResponse>>(okResult.Value).ToList();

        var expectedProducts = (await _mockRepo.GetAllProductsPaginatedAsync(pageNumber, pageSize)).ToList();

        Assert.Equal(expectedProducts.Count, responseProducts.Count);

        var expectedProduct = expectedProducts.First();
        var actualProduct = responseProducts.First();

        Assert.Equal(expectedProduct.Id, actualProduct.Id);
        Assert.Equal(expectedProduct.Name, actualProduct.Name);
        Assert.Equal(expectedProduct.Description, actualProduct.Description);
        Assert.Equal(expectedProduct.Price, actualProduct.Price);
    }

    [Fact]
    public async Task GetAllProducts_ReturnsNotFound_WhenNoProductsExist()
    {
        //Backup the current mock data
        var originalProducts = MockProductData.GetProducts().ToList();

        // Arrange: Clear mock data for this test
        MockProductData.GetProducts().Clear();
        const int pageNumber = 1;
        const int pageSize = 5;

        // Act
        var result = await _controller.GetAllProducts(pageNumber, pageSize);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
        Assert.Equal("No products were found.", notFoundResult.Value);

        // Restore the original mock data after the test
        MockProductData.GetProducts().Clear();
        MockProductData.GetProducts().AddRange(originalProducts);
    }

    [Fact]
    public async Task GetAllProducts_ReturnsBadRequest_WhenPageNumberIsInvalid()
    {
        // Arrange
        const int pageNumber = 0; // Invalid page number
        const int pageSize = 5;

        // Act
        var result = await _controller.GetAllProducts(pageNumber, pageSize);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("Page number and page size must be non-negative.", badRequestResult.Value);
    }

    [Theory]
    [InlineData(0, 5)]
    [InlineData(1, 0)]
    [InlineData(0, 0)]
    [InlineData(-1, 5)]
    [InlineData(1, -5)]
    [InlineData(-1, -5)]
    public async Task GetAllProducts_ReturnsBadRequest_WhenPageNumberOrPageSizeIsInvalid(int pageNumber, int pageSize)
    {
        // Act
        var result = await _controller.GetAllProducts(pageNumber, pageSize);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        Assert.Equal("Page number and page size must be non-negative.", badRequestResult.Value);
    }
}