using MediatR;
using src.Meals.Meals.API.Queries.Meals.DTOs;

namespace src.Meals.Meals.API.Queries.Meals.GetMeals;

public class GetMealsQuery : IRequest<IEnumerable<MealDTO>>
{
    public GetMealsQuery() { }
}
