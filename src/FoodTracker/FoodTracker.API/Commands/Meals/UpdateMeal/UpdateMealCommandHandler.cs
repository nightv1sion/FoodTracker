using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using src.FoodTracker.API.Commands.Meals.DTOs;
using src.FoodTracker.API.Entities;
using src.FoodTracker.API.Exceptions;
using src.FoodTracker.API.Repository.Contracts;

namespace src.FoodTracker.API.Commands.Meals.UpdateMeal;

public class UpdateMealCommandHandler : IRequestHandler<UpdateMealCommand, MealDTO>
{
    private readonly IIngredientRepository _ingredientRepository;
    private readonly IMealRepository _mealRepository;
    private readonly IMapper _mapper;

    public UpdateMealCommandHandler(
        IMealRepository mealRepository,
        IIngredientRepository ingredientRepository,
        IMapper mapper)
    {
        _ingredientRepository = ingredientRepository;
        _mealRepository = mealRepository;
        _mapper = mapper;
    }
    public async Task<MealDTO> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
    {
        var meal = await _mealRepository.GetMeals(true)
            .Include(x => x.Ingredients)
            .FirstOrDefaultAsync(x => x.Id == request.UpdateMealDTO.Id);
        if (meal == null)
        {
            throw new MealNotFoundException(request.UpdateMealDTO.Id);
        }

        meal = _mapper.Map<UpdateMealDTO, Meal>(request.UpdateMealDTO, meal);

        if (request.UpdateMealDTO.IngredientsIds != null)
        {
            meal.Ingredients.Clear();
            await _mealRepository.SaveChangesAsync();
            foreach (var ingredientId in request.UpdateMealDTO.IngredientsIds)
            {
                var ingredient = await _ingredientRepository.GetIngredientAsync(ingredientId, false);
                if (ingredient == null)
                {
                    throw new IngredientNotFoundException(ingredientId);
                }
                meal.Ingredients.Add(ingredient);
            }
        }

        _mealRepository.UpdateMeal(meal);
        await _mealRepository.SaveChangesAsync();
        var dto = _mapper.Map<MealDTO>(meal);
        return dto;
    }
}
