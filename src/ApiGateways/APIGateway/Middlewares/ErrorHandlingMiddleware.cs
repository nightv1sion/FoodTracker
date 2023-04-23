using Grpc.Core;

namespace src.ApiGateways.APIGateway.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (RpcException exception)
        {
            context.Response.ContentType = "application/json";
            switch (exception.Status.StatusCode)
            {
                case StatusCode.OK:
                    context.Response.StatusCode = StatusCodes.Status200OK; break;
                case StatusCode.NotFound:
                    context.Response.StatusCode = StatusCodes.Status404NotFound; break;
                default:
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError; break;
            }
            await context.Response.WriteAsync(exception.Status.Detail);
        }
    }
}