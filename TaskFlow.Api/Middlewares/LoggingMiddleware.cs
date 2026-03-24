namespace TaskFlow.Api.Middlewares
{
    public class LoggingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingMiddleware> _logger;
        public LoggingMiddleware(ILogger<LoggingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var startTime = DateTime.UtcNow;
            var path = context.Request.Path;
            _logger.LogInformation("→ {Method} {Path}", context.Request.Method, path);

            await next(context);

            var duration = (DateTime.UtcNow - startTime).TotalMilliseconds;
            _logger.LogInformation("← {Method} {Path} → {StatusCode} ({Duration}ms)",
                context.Request.Method, path, context.Response.StatusCode, duration);
        }
    }
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LoggingMiddleware>();
        }
    }
}
