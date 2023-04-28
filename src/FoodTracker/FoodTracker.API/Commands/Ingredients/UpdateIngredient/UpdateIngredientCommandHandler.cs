using AutoMapper;
using MediatR;
using src.FoodTracker.API.Commands.Ingredients.DTOs;
using src.FoodTracker.API.Entities;
using src.FoodTracker.API.Exceptions;
using src.FoodTracker.API.Repository.Contracts;

namespace src.FoodTracker.API.Commands.Ingredients.UpdateIngredient
{
    public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand, IngredientDTO>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;
        public UpdateIngredientCommandHandler(
            IIngredientRepository ingredientRepository,
            IMealRepository mealRepository,
            IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mealRepository = mealRepository;
            _mapper = mapper;
        }
        public async Task<IngredientDTO> Handle(
            UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetIngredientAsync(request.UpdateIngredientDTO.Id, false);
            if (ingredient == null)
            {
                throw new IngredientNotFoundException(request.UpdateIngredientDTO.Id);
            }
            var updatedIngredient = _mapper.Map<UpdateIngredientDTO, Ingredient>(request.UpdateIngredientDTO, ingredient);
            _ingredientRepository.UpdateIngredient(updatedIngredient);
            await _ingredientRepository.SaveChangesAsync();
            var dto = _mapper.Map<IngredientDTO>(updatedIngredient);
            return dto;
        }
    }
}