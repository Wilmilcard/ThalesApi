using Moq;
using ThalesApi.BLL;
using ThalesApi.Domain.Models;
using ThalesApi.HttpResponse;
using ThalesApi.Interfaces;

namespace ThalesApi.Test
{
    public class ProductBusinessTests
    {
        [Fact]
        public async Task GetProductsAsync_ShouldCalculateTax()
        {
            // Arrange
            var mockService = new Mock<IProductServices>();
            mockService.Setup(s => s.GetProductsAsync()).ReturnsAsync(new List<Product>
            {
                new Product { id = 1, title = "Producto A", price = 100, category = new Category { name = "Categoria A" }, images = new List<string>() },
                new Product { id = 2, title = "Producto B", price = 200, category = new Category { name = "Categoria B" }, images = new List<string>() }
            });

            var business = new ProductBusiness(mockService.Object);

            // Act
            var products = await business.GetProductsAsync();

            // Assert
            Assert.Equal(19, products[0].tax);  // 100 * 0.19
            Assert.Equal(38, products[1].tax);  // 200 * 0.19
        }
    }
}