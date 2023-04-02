using MediatR;
using src.Ingredients.Ingredients.API.Entities;
using src.Ingredients.Ingredients.API.Exceptions;
using src.Ingredients.Ingredients.API.Repository.Contracts;

namespace src.Ingredients.Ingredients.API.Queries.GetIngredient
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