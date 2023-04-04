using AutoMapper;
using src.Meals.Meals.API.Entities;
using src.Meals.Meals.API.Queries.Ingredients.DTOs;

namespace src.Meals.Meals.API.Queries.Ingredients;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Ingredient, IngredientDTO>();
    }
}