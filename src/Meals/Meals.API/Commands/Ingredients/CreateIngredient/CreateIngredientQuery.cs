using MediatR;
using src.Meals.Meals.API.Commands.DTOs;
using src.Meals.Meals.API.Entities;

namespace src.Meals.Meals.API.Commands.Ingredients.CreateIngredient
{
    public class CreateIngredientQuery : IRequest<Ingredient>
    {
        public CreateIngredientQuery(CreateIngredientDTO createIngredientDTO)
        {
            CreateIngredientDTO = createIngredientDTO;
        }

        public CreateIngredientDTO CreateIngredientDTO { get; set; }
    }
}