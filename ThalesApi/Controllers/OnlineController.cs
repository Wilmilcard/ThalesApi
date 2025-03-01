using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ThalesApi.Domain.Models;

namespace ThalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public OnlineController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration["ApiSettings:ExternalApi"]; 
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetProductsFromApi()
        {
            // Catch errors are caught by the GlobalExceptionHandler class
            var response = await _httpClient.GetAsync(_apiUrl);
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error al obtener los productos");

            var content = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<List<Product>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return Ok(products);
        }

        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetProductsFromApi(int id)
        {
            // Catch errors are caught by the GlobalExceptionHandler class

            var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error al obtener los productos");

            var content = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return Ok(products);
        }
    }
}
