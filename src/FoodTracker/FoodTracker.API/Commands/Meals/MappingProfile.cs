using AutoMapper;
using src.FoodTracker.API.Commands.Meals.DTOs;
using src.FoodTracker.API.Entities;

namespace src.FoodTracker.API.Commands.Meals;

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
