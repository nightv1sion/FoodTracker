using MediatR;
using src.Meals.Meals.API.Commands.DTOs;
using src.Meals.Meals.API.Entities;

namespace src.Meals.Meals.API.Commands.Ingredients.UpdateIngredient
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
