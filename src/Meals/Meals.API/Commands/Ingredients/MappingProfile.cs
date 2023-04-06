using AutoMapper;
using src.Meals.Meals.API.Commands.Ingredients.DTOs;
using src.Meals.Meals.API.Entities;

namespace src.Meals.Meals.API.Commands.Ingredients
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateIngredientDTO, Ingredient>();
            CreateMap<UpdateIngredientDTO, Ingredient>();
            CreateMap<Ingredient, IngredientDTO>()
                .ForMember(dto => dto.MealsIds, entity => entity.MapFrom(x => x.Meals.Select(meal => meal.Id)));
        }
    }
}
