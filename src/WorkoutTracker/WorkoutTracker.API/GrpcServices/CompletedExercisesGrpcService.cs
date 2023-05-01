using System.Text.Json;
using AutoMapper;
using Grpc.Core;
using src.WorkoutTracker.API.DataTransferObjects.CompletedExercise;
using src.WorkoutTracker.API.Exceptions.Contracts;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.GrpcServices;

public class CompletedExercisesGrpcService : CompletedExercises.CompletedExercisesBase
{
    private readonly IMapper _mapper;
    private readonly ICompletedExerciseService _completedExerciseService;

    public CompletedExercisesGrpcService(
        IMapper mapper,
        ICompletedExerciseService completedExerciseService)
    {
        _mapper = mapper;
        _completedExerciseService = completedExerciseService;
    }
    public override async Task<GetCompletedExercisesResponse> GetCompletedExercises(
        GetCompletedExercisesRequest request, ServerCallContext context)
    {
        var completedExercises = await _completedExerciseService.GetCompletedExercisesAsync(false);
        var response = new GetCompletedExercisesResponse();
        foreach (var completedExercise in completedExercises)
        {
            var dto = _mapper.Map<CompletedExerciseProto>(completedExercise);
            // dto.RepetitionCount.AddRange(completedExercise.RepetitionCountArray);
            response.CompletedExercises.Add(dto);
        }
        return response;
    }
    public override async Task<GetCompletedExerciseResponse> GetCompletedExercise(
        GetCompletedExerciseRequest request, ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        var completedExercise = await _completedExerciseService.GetCompletedExerciseAsync(id, false);

        var response = new GetCompletedExerciseResponse();
        response.CompletedExercise = _mapper.Map<CompletedExerciseProto>(completedExercise);
        // response.CompletedExercise.RepetitionCount.AddRange(completedExercise.RepetitionCountArray);
        return response;
    }
    public override async Task<CreateCompletedExerciseResponse> CreateCompletedExercise(
        CreateCompletedExerciseRequest request, ServerCallContext context)
    {
        Console.WriteLine(JsonSerializer.Serialize(request));
        var dto = _mapper.Map<CreateCompletedExerciseDTO>(request.CompletedExercise);
        Console.WriteLine(JsonSerializer.Serialize(dto));
        var createdCompletedExercise = await _completedExerciseService.CreateCompletedExerciseAsync(dto);
        var response = new CreateCompletedExerciseResponse();
        response.CompletedExercise = _mapper.Map<CompletedExerciseProto>(createdCompletedExercise);
        return response;
    }
    public override async Task<UpdateCompletedExerciseResponse> UpdateCompletedExercise(
        UpdateCompletedExerciseRequest request, ServerCallContext context)
    {
        var dto = _mapper.Map<UpdateCompletedExerciseDTO>(request.CompletedExercise);
        var updatedCompletedExercise = await _completedExerciseService.UpdateCompletedExerciseAsync(dto);
        var response = new UpdateCompletedExerciseResponse();
        response.CompletedExercise = _mapper.Map<CompletedExerciseProto>(updatedCompletedExercise);
        return response;
    }
    public override async Task<DeleteCompletedExerciseResponse> DeleteCompletedExercise(
        DeleteCompletedExerciseRequest request, ServerCallContext context)
    {
        var id = Guid.Parse(request.Id);
        await _completedExerciseService.DeleteCompletedExerciseAsync(id);
        return new DeleteCompletedExerciseResponse();
    }
}