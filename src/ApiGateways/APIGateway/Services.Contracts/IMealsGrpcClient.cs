using Grpc.Net.Client;

namespace src.ApiGateways.APIGateway.Services.Contracts;

public interface IMealsGrpcClient
{
    Task<IEnumerable<MealProto>> GetMealsAsync();
    Task<MealProto> GetMealAsync(Guid id);
    Task<MealProto> CreateMealAsync(CreateMealProto ingredient);
    Task<MealProto> UpdateMealAsync(UpdateMealProto ingredient);
    Task DeleteMealAsync(Guid id);

}