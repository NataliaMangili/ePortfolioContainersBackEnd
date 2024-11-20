using System.Net;

namespace ePortfolio.Infrastructure.Middleware
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandling> _logger;

        public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Passa a requisição para o próximo middleware
            }
            catch (FluentValidation.ValidationException ex)
            {
                // Lidar com erros de validação
                _logger.LogWarning("Validation error occurred: {Errors}", string.Join(", ", ex.Errors.Select(e => e.ErrorMessage)));

                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var response = new
                {
                    success = false,
                    errors = ex.Errors.Select(e => new
                    {
                        e.PropertyName,
                        e.ErrorMessage
                    }).ToList() // Retorna os erros de validação em formato JSON
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    success = false,
                    message = "An unexpected error occurred. Please try again later."
                };

                await context.Response.WriteAsJsonAsync(response);

                throw ex;
            }
        }
    }
}
