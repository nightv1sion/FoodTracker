using System.Text.Json;
using AutoMapper;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using src.ApiGateways.APIGateway.DataTransferObjects.WorkoutTracker.API;
using src.ApiGateways.APIGateway.Interceptors;
using src.ApiGateways.APIGateway.Services.Contracts.WorkoutTracker.API;

namespace src.ApiGateways.APIGateway.Services.WorkoutTracker.API;

public class CompletedExercisesGrpcClient : ICompletedExercisesGrpcClient
{
    private readonly CompletedExercises.CompletedExercisesClient _client;
    private readonly IMapper _mapper;

    public CompletedExercisesGrpcClient(
        IConfiguration configuration,
        IMapper mapper)
    {
        var channel = GrpcChannel.ForAddress(configuration["WorkoutTrackerAPI"]);
        _client = new CompletedExercises.CompletedExercisesClient(
            channel.Intercept(new GrpcErrorHandlingInterceptor()));
        _mapper = mapper;
    }

    public async Task<IEnumerable<CompletedExerciseProto>> GetCompletedExercisesAsync()
    {
        var reply = await _client.GetCompletedExercisesAsync(new GetCompletedExercisesRequest());
        return reply.CompletedExercises;
    }
    public async Task<CompletedExerciseProto> GetCompletedExerciseAsync(Guid id)
    {
        var reply = await _client.GetCompletedExerciseAsync(new GetCompletedExerciseRequest()
        {
            Id = id.ToString()
        });
        return reply.CompletedExercise;
    }
    public async Task<CompletedExerciseProto> CreateCompletedExerciseAsync(
        CreateCompletedExerciseDTO dto)
    {
        var completedExercise = _mapper.Map<CreateCompletedExerciseProto>(dto);
        completedExercise.RepetitionCount.AddRange(dto.RepetitionCount);
        var reply = await _client.CreateCompletedExerciseAsync(new CreateCompletedExerciseRequest()
        {
            CompletedExercise = completedExercise
        });
        return reply.CompletedExercise;
    }
    public async Task<CompletedExerciseProto> UpdateCompletedExerciseAsync(
        UpdateCompletedExerciseDTO dto)
    {
        var completedExercise = _mapper.Map<UpdateCompletedExerciseProto>(dto);
        completedExercise.RepetitionCount.AddRange(dto.RepetitionCount);
        var reply = await _client.UpdateCompletedExerciseAsync(new UpdateCompletedExerciseRequest()
        {
            CompletedExercise = completedExercise
        });
        return reply.CompletedExercise;
    }
    public async Task DeleteCompletedExerciseAsync(Guid id)
    {
        await _client.DeleteCompletedExerciseAsync(new DeleteCompletedExerciseRequest()
        {
            Id = id.ToString()
        });
    }
}