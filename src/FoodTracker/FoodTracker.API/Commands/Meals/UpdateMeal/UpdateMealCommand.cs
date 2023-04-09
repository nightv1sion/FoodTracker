using MediatR;
using src.FoodTracker.API.Commands.Meals.DTOs;

namespace src.FoodTracker.API.Commands.Meals.UpdateMeal;

public class UpdateMealCommand : IRequest<MealDTO>
{
    public UpdateMealCommand(UpdateMealDTO updateMealDTO)
    {
        UpdateMealDTO = updateMealDTO;
    }
    public UpdateMealDTO UpdateMealDTO { get; set; }
}
