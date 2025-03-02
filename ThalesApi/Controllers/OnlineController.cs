using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ThalesApi.BLL;
using ThalesApi.Domain.Models;
using ThalesApi.Interfaces;
using ThalesApi.Services;

namespace ThalesApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineController : ControllerBase
    {
        private readonly IProductBusiness _business;

        public OnlineController(IProductBusiness business)
        {
            _business = business;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetProductsFromApi()
        {
            try
            {
                var products = await _business.GetProductsAsync();
                return Ok(products);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, $"Error en la API externa: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno: {ex.Message}");
            }
        }

        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetProductByIdFromApi(int id)
        {
            try
            {
                var product = await _business.GetProductByIdAsync(id);
                return product != null ? Ok(product) : NotFound($"Producto con ID {id} no encontrado.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, $"Error en la API externa: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno: {ex.Message}");
            }
        }
    }
}
