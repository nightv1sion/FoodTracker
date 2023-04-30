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

        CreateMap<src.WorkoutTracker.API.Entities.Training, TrainingProto>();
        CreateMap<CreateTrainingProto, src.WorkoutTracker.API.DataTransferObjects.Training.CreateTrainingDTO>();
        CreateMap<UpdateTrainingProto, src.WorkoutTracker.API.DataTransferObjects.Training.UpdateTrainingDTO>()
            .ForMember(proto => proto.Id, dto => dto.MapFrom(x => Guid.Parse(x.Id)));
    }
}