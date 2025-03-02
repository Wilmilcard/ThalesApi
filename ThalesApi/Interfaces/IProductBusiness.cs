using ThalesApi.HttpResponse;

namespace ThalesApi.Interfaces
{
    public interface IProductBusiness
    {
        Task<List<ProductResponse>> GetProductsAsync();
        Task<ProductResponse?> GetProductByIdAsync(int id);
    }
}
