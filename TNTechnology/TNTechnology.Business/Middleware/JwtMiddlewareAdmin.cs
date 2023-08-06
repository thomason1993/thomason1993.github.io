using Microsoft.AspNetCore.Http;
using TNTechnology.Business.Services.Interfaces;

namespace TNTechnology.Business.Middleware
{
    public class JwtMiddlewareAdmin
    {
        private readonly RequestDelegate _next;

        public JwtMiddlewareAdmin(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAdminService adminService, IJwtUtilsService jwtUtils)
        {
            string? token = context.Request.Cookies["Authorization"];
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["Admin"] = await adminService.Get(userId.Value);
            }

            await _next(context);
        }
    }
}
