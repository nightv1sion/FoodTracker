using MediatR;
using src.Ingredients.Ingredients.API.Commands.DTOs;
using src.Ingredients.Ingredients.API.Entities;

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
