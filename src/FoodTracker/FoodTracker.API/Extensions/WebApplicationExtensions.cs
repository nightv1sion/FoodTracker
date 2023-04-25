using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using src.FoodTracker.API.GrpcServices;

namespace src.FoodTracker.API.Extensions;
public static class WebApplicationExtensions
{
    public static void ConfigureHttp1AndHttp2(this WebApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.Listen(IPAddress.Any, int.Parse(configuration["Kestrel:Http1ListeningPort"]), listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1;
            });

            options.Listen(IPAddress.Any, int.Parse(configuration["Kestrel:Http2ListeningPort"]), listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http2;
            });
        });
    }
    public static void MapGrpcServices(this WebApplication app)
    {
        app.MapGrpcService<IngredientsGrpcService>();
        app.MapGrpcService<MealsGrpcService>();
    }
}