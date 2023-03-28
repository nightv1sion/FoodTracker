using src.ApiGateways.APIGateway.Services;
using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureHttpRequestReader(this IServiceCollection services)
    {
        services.AddScoped<IHttpRequestReader, HttpRequestReader>();
    }

    public static void ConfigureStringContentCreator(this IServiceCollection services)
    {
        services.AddScoped<IStringContentCreator, StringContentCreator>();
    }
    public static void ConfigureProxyClient(this IServiceCollection services)
    {
        services.AddScoped<IProxyClient, ProxyClient>();
    }
}
