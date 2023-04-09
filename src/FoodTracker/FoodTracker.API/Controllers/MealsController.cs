using MediatR;
using Microsoft.AspNetCore.Mvc;
using src.FoodTracker.API.Commands.Meals.CreateMeal;
using src.FoodTracker.API.Commands.Meals.DeleteMeal;
using src.FoodTracker.API.Commands.Meals.DTOs;
using src.FoodTracker.API.Commands.Meals.UpdateMeal;
using src.FoodTracker.API.Entities;
using src.FoodTracker.API.Queries.Meals.GetMeal;
using src.FoodTracker.API.Queries.Meals.GetMeals;

namespace src.FoodTracker.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MealsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MealsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult> GetMeals()
    {
        var result = await _mediator.Send(new GetMealsQuery());
        return Ok(result);
    }
    [HttpGet("{id:guid}", Name = "GetMealById")]
    public async Task<ActionResult> GetMeal(Guid id)
    {
        var result = await _mediator.Send(new GetMealQuery(id));
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult> CreateMeal(CreateMealDTO createMealDTO)
    {
        var meal = await _mediator.Send(new CreateMealCommand(createMealDTO));
        return CreatedAtRoute("GetMealById", new { Id = meal.Id }, meal);
    }
    [HttpPut]
    public async Task<ActionResult> UpdateMeal(UpdateMealDTO updateMealDTO)
    {
        var meal = await _mediator.Send(new UpdateMealCommand(updateMealDTO));
        return Ok(meal);
    }
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteMeal(Guid id)
    {
        await _mediator.Send(new DeleteMealCommand(id));
        return Ok();
    }
}