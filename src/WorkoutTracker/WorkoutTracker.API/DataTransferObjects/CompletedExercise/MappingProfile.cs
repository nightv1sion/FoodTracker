using AutoMapper;
namespace src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<src.WorkoutTracker.API.Entities.CompletedExercise, CompletedExerciseDTO>();
        CreateMap<CreateCompletedExerciseDTO, src.WorkoutTracker.API.Entities.CompletedExercise>();
        CreateMap<UpdateCompletedExerciseDTO, src.WorkoutTracker.API.Entities.CompletedExercise>();

        CreateMap<src.WorkoutTracker.API.Entities.CompletedExercise, CompletedExerciseProto>();
        CreateMap<CreateCompletedExerciseProto,
            src.WorkoutTracker.API.DataTransferObjects.CompletedExercise.CreateCompletedExerciseDTO>();
        CreateMap<UpdateCompletedExerciseProto,
            src.WorkoutTracker.API.DataTransferObjects.CompletedExercise.UpdateCompletedExerciseDTO>()
            .ForMember(proto => proto.Id, dto => dto.MapFrom(x => Guid.Parse(x.Id)));
    }
}