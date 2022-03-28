using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HelloApp.Middlewares
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutingMiddleware(RequestDelegate next) {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/index")
            {
                await context.Response.WriteAsync("Home Page");
            }
            else if (path == "/about")
            {
                await context.Response.WriteAsync("About");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
