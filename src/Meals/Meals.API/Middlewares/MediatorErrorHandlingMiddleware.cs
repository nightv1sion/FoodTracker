using System.Net;
using MediatR;
using src.Meals.Meals.API.Exceptions;

namespace src.Meals.Meals.API.Middlewares
{
    public class MediatorErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public MediatorErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IMediator mediator)
        {
            try
            {
                await _next(context);
            }
            catch (IngredientNotFoundException exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(exception.Message);
            }
        }
    }
}