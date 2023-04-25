using AutoMapper;
using src.FoodTracker.API.Commands.Ingredients.DTOs;
using src.FoodTracker.API.Commands.Meals.DTOs;
using src.FoodTracker.API.Queries.Ingredients.DTOs;

namespace src.FoodTracker.API.GrpcServices;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<src.FoodTracker.API.Queries.Ingredients.DTOs.IngredientDTO, IngredientProto>()
            .ForMember(x => x.MealsIds, options => options.Ignore());
        CreateMap<src.FoodTracker.API.Commands.Ingredients.DTOs.IngredientDTO, IngredientProto>()
            .ForMember(x => x.MealsIds, options => options.Ignore());
        CreateMap<CreateIngredientProto, CreateIngredientDTO>();
        CreateMap<UpdateIngredientProto, UpdateIngredientDTO>();

        CreateMap<src.FoodTracker.API.Queries.Meals.DTOs.MealDTO, MealProto>()
            .ForMember(x => x.IngredientsIds, options => options.Ignore());
        CreateMap<src.FoodTracker.API.Commands.Meals.DTOs.MealDTO, MealProto>()
            .ForMember(x => x.IngredientsIds, options => options.Ignore());
        CreateMap<CreateMealProto, CreateMealDTO>();
        CreateMap<UpdateMealProto, UpdateMealDTO>();
    }
}