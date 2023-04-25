using System.Text;
using System.Text.Json;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using src.ApiGateways.APIGateway.Services.Contracts;

namespace src.ApiGateways.APIGateway.Controllers.FoodTracker.API;

[Route("foodtracker-api/[controller]")]
[ApiController]
public class MealsController : ControllerBase
{
    private readonly IMealsGrpcClient _mealGrpcClient;

    public MealsController(
        IMealsGrpcClient mealGrpcClient
        )
    {
        _mealGrpcClient = mealGrpcClient;
    }

    [HttpGet]
    public async Task<ActionResult> GetMeals()
    {
        var meals = await _mealGrpcClient.GetMealsAsync();
        return Ok(meals);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetMealById(Guid id)
    {
        var meal = await _mealGrpcClient.GetMealAsync(id);
        return Ok(meal);
    }
    [HttpPost]
    public async Task<ActionResult> CreateMeal(CreateMealProto mealProto)
    {
        var meal = await _mealGrpcClient.CreateMealAsync(mealProto);
        return Ok(meal);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateMeal(UpdateMealProto mealProto)
    {
        var meal = await _mealGrpcClient.UpdateMealAsync(mealProto);
        return Ok(meal);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteMeal(Guid id)
    {
        await _mealGrpcClient.DeleteMealAsync(id);
        return Ok();
    }
}