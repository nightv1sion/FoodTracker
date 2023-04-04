using MediatR;
using src.Meals.Meals.API.Commands.Meals.DTOs;

namespace src.Meals.Meals.API.Commands.Meals.CreateMeal;

public class CreateMealCommand : IRequest<MealDTO>
{
    public CreateMealCommand(CreateMealDTO createMealDTO)
    {
        CreateMealDTO = createMealDTO;
    }
    public CreateMealDTO CreateMealDTO { get; set; }
}
