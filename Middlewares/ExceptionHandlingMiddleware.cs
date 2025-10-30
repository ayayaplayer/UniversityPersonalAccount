using System.Net;
using System.Text.Json;

namespace UniversityPersonalAccount.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошло необработанное исключение");
                await HandleExceptionAsync(context, ex);
            }
        }

            private static Task HandleExceptionAsync(HttpContext context, Exception ex)
            {
                 HttpStatusCode code = ex switch
             {
                 ArgumentNullException => HttpStatusCode.BadRequest,
                 KeyNotFoundException => HttpStatusCode.NotFound,
                 UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                _ => HttpStatusCode.InternalServerError
             };

                 var result = JsonSerializer.Serialize(new
                    {
                        success = false,
                        message = ex.Message
                    });

               context.Response.ContentType = "application/json";
               context.Response.StatusCode = (int)code;

               return context.Response.WriteAsync(result);
            }   
    }
}
