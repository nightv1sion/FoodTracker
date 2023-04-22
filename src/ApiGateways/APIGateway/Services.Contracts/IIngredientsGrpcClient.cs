using Grpc.Net.Client;

namespace src.ApiGateways.APIGateway.Services.Contracts;

public interface IIngredientsGrpcClient
{
    Task<IEnumerable<IngredientProto>> GetIngredientsAsync();
    Task<IngredientProto> GetIngredientAsync(Guid id);
}