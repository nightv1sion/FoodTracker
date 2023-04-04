using AutoMapper;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Queries.Meals.DTOs;

namespace src.Meals.Meals.API.Queries.Meals;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Meal, MealDTO>().ForMember(
            x => x.IngredientsIds, x => x.MapFrom(x => x.Ingredients.Select(x => x.Id)));
    }
}