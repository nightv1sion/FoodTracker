using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.GrpcServices;
using src.WorkoutTracker.API.Helper;
using src.WorkoutTracker.API.Middlewares;
using src.WorkoutTracker.API.Repository;
using src.WorkoutTracker.API.Repository.Contracts;
using src.WorkoutTracker.API.Service;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Extensions;
public static class WebApplicationExtensions
{
    public static void UseGlobalErrorHandling(this WebApplication app)
    {
        app.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
    public static void MapGrpcServices(this WebApplication app)
    {
        app.MapGrpcService<ExercisesGrpcService>();
        app.MapGrpcService<TrainingsGrpcService>();
        app.MapGrpcService<CompletedExercisesGrpcService>();
    }
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
}