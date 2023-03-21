using MediatR;
using src.Ingredients.Ingredients.API.Commands.DTOs;

namespace src.Ingredients.Ingredients.API.Commands.Ingredients.UpdateIngredient
{
    public class UpdateIngredientQuery : IRequest<Ingredient>
    {
        public UpdateIngredientQuery(UpdateIngredientDTO updateIngredientDTO)
        {
            UpdateIngredientDTO = updateIngredientDTO;
        }
        public UpdateIngredientDTO UpdateIngredientDTO { get; set; }
    }
}
