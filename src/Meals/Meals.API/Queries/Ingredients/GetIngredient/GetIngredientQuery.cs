using MediatR;
using src.Meals.Meals.API.Entities;

namespace src.Meals.Meals.API.Queries.Ingredients.GetIngredient
{
    public class GetIngredientQuery : IRequest<Ingredient>
    {
        public GetIngredientQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}