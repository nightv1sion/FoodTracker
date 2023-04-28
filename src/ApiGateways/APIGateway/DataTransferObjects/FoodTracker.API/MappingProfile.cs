using AutoMapper;

namespace src.ApiGateways.APIGateway.DataTransferObjects.FoodTracker.API;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateMealDTO, CreateMealProto>().ForMember(x => x.IngredientsIds, x => x.Ignore());
        CreateMap<UpdateMealDTO, UpdateMealProto>().ForMember(x => x.IngredientsIds, x => x.Ignore());
    }
}