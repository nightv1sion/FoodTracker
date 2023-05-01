using AutoMapper;
namespace src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<src.WorkoutTracker.API.Entities.CompletedExercise, CompletedExerciseDTO>()
            .ForMember(entity => entity.RepetitionCount, dto => dto.MapFrom(
                x => x.RepetitionCount.Split(";", StringSplitOptions.None).Select(str => int.Parse(str))));
        CreateMap<CreateCompletedExerciseDTO, src.WorkoutTracker.API.Entities.CompletedExercise>()
            .ForMember(entity => entity.RepetitionCount, dto => dto.Ignore())
            .ForMember(entity => entity.RepetitionCountArray, dto => dto.MapFrom(x => x.RepetitionCount));
        CreateMap<UpdateCompletedExerciseDTO, src.WorkoutTracker.API.Entities.CompletedExercise>()
            .ForMember(entity => entity.RepetitionCount, dto => dto.Ignore())
            .ForMember(entity => entity.RepetitionCountArray, dto => dto.MapFrom(x => x.RepetitionCount));

        CreateMap<src.WorkoutTracker.API.DataTransferObjects.CompletedExercise.CompletedExerciseDTO,
            CompletedExerciseProto>();
        CreateMap<CreateCompletedExerciseProto,
            src.WorkoutTracker.API.DataTransferObjects.CompletedExercise.CreateCompletedExerciseDTO>();
        CreateMap<UpdateCompletedExerciseProto,
            src.WorkoutTracker.API.DataTransferObjects.CompletedExercise.UpdateCompletedExerciseDTO>()
            .ForMember(proto => proto.Id, dto => dto.MapFrom(x => Guid.Parse(x.Id)));
    }
}