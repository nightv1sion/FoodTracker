using System.Text.Json;
using Grpc.Core;
using Grpc.Core.Interceptors;
using src.WorkoutTracker.API.Exceptions;
using src.WorkoutTracker.API.Exceptions.Contracts;

namespace src.WorkoutTracker.API.Intereptors;
public class GrpcGlobalExceptionHandlerInterceptor : Interceptor
{
    public GrpcGlobalExceptionHandlerInterceptor()
    {

    }
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await base.UnaryServerHandler(request, context, continuation);
        }
        catch (NotFoundException exception)
        {
            var status = new Status(StatusCode.NotFound, exception.Message);
            throw new RpcException(status);
        }
        catch (Exception exception)
        {
            var response = new ResponseViewModel
            {
                Code = "99999",
                Message = "Server error"
            };

            return MapResponse<TRequest, TResponse>(response);
        }
    }

    private TResponse MapResponse<TRequest, TResponse>(ResponseViewModel response)
    {
        var concreteResponse = Activator.CreateInstance<TResponse>();
        concreteResponse?.GetType().GetProperty(nameof(response.Code))?.SetValue(concreteResponse, response.Code);
        concreteResponse?.GetType().GetProperty(nameof(response.Message))?.SetValue(concreteResponse, response.Message);
        return concreteResponse;
    }
}

public class ResponseViewModel
{
    public string Code { get; set; }
    public string Message { get; set; }
}