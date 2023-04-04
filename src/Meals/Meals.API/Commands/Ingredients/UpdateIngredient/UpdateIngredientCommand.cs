using MediatR;
using src.Meals.Meals.API.Commands.Ingredients.DTOs;

namespace src.Meals.Meals.API.Commands.Ingredients.UpdateIngredient
{
    public class UpdateIngredientCommand : IRequest<IngredientDTO>
    {
        public UpdateIngredientCommand(UpdateIngredientDTO updateIngredientDTO)
        {
            UpdateIngredientDTO = updateIngredientDTO;
        }
        public UpdateIngredientDTO UpdateIngredientDTO { get; set; }
    }
}
