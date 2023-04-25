using System.Text.Json;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using src.ApiGateways.APIGateway.Interceptors;
using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Services;

public class MealsGrpcClient : IMealsGrpcClient
{
    private readonly Meals.MealsClient _client;
    public MealsGrpcClient(IConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration["FoodTrackerAPI"]);
        _client = new Meals.MealsClient(channel.Intercept(new GrpcErrorHandlingInterceptor()));
    }

    public async Task<IEnumerable<MealProto>> GetMealsAsync()
    {
        var reply = await _client.GetMealsAsync(new GetMealsRequest());
        return reply.Meals;
    }
    public async Task<MealProto> GetMealAsync(Guid id)
    {
        var reply = await _client.GetMealAsync(new GetMealRequest()
        {
            Id = id.ToString()
        });
        return reply.Meal;
    }
    public async Task<MealProto> CreateMealAsync(CreateMealProto meal)
    {
        Console.WriteLine(JsonSerializer.Serialize(meal));
        var reply = await _client.CreateMealAsync(new CreateMealRequest()
        {
            Meal = meal
        });
        return reply.Meal;
    }
    public async Task<MealProto> UpdateMealAsync(UpdateMealProto meal)
    {
        var reply = await _client.UpdateMealAsync(new UpdateMealRequest()
        {
            Meal = meal
        });
        return reply.Meal;
    }
    public async Task DeleteMealAsync(Guid id)
    {
        await _client.DeleteMealAsync(new DeleteMealRequest()
        {
            Id = id.ToString()
        });
    }
}