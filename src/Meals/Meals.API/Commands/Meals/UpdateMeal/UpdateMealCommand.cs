using MediatR;
using src.Meals.Meals.API.Commands.Meals.DTOs;

namespace src.Meals.Meals.API.Commands.Meals.UpdateMeal;

public class UpdateMealCommand : IRequest<MealDTO>
{
    public UpdateMealCommand(UpdateMealDTO updateMealDTO)
    {
        UpdateMealDTO = updateMealDTO;
    }
    public UpdateMealDTO UpdateMealDTO { get; set; }
}
