using MediatR;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Exceptions;
using src.Meals.Meals.API.Repository.Contracts;

namespace src.Meals.Meals.API.Queries.Ingredients.GetIngredient
{
    public class GetIngredientQueryHandler : IRequestHandler<GetIngredientQuery, Ingredient>
    {
        private readonly IIngredientRepository _ingredientRepository;

        public GetIngredientQueryHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public async Task<Ingredient> Handle(
            GetIngredientQuery request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientAsync(request.Id, false);
            if (ingredient == null)
            {
                throw new IngredientNotFoundException(request.Id);
            }
            return ingredient;
        }
    }


}