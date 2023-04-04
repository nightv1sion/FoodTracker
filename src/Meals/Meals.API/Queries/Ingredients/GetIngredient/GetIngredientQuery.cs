using MediatR;
using src.Meals.Meals.API.Queries.Ingredients.DTOs;

namespace src.Meals.Meals.API.Queries.Ingredients.GetIngredient
{
    public class GetIngredientQuery : IRequest<IngredientDTO>
    {
        public GetIngredientQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}