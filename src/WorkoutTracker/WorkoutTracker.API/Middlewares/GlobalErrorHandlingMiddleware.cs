using System.Net;
using src.WorkoutTracker.API.Exceptions.Contracts;

namespace src.WorkoutTracker.API.Middlewares
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException exception)
            {
                Console.WriteLine(exception.Message);
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}