using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using ThalesApi.Domain.DB;
using ThalesApi.Domain.Models;
using ThalesApi.Interfaces;

namespace ThalesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly ThalesContext _context;
        private readonly IConfiguration _configuration;

        public LocalController(ThalesContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetProductsFromDB()
        {
            //Catch errors are caught by the GlobalExceptionHandler class,
            //but can also be handled locally
            try
            {
                var rpta = _context.products
                    .Select(x => new
                    {
                        x.id,
                        x.title,
                        x.description,
                        x.price,
                        x.category.name,
                        x.images
                    })
                    .OrderByDescending(x => x.id)
                    .ToList();

                var response = new
                {
                    succcess = true,
                    data = rpta
                };

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    succcess = false,
                    error = ex.Message,
                    errorCode = ex.HResult,
                    stackTrace = ex.StackTrace
                };

                return new BadRequestObjectResult(response);
            }
        }

        [AllowAnonymous]
        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetProductsFromDB(int id)
        {
            //Catch errors are caught by the GlobalExceptionHandler class,
            //but can also be handled locally
            try
            {
                var rpta = _context.products
                    .Select(x => new
                    {
                        x.id,
                        x.title,
                        x.description,
                        x.price,
                        x.category.name,
                        x.images
                    })
                    .OrderByDescending(x => x.id)
                    .Where(x => x.id == id)
                    .ToList();

                var response = new
                {
                    succcess = true,
                    data = rpta
                };

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    succcess = false,
                    error = ex.Message,
                    errorCode = ex.HResult,
                    stackTrace = ex.StackTrace
                };

                return new BadRequestObjectResult(response);
            }
        }
    }
}
