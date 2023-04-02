using MediatR;
using src.Ingredients.Ingredients.API.Commands.DTOs;
using src.Ingredients.Ingredients.API.Entities;

namespace src.Ingredients.Ingredients.API.Commands.Ingredients.CreateIngredient
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