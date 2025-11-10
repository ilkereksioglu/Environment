using EnvironmentAPI.Models.Response;
using System.Net;
using System.Text.Json;

namespace EnvironmentAPI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var responseModel = ApiResponse<string>.Fail(error.Message);
                context.Response.StatusCode = error switch
                {
                    // KeyNotFoundException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.BadRequest
                };
                var result = JsonSerializer.Serialize("Something went wrong");
                await context.Response.WriteAsJsonAsync(result);    
            }
        }
    }
}
