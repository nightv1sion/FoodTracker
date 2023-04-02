using MediatR;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Repository.Contracts;


namespace src.Meals.Meals.API.Queries.Ingredients.GetIngredients
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