using Microsoft.AspNetCore.Http;
using TNTechnology.Business.Services.Interfaces;

namespace TNTechnology.Business.Middleware
{
    public class JwtMiddlewareUser
    {
        private readonly RequestDelegate _next;

        public JwtMiddlewareUser(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtilsService jwtUtils)
        {
            string? token = context.Request.Cookies["Authorization"];
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = await userService.Get(userId.Value);
            }

            await _next(context);
        }
    }
}
