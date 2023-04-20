using AutoMapper;
namespace src.WorkoutTracker.API.DataTransferObjects.Training;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<src.WorkoutTracker.API.Entities.Training, TrainingDTO>()
            .ForMember(x => x.CompletedExercisesIds, opts => opts.MapFrom(x => x.CompletedExercises.Select(x => x.Id)));
        CreateMap<CreateTrainingDTO, src.WorkoutTracker.API.Entities.Training>();
        CreateMap<UpdateTrainingDTO, src.WorkoutTracker.API.Entities.Training>();
    }
}