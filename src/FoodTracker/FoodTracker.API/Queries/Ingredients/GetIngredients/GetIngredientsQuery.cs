using MediatR;
using src.FoodTracker.API.Queries.Ingredients.DTOs;

namespace src.FoodTracker.API.Queries.Ingredients.GetIngredients
{
    public class GetIngredientsQuery : IRequest<IEnumerable<IngredientDTO>>
    {

    }
}