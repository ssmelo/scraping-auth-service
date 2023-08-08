using auth_service.Domain.Errors;

namespace auth_service.Application.Middlewares
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            string message;
            if(exception is DefaultException)
            {
                var ex = (DefaultException)exception;
                message = new BaseError(ex.StatusCode, ex.Message, ex.Errors).ToString();
                context.Response.StatusCode = ex.StatusCode;
            } else
            {
                var statusCode = 500;
                message = new BaseError(statusCode, exception.Message).ToString();
                context.Response.StatusCode = statusCode;
            }

            await context.Response.WriteAsync(message);
        }
    }
}