using MediatR;
using Microsoft.AspNetCore.Mvc;
using src.Meals.Meals.API.Commands.Ingredients.CreateIngredient;
using src.Meals.Meals.API.Commands.Ingredients.DeleteIngredient;
using src.Meals.Meals.API.Commands.Ingredients.DTOs;
using src.Meals.Meals.API.Commands.Ingredients.UpdateIngredient;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Queries.Ingredients.GetIngredient;
using src.Meals.Meals.API.Queries.Ingredients.GetIngredients;

namespace src.Meals.Meals.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
            var ingredients = await _mediator.Send(new GetIngredientsQuery());
            return Ok(ingredients);
        }
        [HttpGet("{id:guid}", Name = "GetIngredientById")]
        public async Task<ActionResult<Ingredient>> GetIngredient(Guid id)
        {
            var ingredient = await _mediator.Send(new GetIngredientQuery(id));
            if (ingredient == null)
            {
                return NotFound("Ingredient is not found");
            }
            return Ok(ingredient);
        }
        [HttpPost]
        public async Task<ActionResult<Ingredient>> CreateIngredient(CreateIngredientDTO dto)
        {
            var ingredient = await _mediator.Send(new CreateIngredientCommand(dto));
            return CreatedAtRoute("GetIngredientById", new { Id = ingredient.Id }, ingredient);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateIngredient(UpdateIngredientDTO dto)
        {
            var ingredient = await _mediator.Send(new UpdateIngredientCommand(dto));
            if (ingredient == null)
                return NotFound("Ingredient is not found");
            return Ok(ingredient);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteIngredient(Guid id)
        {
            await _mediator.Send(new DeleteIngredientCommand(id));
            return Ok();
        }
    }
}