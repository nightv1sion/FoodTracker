using MediatR;
using src.FoodTracker.API.Commands.Ingredients.DTOs;

namespace src.FoodTracker.API.Commands.Ingredients.UpdateIngredient
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
