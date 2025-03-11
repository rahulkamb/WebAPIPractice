namespace WebAPI
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _userKey;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _userKey = configuration["Authentication:UserKey"];
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if User Key is present in request headers
            if (!context.Request.Headers.TryGetValue("user_key", out var providedKey))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("User Key is missing.");
                return;
            }

            // Validate the provided User Key
            if (!_userKey.Equals(providedKey))
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Invalid User Key.");
                return;
            }

            await _next(context); // Call the next middleware
        }
    }

}
