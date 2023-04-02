using MediatR;
using src.Ingredients.Ingredients.API.Entities;

namespace src.Ingredients.Ingredients.API.Queries.GetIngredients
{
    public class GetIngredientsQuery : IRequest<IEnumerable<Ingredient>>
    {

    }
}