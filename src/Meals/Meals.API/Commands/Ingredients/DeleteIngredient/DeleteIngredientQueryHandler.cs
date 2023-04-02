using MediatR;
using src.Meals.Meals.API.Exceptions;
using src.Meals.Meals.API.Repository.Contracts;

namespace src.Meals.Meals.API.Commands.Ingredients.DeleteIngredient
{
    public class DeleteIngredientQueryHandler : IRequestHandler<DeleteIngredientQuery>
    {
        private readonly IIngredientRepository _ingredientRepository;

        public DeleteIngredientQueryHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public async Task Handle(
            DeleteIngredientQuery request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientAsync(request.Id, false);

            if (ingredient == null)
            {
                throw new IngredientNotFoundException(request.Id);
            }
            _ingredientRepository.DeleteIngredient(ingredient);
            await _ingredientRepository.SaveChangesAsync();
        }
    }

}