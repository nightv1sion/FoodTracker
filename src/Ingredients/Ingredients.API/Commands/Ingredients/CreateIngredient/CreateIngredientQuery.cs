using MediatR;
using src.Ingredients.Ingredients.API.Commands.DTOs;

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