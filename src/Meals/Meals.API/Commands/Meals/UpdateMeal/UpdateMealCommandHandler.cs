using AutoMapper;
using MediatR;
using src.Meals.Meals.API.Commands.Meals.DTOs;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Exceptions;
using src.Meals.Meals.API.Repository.Contracts;

namespace src.Meals.Meals.API.Commands.Meals.UpdateMeal;

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
        var meal = _mealRepository.GetMealAsync(request.UpdateMealDTO.Id, true);
        if (meal == null)
        {
            throw new MealNotFoundException(request.UpdateMealDTO.Id);
        }

        var updatedMeal = _mapper.Map<Meal>(request.UpdateMealDTO);
        if (request.UpdateMealDTO.IngredientsIds != null)
        {
            updatedMeal.Ingredients = new List<Ingredient>();
            foreach (var ingredientId in request.UpdateMealDTO.IngredientsIds)
            {
                var ingredient = await _ingredientRepository.GetIngredientAsync(ingredientId, false);
                if (ingredient == null)
                {
                    throw new IngredientNotFoundException(ingredientId);
                }
                updatedMeal.Ingredients.Add(ingredient);
            }
        }

        _mealRepository.UpdateMeal(updatedMeal);
        await _mealRepository.SaveChangesAsync();
        var dto = _mapper.Map<MealDTO>(updatedMeal);
        return dto;
    }
}
