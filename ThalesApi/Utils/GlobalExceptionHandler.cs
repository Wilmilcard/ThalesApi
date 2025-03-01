using Newtonsoft.Json;
using System.Net;

namespace ThalesApi.Utils
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError($"Error personalizado: {msg}");

                var response = new
                {
                    succcess = false,
                    message = "Mensaje de error interno personalizado",
                    data = msg,
                    status = (int)HttpStatusCode.InternalServerError
                };

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
