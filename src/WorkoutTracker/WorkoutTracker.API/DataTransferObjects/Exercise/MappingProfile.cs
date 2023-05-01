using AutoMapper;
namespace src.WorkoutTracker.API.DataTransferObjects.Exercise;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<src.WorkoutTracker.API.Entities.Exercise, ExerciseDTO>();
        CreateMap<CreateExerciseDTO, src.WorkoutTracker.API.Entities.Exercise>();
        CreateMap<UpdateExerciseDTO, src.WorkoutTracker.API.Entities.Exercise>();

        CreateMap<src.WorkoutTracker.API.DataTransferObjects.Exercise.ExerciseDTO, ExerciseProto>();
        CreateMap<CreateExerciseProto, src.WorkoutTracker.API.DataTransferObjects.Exercise.CreateExerciseDTO>();
        CreateMap<UpdateExerciseProto, src.WorkoutTracker.API.DataTransferObjects.Exercise.UpdateExerciseDTO>()
            .ForMember(proto => proto.Id, dto => dto.MapFrom(x => Guid.Parse(x.Id)));
    }
}