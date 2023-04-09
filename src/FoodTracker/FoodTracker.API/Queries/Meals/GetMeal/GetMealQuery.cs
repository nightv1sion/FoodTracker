using MediatR;
using src.FoodTracker.API.Queries.Meals.DTOs;

namespace src.FoodTracker.API.Queries.Meals.GetMeal;

public class GetMealQuery : IRequest<MealDTO>
{
    public GetMealQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}