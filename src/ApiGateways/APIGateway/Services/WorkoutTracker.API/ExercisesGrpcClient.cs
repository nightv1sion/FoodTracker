using System.Text.Json;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using src.ApiGateways.APIGateway.Interceptors;
using src.ApiGateways.APIGateway.Services.Contracts.WorkoutTracker.API;

namespace src.ApiGateways.APIGateway.Services.WorkoutTracker.API;

public class ExercisesGrpcClient : IExercisesGrpcClient
{
    private readonly Exercises.ExercisesClient _client;
    public ExercisesGrpcClient(IConfiguration configuration)
    {
        var channel = GrpcChannel.ForAddress(configuration["WorkoutTrackerAPI"]);
        _client = new Exercises.ExercisesClient(channel.Intercept(new GrpcErrorHandlingInterceptor()));
    }

    public async Task<IEnumerable<ExerciseProto>> GetExercisesAsync()
    {
        var reply = await _client.GetExercisesAsync(new GetExercisesRequest());
        return reply.Exercises;
    }
    public async Task<ExerciseProto> GetExerciseAsync(Guid id)
    {
        var reply = await _client.GetExerciseAsync(new GetExerciseRequest()
        {
            Id = id.ToString()
        });
        return reply.Exercise;
    }
    public async Task<ExerciseProto> CreateExerciseAsync(CreateExerciseProto exercise)
    {
        var reply = await _client.CreateExerciseAsync(new CreateExerciseRequest()
        {
            Exercise = exercise
        });
        return reply.Exercise;
    }
    public async Task<ExerciseProto> UpdateExerciseAsync(UpdateExerciseProto exercise)
    {
        var reply = await _client.UpdateExerciseAsync(new UpdateExerciseRequest()
        {
            Exercise = exercise
        });
        return reply.Exercise;
    }
    public async Task DeleteExerciseAsync(Guid id)
    {
        await _client.DeleteExerciseAsync(new DeleteExerciseRequest()
        {
            Id = id.ToString()
        });
    }
}