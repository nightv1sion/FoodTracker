using AutoMapper;
using src.FoodTracker.API.Entities;
using src.FoodTracker.API.Queries.Ingredients.DTOs;

namespace src.FoodTracker.API.Queries.Ingredients;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Ingredient, IngredientDTO>();
    }
}