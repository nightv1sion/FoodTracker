using AutoMapper;
using Grpc.Core;
using src.WorkoutTracker.API.DataTransferObjects.Exercise;
using src.WorkoutTracker.API.Exceptions.Contracts;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.GrpcServices;

public class ExercisesGrpcService : Exercises.ExercisesBase
{
    private readonly IMapper _mapper;
    private readonly IExerciseService _exerciseService;

    public ExercisesGrpcService(
        IMapper mapper,
        IExerciseService exerciseService)
    {
        _mapper = mapper;
        _exerciseService = exerciseService;
    }
    public override async Task<GetExercisesResponse> GetExercises(
        GetExercisesRequest request, ServerCallContext context)
    {
        var exercises = await _exerciseService.GetExercisesAsync(false);
        var response = new GetExercisesResponse();
        var dtos = _mapper.Map<IEnumerable<ExerciseProto>>(exercises);
        response.Exercises.AddRange(dtos);
        return response;
    }
    public override async Task<GetExerciseResponse> GetExercise(
        GetExerciseRequest request, ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var exercise = await _exerciseService.GetExerciseAsync(id, false);

        var response = new GetExerciseResponse();
        response.Exercise = _mapper.Map<ExerciseProto>(exercise);
        return response;
    }
    public override async Task<CreateExerciseResponse> CreateExercise(
        CreateExerciseRequest request, ServerCallContext context)
    {
        var dto = _mapper.Map<CreateExerciseDTO>(request.Exercise);
        var createdExercise = await _exerciseService.CreateExerciseAsync(dto);
        var response = new CreateExerciseResponse();
        response.Exercise = _mapper.Map<ExerciseProto>(createdExercise);
        return response;
    }
    public override async Task<UpdateExerciseResponse> UpdateExercise(
        UpdateExerciseRequest request, ServerCallContext context)
    {
        var dto = _mapper.Map<UpdateExerciseDTO>(request.Exercise);
        var updatedExercise = await _exerciseService.UpdateExerciseAsync(dto);
        var response = new UpdateExerciseResponse();
        response.Exercise = _mapper.Map<ExerciseProto>(updatedExercise);
        return response;
    }
    public override async Task<DeleteExerciseResponse> DeleteExercise(
        DeleteExerciseRequest request, ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        await _exerciseService.DeleteExerciseAsync(id);
        return new DeleteExerciseResponse();
    }
}