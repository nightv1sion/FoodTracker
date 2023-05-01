using AutoMapper;

namespace src.ApiGateways.APIGateway.DataTransferObjects.WorkoutTracker.API;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCompletedExerciseDTO, CreateCompletedExerciseProto>()
            .ForMember(dto => dto.RepetitionCount, proto => proto.Ignore());
        CreateMap<UpdateCompletedExerciseDTO, UpdateCompletedExerciseProto>()
            .ForMember(dto => dto.RepetitionCount, proto => proto.Ignore());
    }
}