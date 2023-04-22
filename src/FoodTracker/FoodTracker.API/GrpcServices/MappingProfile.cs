using AutoMapper;
using src.FoodTracker.API.Commands.Ingredients.DTOs;
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
    }
}