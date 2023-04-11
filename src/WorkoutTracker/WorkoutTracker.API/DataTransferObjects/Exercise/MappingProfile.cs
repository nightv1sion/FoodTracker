using AutoMapper;
namespace src.WorkoutTracker.API.DataTransferObjects.Exercise;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<src.WorkoutTracker.API.Entities.Exercise, ExerciseDTO>();
        CreateMap<CreateExerciseDTO, src.WorkoutTracker.API.Entities.Exercise>();
        CreateMap<UpdateExerciseDTO, src.WorkoutTracker.API.Entities.Exercise>();
    }
}