using System.Text;
using System.Text.Json;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using src.ApiGateways.APIGateway.Services.Contracts.FoodTracker.API;

namespace src.ApiGateways.APIGateway.Controllers.FoodTracker.API;

[Route("foodtracker-api/[controller]")]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientsGrpcClient _ingredientGrpcClient;

    public IngredientsController(
        IIngredientsGrpcClient ingredientGrpcClient
        )
    {
        _ingredientGrpcClient = ingredientGrpcClient;
    }

    [HttpGet]
    public async Task<ActionResult> GetIngredients()
    {
        var ingredients = await _ingredientGrpcClient.GetIngredientsAsync();
        return Ok(ingredients);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetIngredientById(Guid id)
    {
        var ingredient = await _ingredientGrpcClient.GetIngredientAsync(id);
        return Ok(ingredient);
    }
    [HttpPost]
    public async Task<ActionResult> CreateIngredient(CreateIngredientProto ingredientProto)
    {
        var ingredient = await _ingredientGrpcClient.CreateIngredientAsync(ingredientProto);
        return Ok(ingredient);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateIngredient(UpdateIngredientProto ingredientProto)
    {
        var ingredient = await _ingredientGrpcClient.UpdateIngredientAsync(ingredientProto);
        return Ok(ingredient);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteIngredient(Guid id)
    {
        await _ingredientGrpcClient.DeleteIngredientAsync(id);
        return Ok();
    }
}