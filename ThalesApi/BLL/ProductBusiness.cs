using ThalesApi.Domain.Models;
using ThalesApi.HttpResponse;
using ThalesApi.Interfaces;

namespace ThalesApi.BLL
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductServices _productService;
        
        public ProductBusiness(IProductServices productService)
        {
            _productService = productService;
        }


        public async Task<List<ProductResponse>> GetProductsAsync()
        {
            var products = await _productService.GetProductsAsync();
            return products.Select(p => new ProductResponse
            {
                id = p.id,
                title = p.title,
                price = p.price,
                description = p.description,
                category = p.category.name,
                images = p.images,
                tax = p.price * 0.19m
            }).ToList();
        }

        public async Task<ProductResponse?> GetProductByIdAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return product == null ? null : new ProductResponse
            {
                id = product.id,
                title = product.title,
                price = product.price,
                category = product.category.name,
                images = product.images,
                description = product.description,
                tax = product.price * 0.19m
            };
        }
    }
}
