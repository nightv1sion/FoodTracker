using MediatR;
using src.FoodTracker.API.Queries.Ingredients.DTOs;

namespace src.FoodTracker.API.Queries.Ingredients.GetIngredient
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