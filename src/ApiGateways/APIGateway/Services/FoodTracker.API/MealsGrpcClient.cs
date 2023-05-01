using System.Text.Json;
using AutoMapper;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using src.ApiGateways.APIGateway.DataTransferObjects.FoodTracker.API;
using src.ApiGateways.APIGateway.Interceptors;
using src.ApiGateways.APIGateway.Services.Contracts;
using src.ApiGateways.APIGateway.Services.Contracts.FoodTracker.API;

namespace src.ApiGateways.APIGateway.Services.FoodTracker.API;

public class MealsGrpcClient : IMealsGrpcClient
{
    private readonly Meals.MealsClient _client;
    private readonly IMapper _mapper;

    public MealsGrpcClient(
        IConfiguration configuration,
        IMapper mapper)
    {
        var channel = GrpcChannel.ForAddress(configuration["FoodTrackerAPI"]);
        _client = new Meals.MealsClient(channel.Intercept(new GrpcErrorHandlingInterceptor()));
        _mapper = mapper;
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
    public async Task<MealProto> CreateMealAsync(CreateMealDTO dto)
    {
        var meal = _mapper.Map<CreateMealProto>(dto);
        meal.IngredientsIds.AddRange(dto.IngredientsIds.Select(x => x.ToString()));
        var reply = await _client.CreateMealAsync(new CreateMealRequest()
        {
            Meal = meal
        });
        return reply.Meal;
    }
    public async Task<MealProto> UpdateMealAsync(UpdateMealDTO dto)
    {
        var meal = _mapper.Map<UpdateMealProto>(dto);
        meal.IngredientsIds.AddRange(dto.IngredientsIds.Select(x => x.ToString()));
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