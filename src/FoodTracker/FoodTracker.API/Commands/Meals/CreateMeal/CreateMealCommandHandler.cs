using AutoMapper;
using MediatR;
using src.FoodTracker.API.Commands.Meals.DTOs;
using src.FoodTracker.API.Entities;
using src.FoodTracker.API.Exceptions;
using src.FoodTracker.API.Repository.Contracts;

namespace src.FoodTracker.API.Commands.Meals.CreateMeal;

public class CreateMealCommandHandler : IRequestHandler<CreateMealCommand, MealDTO>
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMealRepository _mealRepository;
    private readonly IMapper _mapper;

    public CreateMealCommandHandler(
        IMealRepository mealRepository,
        IIngredientRepository ingredientRepository,
        IMapper mapper)
    {
        _ingredientRepository = ingredientRepository;
        _mealRepository = mealRepository;
        _mapper = mapper;
    }
    public async Task<MealDTO> Handle(
        CreateMealCommand request, CancellationToken cancellationToken)
    {
        var meal = _mapper.Map<Meal>(request.CreateMealDTO);
        if (request.CreateMealDTO.IngredientsIds != null)
        {
            meal.Ingredients = new List<Ingredient>();
            foreach (var ingredientId in request.CreateMealDTO.IngredientsIds)
            {
                var ingredient = await _ingredientRepository.GetIngredientAsync(ingredientId, true);
                if (ingredient == null)
                {
                    throw new IngredientNotFoundException(ingredientId);
                }
                meal.Ingredients.Add(ingredient);
            }
        }
        _mealRepository.CreateMeal(meal);
        await _mealRepository.SaveChangesAsync();
        var dto = _mapper.Map<MealDTO>(meal);
        return dto;
    }
}