using MediatR;
using src.FoodTracker.API.Queries.Meals.DTOs;

namespace src.FoodTracker.API.Queries.Meals.GetMeals;

public class GetMealsQuery : IRequest<IEnumerable<MealDTO>>
{
    public GetMealsQuery() { }
}
