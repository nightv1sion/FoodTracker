using System.Text;
using System.Text.Json;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using src.ApiGateways.APIGateway.DataTransferObjects.FoodTracker.API;
using src.ApiGateways.APIGateway.Services.Contracts.FoodTracker.API;

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
    public async Task<ActionResult> CreateMeal(CreateMealDTO dto)
    {
        var meal = await _mealGrpcClient.CreateMealAsync(dto);
        return Ok(meal);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateMeal(UpdateMealDTO dto)
    {
        var meal = await _mealGrpcClient.UpdateMealAsync(dto);
        return Ok(meal);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteMeal(Guid id)
    {
        await _mealGrpcClient.DeleteMealAsync(id);
        return Ok();
    }
}