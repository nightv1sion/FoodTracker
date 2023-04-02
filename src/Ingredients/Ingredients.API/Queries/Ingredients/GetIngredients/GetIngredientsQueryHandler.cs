using MediatR;
using src.Ingredients.Ingredients.API.Entities;
using src.Ingredients.Ingredients.API.Repository.Contracts;


namespace src.Ingredients.Ingredients.API.Queries.GetIngredients
{
    public class GetIngredientsQueryHandler : IRequestHandler<GetIngredientsQuery, IEnumerable<Ingredient>>
    {
        private readonly IIngredientRepository _ingredientRepository;
        public GetIngredientsQueryHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public async Task<IEnumerable<Ingredient>> Handle(
            GetIngredientsQuery request, CancellationToken cancellationToken)
            => await _ingredientRepository.GetIngredientsAsync(true);
    }
}