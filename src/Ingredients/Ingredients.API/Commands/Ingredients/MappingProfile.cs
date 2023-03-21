using AutoMapper;
using src.Ingredients.Ingredients.API.Commands.DTOs;

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
