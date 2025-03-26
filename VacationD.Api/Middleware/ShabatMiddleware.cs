using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Net.Http;

namespace VacationD.Api.Middleware
{
    public class ShabatMiddleware
    {
        private readonly RequestDelegate _next;
        public ShabatMiddleware(RequestDelegate next)
        {
            _next = next;
                }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("middleware start");
            var shabat = false;
            if(shabat) 
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            else 
            {

            await _next(context);
        }
            Console.WriteLine("middleware end");
    }
    }
}
