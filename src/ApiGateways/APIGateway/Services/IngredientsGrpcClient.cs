using Grpc.Net.Client;
using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Services;

public class IngredientsGrpcClient : IIngredientsGrpcClient
{
    private readonly Ingredients.IngredientsClient _client;
    public IngredientsGrpcClient(IConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration["FoodTrackerAPI:Ingredients"]);
        _client = new Ingredients.IngredientsClient(channel);
    }

    public async Task<IEnumerable<IngredientProto>> GetIngredientsAsync()
    {
        var reply = await _client.GetIngredientsAsync(new GetIngredientsRequest());
        return reply.Ingredients;
    }
    public async Task<IngredientProto> GetIngredientAsync(Guid id)
    {
        var reply = await _client.GetIngredientAsync(new GetIngredientRequest()
        {
            Id = id.ToString()
        });
        return reply.Ingredient;
    }
}