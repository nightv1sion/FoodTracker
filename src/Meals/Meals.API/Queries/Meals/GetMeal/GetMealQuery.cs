using MediatR;
using src.Meals.Meals.API.Queries.Meals.DTOs;

namespace src.Meals.Meals.API.Queries.Meals.GetMeal;

public class GetMealQuery : IRequest<MealDTO>
{
    public GetMealQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}