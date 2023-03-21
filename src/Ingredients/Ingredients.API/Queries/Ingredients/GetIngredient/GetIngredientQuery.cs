using MediatR;

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