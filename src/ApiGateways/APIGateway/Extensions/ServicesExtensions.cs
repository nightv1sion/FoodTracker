using src.ApiGateways.APIGateway.Services;
using src.ApiGateways.APIGateway.Services.Contracts;
using src.ApiGateways.APIGateway.Services.Contracts.FoodTracker.API;
using src.ApiGateways.APIGateway.Services.Contracts.WorkoutTracker.API;
using src.ApiGateways.APIGateway.Services.FoodTracker.API;
using src.ApiGateways.APIGateway.Services.WorkoutTracker.API;

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
    public static void ConfigureGrpcClients(this IServiceCollection services)
    {
        services.AddScoped<IIngredientsGrpcClient, IngredientsGrpcClient>();
        services.AddScoped<IMealsGrpcClient, MealsGrpcClient>();
        services.AddScoped<IExercisesGrpcClient, ExercisesGrpcClient>();
        services.AddScoped<ITrainingsGrpcClient, TrainingsGrpcClient>();
        services.AddScoped<ICompletedExercisesGrpcClient, CompletedExercisesGrpcClient>();
    }
}
