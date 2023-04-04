using AutoMapper;
using src.Meals.Meals.API.Commands.Meals.DTOs;
using src.Meals.Meals.API.Entities;

namespace src.Meals.Meals.API.Commands.Meals;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateMealDTO, Meal>();
        CreateMap<UpdateMealDTO, Meal>();
        CreateMap<Meal, MealDTO>().ForMember(
            dto => dto.IngredientsIds, entity => entity.MapFrom(x => x.Ingredients.Select(x => x.Id)));
    }
}
