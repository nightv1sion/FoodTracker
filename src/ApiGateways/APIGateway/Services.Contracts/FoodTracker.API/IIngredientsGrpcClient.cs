using Grpc.Net.Client;

namespace src.ApiGateways.APIGateway.Services.Contracts.FoodTracker.API;

public interface IIngredientsGrpcClient
{
    Task<IEnumerable<IngredientProto>> GetIngredientsAsync();
    Task<IngredientProto> GetIngredientAsync(Guid id);
    Task<IngredientProto> CreateIngredientAsync(CreateIngredientProto ingredient);
    Task<IngredientProto> UpdateIngredientAsync(UpdateIngredientProto ingredient);
    Task DeleteIngredientAsync(Guid id);

}