using MediatR;
using src.Ingredients.Ingredients.API.Entities;

namespace src.Ingredients.Ingredients.API.Queries.GetIngredient
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