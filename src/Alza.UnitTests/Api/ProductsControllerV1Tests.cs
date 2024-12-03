using Alza.Api.Controllers.V1;
using Alza.Api.Dtos;
using Alza.MockInfrastructure;
using Alza.MockInfrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Alza.UnitTests.Api;

public class ProductsControllerV1Tests
{
    private readonly ProductsController _controller;
    private readonly MockProductRepository _mockRepo;

    public ProductsControllerV1Tests()
    {
        _mockRepo = new MockProductRepository();
        _controller = new ProductsController(_mockRepo);
    }

    [Fact]
    public async Task GetAllProducts_ReturnsOkWithProducts_WhenProductsExist()
    {
        // Arrange
        var products = (await _mockRepo.GetAllProductsAsync()).ToList();
        var expectedProduct = products.First();
        
        // Acts
        var result = await _controller.GetAllProducts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var responseProducts = Assert.IsAssignableFrom<IEnumerable<ProductResponse>>(okResult.Value).ToList();
        Assert.Equal(products.Count, responseProducts.Count);

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

        // Act
        var result = await _controller.GetAllProducts();

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
        Assert.Equal("No products were found.", notFoundResult.Value);

        // Restore the original mock data after the test
        MockProductData.GetProducts().Clear();
        MockProductData.GetProducts().AddRange(originalProducts);
    }

    [Fact]
    public async Task GetProductById_ReturnsOkWithProduct_WhenProductExists()
    {
        // Arrange
        var product = (await _mockRepo.GetAllProductsAsync()).First();

        // Act
        var result = await _controller.GetProductById(product.Id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var responseProducts = Assert.IsType<ProductResponse>(okResult.Value);

        Assert.Equal(product.Id, responseProducts.Id);
        Assert.Equal(product.Name, responseProducts.Name);
        Assert.Equal(product.Description, responseProducts.Description);
        Assert.Equal(product.Price, responseProducts.Price);
    }

    [Fact]
    public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
    {
        // Arrange
        var nonExistentId = Guid.NewGuid();

        // Act
        var result = await _controller.GetProductById(nonExistentId);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
        Assert.Equal($"Product with ID {nonExistentId} was not found.", notFoundResult.Value);
    }

    [Fact]
    public async Task UpdateProductDescription_ReturnsNoContent_WhenUpdateIsSuccessful()
    {
        // Arrange
        var products = (await _mockRepo.GetAllProductsAsync()).ToList();
        var product = products.First();
        var updatedDescription = "Updated Description";
        var request = new UpdateProductDescriptionRequest
        {
            Description = updatedDescription
        };

        // Act
        var result = await _controller.UpdateProductDescription(product.Id, request);

        // Assert
        Assert.IsType<NoContentResult>(result);
        Assert.Equal(updatedDescription, product.Description);
    }
}
