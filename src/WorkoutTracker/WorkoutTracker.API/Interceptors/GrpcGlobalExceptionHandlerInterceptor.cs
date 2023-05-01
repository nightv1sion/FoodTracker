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
            Console.WriteLine(exception.Message);
            Console.WriteLine(exception.StackTrace);
            var status = new Status(StatusCode.Internal, "Something went wrong");
            throw new RpcException(status);
        }
    }
}

public class ResponseViewModel
{
    public string Code { get; set; }
    public string Message { get; set; }
}