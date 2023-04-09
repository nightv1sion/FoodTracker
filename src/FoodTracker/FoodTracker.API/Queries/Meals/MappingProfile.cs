using AutoMapper;
using src.FoodTracker.API.Entities;
using src.FoodTracker.API.Queries.Meals.DTOs;

namespace src.FoodTracker.API.Queries.Meals;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Meal, MealDTO>().ForMember(
            x => x.IngredientsIds, x => x.MapFrom(x => x.Ingredients.Select(x => x.Id)));
    }
}