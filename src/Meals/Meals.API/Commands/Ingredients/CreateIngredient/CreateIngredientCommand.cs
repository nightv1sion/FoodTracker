using MediatR;
using src.Meals.Meals.API.Commands.Ingredients.DTOs;

namespace src.Meals.Meals.API.Commands.Ingredients.CreateIngredient
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