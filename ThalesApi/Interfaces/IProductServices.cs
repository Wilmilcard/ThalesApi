using ThalesApi.Domain.Models;
using ThalesApi.Domain.Repository;

namespace ThalesApi.Interfaces
{
    public interface IProductServices : IRepository<Product>
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
    }
}
