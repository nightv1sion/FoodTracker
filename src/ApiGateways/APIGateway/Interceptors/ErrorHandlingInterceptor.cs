using System.Text.Json;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace src.ApiGateways.APIGateway.Interceptors;

public class GrpcErrorHandlingInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>
        (TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await base.UnaryServerHandler(request, context, continuation);
        }
        catch (RpcException exception)
        {
            throw;
        }
    }
}