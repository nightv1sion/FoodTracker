using MediatR;
using src.Meals.Meals.API.Queries.Ingredients.DTOs;

namespace src.Meals.Meals.API.Queries.Ingredients.GetIngredients
{
    public class GetIngredientsQuery : IRequest<IEnumerable<IngredientDTO>>
    {

    }
}