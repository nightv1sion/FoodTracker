using MediatR;
using src.FoodTracker.API.Commands.Ingredients.DTOs;

namespace src.FoodTracker.API.Commands.Ingredients.CreateIngredient
{
    public class CreateIngredientCommand : IRequest<IngredientDTO>
    {
        public CreateIngredientCommand(CreateIngredientDTO createIngredientDTO)
        {
            CreateIngredientDTO = createIngredientDTO;
        }

        public CreateIngredientDTO CreateIngredientDTO { get; set; }
    }
}