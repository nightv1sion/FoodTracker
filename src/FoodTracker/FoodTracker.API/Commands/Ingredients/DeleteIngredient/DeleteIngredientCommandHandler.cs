using MediatR;
using src.FoodTracker.API.Exceptions;
using src.FoodTracker.API.Repository.Contracts;

namespace src.FoodTracker.API.Commands.Ingredients.DeleteIngredient
{
    public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand>
    {
        private readonly IIngredientRepository _ingredientRepository;

        public DeleteIngredientCommandHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
        public async Task Handle(
            DeleteIngredientCommand request, CancellationToken cancellationToken)
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