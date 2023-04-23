using System.Text.Json;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using src.ApiGateways.APIGateway.Interceptors;
using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Services;

public class IngredientsGrpcClient : IIngredientsGrpcClient
{
    private readonly Ingredients.IngredientsClient _client;
    public IngredientsGrpcClient(IConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration["FoodTrackerAPI:Ingredients"]);
        _client = new Ingredients.IngredientsClient(channel.Intercept(new GrpcErrorHandlingInterceptor()));
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
    public async Task<IngredientProto> CreateIngredientAsync(CreateIngredientProto ingredient)
    {
        var reply = await _client.CreateIngredientAsync(new CreateIngredientRequest()
        {
            Ingredient = ingredient
        });
        return reply.Ingredient;
    }
    public async Task<IngredientProto> UpdateIngredientAsync(UpdateIngredientProto ingredient)
    {
        var reply = await _client.UpdateIngredientAsync(new UpdateIngredientRequest()
        {
            Ingredient = ingredient
        });
        return reply.Ingredient;
    }
    public async Task DeleteIngredientAsync(Guid id)
    {
        await _client.DeleteIngredientAsync(new DeleteIngredientRequest()
        {
            Id = id.ToString()
        });
    }
}