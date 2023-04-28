using Grpc.Net.Client;
using src.ApiGateways.APIGateway.DataTransferObjects.FoodTracker.API;

namespace src.ApiGateways.APIGateway.Services.Contracts;

public interface IMealsGrpcClient
{
    Task<IEnumerable<MealProto>> GetMealsAsync();
    Task<MealProto> GetMealAsync(Guid id);
    Task<MealProto> CreateMealAsync(CreateMealDTO ingredient);
    Task<MealProto> UpdateMealAsync(UpdateMealDTO ingredient);
    Task DeleteMealAsync(Guid id);

}