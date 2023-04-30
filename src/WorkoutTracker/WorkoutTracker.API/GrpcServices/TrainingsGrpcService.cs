using AutoMapper;
using Grpc.Core;
using src.WorkoutTracker.API.DataTransferObjects.Training;
using src.WorkoutTracker.API.Exceptions.Contracts;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.GrpcServices;

public class TrainingsGrpcService : Trainings.TrainingsBase
{
    private readonly IMapper _mapper;
    private readonly ITrainingService _trainingService;

    public TrainingsGrpcService(
        IMapper mapper,
        ITrainingService trainingService)
    {
        _mapper = mapper;
        _trainingService = trainingService;
    }
    public override async Task<GetTrainingsResponse> GetTrainings(
        GetTrainingsRequest request, ServerCallContext context)
    {
        var trainings = await _trainingService.GetTrainingsAsync(false);
        var response = new GetTrainingsResponse();
        var dtos = _mapper.Map<IEnumerable<TrainingProto>>(trainings);
        response.Trainings.AddRange(dtos);
        return response;
    }
    public override async Task<GetTrainingResponse> GetTraining(
        GetTrainingRequest request, ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var training = await _trainingService.GetTrainingAsync(id, false);

        var response = new GetTrainingResponse();
        response.Training = _mapper.Map<TrainingProto>(training);
        return response;
    }
    public override async Task<CreateTrainingResponse> CreateTraining(
        CreateTrainingRequest request, ServerCallContext context)
    {
        var dto = _mapper.Map<CreateTrainingDTO>(request.Training);
        var createdTraining = await _trainingService.CreateTrainingAsync(dto);
        var response = new CreateTrainingResponse();
        response.Training = _mapper.Map<TrainingProto>(createdTraining);
        return response;
    }
    public override async Task<UpdateTrainingResponse> UpdateTraining(
        UpdateTrainingRequest request, ServerCallContext context)
    {
        var dto = _mapper.Map<UpdateTrainingDTO>(request.Training);
        var updatedTraining = await _trainingService.UpdateTrainingAsync(dto);
        var response = new UpdateTrainingResponse();
        response.Training = _mapper.Map<TrainingProto>(updatedTraining);
        return response;
    }
    public override async Task<DeleteTrainingResponse> DeleteTraining(
        DeleteTrainingRequest request, ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        await _trainingService.DeleteTrainingAsync(id);
        return new DeleteTrainingResponse();
    }
}