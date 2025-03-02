using ThalesApi.Domain.Models;
using ThalesApi.Domain.Repository;
using ThalesApi.Interfaces;

namespace ThalesApi.Services
{
    public class ProductServices : BaseRepository<Product>, IProductServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public ProductServices(IRepository<Product> repository, HttpClient httpClient, IConfiguration configuration) : base(repository)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiSettings:ExternalApi"];
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Product>>(_apiUrl);
            return response ?? new List<Product>();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Product>($"{_apiUrl}/{id}");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
