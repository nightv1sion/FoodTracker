using MediatR;

namespace src.Ingredients.Ingredients.API.Queries.GetIngredients
{
    public class GetIngredientsQuery : IRequest<IEnumerable<Ingredient>>
    {

    }
}