using AutoMapper;
using src.FoodTracker.API.Commands.Ingredients.DTOs;
using src.FoodTracker.API.Entities;

namespace src.FoodTracker.API.Commands.Ingredients
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateIngredientDTO, Ingredient>();
            CreateMap<UpdateIngredientDTO, Ingredient>();
            CreateMap<Ingredient, IngredientDTO>();
        }
    }
}
