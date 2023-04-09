using AutoMapper;
using MediatR;
using src.FoodTracker.API.Commands.Ingredients.DTOs;
using src.FoodTracker.API.Entities;
using src.FoodTracker.API.Exceptions;
using src.FoodTracker.API.Repository.Contracts;

namespace src.FoodTracker.API.Commands.Ingredients.CreateIngredient
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, IngredientDTO>
    {
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMealRepository _mealRepository;

        public CreateIngredientCommandHandler(
            IMapper mapper,
            IIngredientRepository ingredientRepository,
            IMealRepository mealRepository)
        {
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
            _mealRepository = mealRepository;
        }
        public async Task<IngredientDTO> Handle(
            CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = _mapper.Map<Ingredient>(request.CreateIngredientDTO);
            ingredient.Meals = new List<Meal>();
            _ingredientRepository.CreateIngredient(ingredient);
            await _ingredientRepository.SaveChangesAsync();
            var dto = _mapper.Map<IngredientDTO>(ingredient);
            return dto;
        }
    }
}