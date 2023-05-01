using Grpc.Net.Client;
using src.ApiGateways.APIGateway.DataTransferObjects.FoodTracker.API;

namespace src.ApiGateways.APIGateway.Services.Contracts.FoodTracker.API;

public interface IMealsGrpcClient
{
    Task<IEnumerable<MealProto>> GetMealsAsync();
    Task<MealProto> GetMealAsync(Guid id);
    Task<MealProto> CreateMealAsync(CreateMealDTO meal);
    Task<MealProto> UpdateMealAsync(UpdateMealDTO meal);
    Task DeleteMealAsync(Guid id);

}