using AutoMapper;
namespace src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<src.WorkoutTracker.API.Entities.CompletedExercise, CompletedExerciseDTO>();
        CreateMap<CreateCompletedExerciseDTO, src.WorkoutTracker.API.Entities.CompletedExercise>();
        CreateMap<UpdateCompletedExerciseDTO, src.WorkoutTracker.API.Entities.CompletedExercise>();
    }
}