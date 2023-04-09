using MediatR;
using src.FoodTracker.API.Commands.Meals.DTOs;

namespace src.FoodTracker.API.Commands.Meals.CreateMeal;

public class CreateMealCommand : IRequest<MealDTO>
{
    public CreateMealCommand(CreateMealDTO createMealDTO)
    {
        CreateMealDTO = createMealDTO;
    }
    public CreateMealDTO CreateMealDTO { get; set; }
}
