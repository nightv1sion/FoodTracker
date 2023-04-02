using AutoMapper;
using src.Ingredients.Ingredients.API.Commands.DTOs;
using src.Ingredients.Ingredients.API.Entities;

namespace src.Ingredients.Ingredients.API.Commands.Ingredients
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateIngredientDTO, Ingredient>();
            CreateMap<UpdateIngredientDTO, Ingredient>();
        }
    }
}
