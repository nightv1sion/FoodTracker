using MediatR;
using src.Meals.Meals.API.Entities;

namespace src.Meals.Meals.API.Queries.Ingredients.GetIngredients
{
    public class GetIngredientsQuery : IRequest<IEnumerable<Ingredient>>
    {

    }
}